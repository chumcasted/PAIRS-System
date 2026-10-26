using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MemberReservation : Form
    {
        public MemberReservation()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. FORM LOAD & INITIALIZATION
        // ==========================================
        private void MemberReservation_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            if (dgvMemberReservations != null)
            {
                dgvMemberReservations.SelectionChanged -= dgvMemberReservations_SelectionChanged;
                dgvMemberReservations.SelectionChanged += dgvMemberReservations_SelectionChanged;
            }

            if (btnCancelReservation != null)
            {
                btnCancelReservation.Click -= btnCancelReservation_Click;
                btnCancelReservation.Click += btnCancelReservation_Click;
            }

            if (cmbStatus != null)
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new object[] { "All", "Pending", "Approved", "Rejected", "Cancelled" });
                cmbStatus.SelectedIndex = 0;
            }

            LoadMemberReservations();
        }

        // ==========================================
        // 2. LOAD RESERVATIONS INTO DATA GRID
        // ==========================================
        private void LoadMemberReservations()
        {
            string currentUserId = UserSession.UserID ?? "U002";
            string statusFilter = cmbStatus?.SelectedItem?.ToString() ?? "All";
            string searchVal = txtSearch?.Text.Trim() ?? "";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        r.BookingID AS 'Booking ID',
                                        r.StartDate AS 'Start Date',
                                        r.EndDate AS 'Return Date',
                                        COUNT(ri.ItemID) AS 'Total Items',
                                        r.ApprovalStatus AS 'Status'
                                     FROM reservation r
                                     LEFT JOIN reservation_item ri ON r.BookingID = ri.BookingID
                                     WHERE r.UserID = @UserID ";

                    if (statusFilter != "All")
                        query += " AND r.ApprovalStatus = @Status ";

                    if (!string.IsNullOrWhiteSpace(searchVal))
                        query += " AND (r.BookingID LIKE @Search OR r.ApprovalStatus LIKE @Search) ";

                    query += " GROUP BY r.BookingID, r.StartDate, r.EndDate, r.ApprovalStatus ORDER BY r.BookingID DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserId);

                        if (statusFilter != "All")
                            cmd.Parameters.AddWithValue("@Status", statusFilter);

                        if (!string.IsNullOrWhiteSpace(searchVal))
                            cmd.Parameters.AddWithValue("@Search", $"%{searchVal}%");

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dgvMemberReservations != null)
                        {
                            dgvMemberReservations.DataSource = dt;
                            dgvMemberReservations.ClearSelection();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reservations: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 3. GRID SELECTION -> LOAD DETAILS
        // ==========================================
        private void dgvMemberReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMemberReservations == null || dgvMemberReservations.SelectedRows.Count == 0) return;

            string bookingId = dgvMemberReservations.SelectedRows[0].Cells["Booking ID"].Value?.ToString();
            if (string.IsNullOrEmpty(bookingId)) return;

            LoadBookingDetails(bookingId);
        }

        private void LoadBookingDetails(string bookingId)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT BookingID, StartDate, EndDate, ApprovalStatus, RequestDate 
                                     FROM reservation 
                                     WHERE BookingID = @BookingID LIMIT 1;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                if (txtBookingID != null) txtBookingID.Text = r["BookingID"]?.ToString();

                                if (dtpDateRequested != null && r["RequestDate"] != DBNull.Value)
                                    dtpDateRequested.Value = Convert.ToDateTime(r["RequestDate"]);

                                string status = r["ApprovalStatus"]?.ToString() ?? "Pending";

                                if (txtStatus != null) txtStatus.Text = status;

                                if (btnCancelReservation != null)
                                {
                                    btnCancelReservation.Enabled = status.Equals("Pending", StringComparison.OrdinalIgnoreCase);
                                }
                            }
                        }
                    }

                    if (lstRsvCart != null)
                    {
                        lstRsvCart.Items.Clear();
                        string itemsQuery = @"SELECT i.ItemName, ri.QuantityReserved AS Qty 
                                             FROM reservation_item ri
                                             JOIN inventory_item i ON ri.ItemID = i.ItemID
                                             WHERE ri.BookingID = @BookingID;";

                        using (MySqlCommand cmdItems = new MySqlCommand(itemsQuery, conn))
                        {
                            cmdItems.Parameters.AddWithValue("@BookingID", bookingId);
                            using (MySqlDataReader rItems = cmdItems.ExecuteReader())
                            {
                                while (rItems.Read())
                                {
                                    int qty = rItems["Qty"] != DBNull.Value ? Convert.ToInt32(rItems["Qty"]) : 1;
                                    lstRsvCart.Items.Add($"• {rItems["ItemName"]} (x{qty})");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading booking details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 4. CANCEL RESERVATION REQUEST
        // ==========================================
        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (dgvMemberReservations == null || dgvMemberReservations.SelectedRows.Count == 0) return;

            string bookingId = dgvMemberReservations.SelectedRows[0].Cells["Booking ID"].Value?.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to cancel reservation #{bookingId}?", "Cancel Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE reservation SET ApprovalStatus = 'Cancelled' WHERE BookingID = @BookingID AND ApprovalStatus = 'Pending';";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@BookingID", bookingId);
                            int count = cmd.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("Reservation request cancelled successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadMemberReservations();
                            }
                            else
                            {
                                MessageBox.Show("Only pending reservations can be cancelled.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error cancelling reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 5. SEARCH & FILTER HANDLERS
        // ==========================================
        private void btnSearch_Click(object sender, EventArgs e) => LoadMemberReservations();
        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadMemberReservations();
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) => LoadMemberReservations();

        // ==========================================
        // 6. MEMBER NAVIGATION HANDLERS
        // ==========================================
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnDashboard_Click(sender, e);
        private void btnDashboard_Click(object sender, EventArgs e) { new MemberDashboard().Show(); this.Hide(); }

        private void EquipmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnEquipment_Click(sender, e);
        private void btnEquipment_Click(object sender, EventArgs e) { new EquipmentCatalog().Show(); this.Hide(); }

        private void ReservationsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnReservations_Click(sender, e);
        private void btnReservations_Click(object sender, EventArgs e) { } // Already on MemberReservation

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