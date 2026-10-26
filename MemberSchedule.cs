using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MemberSchedule : Form
    {
        public MemberSchedule()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. FORM LOAD & INITIALIZATION
        // ==========================================
        private void MemberSchedule_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            // Wire up DataGridView selection event safely using recursive search
            DataGridView grid = GetScheduleGrid();
            if (grid != null)
            {
                grid.SelectionChanged -= dgvSchedule_SelectionChanged;
                grid.SelectionChanged += dgvSchedule_SelectionChanged;
            }

            // Populate Month Filter Dropdown
            ComboBox cmbM = GetControl<ComboBox>("cmbMonth") ?? GetControl<ComboBox>("comboBox1");
            if (cmbM != null)
            {
                cmbM.Items.Clear();
                cmbM.Items.AddRange(new object[] {
                    "All Months", "January", "February", "March", "April",
                    "May", "June", "July", "August", "September",
                    "October", "November", "December"
                });
                cmbM.SelectedIndex = 0;
            }

            // Populate Category / Event Type Filter Dropdown
            ComboBox cmbF = GetControl<ComboBox>("cmbFilter");
            if (cmbF != null)
            {
                cmbF.Items.Clear();
                cmbF.Items.AddRange(new object[] { "All Types", "Special Event", "Play", "Cultural", "Rehearsal", "Concert", "Gig", "Meeting" });
                cmbF.SelectedIndex = 0;
            }

            LoadScheduleData();
        }

        // ==========================================
        // 2. LOAD SCHEDULE & EVENTS FROM MYSQL
        // ==========================================
        private void LoadScheduleData()
        {
            ComboBox cmbM = GetControl<ComboBox>("cmbMonth") ?? GetControl<ComboBox>("comboBox1");
            ComboBox cmbF = GetControl<ComboBox>("cmbFilter");

            string monthFilter = cmbM?.SelectedItem?.ToString() ?? "All Months";
            string typeFilter = cmbF?.SelectedItem?.ToString() ?? "All Types";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Query outputs single 'Date' column containing formatted date range
                    string query = @"SELECT 
                                        p.PerformanceID AS 'Event ID',
                                        p.Title AS 'Title',
                                        COALESCE(p.Category, 'Event') AS 'Event Type',
                                        COALESCE(p.Venue, 'TBA') AS 'Venue',
                                        CONCAT(DATE_FORMAT(p.DateFrom, '%b %d'), ' - ', DATE_FORMAT(p.DateTo, '%b %d, %Y')) AS 'Date',
                                        COALESCE(p.Status, 'Scheduled') AS 'Status'
                                     FROM performance p
                                     WHERE 1=1 ";

                    if (monthFilter != "All Months" && cmbM != null && cmbM.SelectedIndex > 0)
                    {
                        query += " AND MONTH(p.DateFrom) = @Month ";
                    }

                    if (typeFilter != "All Types")
                    {
                        query += " AND p.Category = @Category ";
                    }

                    query += " ORDER BY p.DateFrom ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (monthFilter != "All Months" && cmbM != null && cmbM.SelectedIndex > 0)
                            cmd.Parameters.AddWithValue("@Month", cmbM.SelectedIndex);

                        if (typeFilter != "All Types")
                            cmd.Parameters.AddWithValue("@Category", typeFilter);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DataGridView grid = GetScheduleGrid();
                        if (grid != null)
                        {
                            grid.DataSource = dt;
                            grid.ClearSelection();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading schedule: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ClearDetailsPanel();
        }

        // ==========================================
        // 3. GRID SELECTION -> POPULATE EVENT DETAILS
        // ==========================================
        private void dgvSchedule_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView grid = GetScheduleGrid();
            if (grid == null || grid.SelectedRows.Count == 0) return;

            DataGridViewRow row = grid.SelectedRows[0];

            if (txtEventID != null) txtEventID.Text = row.Cells["Event ID"].Value?.ToString();
            if (txtTitle != null) txtTitle.Text = row.Cells["Title"].Value?.ToString();
            if (txtEventType != null) txtEventType.Text = row.Cells["Event Type"].Value?.ToString();
            if (txtVenue != null) txtVenue.Text = row.Cells["Venue"].Value?.ToString();
            if (txtStatus3 != null) txtStatus3.Text = row.Cells["Status"].Value?.ToString();

            // Populate the formatted date range into the side panel date field
            string dateVal = row.Cells["Date"].Value?.ToString();
            if (txtTime != null) txtTime.Text = dateVal;
            SetControlText("txtDate", dateVal);
        }

        // ==========================================
        // 4. EXPORT BUTTON HANDLER
        // ==========================================
        private void btnExport_Click(object sender, EventArgs e)
        {
            DataGridView grid = GetScheduleGrid();
            if (grid == null || grid.Rows.Count == 0)
            {
                MessageBox.Show("No schedule data available to export.", "Export Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv|Text File (*.txt)|*.txt";
                sfd.FileName = $"PAIRS_Schedule_{DateTime.Now:yyyyMMdd}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < grid.Columns.Count; i++)
                        {
                            sb.Append(grid.Columns[i].HeaderText + (i < grid.Columns.Count - 1 ? "," : ""));
                        }
                        sb.AppendLine();

                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int j = 0; j < grid.Columns.Count; j++)
                                {
                                    string cellVal = row.Cells[j].Value?.ToString().Replace(",", ";") ?? "";
                                    sb.Append(cellVal + (j < grid.Columns.Count - 1 ? "," : ""));
                                }
                                sb.AppendLine();
                            }
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Schedule data exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 5. HELPER METHODS & DYNAMIC CONTROL LOOKUP
        // ==========================================
        private T GetControl<T>(string name) where T : Control
        {
            Control[] found = Controls.Find(name, true);
            return (found.Length > 0 && found[0] is T ctrl) ? ctrl : null;
        }

        private void SetControlText(string name, string text)
        {
            Control ctrl = GetControl<Control>(name);
            if (ctrl != null) ctrl.Text = text ?? string.Empty;
        }

        private void ClearDetailsPanel()
        {
            if (txtEventID != null) txtEventID.Clear();
            if (txtTitle != null) txtTitle.Clear();
            if (txtEventType != null) txtEventType.Clear();
            if (txtVenue != null) txtVenue.Clear();
            if (txtStatus3 != null) txtStatus3.Text = string.Empty;
            if (txtTime != null) txtTime.Clear();

            SetControlText("txtDate", string.Empty);
        }

        private DataGridView GetScheduleGrid()
        {
            return FindControl<DataGridView>(this);
        }

        private T FindControl<T>(Control parent) where T : Control
        {
            foreach (Control c in parent.Controls)
            {
                if (c is T typedControl)
                    return typedControl;

                T child = FindControl<T>(c);
                if (child != null)
                    return child;
            }
            return null;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e) => LoadScheduleData();
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadScheduleData();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => LoadScheduleData();

        // Preserved Exact Designer Event Handler Stubs
        private void dtpDueDate_ValueChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtQuantity_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtStatus3_TextChanged(object sender, EventArgs e) { }
        private void lstSchedule_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtEventID_TextChanged(object sender, EventArgs e) { }
        private void txtEventID_TextChanged_1(object sender, EventArgs e) { }
        private void txtTitle_TextChanged(object sender, EventArgs e) { }
        private void txtEventType_TextChanged(object sender, EventArgs e) { }
        private void txtVenue_TextChanged(object sender, EventArgs e) { }
        private void txtTime_TextChanged(object sender, EventArgs e) { }
        private void txtStatus3_TextChanged_1(object sender, EventArgs e) { }

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
        private void btnBorrowed_Click(object sender, EventArgs e) { new MemberBorrowed().Show(); this.Hide(); }

        private void ScheduleLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnSchedule_Click(sender, e);
        private void btnSchedule_Click(object sender, EventArgs e) { } // Already on MemberSchedule

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