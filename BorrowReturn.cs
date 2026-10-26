using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class BorrowReturnForm : Form
    {
        // Flag to prevent infinite re-entry between dropdown and checkbox events
        private bool isSyncingStatusAndCheckbox = false;

        public BorrowReturnForm()
        {
            InitializeComponent();
        }

        private void BorrowReturnForm_Load(object sender, EventArgs e)
        {
            isSyncingStatusAndCheckbox = true;

            try
            {
                // Unsubscribe first to avoid double-wiring
                chkReturned.CheckedChanged -= chkReturned_CheckedChanged;
                cmbStatus.SelectedIndexChanged -= cmbStatus_SelectedIndexChanged;
                dtpBorrowDate.ValueChanged -= dtpBorrowDate_ValueChanged;

                // Safely wire events
                chkReturned.CheckedChanged += chkReturned_CheckedChanged;
                cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
                dtpBorrowDate.ValueChanged += dtpBorrowDate_ValueChanged;

                // Ensure tables exist
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        EnsureTablesExist(conn);
                    }
                    catch { }
                }

                // Enforce minimum quantity of 1 on control
                if (numQuantity != null)
                {
                    numQuantity.Minimum = 1;
                    if (numQuantity.Value < 1) numQuantity.Value = 1;
                }

                // Populate cmbStatus items dynamically if empty
                if (cmbStatus.Items.Count == 0)
                {
                    cmbStatus.Items.AddRange(new object[] { "Borrowed", "Returned", "Overdue" });
                }

                PopulateUserDropdown();
                LoadItemDropdown();
                LoadBorrowGrid();

                dtpBorrowDate.Value = DateTime.Now;
                var (durationDays, _) = GetLoanRulesFromDB();
                dtpDueDate.Value = DateTime.Now.AddDays(durationDays);
                dtpReturnDate.Value = DateTime.Now;

                // Set initial state
                if (cmbStatus.Items.Count > 0 && cmbStatus.SelectedIndex < 0)
                {
                    cmbStatus.SelectedIndex = 0; // Default: 'Borrowed'
                }

                dtpReturnDate.Enabled = chkReturned.Checked;
            }
            finally
            {
                isSyncingStatusAndCheckbox = false;
            }
        }

        // ==========================================
        // AUTO-TABLE CREATION HELPER
        // ==========================================
        private void EnsureTablesExist(MySqlConnection conn)
        {
            string createBorrow = @"
                CREATE TABLE IF NOT EXISTS `borrow` (
                    `BorrowID` VARCHAR(50) NOT NULL PRIMARY KEY,
                    `UserID` VARCHAR(50) NOT NULL,
                    `BookingID` VARCHAR(50) NULL,
                    `BorrowDate` DATE NOT NULL,
                    `DueDate` DATE NOT NULL,
                    `ReturnDate` DATE NULL,
                    `Status` VARCHAR(50) DEFAULT 'Borrowed'
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

            string createBorrowItem = @"
                CREATE TABLE IF NOT EXISTS `borrow_item` (
                    `BorrowID` VARCHAR(50) NOT NULL,
                    `ItemID` VARCHAR(50) NOT NULL,
                    `QuantityBorrowed` INT DEFAULT 1,
                    PRIMARY KEY (`BorrowID`, `ItemID`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

            using (MySqlCommand cmd = new MySqlCommand(createBorrow, conn)) { cmd.ExecuteNonQuery(); }
            using (MySqlCommand cmd = new MySqlCommand(createBorrowItem, conn)) { cmd.ExecuteNonQuery(); }
        }

        // ==========================================
        // 1. POPULATE DROPDOWNS (USER & EQUIPMENT)
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
                        cmbUser.DisplayMember = "DisplayText"; // e.g. "Charles Tejano (U001)"
                        cmbUser.ValueMember = "UserID";        // e.g. "U001"

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
                    MessageBox.Show("Error loading equipment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 2. LOAD BORROW LOGS INTO DATAGRIDVIEW
        // ==========================================
        private void LoadBorrowGrid(string searchQuery = "")
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT b.BorrowID AS 'Borrow ID', 
                                            b.UserID AS 'User ID', 
                                            u.FullName AS 'Borrower',
                                            b.BookingID AS 'Booking ID', 
                                            b.BorrowDate AS 'Borrow Date', 
                                            b.DueDate AS 'Due Date', 
                                            b.ReturnDate AS 'Return Date', 
                                            bi.ItemID,
                                            i.ItemName AS 'Item Name',
                                            bi.QuantityBorrowed AS 'Qty',
                                            b.Status
                                     FROM borrow b
                                     INNER JOIN `user` u ON b.UserID = u.UserID
                                     INNER JOIN borrow_item bi ON b.BorrowID = bi.BorrowID
                                     INNER JOIN inventory_item i ON bi.ItemID = i.ItemID";

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE b.BorrowID LIKE @search OR b.UserID LIKE @search OR u.FullName LIKE @search OR i.ItemName LIKE @search OR b.BookingID LIKE @search";
                    }

                    query += " ORDER BY b.BorrowDate DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(searchQuery))
                        {
                            cmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        }

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvBorrow.DataSource = dt;

                        if (dgvBorrow.Columns.Contains("ItemID"))
                        {
                            dgvBorrow.Columns["ItemID"].Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading borrow records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 3. DATE LOGIC & RETURN SYNCHRONIZATION
        // ==========================================
        private void chkReturned_CheckedChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Enabled = chkReturned.Checked;

            if (isSyncingStatusAndCheckbox) return;

            try
            {
                isSyncingStatusAndCheckbox = true;

                if (chkReturned.Checked)
                {
                    cmbStatus.SelectedItem = "Returned";

                    if (dtpReturnDate.Value.Date < dtpBorrowDate.Value.Date)
                    {
                        dtpReturnDate.Value = dtpBorrowDate.Value;
                    }
                }
                else
                {
                    if (cmbStatus.SelectedItem?.ToString() == "Returned")
                    {
                        cmbStatus.SelectedItem = "Borrowed";
                    }
                }
            }
            finally
            {
                isSyncingStatusAndCheckbox = false;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSyncingStatusAndCheckbox) return;

            try
            {
                isSyncingStatusAndCheckbox = true;

                string selectedStatus = cmbStatus.SelectedItem?.ToString();
                if (selectedStatus == "Returned")
                {
                    chkReturned.Checked = true;
                    dtpReturnDate.Enabled = true;

                    if (dtpReturnDate.Value.Date < dtpBorrowDate.Value.Date)
                    {
                        dtpReturnDate.Value = dtpBorrowDate.Value;
                    }
                }
                else
                {
                    chkReturned.Checked = false;
                    dtpReturnDate.Enabled = false;
                }
            }
            finally
            {
                isSyncingStatusAndCheckbox = false;
            }
        }

        // ==========================================
        // 4. FETCH LOAN RULES & RULE 2 (AUTO DUE DATE)
        // ==========================================
        private (int durationDays, int maxItems) GetLoanRulesFromDB()
        {
            int duration = 7;
            int maxItems = 3;

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DefaultBorrowDuration, MaxItemsPerBorrower FROM `settings` WHERE id = 1 LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["DefaultBorrowDuration"] != DBNull.Value)
                                    duration = Convert.ToInt32(reader["DefaultBorrowDuration"]);
                                if (reader["MaxItemsPerBorrower"] != DBNull.Value)
                                    maxItems = Convert.ToInt32(reader["MaxItemsPerBorrower"]);
                            }
                        }
                    }
                }
                catch
                {
                    // Fallback defaults
                }
            }
            return (duration, maxItems);
        }

        private void dtpBorrowDate_ValueChanged(object sender, EventArgs e)
        {
            var (durationDays, _) = GetLoanRulesFromDB();
            dtpDueDate.Value = dtpBorrowDate.Value.AddDays(durationDays);
        }

        // ==========================================
        // 5. HELPER METHODS FOR INVENTORY & RULES
        // ==========================================
        private int GetAvailableStock(string itemID)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Quantity FROM inventory_item WHERE ItemID = @ItemID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        object result = cmd.ExecuteScalar();
                        return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }

        private int GetUserActiveBorrowedCount(string userID, string excludeBorrowID = "")
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT COALESCE(SUM(bi.QuantityBorrowed), 0) 
                                     FROM borrow b
                                     INNER JOIN borrow_item bi ON b.BorrowID = bi.BorrowID
                                     WHERE b.UserID = @UserID AND b.Status = 'Borrowed'";

                    if (!string.IsNullOrEmpty(excludeBorrowID))
                    {
                        query += " AND b.BorrowID != @ExcludeID";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        if (!string.IsNullOrEmpty(excludeBorrowID))
                        {
                            cmd.Parameters.AddWithValue("@ExcludeID", excludeBorrowID);
                        }
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }

        private bool HasActiveBorrowForSameItem(string userID, string itemID)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) 
                                     FROM borrow b
                                     INNER JOIN borrow_item bi ON b.BorrowID = bi.BorrowID
                                     WHERE b.UserID = @UserID AND bi.ItemID = @ItemID AND b.Status = 'Borrowed'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        // ==========================================
        // 6. ADD BORROW RECORD (WITH STOCK VALIDATION)
        // ==========================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBorrowID.Text))
            {
                MessageBox.Show("Please enter a valid Borrow ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbUser.SelectedValue == null || cmbItem.SelectedValue == null)
            {
                MessageBox.Show("Please select both a User and an Item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUserID = cmbUser.SelectedValue.ToString();
            string selectedItemID = cmbItem.SelectedValue.ToString();
            int requestedQty = Convert.ToInt32(numQuantity.Value);

            // 1. INVENTORY STOCK AVAILABILITY CHECK
            int availableStock = GetAvailableStock(selectedItemID);
            if (requestedQty > availableStock)
            {
                MessageBox.Show($"Insufficient Stock: Item '{selectedItemID}' only has {availableStock} unit(s) available in inventory stock. You requested {requestedQty}.",
                                "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ENFORCE RULE 3: MAX ITEMS PER BORROWER
            var (_, maxAllowedItems) = GetLoanRulesFromDB();
            if (requestedQty > maxAllowedItems)
            {
                MessageBox.Show($"Policy Violation: You cannot borrow more than {maxAllowedItems} items in a single transaction.",
                                "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentActiveQty = GetUserActiveBorrowedCount(selectedUserID);
            if ((currentActiveQty + requestedQty) > maxAllowedItems)
            {
                MessageBox.Show($"Policy Violation: User '{selectedUserID}' already has {currentActiveQty} active borrowed item(s). Borrowing {requestedQty} more would exceed the limit of {maxAllowedItems}.",
                                "Borrow Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. OVERLAPPING BORROW CHECK
            if (HasActiveBorrowForSameItem(selectedUserID, selectedItemID))
            {
                MessageBox.Show($"Overlapping Borrow Error: User '{selectedUserID}' already has an active borrowed record for item '{selectedItemID}'.",
                                "Duplicate Borrow Rejection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string borrowID = txtBorrowID.Text.Trim();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert into borrow (Header)
                        string insertBorrow = @"INSERT INTO borrow 
                                                    (BorrowID, UserID, BookingID, BorrowDate, DueDate, Status) 
                                                VALUES 
                                                    (@BorrowID, @UserID, @BookingID, @BorrowDate, @DueDate, 'Borrowed')";

                        using (MySqlCommand cmd = new MySqlCommand(insertBorrow, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BorrowID", borrowID);
                            cmd.Parameters.AddWithValue("@UserID", selectedUserID);
                            cmd.Parameters.AddWithValue("@BookingID", string.IsNullOrWhiteSpace(txtBookingID.Text) ? (object)DBNull.Value : txtBookingID.Text.Trim());
                            cmd.Parameters.AddWithValue("@BorrowDate", dtpBorrowDate.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value.ToString("yyyy-MM-dd"));
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Insert into borrow_item (Details)
                        string insertItem = @"INSERT INTO borrow_item 
                                                (BorrowID, ItemID, QuantityBorrowed) 
                                              VALUES 
                                                (@BorrowID, @ItemID, @Qty)";

                        using (MySqlCommand cmd = new MySqlCommand(insertItem, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BorrowID", borrowID);
                            cmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                            cmd.Parameters.AddWithValue("@Qty", requestedQty);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Deduct requested quantity from inventory stock
                        string deductStock = "UPDATE inventory_item SET Quantity = Quantity - @Qty WHERE ItemID = @ItemID";
                        using (MySqlCommand cmd = new MySqlCommand(deductStock, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Qty", requestedQty);
                            cmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show($"Borrow record added successfully! ({requestedQty} unit(s) deducted from inventory)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadBorrowGrid();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error adding borrow record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 7. UPDATE BORROW RECORD / STOCK ADJUSTMENTS
        // ==========================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBorrowID.Text))
            {
                MessageBox.Show("Please select a borrow record from the table to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value < 1)
            {
                MessageBox.Show("Borrow quantity must be at least 1.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQuantity.Value = 1;
                return;
            }

            if (dtpDueDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                MessageBox.Show("Due Date cannot be earlier than Borrow Date.", "Date Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = cmbStatus.SelectedItem?.ToString() ?? "Borrowed";

            if ((chkReturned.Checked || newStatus == "Returned") && dtpReturnDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                MessageBox.Show("Return Date cannot be earlier than Borrow Date.", "Date Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string borrowID = txtBorrowID.Text.Trim();
            string selectedUserID = cmbUser.SelectedValue?.ToString() ?? "";
            string selectedItemID = cmbItem.SelectedValue?.ToString() ?? "";
            int newQty = Convert.ToInt32(numQuantity.Value);

            var (_, maxAllowedItems) = GetLoanRulesFromDB();

            // --- ENFORCE RULE 3 ON UPDATE ---
            if (newStatus.Equals("Borrowed", StringComparison.OrdinalIgnoreCase))
            {
                if (newQty > maxAllowedItems)
                {
                    MessageBox.Show($"Policy Violation: Cannot set quantity to {newQty}. Maximum allowed is {maxAllowedItems}.",
                                    "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int activeOtherQty = GetUserActiveBorrowedCount(selectedUserID, borrowID);
                if ((activeOtherQty + newQty) > maxAllowedItems)
                {
                    MessageBox.Show($"Policy Violation: User '{selectedUserID}' already has {activeOtherQty} active item(s). Updating this record to {newQty} exceeds the limit of {maxAllowedItems}.",
                                    "Borrow Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string fetchOldQuery = @"SELECT b.Status, bi.QuantityBorrowed, bi.ItemID 
                                            FROM borrow b 
                                            INNER JOIN borrow_item bi ON b.BorrowID = bi.BorrowID 
                                            WHERE b.BorrowID = @BorrowID";

                    string previousStatus = "";
                    int previousQty = 0;
                    string previousItemID = "";

                    using (MySqlCommand fetchCmd = new MySqlCommand(fetchOldQuery, conn))
                    {
                        fetchCmd.Parameters.AddWithValue("@BorrowID", borrowID);
                        using (MySqlDataReader reader = fetchCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                previousStatus = reader["Status"].ToString();
                                previousQty = Convert.ToInt32(reader["QuantityBorrowed"]);
                                previousItemID = reader["ItemID"].ToString();
                            }
                        }
                    }

                    // --- STOCK AVAILABILITY CHECK ON UPDATE ---
                    int availableStock = GetAvailableStock(selectedItemID);

                    if (newStatus == "Borrowed")
                    {
                        if (previousStatus == "Returned")
                        {
                            // Re-borrowing an item that was returned requires full stock
                            if (newQty > availableStock)
                            {
                                MessageBox.Show($"Insufficient Stock: Item '{selectedItemID}' only has {availableStock} available in inventory.",
                                                "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else if (previousItemID == selectedItemID)
                        {
                            // Increasing quantity on active record requires additional stock
                            int qtyDiff = newQty - previousQty;
                            if (qtyDiff > 0 && qtyDiff > availableStock)
                            {
                                MessageBox.Show($"Insufficient Stock: Increasing quantity by {qtyDiff} requires more stock than the {availableStock} currently available.",
                                                "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string updateBorrow = @"UPDATE borrow 
                                                   SET UserID = @UserID, 
                                                       BookingID = @BookingID, 
                                                       BorrowDate = @BorrowDate, 
                                                       DueDate = @DueDate, 
                                                       ReturnDate = @ReturnDate, 
                                                       Status = @Status 
                                                   WHERE BorrowID = @BorrowID";

                            using (MySqlCommand cmd = new MySqlCommand(updateBorrow, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BorrowID", borrowID);
                                cmd.Parameters.AddWithValue("@UserID", selectedUserID);
                                cmd.Parameters.AddWithValue("@BookingID", string.IsNullOrWhiteSpace(txtBookingID.Text) ? (object)DBNull.Value : txtBookingID.Text.Trim());
                                cmd.Parameters.AddWithValue("@BorrowDate", dtpBorrowDate.Value.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@ReturnDate", (newStatus == "Returned" || chkReturned.Checked) ? dtpReturnDate.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Status", newStatus);
                                cmd.ExecuteNonQuery();
                            }

                            string updateItem = @"UPDATE borrow_item 
                                                 SET ItemID = @ItemID, 
                                                     QuantityBorrowed = @QuantityBorrowed 
                                                 WHERE BorrowID = @BorrowID";

                            using (MySqlCommand cmd = new MySqlCommand(updateItem, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BorrowID", borrowID);
                                cmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                                cmd.Parameters.AddWithValue("@QuantityBorrowed", newQty);
                                cmd.ExecuteNonQuery();
                            }

                            // --- INVENTORY STOCK ADJUSTMENTS ---
                            if (previousStatus != "Returned" && newStatus == "Returned")
                            {
                                // Item Returned -> Restore stock to inventory
                                string restoreStock = "UPDATE inventory_item SET Quantity = Quantity + @Qty WHERE ItemID = @ItemID";
                                using (MySqlCommand cmd = new MySqlCommand(restoreStock, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Qty", previousQty);
                                    cmd.Parameters.AddWithValue("@ItemID", previousItemID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else if (previousStatus == "Returned" && newStatus != "Returned")
                            {
                                // Status flipped back to Borrowed -> Deduct stock
                                string deductStock = "UPDATE inventory_item SET Quantity = Quantity - @Qty WHERE ItemID = @ItemID";
                                using (MySqlCommand cmd = new MySqlCommand(deductStock, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Qty", newQty);
                                    cmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else if (previousStatus == "Borrowed" && newStatus == "Borrowed" && previousItemID == selectedItemID)
                            {
                                // Adjust differential stock for active borrows
                                int qtyDiff = newQty - previousQty;
                                if (qtyDiff != 0)
                                {
                                    string adjustStock = "UPDATE inventory_item SET Quantity = Quantity - @QtyDiff WHERE ItemID = @ItemID";
                                    using (MySqlCommand cmd = new MySqlCommand(adjustStock, conn, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@QtyDiff", qtyDiff);
                                        cmd.Parameters.AddWithValue("@ItemID", selectedItemID);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Borrow record and inventory stock updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadBorrowGrid();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error updating record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 8. DELETE BORROW RECORD
        // ==========================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBorrowID.Text))
            {
                MessageBox.Show("Select a record to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Delete borrow record '{txtBorrowID.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string deleteDetails = "DELETE FROM borrow_item WHERE BorrowID = @BorrowID";
                            using (MySqlCommand cmd = new MySqlCommand(deleteDetails, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BorrowID", txtBorrowID.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            string deleteHeader = "DELETE FROM borrow WHERE BorrowID = @BorrowID";
                            using (MySqlCommand cmd = new MySqlCommand(deleteHeader, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BorrowID", txtBorrowID.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBorrowGrid();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error deleting record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // ==========================================
        // 9. GRID CELL CLICK SELECTION
        // ==========================================
        private void dgvBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBorrow.Rows[e.RowIndex];

                txtBorrowID.Text = row.Cells["Borrow ID"].Value?.ToString();
                txtBookingID.Text = row.Cells["Booking ID"].Value?.ToString();

                string userID = row.Cells["User ID"].Value?.ToString();
                if (!string.IsNullOrEmpty(userID))
                {
                    cmbUser.SelectedValue = userID;
                }

                if (DateTime.TryParse(row.Cells["Borrow Date"].Value?.ToString(), out DateTime bDate))
                    dtpBorrowDate.Value = bDate;

                if (DateTime.TryParse(row.Cells["Due Date"].Value?.ToString(), out DateTime dDate))
                    dtpDueDate.Value = dDate;

                string returnVal = row.Cells["Return Date"].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(returnVal) && DateTime.TryParse(returnVal, out DateTime rDate))
                {
                    chkReturned.Checked = true;
                    dtpReturnDate.Value = rDate;
                    dtpReturnDate.Enabled = true;
                }
                else
                {
                    chkReturned.Checked = false;
                    dtpReturnDate.Enabled = false;
                }

                string statusVal = row.Cells["Status"].Value?.ToString();
                if (!string.IsNullOrEmpty(statusVal))
                {
                    cmbStatus.SelectedItem = statusVal;
                }

                string itemID = row.Cells["ItemID"].Value?.ToString();
                if (!string.IsNullOrEmpty(itemID))
                {
                    cmbItem.SelectedValue = itemID;
                }

                decimal rawQty = Convert.ToDecimal(row.Cells["Qty"].Value ?? 1);
                numQuantity.Value = Math.Max(numQuantity.Minimum, rawQty);
            }
        }

        private void dgvBorrow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBorrow_CellClick(sender, e);
        }

        // ==========================================
        // 10. UTILITY & NAVIGATION HANDLERS
        // ==========================================
        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadBorrowGrid(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            txtBorrowID.Clear();
            txtBookingID.Clear();
            txtSearch.Clear();

            dtpBorrowDate.Value = DateTime.Now;
            var (durationDays, _) = GetLoanRulesFromDB();
            dtpDueDate.Value = DateTime.Now.AddDays(durationDays);
            chkReturned.Checked = false;
            dtpReturnDate.Value = DateTime.Now;
            dtpReturnDate.Enabled = false;

            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            if (cmbItem.Items.Count > 0) cmbItem.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(UserSession.UserID) && cmbUser.DataSource != null)
                cmbUser.SelectedValue = UserSession.UserID;

            numQuantity.Value = 1;

            LoadBorrowGrid();
        }

        // --- SIDE PANEL NAVIGATION STUBS ---
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { new Dashboard().Show(); this.Hide(); }
        private void btnDashboard_Click(object sender, EventArgs e) { new Dashboard().Show(); this.Hide(); }

        private void ReservationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { new Reservation().Show(); this.Hide(); }
        private void btreservations_Click(object sender, EventArgs e) { new Reservation().Show(); this.Hide(); }

        private void PerformanceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { new Performances().Show(); this.Hide(); }
        private void btnperformances_Click(object sender, EventArgs e) { new Performances().Show(); this.Hide(); }

        private void ReportsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { new Reports().Show(); this.Hide(); }
        private void btnReports_Click(object sender, EventArgs e) { new Reports().Show(); this.Hide(); }

        private void UserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { new Users().Show(); this.Hide(); }
        private void btnUsers_Click(object sender, EventArgs e) { new Users().Show(); this.Hide(); }

        private void SettingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { new Settings().Show(); this.Hide(); }
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

        private void btninventory_Click(object sender, EventArgs e) { new InventoryPairs().Show(); this.Hide(); }
        private void btnborrowreturn_Click(object sender, EventArgs e) { }

        private void itemNameLbl_Click(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void txtBorrowID_TextChanged(object sender, EventArgs e) { }
        private void dtpReturnDate_ValueChanged(object sender, EventArgs e) { }

        private void BorrowReturnLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void InventoryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { new InventoryPairs().Show(); this.Hide(); }
    }
}