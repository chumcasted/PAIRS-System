namespace WinFormsApp2
{
    partial class Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvReports = new DataGridView();
            label1 = new Label();
            pairLbl = new Label();
            btnClear = new Button();
            btnGenerate = new Button();
            label7 = new Label();
            categoryLbl = new Label();
            idLbl = new Label();
            cmbCategory = new ComboBox();
            textBox3 = new TextBox();
            panel1 = new Panel();
            label4 = new Label();
            cmbStatus = new ComboBox();
            label3 = new Label();
            dtpDateTo = new DateTimePicker();
            label2 = new Label();
            txtUser = new TextBox();
            label5 = new Label();
            dtpDateFrom = new DateTimePicker();
            btnExportPDF = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            btnSettings = new Button();
            btnUsers = new Button();
            btnReports = new Button();
            btnperformances = new Button();
            btnborrowreturn = new Button();
            btreservations = new Button();
            btninventory = new Button();
            btnDashboard = new Button();
            txtLocation = new LinkLabel();
            UserLink = new LinkLabel();
            ReportsLink = new LinkLabel();
            PerformanceLink = new LinkLabel();
            BorrowReturnLink = new LinkLabel();
            ReservationLink = new LinkLabel();
            InventoryLink = new LinkLabel();
            DashboardLink = new LinkLabel();
            logOut_btn = new Button();
            cmbReportType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReports
            // 
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.BackgroundColor = SystemColors.ControlLight;
            dgvReports.BorderStyle = BorderStyle.Fixed3D;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(737, 106);
            dgvReports.MultiSelect = false;
            dgvReports.Name = "dgvReports";
            dgvReports.ReadOnly = true;
            dgvReports.RowHeadersWidth = 51;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.Size = new Size(433, 506);
            dgvReports.TabIndex = 44;
            dgvReports.CellContentClick += dgvReports_CellContentClick_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(147, 7);
            label1.Name = "label1";
            label1.Size = new Size(163, 54);
            label1.TabIndex = 2;
            label1.Text = "Reports";
            // 
            // pairLbl
            // 
            pairLbl.AutoSize = true;
            pairLbl.Font = new Font("Bebas Neue", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pairLbl.ForeColor = Color.WhiteSmoke;
            pairLbl.Location = new Point(10, 0);
            pairLbl.Name = "pairLbl";
            pairLbl.Size = new Size(140, 78);
            pairLbl.TabIndex = 1;
            pairLbl.Text = "PAIRS";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Firebrick;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(581, 545);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(143, 58);
            btnClear.TabIndex = 42;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.ForestGreen;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerate.ForeColor = Color.WhiteSmoke;
            btnGenerate.Location = new Point(278, 545);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(143, 60);
            btnGenerate.TabIndex = 38;
            btnGenerate.Text = " Generate Report";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += AddButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(279, 375);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 37;
            label7.Text = "Location";
            label7.Click += label7_Click;
            // 
            // categoryLbl
            // 
            categoryLbl.AutoSize = true;
            categoryLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            categoryLbl.Location = new Point(516, 114);
            categoryLbl.Name = "categoryLbl";
            categoryLbl.Size = new Size(73, 20);
            categoryLbl.TabIndex = 36;
            categoryLbl.Text = "Category";
            // 
            // idLbl
            // 
            idLbl.AutoSize = true;
            idLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            idLbl.Location = new Point(278, 116);
            idLbl.Name = "idLbl";
            idLbl.Size = new Size(94, 20);
            idLbl.TabIndex = 32;
            idLbl.Text = "Report Type";
            // 
            // cmbCategory
            // 
            cmbCategory.Font = new Font("Segoe UI", 10.2F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Instrument", "Costume", "Prop", "Equipment", "Sound System", "Lighting", "Accessory" });
            cmbCategory.Location = new Point(514, 145);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(192, 31);
            cmbCategory.TabIndex = 30;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 10.2F);
            textBox3.Location = new Point(279, 407);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(187, 30);
            textBox3.TabIndex = 28;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Maroon;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pairLbl);
            panel1.Location = new Point(2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1178, 78);
            panel1.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(276, 201);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 142;
            label4.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All Statuses", "Borrowed", "Returned", "Overdue", "Pending", "Approved", "Scheduled", "Ongoing", "Completed", "Cancelled" });
            cmbStatus.Location = new Point(274, 231);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(192, 33);
            cmbStatus.TabIndex = 141;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(514, 292);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 144;
            label3.Text = "Date To";
            // 
            // dtpDateTo
            // 
            dtpDateTo.Font = new Font("Segoe UI", 10.2F);
            dtpDateTo.Format = DateTimePickerFormat.Short;
            dtpDateTo.Location = new Point(514, 324);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.Size = new Size(192, 30);
            dtpDateTo.TabIndex = 143;
            dtpDateTo.ValueChanged += dtpDateTo_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(518, 201);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 146;
            label2.Text = "Name";
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUser.Location = new Point(514, 232);
            txtUser.Name = "txtUser";
            txtUser.ReadOnly = true;
            txtUser.Size = new Size(192, 30);
            txtUser.TabIndex = 145;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(278, 292);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 148;
            label5.Text = "Date From";
            label5.Click += label5_Click;
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.Font = new Font("Segoe UI", 10.2F);
            dtpDateFrom.Format = DateTimePickerFormat.Short;
            dtpDateFrom.Location = new Point(278, 324);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.Size = new Size(188, 30);
            dtpDateFrom.TabIndex = 147;
            dtpDateFrom.ValueChanged += dtpDateFrom_ValueChanged;
            // 
            // btnExportPDF
            // 
            btnExportPDF.BackColor = Color.Goldenrod;
            btnExportPDF.FlatAppearance.BorderSize = 0;
            btnExportPDF.FlatStyle = FlatStyle.Flat;
            btnExportPDF.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportPDF.ForeColor = Color.White;
            btnExportPDF.Location = new Point(432, 545);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(143, 60);
            btnExportPDF.TabIndex = 151;
            btnExportPDF.Text = "Export(PDF)";
            btnExportPDF.UseVisualStyleBackColor = false;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(2, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 570);
            panel2.TabIndex = 152;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Maroon;
            panel3.Controls.Add(btnSettings);
            panel3.Controls.Add(btnUsers);
            panel3.Controls.Add(btnReports);
            panel3.Controls.Add(btnperformances);
            panel3.Controls.Add(btnborrowreturn);
            panel3.Controls.Add(btreservations);
            panel3.Controls.Add(btninventory);
            panel3.Controls.Add(btnDashboard);
            panel3.Controls.Add(txtLocation);
            panel3.Controls.Add(UserLink);
            panel3.Controls.Add(ReportsLink);
            panel3.Controls.Add(PerformanceLink);
            panel3.Controls.Add(BorrowReturnLink);
            panel3.Controls.Add(ReservationLink);
            panel3.Controls.Add(InventoryLink);
            panel3.Controls.Add(DashboardLink);
            panel3.ForeColor = Color.Transparent;
            panel3.Location = new Point(23, 16);
            panel3.Name = "panel3";
            panel3.Size = new Size(198, 544);
            panel3.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Maroon;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Image = Properties.Resources.settings;
            btnSettings.Location = new Point(3, 480);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(51, 52);
            btnSettings.TabIndex = 23;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.Maroon;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Image = Properties.Resources.users;
            btnUsers.Location = new Point(12, 426);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(42, 39);
            btnUsers.TabIndex = 22;
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.Maroon;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Image = Properties.Resources.reports;
            btnReports.Location = new Point(12, 342);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(42, 52);
            btnReports.TabIndex = 21;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnperformances
            // 
            btnperformances.BackColor = Color.Maroon;
            btnperformances.FlatAppearance.BorderSize = 0;
            btnperformances.FlatStyle = FlatStyle.Flat;
            btnperformances.Image = Properties.Resources.performances;
            btnperformances.Location = new Point(12, 278);
            btnperformances.Name = "btnperformances";
            btnperformances.Size = new Size(42, 42);
            btnperformances.TabIndex = 20;
            btnperformances.UseVisualStyleBackColor = false;
            btnperformances.Click += btnperformances_Click;
            // 
            // btnborrowreturn
            // 
            btnborrowreturn.BackColor = Color.Maroon;
            btnborrowreturn.FlatAppearance.BorderSize = 0;
            btnborrowreturn.FlatStyle = FlatStyle.Flat;
            btnborrowreturn.Image = Properties.Resources.borrow_return;
            btnborrowreturn.Location = new Point(12, 215);
            btnborrowreturn.Name = "btnborrowreturn";
            btnborrowreturn.Size = new Size(42, 42);
            btnborrowreturn.TabIndex = 19;
            btnborrowreturn.UseVisualStyleBackColor = false;
            btnborrowreturn.Click += btnborrowreturn_Click;
            // 
            // btreservations
            // 
            btreservations.BackColor = Color.Maroon;
            btreservations.FlatAppearance.BorderSize = 0;
            btreservations.FlatStyle = FlatStyle.Flat;
            btreservations.Image = Properties.Resources.reservations;
            btreservations.Location = new Point(12, 144);
            btreservations.Name = "btreservations";
            btreservations.Size = new Size(42, 45);
            btreservations.TabIndex = 18;
            btreservations.UseVisualStyleBackColor = false;
            btreservations.Click += btreservations_Click;
            // 
            // btninventory
            // 
            btninventory.BackColor = Color.Maroon;
            btninventory.FlatAppearance.BorderSize = 0;
            btninventory.FlatStyle = FlatStyle.Flat;
            btninventory.ForeColor = Color.Transparent;
            btninventory.Image = Properties.Resources.inventory;
            btninventory.Location = new Point(12, 82);
            btninventory.Name = "btninventory";
            btninventory.Size = new Size(42, 41);
            btninventory.TabIndex = 17;
            btninventory.UseVisualStyleBackColor = false;
            btninventory.Click += btninventory_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Maroon;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.Image = Properties.Resources.dashboard;
            btnDashboard.Location = new Point(12, 13);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(42, 43);
            btnDashboard.TabIndex = 16;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // txtLocation
            // 
            txtLocation.AutoSize = true;
            txtLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtLocation.LinkBehavior = LinkBehavior.NeverUnderline;
            txtLocation.LinkColor = Color.White;
            txtLocation.Location = new Point(60, 491);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(66, 20);
            txtLocation.TabIndex = 15;
            txtLocation.TabStop = true;
            txtLocation.Text = "Settings";
            txtLocation.LinkClicked += SettingLink_LinkClicked;
            // 
            // UserLink
            // 
            UserLink.AutoSize = true;
            UserLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            UserLink.LinkBehavior = LinkBehavior.NeverUnderline;
            UserLink.LinkColor = Color.White;
            UserLink.Location = new Point(60, 435);
            UserLink.Name = "UserLink";
            UserLink.Size = new Size(48, 20);
            UserLink.TabIndex = 14;
            UserLink.TabStop = true;
            UserLink.Text = "Users";
            UserLink.LinkClicked += UserLink_LinkClicked;
            // 
            // ReportsLink
            // 
            ReportsLink.AutoSize = true;
            ReportsLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ReportsLink.LinkBehavior = LinkBehavior.NeverUnderline;
            ReportsLink.LinkColor = Color.White;
            ReportsLink.Location = new Point(60, 360);
            ReportsLink.Name = "ReportsLink";
            ReportsLink.Size = new Size(64, 20);
            ReportsLink.TabIndex = 13;
            ReportsLink.TabStop = true;
            ReportsLink.Text = "Reports";
            ReportsLink.LinkClicked += ReportsLink_LinkClicked;
            // 
            // PerformanceLink
            // 
            PerformanceLink.AutoSize = true;
            PerformanceLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PerformanceLink.LinkBehavior = LinkBehavior.NeverUnderline;
            PerformanceLink.LinkColor = Color.White;
            PerformanceLink.Location = new Point(60, 289);
            PerformanceLink.Name = "PerformanceLink";
            PerformanceLink.Size = new Size(106, 20);
            PerformanceLink.TabIndex = 12;
            PerformanceLink.TabStop = true;
            PerformanceLink.Text = "Performances";
            PerformanceLink.LinkClicked += PerformanceLink_LinkClicked;
            // 
            // BorrowReturnLink
            // 
            BorrowReturnLink.AutoSize = true;
            BorrowReturnLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BorrowReturnLink.LinkBehavior = LinkBehavior.NeverUnderline;
            BorrowReturnLink.LinkColor = Color.White;
            BorrowReturnLink.Location = new Point(60, 225);
            BorrowReturnLink.Name = "BorrowReturnLink";
            BorrowReturnLink.Size = new Size(124, 20);
            BorrowReturnLink.TabIndex = 11;
            BorrowReturnLink.TabStop = true;
            BorrowReturnLink.Text = "Borrow / Return";
            BorrowReturnLink.LinkClicked += BorrowReturnLink_LinkClicked;
            // 
            // ReservationLink
            // 
            ReservationLink.AutoSize = true;
            ReservationLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ReservationLink.LinkBehavior = LinkBehavior.NeverUnderline;
            ReservationLink.LinkColor = Color.White;
            ReservationLink.Location = new Point(60, 156);
            ReservationLink.Name = "ReservationLink";
            ReservationLink.Size = new Size(100, 20);
            ReservationLink.TabIndex = 10;
            ReservationLink.TabStop = true;
            ReservationLink.Text = "Reservations";
            ReservationLink.LinkClicked += ReservationLink_LinkClicked;
            // 
            // InventoryLink
            // 
            InventoryLink.AutoSize = true;
            InventoryLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            InventoryLink.LinkBehavior = LinkBehavior.NeverUnderline;
            InventoryLink.LinkColor = Color.White;
            InventoryLink.Location = new Point(60, 92);
            InventoryLink.Name = "InventoryLink";
            InventoryLink.Size = new Size(78, 20);
            InventoryLink.TabIndex = 9;
            InventoryLink.TabStop = true;
            InventoryLink.Text = "Inventory";
            InventoryLink.LinkClicked += InventoryLink_LinkClicked;
            // 
            // DashboardLink
            // 
            DashboardLink.AutoSize = true;
            DashboardLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DashboardLink.LinkBehavior = LinkBehavior.NeverUnderline;
            DashboardLink.LinkColor = Color.White;
            DashboardLink.Location = new Point(60, 22);
            DashboardLink.Name = "DashboardLink";
            DashboardLink.Size = new Size(85, 20);
            DashboardLink.TabIndex = 8;
            DashboardLink.TabStop = true;
            DashboardLink.Text = "Dashboard";
            DashboardLink.LinkClicked += DashboardLink_LinkClicked;
            // 
            // logOut_btn
            // 
            logOut_btn.BackColor = Color.Maroon;
            logOut_btn.BackgroundImage = Properties.Resources.logout_041;
            logOut_btn.BackgroundImageLayout = ImageLayout.Zoom;
            logOut_btn.FlatAppearance.BorderSize = 0;
            logOut_btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            logOut_btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            logOut_btn.FlatStyle = FlatStyle.Flat;
            logOut_btn.ForeColor = SystemColors.ButtonFace;
            logOut_btn.Location = new Point(1107, 16);
            logOut_btn.Name = "logOut_btn";
            logOut_btn.Size = new Size(47, 45);
            logOut_btn.TabIndex = 153;
            logOut_btn.UseVisualStyleBackColor = false;
            logOut_btn.Click += logOut_btn_Click;
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Borrowing History", "Reservations Summary", "Inventory Stock Status", "Performance Event Logs", "Equipment Reviews & Ratings" });
            cmbReportType.Location = new Point(274, 148);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(192, 28);
            cmbReportType.TabIndex = 154;
            cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1182, 653);
            Controls.Add(cmbReportType);
            Controls.Add(logOut_btn);
            Controls.Add(panel2);
            Controls.Add(btnExportPDF);
            Controls.Add(label5);
            Controls.Add(dtpDateFrom);
            Controls.Add(label2);
            Controls.Add(txtUser);
            Controls.Add(label3);
            Controls.Add(dtpDateTo);
            Controls.Add(label4);
            Controls.Add(cmbStatus);
            Controls.Add(dgvReports);
            Controls.Add(btnClear);
            Controls.Add(btnGenerate);
            Controls.Add(label7);
            Controls.Add(categoryLbl);
            Controls.Add(idLbl);
            Controls.Add(cmbCategory);
            Controls.Add(textBox3);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Name = "Reports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            Load += Reports_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvReports;
        private Label label1;
        private Label pairLbl;
        private Button btnClear;
        private Button btnGenerate;
        private Label label7;
        private Label categoryLbl;
        private Label idLbl;
        private ComboBox cmbCategory;
        private TextBox textBox3;
        private Panel panel1;
        private Label label4;
        private ComboBox cmbStatus;
        private Label label3;
        private DateTimePicker dtpDateTo;
        private Label label2;
        private TextBox txtUser;
        private Label label5;
        private DateTimePicker dtpDateFrom;
        private Button btnExportPDF;
        private Panel panel2;
        private Panel panel3;
        private Button btnSettings;
        private Button btnUsers;
        private Button btnReports;
        private Button btnperformances;
        private Button btnborrowreturn;
        private Button btreservations;
        private Button btninventory;
        private Button btnDashboard;
        private LinkLabel txtLocation;
        private LinkLabel UserLink;
        private LinkLabel ReportsLink;
        private LinkLabel PerformanceLink;
        private LinkLabel BorrowReturnLink;
        private LinkLabel ReservationLink;
        private LinkLabel InventoryLink;
        private LinkLabel DashboardLink;
        private Button logOut_btn;
        private ComboBox cmbReportType;
    }
}