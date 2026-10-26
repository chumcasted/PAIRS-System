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
    public partial class InventoryPairs : Form
    {
        private string selectedImagePath = "";

        public InventoryPairs()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void InventoryPairs_Load(object sender, EventArgs e)
        {
            LoadInventoryGrid();
        }

        private void LoadInventoryGrid(string searchQuery = "")
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ItemID AS 'Item ID', 
                                    ItemName AS 'Item Name', 
                                    Category, 
                                    Quantity, 
                                    Status, 
                                    Location, 
                                    InChargePerson AS 'Person In-Charge',
                                    ImagePath 
                             FROM inventory_item";

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE ItemID LIKE @search OR ItemName LIKE @search OR Category LIKE @search OR Location LIKE @search";
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
                        dgvInventory.DataSource = dt;

                        if (dgvInventory.Columns.Contains("ImagePath"))
                        {
                            dgvInventory.Columns["ImagePath"].Visible = false;
                        }

                        // ==========================================
                        // CONDITIONAL LOW-STOCK HIGHLIGHTING
                        // ==========================================
                        var (isAlertEnabled, threshold) = GetLowStockAlertConfigFromDB();

                        if (isAlertEnabled)
                        {
                            foreach (DataGridViewRow row in dgvInventory.Rows)
                            {
                                if (row.Cells["Quantity"].Value != null && row.Cells["Quantity"].Value != DBNull.Value)
                                {
                                    int stock = Convert.ToInt32(row.Cells["Quantity"].Value);

                                    if (stock <= threshold)
                                    {
                                        row.DefaultCellStyle.BackColor = Color.LightCoral; // Red/Pink highlight
                                        row.DefaultCellStyle.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading inventory grid: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // READ ALERT ENABLED STATE & THRESHOLD FROM DB
        // ==========================================
        private (bool isEnabled, int threshold) GetLowStockAlertConfigFromDB()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IsLowStockAlertEnabled, LowStockThreshold FROM `settings` WHERE id = 1 LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isEnabled = reader["IsLowStockAlertEnabled"] == DBNull.Value || Convert.ToBoolean(reader["IsLowStockAlertEnabled"]);
                                int threshold = reader["LowStockThreshold"] != DBNull.Value ? Convert.ToInt32(reader["LowStockThreshold"]) : 2;
                                return (isEnabled, threshold);
                            }
                        }
                    }
                }
                catch
                {
                    // Fallback default
                }
            }
            return (true, 2);
        }

        // ==========================================
        // HELPER METHOD (Add this inside InventoryPairs.cs)
        // ==========================================
        private int GetLowStockThresholdFromDB()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT LowStockThreshold FROM `settings` LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
                catch
                {
                    // Fallback default if settings table isn't read yet
                }
            }
            return 2; // Default low stock threshold
        }
    
        // ==========================================
        // 2. ADD NEW EQUIPMENT (CREATE)
        // ==========================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemID.Text) ||
                           string.IsNullOrWhiteSpace(txtItemName.Text) ||
                           string.IsNullOrWhiteSpace(txtInCharge.Text))
            {
                MessageBox.Show("Please fill in required fields: Item ID, Item Name, and Person In-Charge.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string insertQuery = @"INSERT INTO inventory_item 
                                          (ItemID, ItemName, Category, Quantity, Status, Location, InChargePerson, ImagePath) 
                                          VALUES 
                                          (@ItemID, @ItemName, @Category, @Quantity, @Status, @Location, @InChargePerson, @ImagePath)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", txtItemID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString() ?? "General");
                        cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(numQuantity.Value));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? "Available");
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@InChargePerson", txtInCharge.Text.Trim());
                        cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrWhiteSpace(selectedImagePath) ? (object)DBNull.Value : selectedImagePath);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New inventory item successfully recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadInventoryGrid();
                        ClearFields();
                    }
                }
                catch (MySqlException ex) when (ex.Number == 1062) // Primary Key duplicate error
                {
                    MessageBox.Show($"Item ID '{txtItemID.Text.Trim()}' already exists. Please use a unique Item ID.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding item: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 3. UPDATE EXISTING EQUIPMENT
        // ==========================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemID.Text))
            {
                MessageBox.Show("Please select an item from the table to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string updateQuery = @"UPDATE inventory_item 
                                          SET ItemName = @ItemName, 
                                              Category = @Category, 
                                              Quantity = @Quantity, 
                                              Status = @Status, 
                                              Location = @Location, 
                                              InChargePerson = @InChargePerson, 
                                              ImagePath = @ImagePath 
                                          WHERE ItemID = @ItemID";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", txtItemID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString() ?? "General");
                        cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(numQuantity.Value));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? "Available");
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@InChargePerson", txtInCharge.Text.Trim());
                        cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrWhiteSpace(selectedImagePath) ? (object)DBNull.Value : selectedImagePath);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Inventory record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInventoryGrid();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Item ID not found in database.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating item: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 4. DELETE EQUIPMENT
        // ==========================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemID.Text))
            {
                MessageBox.Show("Please select an item to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to permanently delete '{txtItemName.Text}' ({txtItemID.Text})?",
                                                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM inventory_item WHERE ItemID = @ItemID";

                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ItemID", txtItemID.Text.Trim());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInventoryGrid();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting item: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 5. GRID ROW CLICK TO POPULATE CONTROLS
        // ==========================================
        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInventory.Rows[e.RowIndex];

                txtItemID.Text = row.Cells["Item ID"].Value?.ToString();
                txtItemName.Text = row.Cells["Item Name"].Value?.ToString();
                cmbCategory.SelectedItem = row.Cells["Category"].Value?.ToString();

                // Safely parse quantity and clamp within numQuantity's Minimum/Maximum bounds
                decimal rawQty = Convert.ToDecimal(row.Cells["Quantity"].Value ?? 1);
                numQuantity.Value = Math.Max(numQuantity.Minimum, Math.Min(numQuantity.Maximum, rawQty));
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
                txtLocation.Text = row.Cells["Location"].Value?.ToString();
                txtInCharge.Text = row.Cells["Person In-Charge"].Value?.ToString();

                // Load image into PictureBox preview card
                string imgPath = row.Cells["ImagePath"].Value?.ToString();
                selectedImagePath = imgPath ?? "";

                if (!string.IsNullOrWhiteSpace(imgPath) && File.Exists(imgPath))
                {
                    picItemImage.ImageLocation = imgPath;
                }
                else
                {
                    picItemImage.Image = null; // Clear preview if file is missing or path is NULL
                }
            }
        }

        // ==========================================
        // 6. SEARCH, CLEAR & EXIT CONTROLS
        // ==========================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInventoryGrid(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtItemID.Clear();
            txtItemName.Clear();
            txtLocation.Clear();
            txtInCharge.Clear();
            txtSearch.Clear();

            // Clear image preview & variable
            picItemImage.Image = null;
            selectedImagePath = "";

            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            numQuantity.Value = 1;

            LoadInventoryGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InventoryPairs inventory = new InventoryPairs();
            inventory.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InventoryPairs inventory = new InventoryPairs();
            inventory.Show();
            this.Hide();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BorrowReturnForm borrowReturnForm = new BorrowReturnForm();
            borrowReturnForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BorrowReturnForm borrowReturnForm = new BorrowReturnForm();
            borrowReturnForm.Show();
            this.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Performances performances = new Performances();
            performances.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Performances performances = new Performances();
            performances.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Hide();
        }

        private void statusLbl_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                ofd.Title = "Select Equipment Photo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    picItemImage.ImageLocation = selectedImagePath;
                }
            }
        }



        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            picItemImage.Image = null;
            selectedImagePath = "";
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
