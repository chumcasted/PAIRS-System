using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MemberDashboard : Form
    {
        public MemberDashboard()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. FORM LOAD & INITIALIZATION
        // ==========================================
        private void MemberDashboard_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            string currentUserId = UserSession.UserID ?? "U002";
            string currentUserName = UserSession.FullName;

            if (string.IsNullOrWhiteSpace(currentUserName))
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT FullName FROM user WHERE UserID = @UserID LIMIT 1;";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", currentUserId);
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                currentUserName = result.ToString();
                            }
                        }
                    }
                    catch { }
                }
            }

            if (string.IsNullOrWhiteSpace(currentUserName))
                currentUserName = "Member";

            if (welcome_lbl != null)
            {
                welcome_lbl.Text = $"Welcome Back, {currentUserName}!";
            }

            LoadDashboardMetrics(currentUserId);
            LoadActiveLoansGrid(currentUserId);
            LoadRecentReservationsGrid(currentUserId);
        }

        // ==========================================
        // 2. USER-SPECIFIC METRICS
        // ==========================================
        private void LoadDashboardMetrics(string userId)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Active Loans Count ('Borrowed' status)
                    string activeQuery = "SELECT COUNT(*) FROM borrow WHERE UserID = @UserID AND Status = 'Borrowed';";
                    using (MySqlCommand cmd = new MySqlCommand(activeQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        int activeCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (lblActiveLoans != null) lblActiveLoans.Text = activeCount.ToString();
                    }

                    // 2. Approved Reservations Count
                    string reservedQuery = "SELECT COUNT(*) FROM reservation WHERE UserID = @UserID AND ApprovalStatus = 'Approved';";
                    using (MySqlCommand cmd = new MySqlCommand(reservedQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        int reservedCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (lblReservedCount != null) lblReservedCount.Text = reservedCount.ToString();
                    }

                    // 3. Pending Reservations Count
                    string pendingQuery = "SELECT COUNT(*) FROM reservation WHERE UserID = @UserID AND ApprovalStatus = 'Pending';";
                    using (MySqlCommand cmd = new MySqlCommand(pendingQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        int pendingCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (lblPendingCount != null) lblPendingCount.Text = pendingCount.ToString();
                    }

                    // 4. Overdue Loans Count
                    string overdueQuery = "SELECT COUNT(*) FROM borrow WHERE UserID = @UserID AND Status = 'Overdue';";
                    using (MySqlCommand cmd = new MySqlCommand(overdueQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        int overdueCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (lblOverdueCount != null) lblOverdueCount.Text = overdueCount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading metrics: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 3. USER-SPECIFIC DATA GRIDS
        // ==========================================
        private void LoadActiveLoansGrid(string userId)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        b.BorrowID AS 'Borrow ID',
                                        b.BookingID AS 'Booking ID',
                                        b.BorrowDate AS 'Borrow Date',
                                        b.DueDate AS 'Due Date',
                                        b.Status
                                     FROM borrow b
                                     WHERE b.UserID = @UserID AND b.Status IN ('Borrowed', 'Overdue')
                                     ORDER BY b.DueDate ASC LIMIT 5;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dgvActiveLoans != null)
                        {
                            dgvActiveLoans.DataSource = dt;
                            dgvActiveLoans.ClearSelection();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading active loans grid: " + ex.Message);
                }
            }
        }

        private void LoadRecentReservationsGrid(string userId)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        r.BookingID AS 'Booking ID',
                                        r.StartDate AS 'Start Date',
                                        r.EndDate AS 'End Date',
                                        r.ApprovalStatus AS 'Status'
                                     FROM reservation r
                                     WHERE r.UserID = @UserID
                                     ORDER BY r.RequestDate DESC LIMIT 5;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dgvRecent != null)
                        {
                            dgvRecent.DataSource = dt;
                            dgvRecent.ClearSelection();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading recent reservations grid: " + ex.Message);
                }
            }
        }

        // ==========================================
        // 4. MEMBER SIDEBAR NAVIGATION HANDLERS
        // ==========================================
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnDashboard_Click(sender, e);
        private void btnDashboard_Click(object sender, EventArgs e) { } // Already on Dashboard

        private void EquipmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnEquipment_Click(sender, e);
        private void btnEquipment_Click(object sender, EventArgs e) { new EquipmentCatalog().Show(); this.Hide(); }

        private void ReservationsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnReservations_Click(sender, e);
        private void btnReservations_Click(object sender, EventArgs e) { new MemberReservation().Show(); this.Hide(); }

        private void BorrowedLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnMemberBorrowed_Click(sender, e);
        private void btnMemberBorrowed_Click(object sender, EventArgs e)
        {
            MemberBorrowed memberBorrowed = new MemberBorrowed();
            memberBorrowed.Show();
            this.Hide();
        }

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

        private void lblMembersCount_Click(object sender, EventArgs e) { }
        private void active_lbl_Click(object sender, EventArgs e) { }
        private void recent_lbl_Click(object sender, EventArgs e) { }
    }
}