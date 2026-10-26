using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();

            if (dgvReports != null)
            {
                dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvReports.CellClick += dgvReports_CellContentClick_1;
            }
        }


        private void Reports_Load(object sender, EventArgs e)
        {
            if (cmbReportType.Items.Count == 0)
            {
                cmbReportType.Items.AddRange(new object[] {
            "Borrowing History",
            "Reservations Summary",
            "Inventory Stock Status",
            "Performance Event Logs",
            "Equipment Reviews & Ratings"
        });
            }
            if (cmbReportType.Items.Count > 0) cmbReportType.SelectedIndex = 0;

            UpdateDropdownsByReportType();

            dtpDateFrom.Value = DateTime.Now.AddMonths(-1);
            dtpDateTo.Value = DateTime.Now;

            GenerateSelectedReport();
        }

        // ==========================================
        // DYNAMIC MYSQL REPORT GENERATOR
        // ==========================================
        private void GenerateSelectedReport()
        {
            string selectedReport = cmbReportType.SelectedItem?.ToString().Trim() ?? "";
            string selectedCategory = cmbCategory.SelectedItem?.ToString().Trim();
            string selectedStatus = cmbStatus.SelectedItem?.ToString().Trim();

            string userFilter = txtUser != null ? txtUser.Text.Trim() : "";

            string locationFilter = "";
            Control[] locControls = Controls.Find("txtLocation", true);
            if (locControls.Length > 0 && locControls[0] is TextBox tbLoc)
            {
                locationFilter = tbLoc.Text.Trim();
            }
            else if (textBox3 != null)
            {
                locationFilter = textBox3.Text.Trim();
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    switch (selectedReport)
                    {
                        case "Borrowing History":
                            query = @"SELECT b.BorrowID AS 'Borrow ID', 
                                     u.FullName AS 'User Name', 
                                     i.ItemName AS 'Item', 
                                     bi.QuantityBorrowed AS 'Qty', 
                                     b.BorrowDate AS 'Borrow Date', 
                                     b.DueDate AS 'Due Date', 
                                     b.ReturnDate AS 'Return Date', 
                                     b.Status 
                              FROM borrow b 
                              INNER JOIN user u ON b.UserID = u.UserID
                              INNER JOIN borrow_item bi ON b.BorrowID = bi.BorrowID 
                              INNER JOIN inventory_item i ON bi.ItemID = i.ItemID 
                              WHERE (
                                  CASE WHEN b.BorrowDate LIKE '%/%' 
                                       THEN STR_TO_DATE(b.BorrowDate, '%m/%d/%Y') 
                                       ELSE DATE(b.BorrowDate) 
                                  END
                              ) BETWEEN @DateFrom AND @DateTo";

                            if (!string.IsNullOrWhiteSpace(selectedStatus) && selectedStatus != "All Statuses")
                            {
                                query += " AND b.Status = @Status";
                                cmd.Parameters.AddWithValue("@Status", selectedStatus);
                            }
                            if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All Categories")
                            {
                                query += " AND i.Category = @Category";
                                cmd.Parameters.AddWithValue("@Category", selectedCategory);
                            }
                            if (!string.IsNullOrWhiteSpace(userFilter))
                            {
                                query += " AND (u.FullName LIKE @User OR b.UserID LIKE @User OR i.ItemName LIKE @User)";
                                cmd.Parameters.AddWithValue("@User", $"%{userFilter}%");
                            }
                            break;

                        case "Reservations Summary":
                            query = @"SELECT r.BookingID AS 'Booking ID', 
                                     u.FullName AS 'User Name', 
                                     i.ItemName AS 'Item Name', 
                                     ri.QuantityReserved AS 'Qty', 
                                     r.StartDate AS 'Start Date', 
                                     r.EndDate AS 'End Date', 
                                     r.ApprovalStatus AS 'Status' 
                              FROM RESERVATION r 
                              INNER JOIN user u ON r.UserID = u.UserID
                              INNER JOIN reservation_item ri ON r.BookingID = ri.BookingID
                              INNER JOIN inventory_item i ON ri.ItemID = i.ItemID
                              WHERE (
                                  CASE WHEN r.StartDate LIKE '%/%' 
                                       THEN STR_TO_DATE(r.StartDate, '%m/%d/%Y') 
                                       ELSE DATE(r.StartDate) 
                                  END
                              ) BETWEEN @DateFrom AND @DateTo";

                            if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All Categories")
                            {
                                query += " AND i.Category = @Category";
                                cmd.Parameters.AddWithValue("@Category", selectedCategory);
                            }
                            if (!string.IsNullOrWhiteSpace(selectedStatus) && selectedStatus != "All Statuses")
                            {
                                query += " AND r.ApprovalStatus = @Status";
                                cmd.Parameters.AddWithValue("@Status", selectedStatus);
                            }
                            if (!string.IsNullOrWhiteSpace(userFilter))
                            {
                                query += " AND (u.FullName LIKE @User OR i.ItemName LIKE @User OR r.BookingID LIKE @User)";
                                cmd.Parameters.AddWithValue("@User", $"%{userFilter}%");
                            }
                            break;

                        case "Inventory Stock Status":
                            query = @"SELECT ItemID AS 'Item ID', 
                                     ItemName AS 'Item Name', 
                                     Category, 
                                     Quantity, 
                                     Status 
                              FROM inventory_item 
                              WHERE 1=1";

                            if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All Categories")
                            {
                                query += " AND Category = @Category";
                                cmd.Parameters.AddWithValue("@Category", selectedCategory);
                            }
                            if (!string.IsNullOrWhiteSpace(selectedStatus) && selectedStatus != "All Statuses")
                            {
                                query += " AND Status = @Status";
                                cmd.Parameters.AddWithValue("@Status", selectedStatus);
                            }
                            if (!string.IsNullOrWhiteSpace(userFilter))
                            {
                                query += " AND (ItemName LIKE @User OR ItemID LIKE @User)";
                                cmd.Parameters.AddWithValue("@User", $"%{userFilter}%");
                            }
                            break;

                        case "Performance Event Logs":
                            query = @"SELECT PerformanceID AS 'Performance ID', 
                                     Title, 
                                     Category, 
                                     Venue AS 'Location', 
                                     DateFrom AS 'Date From', 
                                     DateTo AS 'Date To', 
                                     Status 
                              FROM performance 
                              WHERE (
                                  (CASE WHEN DateFrom LIKE '%/%' THEN STR_TO_DATE(DateFrom, '%m/%d/%Y') ELSE DATE(DateFrom) END) <= @DateTo
                                  AND 
                                  (CASE WHEN DateTo LIKE '%/%' THEN STR_TO_DATE(DateTo, '%m/%d/%Y') ELSE DATE(DateTo) END) >= @DateFrom
                              )";

                            if (!string.IsNullOrWhiteSpace(selectedStatus) && selectedStatus != "All Statuses")
                            {
                                query += " AND Status = @Status";
                                cmd.Parameters.AddWithValue("@Status", selectedStatus);
                            }
                            if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All Categories")
                            {
                                query += " AND Category = @Category";
                                cmd.Parameters.AddWithValue("@Category", selectedCategory);
                            }
                            if (!string.IsNullOrWhiteSpace(locationFilter))
                            {
                                query += " AND Venue LIKE @Location";
                                cmd.Parameters.AddWithValue("@Location", $"%{locationFilter}%");
                            }
                            if (!string.IsNullOrWhiteSpace(userFilter))
                            {
                                query += " AND Title LIKE @User";
                                cmd.Parameters.AddWithValue("@User", $"%{userFilter}%");
                            }
                            break;

                        case "Equipment Reviews & Ratings":
                            query = @"SELECT r.ReviewID AS 'Review ID', 
                                     u.FullName AS 'User Name', 
                                     i.ItemName AS 'Item Name', 
                                     r.Rating AS 'Rating (1-5)', 
                                     rt.Tag AS 'Feedback Tag', 
                                     r.Comments, 
                                     r.DateSubmitted AS 'Date' 
                              FROM review r 
                              INNER JOIN user u ON r.UserID = u.UserID
                              INNER JOIN inventory_item i ON r.ItemID = i.ItemID 
                              LEFT JOIN review_tag rt ON r.ReviewID = rt.ReviewID 
                              WHERE (
                                  CASE WHEN r.DateSubmitted LIKE '%/%' 
                                       THEN STR_TO_DATE(r.DateSubmitted, '%m/%d/%Y') 
                                       ELSE DATE(r.DateSubmitted) 
                                  END
                              ) BETWEEN @DateFrom AND @DateTo";

                            if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All Categories")
                            {
                                query += " AND i.Category = @Category";
                                cmd.Parameters.AddWithValue("@Category", selectedCategory);
                            }
                            if (!string.IsNullOrWhiteSpace(userFilter))
                            {
                                query += " AND (u.FullName LIKE @User OR r.UserID LIKE @User OR i.ItemName LIKE @User)";
                                cmd.Parameters.AddWithValue("@User", $"%{userFilter}%");
                            }
                            break;
                    }

                    // Guard check: prevents executing command if no query was matched
                    if (string.IsNullOrWhiteSpace(query))
                    {
                        MessageBox.Show("Please select a valid Report Type.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cmd.CommandText = query;

                    // Safely bind date parameters only if used in the query
                    if (query.Contains("@DateFrom"))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dtpDateFrom.Value.ToString("yyyy-MM-dd"));
                    }
                    if (query.Contains("@DateTo"))
                    {
                        cmd.Parameters.AddWithValue("@DateTo", dtpDateTo.Value.ToString("yyyy-MM-dd"));
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dgvReports != null)
                    {
                        dgvReports.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating report: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // ACTION BUTTON HANDLERS
        // ==========================================
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Triggers "Generate Report" query execution
            GenerateSelectedReport();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvReports == null || dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("No report data available to export.", "Export Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string reportName = cmbReportType.SelectedItem?.ToString().Replace(" ", "_") ?? "Report";
                sfd.Filter = "PDF File (*.pdf)|*.pdf";
                sfd.FileName = $"{reportName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Create PDF Document in Landscape orientation for wide table data
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20f, 20f, 20f, 20f);

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            // Header Title (Using explicit iTextSharp.text.Font namespace)
                            iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font subFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC);
                            iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);

                            Paragraph title = new Paragraph($"PAIRS - {cmbReportType.SelectedItem}", titleFont);
                            Paragraph subtitle = new Paragraph($"Generated Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n", subFont);

                            pdfDoc.Add(title);
                            pdfDoc.Add(subtitle);

                            // Build Data Table
                            PdfPTable pdfTable = new PdfPTable(dgvReports.Columns.Count);
                            pdfTable.WidthPercentage = 100;

                            // Add DataGridView Column Headers to PDF Table
                            foreach (DataGridViewColumn column in dgvReports.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                                pdfTable.AddCell(cell);
                            }

                            // Add DataGridView Rows to PDF Table
                            foreach (DataGridViewRow row in dgvReports.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        string cellValue = cell.Value != null ? cell.Value.ToString() : "";
                                        pdfTable.AddCell(new Phrase(cellValue, FontFactory.GetFont("Arial", 9)));
                                    }
                                }
                            }

                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show($"Report exported successfully!\nSaved to: {sfd.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting PDF: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtUser != null) txtUser.Clear();
            if (textBox3 != null) textBox3.Clear();

            if (cmbReportType.Items.Count > 0) cmbReportType.SelectedIndex = 0;
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;

            dtpDateFrom.Value = DateTime.Now.AddMonths(-1);
            dtpDateTo.Value = DateTime.Now;

            GenerateSelectedReport();
        }

        // ==========================================
        // FILTER & DATE VALIDATION EVENTS
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

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateDropdownsByReportType();
            GenerateSelectedReport();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtUser_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void updateButton_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }

        // ==========================================
        // SIDE PANEL NAVIGATION HANDLERS
        // ==========================================
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

        private void dgvReports_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReports != null)
            {
                DataGridViewRow row = dgvReports.Rows[e.RowIndex];

                // Safely locate Location textbox control
                TextBox locTextBox = null;
                Control[] locControls = Controls.Find("txtLocation", true);
                if (locControls.Length > 0 && locControls[0] is TextBox tbLoc)
                {
                    locTextBox = tbLoc;
                }
                else if (textBox3 != null)
                {
                    locTextBox = textBox3;
                }

                // 1. SPECIFIC CELL CLICK: Populate input based on the clicked column type
                if (e.ColumnIndex >= 0 && row.Cells[e.ColumnIndex].Value != null)
                {
                    string colHeader = dgvReports.Columns[e.ColumnIndex].HeaderText;
                    string colName = dgvReports.Columns[e.ColumnIndex].Name;
                    string cellValue = row.Cells[e.ColumnIndex].Value.ToString();

                    // Populate Location textbox if Location column cell is clicked
                    if ((colHeader.Equals("Location", StringComparison.OrdinalIgnoreCase) ||
                         colName.Equals("Location", StringComparison.OrdinalIgnoreCase)) && locTextBox != null)
                    {
                        locTextBox.Text = cellValue;
                        return;
                    }

                    // Populate User search textbox if Borrower, Item, or Event Title cell is clicked
                    if (colHeader.Contains("User") || colHeader.Contains("Borrower") || colHeader.Contains("Requester") ||
                        colHeader.Contains("Item") || colHeader.Contains("Title") ||
                        colName.Contains("User") || colName.Contains("Borrower") || colName.Contains("Item") || colName.Contains("Title"))
                    {
                        if (txtUser != null)
                        {
                            txtUser.Text = cellValue;
                        }
                        return;
                    }
                }

                // 2. FALLBACK: Auto-populate from row cells if clicked anywhere else
                if (txtUser != null)
                {
                    if (dgvReports.Columns.Contains("User Name") && row.Cells["User Name"].Value != null)
                        txtUser.Text = row.Cells["User Name"].Value.ToString();
                    else if (dgvReports.Columns.Contains("Borrower") && row.Cells["Borrower"].Value != null)
                        txtUser.Text = row.Cells["Borrower"].Value.ToString();
                    else if (dgvReports.Columns.Contains("Requester") && row.Cells["Requester"].Value != null)
                        txtUser.Text = row.Cells["Requester"].Value.ToString();
                    else if (dgvReports.Columns.Contains("Item Name") && row.Cells["Item Name"].Value != null)
                        txtUser.Text = row.Cells["Item Name"].Value.ToString();
                    else if (dgvReports.Columns.Contains("Item") && row.Cells["Item"].Value != null)
                        txtUser.Text = row.Cells["Item"].Value.ToString();
                    else if (dgvReports.Columns.Contains("Title") && row.Cells["Title"].Value != null)
                        txtUser.Text = row.Cells["Title"].Value.ToString();
                }

                if (locTextBox != null && dgvReports.Columns.Contains("Location") && row.Cells["Location"].Value != null)
                {
                    locTextBox.Text = row.Cells["Location"].Value.ToString();
                }
            }
        }

        // Redirect CellClick to CellContentClick_1 to ensure clicks anywhere inside the cell work reliably
        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReports_CellContentClick_1(sender, e);
        }

        private void UpdateDropdownsByReportType()
        {
            string selectedReport = cmbReportType.SelectedItem?.ToString() ?? "";

            cmbStatus.Items.Clear();
            cmbCategory.Items.Clear();

            switch (selectedReport)
            {
                case "Borrowing History":
                    cmbStatus.Items.AddRange(new object[] { "All Statuses", "Borrowed", "Returned", "Overdue" });
                    cmbCategory.Items.AddRange(new object[] { "All Categories", "Audio", "Lighting", "Musical Instruments", "Costumes & Apparel", "Props", "Stage Equipment", "General" });
                    break;

                case "Reservations Summary":
                    cmbStatus.Items.AddRange(new object[] { "All Statuses", "Approved", "Pending", "Rejected" });
                    cmbCategory.Items.AddRange(new object[] { "All Categories", "Audio", "Lighting", "Musical Instruments", "Costumes & Apparel", "Props", "Stage Equipment", "General" });
                    break;

                case "Inventory Stock Status":
                    cmbStatus.Items.AddRange(new object[] { "All Statuses", "Available", "Borrowed", "Under Maintenance", "Damaged" });
                    cmbCategory.Items.AddRange(new object[] { "All Categories", "Audio", "Lighting", "Musical Instruments", "Costumes & Apparel", "Props", "Stage Equipment", "General" });
                    break;

                case "Performance Event Logs":
                    cmbStatus.Items.AddRange(new object[] { "All Statuses", "Scheduled", "Ongoing", "Completed", "Cancelled" });
                    cmbCategory.Items.AddRange(new object[] { "All Categories", "Play", "Theater", "Dance", "Cultural", "Pageant", "Competition", "Olympics", "Rehearsal", "Special Event" });
                    break;

                case "Equipment Reviews & Ratings":
                    cmbStatus.Items.AddRange(new object[] { "All Statuses" });
                    cmbCategory.Items.AddRange(new object[] { "All Categories", "Audio", "Lighting", "Musical Instruments", "Costumes & Apparel", "Props", "Stage Equipment", "General" });
                    break;

                default:
                    cmbStatus.Items.AddRange(new object[] { "All Statuses" });
                    cmbCategory.Items.AddRange(new object[] { "All Categories" });
                    break;
            }

            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }


    }
}