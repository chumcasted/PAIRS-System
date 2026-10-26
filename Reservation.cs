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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            // Ensure schema maintenance runs first to prevent SQL column missing exceptions
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    EnsureSchemaExists(conn);
                }
                catch { }
            }

            AutoCancelExpiredReservations();
            LoadItemDropdown();
            PopulateUserDropdown();
            LoadReservationsGrid();

            if (cmbApprovalStatus.Items.Count > 0)
                cmbApprovalStatus.SelectedIndex = 0;
        }

        // ==========================================
        // AUTO SCHEMA MAINTENANCE HELPER
        // ==========================================
        private void EnsureSchemaExists(MySqlConnection conn)
        {
            try
            {
                // 1. Ensure RequestDate column exists in reservation table
                string checkQuery = @"SELECT COUNT(*) 
                                      FROM INFORMATION_SCHEMA.COLUMNS 
                                      WHERE TABLE_SCHEMA = DATABASE() 
                                        AND TABLE_NAME = 'reservation' 
                                        AND COLUMN_NAME = 'RequestDate'";

                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    long columnExists = Convert.ToInt64(checkCmd.ExecuteScalar() ?? 0);
                    if (columnExists == 0)
                    {
                        string addColumnQuery = "ALTER TABLE `reservation` ADD COLUMN `RequestDate` DATETIME NULL DEFAULT CURRENT_TIMESTAMP;";
                        using (MySqlCommand addCmd = new MySqlCommand(addColumnQuery, conn))
                        {
                            addCmd.ExecuteNonQuery();
                        }
                    }
                }

                // 2. Ensure QuantityReserved column exists in reservation_item table
                string checkQtyQuery = @"SELECT COUNT(*) 
                                         FROM INFORMATION_SCHEMA.COLUMNS 
                                         WHERE TABLE_SCHEMA = DATABASE() 
                                           AND TABLE_NAME = 'reservation_item' 
                                           AND COLUMN_NAME = 'QuantityReserved'";

                using (MySqlCommand checkQtyCmd = new MySqlCommand(checkQtyQuery, conn))
                {
                    long qtyExists = Convert.ToInt64(checkQtyCmd.ExecuteScalar() ?? 0);
                    if (qtyExists == 0)
                    {
                        string addCol = "ALTER TABLE `reservation_item` ADD COLUMN `QuantityReserved` INT NULL DEFAULT 1;";
                        using (MySqlCommand addCmd = new MySqlCommand(addCol, conn))
                        {
                            addCmd.ExecuteNonQuery();
                        }

                        // Sync with Quantity column if present
                        string syncCol = "UPDATE `reservation_item` SET `QuantityReserved` = `Quantity` WHERE `Quantity` IS NOT NULL AND (`QuantityReserved` IS NULL OR `QuantityReserved` = 0);";
                        using (MySqlCommand syncCmd = new MySqlCommand(syncCol, conn))
                        {
                            try { syncCmd.ExecuteNonQuery(); } catch { }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Schema Maintenance Note: " + ex.Message);
            }
        }

        // ==========================================
        // AUTO-CANCEL EXPIRED RESERVATIONS
        // ==========================================
        private void AutoCancelExpiredReservations()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    EnsureSchemaExists(conn);

                    int autoCancelDays = 3;
                    string ruleQuery = "SELECT AutoCancelDays FROM `settings` WHERE id = 1 LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(ruleQuery, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value)
                        {
                            autoCancelDays = Convert.ToInt32(res);
                        }
                    }

                    string cancelQuery = @"UPDATE reservation 
                                           SET ApprovalStatus = 'Cancelled' 
                                           WHERE ApprovalStatus = 'Pending' 
                                             AND RequestDate IS NOT NULL 
                                             AND DATEDIFF(NOW(), RequestDate) >= @Days";

                    using (MySqlCommand cmd = new MySqlCommand(cancelQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Days", autoCancelDays);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }
        }

        // ==========================================
        // REAL-TIME NET AVAILABLE STOCK CALCULATION
        // ==========================================
        private int GetNetAvailableStock(string itemID, DateTime startDate, DateTime endDate, string excludeBookingID = "")
        {
            int currentShelfStock = 0;
            int activeReservedQty = 0;

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Get current available shelf stock
                    string stockQuery = "SELECT Quantity FROM inventory_item WHERE ItemID = @ItemID";
                    using (MySqlCommand cmd = new MySqlCommand(stockQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        object res = cmd.ExecuteScalar();
                        currentShelfStock = (res != null && res != DBNull.Value) ? Convert.ToInt32(res) : 0;
                    }

                    // 2. Subtract overlapping active/pending reservations for requested dates
                    string resQuery = @"SELECT COALESCE(SUM(COALESCE(ri.QuantityReserved, ri.Quantity, 0)), 0) 
                                        FROM reservation r 
                                        INNER JOIN reservation_item ri ON r.BookingID = ri.BookingID 
                                        WHERE ri.ItemID = @ItemID 
                                          AND r.ApprovalStatus IN ('Approved', 'Pending') 
                                          AND NOT (r.EndDate < @StartDate OR r.StartDate > @EndDate)";

                    if (!string.IsNullOrEmpty(excludeBookingID))
                    {
                        resQuery += " AND r.BookingID != @ExcludeID";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(resQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                        if (!string.IsNullOrEmpty(excludeBookingID))
                        {
                            cmd.Parameters.AddWithValue("@ExcludeID", excludeBookingID);
                        }

                        object res = cmd.ExecuteScalar();
                        activeReservedQty = (res != null && res != DBNull.Value) ? Convert.ToInt32(res) : 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }

            int netAvailable = currentShelfStock - activeReservedQty;
            return Math.Max(0, netAvailable);
        }

        // ==========================================
        // 1. POPULATE DROPDOWNS
        // ==========================================
        private void PopulateUserDropdown()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID, CONCAT(FullName, ' (', UserID, ')') AS DisplayText FROM `user` WHERE Status = 'Active';";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbUser.DataSource = dt;
                        cmbUser.DisplayMember = "DisplayText";
                        cmbUser.ValueMember = "UserID";

                        if (!string.IsNullOrEmpty(UserSession.UserID))
                        {
                            cmbUser.SelectedValue = UserSession.UserID;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading user dropdown: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadItemDropdown()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ItemID, 
                                            CONCAT(ItemID, ' - ', ItemName, ' [', Status, ']') AS DisplayText 
                                     FROM inventory_item 
                                     WHERE Status != 'Archived'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbItem.DataSource = dt;
                        cmbItem.DisplayMember = "DisplayText";
                        cmbItem.ValueMember = "ItemID";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading item dropdown: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 2. LOAD RESERVATIONS INTO DATAGRIDVIEW
        // ==========================================
        private void LoadReservationsGrid(string searchQuery = "")
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT 
                                r.BookingID AS 'Booking ID', 
                                r.UserID AS 'User ID', 
                                COALESCE(u.FullName, r.UserID) AS 'User Name',
                                r.StartDate AS 'Start Date', 
                                r.EndDate AS 'End Date', 
                                r.StartTime AS 'Start Time', 
                                r.EndTime AS 'End Time', 
                                ri.ItemID AS 'ItemID',
                                COALESCE(i.ItemName, 'N/A') AS 'Item Name', 
                                COALESCE(SUM(ri.QuantityReserved), 0) AS 'Qty', 
                                r.ApprovalStatus AS 'Status' 
                            FROM reservation r 
                            LEFT JOIN `user` u ON r.UserID = u.UserID 
                            LEFT JOIN reservation_item ri ON r.BookingID = ri.BookingID 
                            LEFT JOIN inventory_item i ON ri.ItemID = i.ItemID 
                            WHERE 1=1 ";

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " AND (r.BookingID LIKE @search OR r.UserID LIKE @search OR u.FullName LIKE @search OR i.ItemName LIKE @search OR r.ApprovalStatus LIKE @search)";
                    }

                    query += @" GROUP BY r.BookingID, ri.ItemID, r.UserID, u.FullName, r.StartDate, r.EndDate, r.StartTime, r.EndTime, i.ItemName, r.ApprovalStatus
                        ORDER BY r.BookingID DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(searchQuery))
                        {
                            cmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        }

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dgvReservations != null)
                        {
                            dgvReservations.DataSource = dt;

                            if (dgvReservations.Columns.Contains("ItemID"))
                            {
                                dgvReservations.Columns["ItemID"].Visible = false;
                            }
                            dgvReservations.ClearSelection();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reservations grid: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 3. ADD NEW RESERVATION
        // ==========================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookingID.Text) ||
                cmbUser.SelectedValue == null ||
                cmbItem.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all required fields (Booking ID, User, and Item).", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageBox.Show("End Date cannot be earlier than Start Date.", "Date Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUserID = cmbUser.SelectedValue.ToString();
            string selectedItemID = cmbItem.SelectedValue.ToString();
            int requestedQty = Convert.ToInt32(numQuantity.Value);
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (requestedQty < 1)
            {
                MessageBox.Show("Quantity reserved must be at least 1.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQuantity.Value = 1;
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    EnsureSchemaExists(conn);

                    string conditionQuery = "SELECT Status, ItemName FROM inventory_item WHERE ItemID = @ItemID";
                    using (MySqlCommand conditionCmd = new MySqlCommand(conditionQuery, conn))
                    {
                        conditionCmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                        using (MySqlDataReader reader = conditionCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string itemStatus = reader["Status"]?.ToString() ?? "";
                                string itemName = reader["ItemName"]?.ToString() ?? "";

                                if (itemStatus.Equals("Damaged", StringComparison.OrdinalIgnoreCase) ||
                                    itemStatus.Equals("Under Maintenance", StringComparison.OrdinalIgnoreCase) ||
                                    itemStatus.Equals("Maintenance", StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show($"Cannot reserve '{itemName}'. Item status is currently '{itemStatus}'.",
                                                    "Item Unavailable Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }

                    int netAvailableQty = GetNetAvailableStock(selectedItemID, startDate, endDate);

                    if (netAvailableQty <= 0)
                    {
                        MessageBox.Show($"Item Unavailable: Item '{selectedItemID}' has 0 available units on shelf for reservation between {startDate:MM/dd/yyyy} and {endDate:MM/dd/yyyy}.",
                                        "Reservation Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (requestedQty > netAvailableQty)
                    {
                        MessageBox.Show($"Insufficient Net Stock: Cannot reserve {requestedQty} pcs. Only {netAvailableQty} pcs currently available on shelf for this date range.",
                                        "Stock Deficit Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string insertRes = @"INSERT INTO reservation 
                                (BookingID, UserID, StartDate, EndDate, StartTime, EndTime, ApprovalStatus, RequestDate) 
                                VALUES 
                                (@BookingID, @UserID, @StartDate, @EndDate, @StartTime, @EndTime, @ApprovalStatus, NOW()) 
                                ON DUPLICATE KEY UPDATE 
                                    ApprovalStatus = VALUES(ApprovalStatus), 
                                    StartDate = VALUES(StartDate), 
                                    EndDate = VALUES(EndDate), 
                                    StartTime = VALUES(StartTime), 
                                    EndTime = VALUES(EndTime);";

                            using (MySqlCommand cmd = new MySqlCommand(insertRes, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BookingID", txtBookingID.Text.Trim());
                                cmd.Parameters.AddWithValue("@UserID", selectedUserID);
                                cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@StartTime", dtpStartTime.Value.ToString("HH:mm:ss"));
                                cmd.Parameters.AddWithValue("@EndTime", dtpEndTime.Value.ToString("HH:mm:ss"));
                                cmd.Parameters.AddWithValue("@ApprovalStatus", cmbApprovalStatus.SelectedItem?.ToString() ?? "Pending");
                                cmd.ExecuteNonQuery();
                            }

                            string insertItem = @"INSERT INTO reservation_item 
                                                 (BookingID, ItemID, QuantityReserved) 
                                                 VALUES 
                                                 (@BookingID, @ItemID, @QuantityReserved) 
                                                 ON DUPLICATE KEY UPDATE 
                                                     QuantityReserved = QuantityReserved + VALUES(QuantityReserved);";

                            using (MySqlCommand cmd = new MySqlCommand(insertItem, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BookingID", txtBookingID.Text.Trim());
                                cmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                                cmd.Parameters.AddWithValue("@QuantityReserved", requestedQty);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Reservation successfully recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadReservationsGrid();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error saving reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 4. UPDATE RESERVATION
        // ==========================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookingID.Text))
            {
                MessageBox.Show("Please select a reservation record from the table to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageBox.Show("End Date cannot be earlier than Start Date.", "Date Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bookingID = txtBookingID.Text.Trim();
            string selectedUserID = cmbUser.SelectedValue?.ToString() ?? "";
            string selectedItemID = cmbItem.SelectedValue?.ToString() ?? "";
            int requestedQty = Convert.ToInt32(numQuantity.Value);
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            string newStatus = cmbApprovalStatus.SelectedItem?.ToString() ?? "Pending";

            if (newStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase) || newStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                int netAvailableQty = GetNetAvailableStock(selectedItemID, startDate, endDate, excludeBookingID: bookingID);

                if (requestedQty > netAvailableQty)
                {
                    MessageBox.Show($"Cannot update reservation: Requested quantity of {requestedQty} pcs exceeds available stock of {netAvailableQty} pcs for this date range.",
                                    "Stock Limit Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    EnsureSchemaExists(conn);

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string updateRes = @"UPDATE reservation 
                                                SET UserID = @UserID, 
                                                    StartDate = @StartDate, 
                                                    EndDate = @EndDate, 
                                                    StartTime = @StartTime, 
                                                    EndTime = @EndTime, 
                                                    ApprovalStatus = @ApprovalStatus 
                                                WHERE BookingID = @BookingID";

                            using (MySqlCommand cmd = new MySqlCommand(updateRes, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                                cmd.Parameters.AddWithValue("@UserID", selectedUserID);
                                cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@StartTime", dtpStartTime.Value.ToString("HH:mm:ss"));
                                cmd.Parameters.AddWithValue("@EndTime", dtpEndTime.Value.ToString("HH:mm:ss"));
                                cmd.Parameters.AddWithValue("@ApprovalStatus", newStatus);
                                cmd.ExecuteNonQuery();
                            }

                            string updateItem = @"UPDATE reservation_item 
                                                 SET ItemID = @ItemID, 
                                                     QuantityReserved = @QuantityReserved 
                                                 WHERE BookingID = @BookingID";

                            using (MySqlCommand cmd = new MySqlCommand(updateItem, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                                cmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                                cmd.Parameters.AddWithValue("@QuantityReserved", requestedQty);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadReservationsGrid();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error updating reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 5. DELETE RESERVATION
        // ==========================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookingID.Text))
            {
                MessageBox.Show("Please select a reservation to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete reservation '{txtBookingID.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        using (MySqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string deleteDetails = "DELETE FROM reservation_item WHERE BookingID = @BookingID";
                                using (MySqlCommand cmd = new MySqlCommand(deleteDetails, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@BookingID", txtBookingID.Text.Trim());
                                    cmd.ExecuteNonQuery();
                                }

                                string deleteHeader = "DELETE FROM reservation WHERE BookingID = @BookingID";
                                using (MySqlCommand cmd = new MySqlCommand(deleteHeader, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@BookingID", txtBookingID.Text.Trim());
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Reservation deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadReservationsGrid();
                                ClearFields();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error deleting record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error establishing connection: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 6. GRID CLICK & FORM CLEAR UTILITIES
        // ==========================================
        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvReservations.Rows[e.RowIndex];

                txtBookingID.Text = row.Cells["Booking ID"].Value?.ToString();

                string userID = row.Cells["User ID"].Value?.ToString();
                if (!string.IsNullOrEmpty(userID))
                {
                    cmbUser.SelectedValue = userID;
                }

                if (DateTime.TryParse(row.Cells["Start Date"].Value?.ToString(), out DateTime sDate))
                    dtpStartDate.Value = sDate;

                if (DateTime.TryParse(row.Cells["End Date"].Value?.ToString(), out DateTime eDate))
                    dtpEndDate.Value = eDate;

                if (TimeSpan.TryParse(row.Cells["Start Time"].Value?.ToString(), out TimeSpan sTime))
                    dtpStartTime.Value = DateTime.Today.Add(sTime);

                if (TimeSpan.TryParse(row.Cells["End Time"].Value?.ToString(), out TimeSpan eTime))
                    dtpEndTime.Value = DateTime.Today.Add(eTime);

                cmbApprovalStatus.SelectedItem = row.Cells["Status"].Value?.ToString();

                string itemID = row.Cells["ItemID"].Value?.ToString();
                if (!string.IsNullOrEmpty(itemID))
                {
                    cmbItem.SelectedValue = itemID;
                }

                numQuantity.Value = Convert.ToDecimal(row.Cells["Qty"].Value ?? 1);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadReservationsGrid(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtBookingID.Clear();
            txtSearch.Clear();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Today.AddHours(9);
            dtpEndTime.Value = DateTime.Today.AddHours(12);

            if (cmbApprovalStatus.Items.Count > 0) cmbApprovalStatus.SelectedIndex = 0;
            if (cmbItem.Items.Count > 0) cmbItem.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(UserSession.UserID) && cmbUser.DataSource != null)
                cmbUser.SelectedValue = UserSession.UserID;
            else if (cmbUser.Items.Count > 0)
                cmbUser.SelectedIndex = 0;

            numQuantity.Value = 1;

            LoadReservationsGrid();
        }

        // Unused event stubs kept for Designer compatibility
        private void Panel3_Paint(object sender, PaintEventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged_1(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void idLbl_Click(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged_2(object sender, EventArgs e) { }
        private void label2_Click_2(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void conditionLbl_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e) { }
        private void AddButton_Click(object sender, EventArgs e) { }
        private void itemNameLbl_Click(object sender, EventArgs e) { }
        private void searchBox_TextChanged(object sender, EventArgs e) { }
        private void pbborrowreturn_Click(object sender, EventArgs e) { }
        private void dateTimePicker4_ValueChanged(object sender, EventArgs e) { }

        // ==========================================
        // 7. SIDEBAR NAVIGATION & LOGOUT
        // ==========================================
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnDashboard_Click(sender, e); }
        private void btnDashboard_Click(object sender, EventArgs e) { new Dashboard().Show(); this.Hide(); }

        private void InventoryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btninventory_Click(sender, e); }
        private void btninventory_Click(object sender, EventArgs e) { new InventoryPairs().Show(); this.Hide(); }

        private void ReservationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void btreservations_Click(object sender, EventArgs e) { }

        private void BorrowReturnLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnborrowreturn_Click(sender, e); }
        private void btnborrowreturn_Click(object sender, EventArgs e) { new BorrowReturnForm().Show(); this.Close(); }

        private void PerformanceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnperformances_Click(sender, e); }
        private void btnperformances_Click(object sender, EventArgs e) { new Performances().Show(); this.Hide(); }

        private void ReportsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnReports_Click(sender, e); }
        private void btnReports_Click(object sender, EventArgs e) { new Reports().Show(); this.Hide(); }

        private void UserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnUsers_Click(sender, e); }
        private void btnUsers_Click(object sender, EventArgs e) { new Users().Show(); this.Hide(); }

        private void SettingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnSettings_Click(sender, e); }
        private void btnSettings_Click(object sender, EventArgs e) { new Settings().Show(); this.Hide(); }

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
    }
}