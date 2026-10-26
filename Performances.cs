using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Performances : Form
    {
        public Performances()
        {
            InitializeComponent();
        }

        private void Performancees_Load_1(object sender, EventArgs e)
        {
            // Populate cmbCategory if empty
            if (cmbCategory.Items.Count == 0)
            {
                cmbCategory.Items.AddRange(new object[] {
                    "Concert",
                    "Play / Theater",
                    "Dance / Cultural",
                    "Pageant / Competition",
                    "Festival / Olympics",
                    "Rehearsal",
                    "Special Event"
                });
            }
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;

            // Populate cmbStatus if empty
            if (cmbStatus.Items.Count == 0)
            {
                cmbStatus.Items.AddRange(new object[] {
                    "Scheduled",
                    "Ongoing",
                    "Completed",
                    "Cancelled"
                });
            }
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;

            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now.AddDays(1);

            LoadPerformanceGrid();
        }

        // ==========================================
        // 1. LOAD PERFORMANCES INTO DATAGRIDVIEW
        // ==========================================
        private void LoadPerformanceGrid(string searchQuery = "")
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT PerformanceID AS 'Performance ID', 
                                            Title, 
                                            Category, 
                                            Venue, 
                                            DateFrom AS 'Date From', 
                                            DateTo AS 'Date To', 
                                            Status 
                                     FROM performance";

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE PerformanceID LIKE @search OR Title LIKE @search OR Category LIKE @search OR Venue LIKE @search OR Status LIKE @search";
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

                        if (dgvPerformance != null)
                        {
                            dgvPerformance.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading performance records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 2. AUTOMATIC DATE VALIDATION
        // ==========================================
        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateTo.Value.Date < dtpDateFrom.Value.Date)
            {
                dtpDateTo.Value = dtpDateFrom.Value.AddDays(1);
            }
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateTo.Value.Date < dtpDateFrom.Value.Date)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Date Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDateTo.Value = dtpDateFrom.Value.AddDays(1);
            }
        }

        // ==========================================
        // 3. ADD PERFORMANCE RECORD
        // ==========================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPerformanceID.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtVenue.Text))
            {
                MessageBox.Show("Please fill in required fields (Performance ID, Title, and Venue).", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDateTo.Value.Date < dtpDateFrom.Value.Date)
            {
                MessageBox.Show("Date To cannot be earlier than Date From.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO performance 
                                    (PerformanceID, Title, Category, Venue, DateFrom, DateTo, Status) 
                                    VALUES 
                                    (@PerformanceID, @Title, @Category, @Venue, @DateFrom, @DateTo, @Status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PerformanceID", txtPerformanceID.Text.Trim());
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString() ?? "Special Event");
                        cmd.Parameters.AddWithValue("@Venue", txtVenue.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateFrom", dtpDateFrom.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@DateTo", dtpDateTo.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? "Scheduled");

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Performance event created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadPerformanceGrid();
                        ClearFields();
                    }
                }
                catch (MySqlException ex) when (ex.Number == 1062)
                {
                    MessageBox.Show($"Performance ID '{txtPerformanceID.Text.Trim()}' already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving performance record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 4. UPDATE PERFORMANCE RECORD
        // ==========================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPerformanceID.Text))
            {
                MessageBox.Show("Please select a performance record from the table to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDateTo.Value.Date < dtpDateFrom.Value.Date)
            {
                MessageBox.Show("Date To cannot be earlier than Date From.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE performance 
                                    SET Title = @Title, 
                                        Category = @Category, 
                                        Venue = @Venue, 
                                        DateFrom = @DateFrom, 
                                        DateTo = @DateTo, 
                                        Status = @Status 
                                    WHERE PerformanceID = @PerformanceID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PerformanceID", txtPerformanceID.Text.Trim());
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString() ?? "Special Event");
                        cmd.Parameters.AddWithValue("@Venue", txtVenue.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateFrom", dtpDateFrom.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@DateTo", dtpDateTo.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? "Scheduled");

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Performance event updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadPerformanceGrid();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Performance ID not found.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating performance record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 5. DELETE PERFORMANCE RECORD
        // ==========================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPerformanceID.Text))
            {
                MessageBox.Show("Select a record to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Delete performance record '{txtPerformanceID.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM performance WHERE PerformanceID = @PerformanceID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@PerformanceID", txtPerformanceID.Text.Trim());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Performance record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadPerformanceGrid();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 6. GRID CELL SELECTION
        // ==========================================
        private void dgvPerformance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPerformance != null)
            {
                DataGridViewRow row = dgvPerformance.Rows[e.RowIndex];

                txtPerformanceID.Text = row.Cells["Performance ID"].Value?.ToString();
                txtTitle.Text = row.Cells["Title"].Value?.ToString();
                txtVenue.Text = row.Cells["Venue"].Value?.ToString();

                string categoryVal = row.Cells["Category"].Value?.ToString();
                if (!string.IsNullOrEmpty(categoryVal)) cmbCategory.SelectedItem = categoryVal;

                string statusVal = row.Cells["Status"].Value?.ToString();
                if (!string.IsNullOrEmpty(statusVal)) cmbStatus.SelectedItem = statusVal;

                if (DateTime.TryParse(row.Cells["Date From"].Value?.ToString(), out DateTime dFrom))
                    dtpDateFrom.Value = dFrom;

                if (DateTime.TryParse(row.Cells["Date To"].Value?.ToString(), out DateTime dTo))
                    dtpDateTo.Value = dTo;
            }
        }

        // ==========================================
        // 7. UTILITY & SEARCH HANDLERS
        // ==========================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPerformanceGrid(txtSearch.Text.Trim());
        }

        private void dgvSearchButton_Click(object sender, EventArgs e)
        {
            LoadPerformanceGrid(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtPerformanceID.Clear();
            txtTitle.Clear();
            txtVenue.Clear();
            txtSearch.Clear();

            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now.AddDays(1);

            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;

            LoadPerformanceGrid();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void idLbl_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void categoryLbl_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void txtPerformanceID_TextChanged(object sender, EventArgs e) { }
        private void txtTitle_TextChanged(object sender, EventArgs e) { }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtVenue_TextChanged(object sender, EventArgs e) { }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtSearch_TextChanged(object sender, EventArgs e) { }

        // ==========================================
        // 8. SIDE PANEL NAVIGATION HANDLERS
        // ==========================================
        private void DashboardLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void InventoryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InventoryPairs inventory = new InventoryPairs();
            inventory.Show();
            this.Hide();
        }

        private void btninventory_Click(object sender, EventArgs e)
        {
            InventoryPairs inventory = new InventoryPairs();
            inventory.Show();
            this.Hide();
        }

        private void ReservationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.Show();
            this.Hide();
        }

        private void btreservations_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.Show();
            this.Hide();
        }

        private void PerformanceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Performances performances = new Performances();
            performances.Show();
            this.Hide();
        }

        private void btnperformances_Click(object sender, EventArgs e)
        {
            Performances performances = new Performances();
            performances.Show();
            this.Hide();
        }

        private void ReportsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void UserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void SettingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Hide();
        }

        private void BorrowReturnLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BorrowReturnForm borrowReturn = new BorrowReturnForm();
            borrowReturn.Show();
            this.Hide();
        }

        private void btnborrowreturn_Click(object sender, EventArgs e)
        {
            BorrowReturnForm borrowReturn = new BorrowReturnForm();
            borrowReturn.Show();
            this.Hide();
        }

        private void logOut_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out of PAIRS?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserSession.EndSession(); // Triggers the MySQL update & confirmation popup

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }
    }
}