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
    public partial class Dashboard : Form
    {
        public string CurrentUserID { get; private set; } = string.Empty;
        public string CurrentUserName { get; private set; } = string.Empty;

        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(string userId, string fullName) : this()
        {
            CurrentUserID = userId;
            CurrentUserName = fullName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SetWelcomeGreeting();
            LoadDashboardGrids();
            UpdateDashboardCards();
        }

        // ==========================================
        // DYNAMIC USER GREETING HELPER
        // ==========================================
        private void SetWelcomeGreeting()
        {
            string displayName = CurrentUserName;

            // 1. Fallback to active UserSession FullName if CurrentUserName was not passed via constructor
            if (string.IsNullOrWhiteSpace(displayName) && !string.IsNullOrWhiteSpace(UserSession.FullName))
            {
                displayName = UserSession.FullName;
            }

            // 2. Fallback to DB query using UserSession UserID if name is still empty
            if (string.IsNullOrWhiteSpace(displayName) && !string.IsNullOrWhiteSpace(UserSession.UserID))
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT FullName FROM `user` WHERE UserID = @UserID LIMIT 1";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                            object res = cmd.ExecuteScalar();
                            if (res != null && res != DBNull.Value)
                            {
                                displayName = res.ToString();
                            }
                        }
                    }
                    catch { }
                }
            }

            // Display greeting
            if (!string.IsNullOrWhiteSpace(displayName))
            {
                welcome_lbl.Text = $"Welcome Back, {displayName}!";
            }
            else
            {
                welcome_lbl.Text = "Welcome Back!";
            }
        }

        private void LoadDashboardGrids()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string overdueQuery = @"SELECT 
                                        COALESCE(u.FullName, b.UserID) AS 'Borrower',
                                        COALESCE(i.ItemName, 'N/A') AS 'Item Name',
                                        CONCAT(DATEDIFF(CURRENT_DATE(), 
                                            CASE 
                                                WHEN b.DueDate LIKE '%/%' THEN STR_TO_DATE(b.DueDate, '%m/%d/%Y') 
                                                ELSE DATE(b.DueDate) 
                                            END
                                        ), ' Days') AS 'Days Overdue'
                                    FROM borrow b
                                    LEFT JOIN borrow_item bi ON b.BorrowID = bi.BorrowID
                                    LEFT JOIN inventory_item i ON bi.ItemID = i.ItemID
                                    LEFT JOIN `user` u ON b.UserID = u.UserID
                                    WHERE b.Status != 'Returned' 
                                      AND (
                                          b.Status = 'Overdue' 
                                          OR (
                                              CASE 
                                                  WHEN b.DueDate LIKE '%/%' THEN STR_TO_DATE(b.DueDate, '%m/%d/%Y') 
                                                  ELSE DATE(b.DueDate) 
                                              END
                                          ) < CURRENT_DATE()
                                      );";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(overdueQuery, conn))
                    {
                        DataTable dtOverdue = new DataTable();
                        adapter.Fill(dtOverdue);

                        if (Controls.Find("dgvOverdueItems", true).Length > 0 && Controls.Find("dgvOverdueItems", true)[0] is DataGridView dgvItems)
                        {
                            dgvItems.DataSource = dtOverdue;
                        }
                        else if (Controls.Find("dgvOverdue", true).Length > 0 && Controls.Find("dgvOverdue", true)[0] is DataGridView dgv)
                        {
                            dgv.DataSource = dtOverdue;
                        }
                    }

                    string pendingQuery = @"SELECT 
                                                u.FullName AS 'Requester', 
                                                r.StartDate AS 'Start Date',
                                                r.EndDate AS 'End Date'
                                            FROM reservation r
                                            INNER JOIN `user` u ON r.UserID = u.UserID
                                            WHERE r.ApprovalStatus = 'Pending';";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(pendingQuery, conn))
                    {
                        DataTable dtPending = new DataTable();
                        adapter.Fill(dtPending);
                        dgvPending.DataSource = dtPending;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading dashboard UI: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                string rowIdx = (e.RowIndex + 1).ToString();

                using (SolidBrush brush = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString(
                        rowIdx,
                        dgv.Font,
                        brush,
                        e.RowBounds.Location.X + 10,
                        e.RowBounds.Location.Y + 4
                    );
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InventoryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InventoryPairs inventoryForm = new InventoryPairs();
            inventoryForm.Show();
            this.Hide();
        }

        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void InventoryLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void welcome_lbl_Click(object sender, EventArgs e)
        {

        }

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

        private void UpdateDashboardCards()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Total Members
                    string memberQuery = "SELECT COUNT(*) FROM `user`;";
                    using (MySqlCommand cmd = new MySqlCommand(memberQuery, conn))
                    {
                        lblMembersCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    // 2. Approved / Active Reservations
                    string reservedQuery = "SELECT COUNT(*) FROM reservation WHERE ApprovalStatus = 'Approved';";
                    using (MySqlCommand cmd = new MySqlCommand(reservedQuery, conn))
                    {
                        lblReservedCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    // 3. Pending Reservation Requests
                    string pendingQuery = "SELECT COUNT(*) FROM reservation WHERE ApprovalStatus = 'Pending';";
                    using (MySqlCommand cmd = new MySqlCommand(pendingQuery, conn))
                    {
                        lblPendingCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    // 4. Overdue Loans
                    string overdueQuery = @"SELECT COUNT(*) FROM borrow 
                        WHERE Status != 'Returned' 
                        AND (
                            Status = 'Overdue' 
                            OR (
                                CASE 
                                    WHEN DueDate LIKE '%/%' THEN STR_TO_DATE(DueDate, '%m/%d/%Y') 
                                    ELSE DATE(DueDate) 
                                END
                            ) < CURRENT_DATE()
                        );";

                    using (MySqlCommand cmd = new MySqlCommand(overdueQuery, conn))
                    {
                        lblOverdueCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading summary metrics: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOverdue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}