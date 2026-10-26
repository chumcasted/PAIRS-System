using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            // Bind click event programmatically
            dgvUsers.CellClick -= dgvUsers_CellClick; // Prevent duplicate bindings
            dgvUsers.CellClick += dgvUsers_CellClick;

            // Populate Role Dropdown
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new object[] { "Admin", "Staff", "Member", "Student" });
            cmbRole.SelectedIndex = 0;

            // Populate Status Dropdown
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cmbStatus.SelectedIndex = 0;

            // Load data table
            LoadUsersGrid();
        }

        // ==========================================
        // 1. LOAD USERS TO DATAGRIDVIEW
        // ==========================================
        private void LoadUsersGrid(string searchQuery = "")
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        UserID AS 'User ID', 
                                        FullName AS 'Name', 
                                        Email AS 'Email', 
                                        Role AS 'Role', 
                                        Status AS 'Status' 
                                     FROM `user`";

                    // Add search filtering if query string is provided
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += @" WHERE UserID LIKE @search 
                                       OR FullName LIKE @search 
                                       OR Email LIKE @search 
                                       OR Role LIKE @search 
                                       OR Status LIKE @search";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(searchQuery))
                        {
                            cmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        }

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind result to DataGridView
                        dgvUsers.DataSource = dt;
                        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 2. GRID CELL CLICK SELECTION
        // ==========================================
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row and not on column headers (e.RowIndex >= 0)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                // Fill TextBoxes safely
                txtUserID.Text = row.Cells["User ID"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

                // Select matching Role in ComboBox
                string selectedRole = row.Cells["Role"].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedRole) && cmbRole.Items.Contains(selectedRole))
                {
                    cmbRole.SelectedItem = selectedRole;
                }

                // Select matching Status in ComboBox
                string selectedStatus = row.Cells["Status"].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedStatus) && cmbStatus.Items.Contains(selectedStatus))
                {
                    cmbStatus.SelectedItem = selectedStatus;
                }
            }
        }
        // ==========================================
        // 4. UPDATE USER BUTTON
        // ==========================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Please select a user from the table to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE `user` 
                                     SET FullName = @FullName, 
                                         Email = @Email, 
                                         Role = @Role, 
                                         Status = @Status 
                                     WHERE UserID = @UserID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", txtUserID.Text.Trim());
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem?.ToString() ?? "Member");
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? "Active");

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("User record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsersGrid();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No user found with the specified User ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 5. DELETE USER BUTTON
        // ==========================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Please select a user from the table to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete user '{txtUserID.Text.Trim()}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM `user` WHERE UserID = @UserID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", txtUserID.Text.Trim());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("User record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsersGrid();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 6. SEARCH & CLEAR UTILITIES
        // ==========================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void ExecuteSearch()
        {
            string searchQuery = GetSearchInputText();
            LoadUsersGrid(searchQuery);
        }

        private string GetSearchInputText()
        {
            // Dynamically checks control name to prevent null reference errors
            Control[] searchControls = this.Controls.Find("txtSearch", true);
            if (searchControls.Length == 0) searchControls = this.Controls.Find("txtSearchItem", true);
            if (searchControls.Length == 0) searchControls = this.Controls.Find("searchTextBox", true);

            if (searchControls.Length > 0 && searchControls[0] is TextBox tb)
            {
                return tb.Text.Trim();
            }
            return "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtUserID.Clear();
            txtName.Clear();
            txtEmail.Clear();

            // Clear search box if present
            Control[] searchControls = this.Controls.Find("txtSearch", true);
            if (searchControls.Length == 0) searchControls = this.Controls.Find("txtSearchItem", true);
            if (searchControls.Length == 0) searchControls = this.Controls.Find("searchTextBox", true);
            if (searchControls.Length > 0 && searchControls[0] is TextBox tb)
            {
                tb.Clear();
            }

            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;

            LoadUsersGrid();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        // ==========================================
        // 7. NAVIGATION & LOGOUT
        // ==========================================
        private void logOut_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out of PAIRS?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserSession.EndSession();

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnDashboard_Click(sender, e); }
        private void btnDashboard_Click(object sender, EventArgs e) { new Dashboard().Show(); this.Hide(); }

        private void InventoryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btninventory_Click(sender, e); }
        private void btninventory_Click(object sender, EventArgs e) { new InventoryPairs().Show(); this.Hide(); }

        private void ReservationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btreservations_Click(sender, e); }
        private void btreservations_Click(object sender, EventArgs e) { new Reservation().Show(); this.Hide(); }

        private void BorrowReturnLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnborrowreturn_Click(sender, e); }
        private void btnborrowreturn_Click(object sender, EventArgs e) { new BorrowReturnForm().Show(); this.Hide(); }

        private void PerformanceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnperformances_Click(sender, e); }
        private void btnperformances_Click(object sender, EventArgs e) { new Performances().Show(); this.Hide(); }

        private void UserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void btnUsers_Click(object sender, EventArgs e) { }

        private void ReportsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnReports_Click(sender, e); }
        private void btnReports_Click(object sender, EventArgs e) { new Reports().Show(); this.Hide(); }

        private void SettingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnSettings_Click(sender, e); }
        private void btnSettings_Click(object sender, EventArgs e) { new Settings().Show(); this.Hide(); }
    }
}