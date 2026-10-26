using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MemberBorrowed : Form
    {
        public MemberBorrowed()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. FORM LOAD & INITIALIZATION
        // ==========================================
        private void MemberBorrowed_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            // Wire up DataGridView selection event
            DataGridView grid = GetLoansGrid();
            if (grid != null)
            {
                grid.SelectionChanged -= dgvLoans_SelectionChanged;
                grid.SelectionChanged += dgvLoans_SelectionChanged;
            }

            // Populate Status Filter Dropdown
            if (cmbFilter != null)
            {
                cmbFilter.Items.Clear();
                cmbFilter.Items.AddRange(new object[] { "All Statuses", "Borrowed", "Overdue", "Return Pending", "Returned", "Completed" });
                cmbFilter.SelectedIndex = 0;
            }

            // Populate Issued Condition ComboBox
            if (cmbIssuedCondition != null && cmbIssuedCondition.Items.Count == 0)
            {
                cmbIssuedCondition.Items.AddRange(new object[] { "Good", "Fair", "Minor Wear/Scratches", "Damaged", "Incomplete" });
            }

            LoadLoansData();
        }

        // ==========================================
        // 2. LOAD BORROW RECORDS FROM MYSQL
        // ==========================================
        private void LoadLoansData()
        {
            string currentUserId = UserSession.UserID ?? "U002";
            string searchVal = txtSearch?.Text.Trim() ?? "";
            string statusFilter = cmbFilter?.SelectedItem?.ToString() ?? "All Statuses";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT 
                                        b.BorrowID AS 'Borrow ID',
                                        COALESCE(NULLIF(b.BookingID, ''), 'N/A') AS 'Booking ID',
                                        COALESCE(
                                            NULLIF(GROUP_CONCAT(DISTINCT COALESCE(i_borrow.ItemName, i_res.ItemName) SEPARATOR ', '), ''), 
                                            'N/A'
                                        ) AS 'Equipments',
                                        COALESCE(SUM(COALESCE(bi.QuantityBorrowed, ri.QuantityReserved, 1)), 1) AS 'Quantity',
                                        b.BorrowDate AS 'Borrow Date',
                                        b.DueDate AS 'Due Date',
                                        b.Status AS 'Status',
                                        COALESCE(b.IssuedCondition, 'Good') AS 'Issued Condition'
                                     FROM borrow b
                                     LEFT JOIN borrow_item bi ON b.BorrowID = bi.BorrowID
                                     LEFT JOIN inventory_item i_borrow ON bi.ItemID = i_borrow.ItemID
                                     LEFT JOIN reservation_item ri ON (b.BookingID IS NOT NULL AND b.BookingID != '' AND b.BookingID = ri.BookingID)
                                     LEFT JOIN inventory_item i_res ON ri.ItemID = i_res.ItemID
                                     WHERE b.UserID = @UserID ";

                    if (statusFilter != "All Statuses")
                    {
                        query += " AND b.Status = @FilterStatus ";
                    }

                    if (!string.IsNullOrWhiteSpace(searchVal))
                    {
                        query += " AND (b.BorrowID LIKE @Search OR b.BookingID LIKE @Search OR i_borrow.ItemName LIKE @Search OR i_res.ItemName LIKE @Search) ";
                    }

                    query += @" GROUP BY b.BorrowID, b.BookingID, b.BorrowDate, b.DueDate, b.Status, b.IssuedCondition
                                ORDER BY b.DueDate DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserId);

                        if (statusFilter != "All Statuses")
                            cmd.Parameters.AddWithValue("@FilterStatus", statusFilter);

                        if (!string.IsNullOrWhiteSpace(searchVal))
                            cmd.Parameters.AddWithValue("@Search", $"%{searchVal}%");

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DataGridView grid = GetLoansGrid();
                        if (grid != null)
                        {
                            grid.DataSource = dt;
                            grid.ClearSelection();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading borrowed items: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ClearDetailsPanel();
        }

        // ==========================================
        // 3. GRID SELECTION -> POPULATE DETAILS
        // ==========================================
        private void dgvLoans_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView grid = GetLoansGrid();
            if (grid == null || grid.SelectedRows.Count == 0) return;

            DataGridViewRow row = grid.SelectedRows[0];

            if (txtBorrowID != null) txtBorrowID.Text = row.Cells["Borrow ID"].Value?.ToString();
            if (txtEquipments != null) txtEquipments.Text = row.Cells["Equipments"].Value?.ToString();
            if (txtQuantity != null) txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();

            if (dtpBorrowDate != null && DateTime.TryParse(row.Cells["Borrow Date"].Value?.ToString(), out DateTime bDate))
                dtpBorrowDate.Value = bDate;

            if (dtpDueDate != null && DateTime.TryParse(row.Cells["Due Date"].Value?.ToString(), out DateTime dDate))
                dtpDueDate.Value = dDate;

            string status = row.Cells["Status"].Value?.ToString() ?? "";
            if (txtStatus != null) txtStatus.Text = status;

            string condition = row.Cells["Issued Condition"].Value?.ToString() ?? "Good";
            if (cmbIssuedCondition != null)
            {
                if (cmbIssuedCondition.Items.Contains(condition))
                    cmbIssuedCondition.SelectedItem = condition;
                else
                    cmbIssuedCondition.Text = condition;
            }

            // Enable Submit Return Request button only if loan is active
            if (btnSubmitReturn != null)
            {
                btnSubmitReturn.Enabled = status.Equals("Borrowed", StringComparison.OrdinalIgnoreCase) ||
                                          status.Equals("Overdue", StringComparison.OrdinalIgnoreCase);
            }
        }

        // ==========================================
        // 4. SUBMIT RETURN REQUEST HANDLER
        // ==========================================
        private void btnSubmitReturn_Click(object sender, EventArgs e)
        {
            string borrowId = txtBorrowID?.Text.Trim() ?? "";

            if (string.IsNullOrEmpty(borrowId))
            {
                MessageBox.Show("Please select an active loan from the list first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Submit return request for Borrow ID '{borrowId}'?\n\nRemember to hand in the equipment at the Cultural office for custodian inspection.",
                                                 "Confirm Return Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string updateQuery = @"UPDATE borrow 
                                               SET Status = 'Return Pending' 
                                               WHERE BorrowID = @BorrowID;";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@BorrowID", borrowId);
                            int affected = cmd.ExecuteNonQuery();

                            if (affected > 0)
                            {
                                MessageBox.Show("Return request submitted! Please bring the equipment to the Cultural office for physical inspection.",
                                                "Request Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadLoansData();
                            }
                            else
                            {
                                MessageBox.Show("Unable to update return status.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error submitting return request: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 5. HELPER METHODS
        // ==========================================
        private DataGridView GetLoansGrid()
        {
            if (Controls.Find("dgvLoans", true).Length > 0)
                return Controls.Find("dgvLoans", true)[0] as DataGridView;
            if (Controls.Find("dgvBorrowed", true).Length > 0)
                return Controls.Find("dgvBorrowed", true)[0] as DataGridView;
            if (Controls.Find("dgvMemberBorrowed", true).Length > 0)
                return Controls.Find("dgvMemberBorrowed", true)[0] as DataGridView;
            return null;
        }

        private void ClearDetailsPanel()
        {
            if (txtBorrowID != null) txtBorrowID.Clear();
            if (txtEquipments != null) txtEquipments.Clear();
            if (txtQuantity != null) txtQuantity.Clear();
            if (dtpBorrowDate != null) dtpBorrowDate.Value = DateTime.Today;
            if (dtpDueDate != null) dtpDueDate.Value = DateTime.Today;
            if (txtStatus != null) txtStatus.Text = string.Empty;
            if (cmbIssuedCondition != null) cmbIssuedCondition.SelectedIndex = -1;
            if (btnSubmitReturn != null) btnSubmitReturn.Enabled = false;
        }

        // Search & Filter event handlers
        private void btnSearch_Click(object sender, EventArgs e) => LoadLoansData();
        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadLoansData();
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadLoansData();

        // ==========================================
        // 6. MEMBER SIDEBAR NAVIGATION HANDLERS
        // ==========================================
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnDashboard_Click(sender, e);
        private void btnDashboard_Click(object sender, EventArgs e) { new MemberDashboard().Show(); this.Hide(); }

        private void EquipmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnEquipment_Click(sender, e);
        private void btnEquipment_Click(object sender, EventArgs e) { new EquipmentCatalog().Show(); this.Hide(); }

        private void ReservationsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnReservations_Click(sender, e);
        private void btnReservations_Click(object sender, EventArgs e) { new MemberReservation().Show(); this.Hide(); }

        private void BorrowedLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnBorrowed_Click(sender, e);
        private void btnBorrowed_Click(object sender, EventArgs e) { } // Already on MemberBorrowed

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