using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class EquipmentCatalog : Form
    {
        // Internal cart item model
        private class CartItem
        {
            public string ItemID { get; set; }
            public string ItemName { get; set; }
            public int Quantity { get; set; }
            public int MaxAvailable { get; set; }

            public override string ToString() => $"{ItemName} (x{Quantity})";
        }

        private readonly List<CartItem> cartList = new List<CartItem>();

        public EquipmentCatalog()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. FORM LOAD & INITIALIZATION
        // ==========================================
        private void EquipmentCatalog_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            if (dtpStartDate != null) dtpStartDate.Value = DateTime.Today;
            if (dtpEndDate != null) dtpEndDate.Value = DateTime.Today.AddDays(1);

            LoadCategoriesDropdown();
            LoadCatalogCards();
            RefreshCartUI();
        }

        // ==========================================
        // 2. DYNAMIC CATALOG CARD LOADER (flpCatalog)
        // ==========================================
        private void LoadCatalogCards(string searchTerm = "", string selectedCategory = "All")
        {
            if (flpCatalog == null) return;

            flpCatalog.Controls.Clear();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ItemID, ItemName, Category, Quantity, ImagePath 
                                     FROM inventory_item 
                                     WHERE 1=1 ";

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                        query += " AND ItemName LIKE @Search ";

                    if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All")
                        query += " AND Category = @Category ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(searchTerm))
                            cmd.Parameters.AddWithValue("@Search", $"%{searchTerm}%");

                        if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All")
                            cmd.Parameters.AddWithValue("@Category", selectedCategory);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string itemId = reader["ItemID"].ToString();
                                string name = reader["ItemName"]?.ToString() ?? "Equipment";
                                string category = reader["Category"]?.ToString() ?? "General";
                                int availableQty = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;
                                string imgPath = reader["ImagePath"]?.ToString() ?? "";

                                Panel card = CreateItemCard(itemId, name, category, availableQty, imgPath);
                                flpCatalog.Controls.Add(card);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading equipment catalog: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Panel CreateItemCard(string itemId, string name, string category, int availableQty, string imgPath)
        {
            Panel card = new Panel
            {
                Size = new Size(180, 220),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(8)
            };

            Label lblTitle = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Location = new Point(0, 0),
                Size = new Size(180, 32),
                BackColor = Color.FromArgb(238, 238, 238),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter
            };

            PictureBox pic = new PictureBox
            {
                Size = new Size(160, 85),
                Location = new Point(10, 36),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
            {
                try { pic.Image = Image.FromFile(imgPath); } catch { }
            }

            Label lblCategory = new Label
            {
                Text = $"Category: {category}",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                Location = new Point(8, 123),
                Size = new Size(164, 18),
                ForeColor = Color.FromArgb(40, 40, 40)
            };

            Label lblStock = new Label
            {
                Text = $"Available: {availableQty}",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                Location = new Point(8, 141),
                Size = new Size(164, 18),
                ForeColor = Color.FromArgb(40, 40, 40)
            };

            Button btnAdd = new Button
            {
                Size = new Size(164, 34),
                Location = new Point(8, 165),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnAdd.FlatAppearance.BorderSize = 0;

            if (availableQty > 0)
            {
                btnAdd.Text = "+ Add to Cart";
                btnAdd.Enabled = true;
                btnAdd.BackColor = Color.FromArgb(85, 107, 47); // Olive Green
                btnAdd.ForeColor = Color.White;
                btnAdd.Click += (s, e) => AddToCart(itemId, name, availableQty);
            }
            else
            {
                btnAdd.Text = "Out of Stock";
                btnAdd.Enabled = false;
                btnAdd.BackColor = Color.FromArgb(215, 215, 215);
                btnAdd.ForeColor = Color.FromArgb(120, 120, 120);
            }

            card.Controls.Add(lblTitle);
            card.Controls.Add(pic);
            card.Controls.Add(lblCategory);
            card.Controls.Add(lblStock);
            card.Controls.Add(btnAdd);

            return card;
        }

        // ==========================================
        // 3. SHOPPING CART LOGIC
        // ==========================================
        private void AddToCart(string itemId, string name, int maxQty)
        {
            CartItem existing = cartList.FirstOrDefault(x => x.ItemID == itemId);

            if (existing != null)
            {
                if (existing.Quantity < maxQty)
                {
                    existing.Quantity++;
                }
                else
                {
                    MessageBox.Show($"Cannot add more. Only {maxQty} unit(s) available in stock.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                cartList.Add(new CartItem { ItemID = itemId, ItemName = name, Quantity = 1, MaxAvailable = maxQty });
            }

            RefreshCartUI();
        }

        private void RefreshCartUI()
        {
            if (lstCart != null)
            {
                lstCart.Items.Clear();
                foreach (var item in cartList)
                {
                    lstCart.Items.Add(item.ToString());
                }
            }

            if (lblCartCount != null)
            {
                lblCartCount.Text = $"{cartList.Sum(x => x.Quantity)} Items Selected";
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            cartList.Clear();
            RefreshCartUI();
        }

        // ==========================================
        // 4. SUBMIT RESERVATION REQUEST TO MYSQL
        // ==========================================
        private void btnSubmitReservation_Click(object sender, EventArgs e)
        {
            if (cartList.Count == 0)
            {
                MessageBox.Show("Your reservation cart is empty! Please select equipment first.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEndDate != null && dtpStartDate != null && dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End Date cannot be earlier than Start Date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentUserId = UserSession.UserID ?? "U002";
            string newBookingId = "BK" + DateTime.Now.ToString("MMddHHmmss");
            string startDate = dtpStartDate != null ? dtpStartDate.Value.ToString("yyyy-MM-dd") : DateTime.Today.ToString("yyyy-MM-dd");
            string endDate = dtpEndDate != null ? dtpEndDate.Value.ToString("yyyy-MM-dd") : DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        // 1. Insert into reservation table matching database schema
                        string bookingQuery = @"INSERT INTO reservation 
                    (BookingID, UserID, StartDate, EndDate, StartTime, EndTime, ApprovalStatus, RequestDate) 
                    VALUES (@BookingID, @UserID, @Start, @End, '08:00:00', '17:00:00', 'Pending', NOW());";

                        using (MySqlCommand cmd = new MySqlCommand(bookingQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BookingID", newBookingId);
                            cmd.Parameters.AddWithValue("@UserID", currentUserId);
                            cmd.Parameters.AddWithValue("@Start", startDate);
                            cmd.Parameters.AddWithValue("@End", endDate);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Insert items into reservation_item using QuantityReserved column
                        string itemQuery = @"INSERT INTO reservation_item (BookingID, ItemID, QuantityReserved) 
                                     VALUES (@BookingID, @ItemID, @Qty);";

                        foreach (var item in cartList)
                        {
                            using (MySqlCommand cmdItem = new MySqlCommand(itemQuery, conn, transaction))
                            {
                                cmdItem.Parameters.AddWithValue("@BookingID", newBookingId);
                                cmdItem.Parameters.AddWithValue("@ItemID", item.ItemID);
                                cmdItem.Parameters.AddWithValue("@Qty", item.Quantity);
                                cmdItem.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        MessageBox.Show($"Reservation request '{newBookingId}' submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cartList.Clear();
                        RefreshCartUI();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to submit reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 5. SEARCH & CATEGORY FILTERS
        // ==========================================
        private void LoadCategoriesDropdown()
        {
            if (cmbCategory == null) return;

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All");

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DISTINCT Category FROM inventory_item WHERE Category IS NOT NULL AND Category != '';";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            cmbCategory.Items.Add(r["Category"].ToString());
                        }
                    }
                }
                catch { }
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void TriggerSearch()
        {
            string searchVal = txtSearch != null ? txtSearch.Text.Trim() : "";
            string catVal = cmbCategory?.SelectedItem?.ToString() ?? "All";
            LoadCatalogCards(searchVal, catVal);
        }

        private void btnSearch_Click(object sender, EventArgs e) => TriggerSearch();
        private void txtSearch_TextChanged(object sender, EventArgs e) => TriggerSearch();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => TriggerSearch();

        // ==========================================
        // 6. MEMBER NAVIGATION HANDLERS
        // ==========================================
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnDashboard_Click(sender, e);
        private void btnDashboard_Click(object sender, EventArgs e) { new MemberDashboard().Show(); this.Hide(); }

        private void EquipmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnEquipment_Click(sender, e);
        private void btnEquipment_Click(object sender, EventArgs e) { } // Already on EquipmentCatalog

        private void ReservationsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnReservations_Click(sender, e);
        private void btnReservations_Click(object sender, EventArgs e) { new MemberReservation().Show(); this.Hide(); }

        private void BorrowedLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnBorrowed_Click(sender, e);
        private void btnBorrowed_Click(object sender, EventArgs e) { new MemberBorrowed().Show(); this.Hide(); }

        private void ScheduleLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnSchedule_Click(sender, e);
        private void btnSchedule_Click(object sender, EventArgs e) { new MemberSchedule().Show(); this.Hide(); }

        private void AccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnAccount_Click(sender, e);
        private void btnAccount_Click(object sender, EventArgs e) { new MemberAccount().Show(); this.Hide(); }

        private void logOut_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out of PAIRS?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserSession.EndSession();
                new frmLogin().Show();
                this.Close();
            }
        }
    }
}