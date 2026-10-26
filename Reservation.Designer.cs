namespace WinFormsApp2
{
    partial class Reservation
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
            label1 = new Label();
            pairLbl = new Label();
            panel1 = new Panel();
            logOut_btn = new Button();
            itemNameLbl = new Label();
            idLbl = new Label();
            txtBookingID = new TextBox();
            dgvReservations = new DataGridView();
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
            SettingLink = new LinkLabel();
            UserLink = new LinkLabel();
            ReportsLink = new LinkLabel();
            PerformanceLink = new LinkLabel();
            BorrowReturnLink = new LinkLabel();
            ReservationLink = new LinkLabel();
            InventoryLink = new LinkLabel();
            DashboardLink = new LinkLabel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnClear = new Button();
            grpTimeline = new GroupBox();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label5 = new Label();
            label3 = new Label();
            dtpStartDate = new DateTimePicker();
            label4 = new Label();
            label2 = new Label();
            label6 = new Label();
            cmbApprovalStatus = new ComboBox();
            label7 = new Label();
            cmbItem = new ComboBox();
            label8 = new Label();
            numQuantity = new NumericUpDown();
            cmbUser = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            grpTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(147, 7);
            label1.Name = "label1";
            label1.Size = new Size(251, 54);
            label1.TabIndex = 2;
            label1.Text = "Reservations";
            label1.Click += label1_Click;
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
            // panel1
            // 
            panel1.BackColor = Color.Maroon;
            panel1.Controls.Add(logOut_btn);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pairLbl);
            panel1.Location = new Point(2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1178, 78);
            panel1.TabIndex = 25;
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
            logOut_btn.Location = new Point(1105, 16);
            logOut_btn.Name = "logOut_btn";
            logOut_btn.Size = new Size(47, 45);
            logOut_btn.TabIndex = 52;
            logOut_btn.UseVisualStyleBackColor = false;
            logOut_btn.Click += logOut_btn_Click;
            // 
            // itemNameLbl
            // 
            itemNameLbl.AutoSize = true;
            itemNameLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            itemNameLbl.Location = new Point(515, 99);
            itemNameLbl.Name = "itemNameLbl";
            itemNameLbl.Size = new Size(87, 20);
            itemNameLbl.TabIndex = 67;
            itemNameLbl.Text = "User Name";
            itemNameLbl.Click += itemNameLbl_Click;
            // 
            // idLbl
            // 
            idLbl.AutoSize = true;
            idLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            idLbl.Location = new Point(276, 99);
            idLbl.Name = "idLbl";
            idLbl.Size = new Size(87, 20);
            idLbl.TabIndex = 66;
            idLbl.Text = "Booking ID";
            // 
            // txtBookingID
            // 
            txtBookingID.Location = new Point(276, 129);
            txtBookingID.Name = "txtBookingID";
            txtBookingID.Size = new Size(192, 27);
            txtBookingID.TabIndex = 61;
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.BackgroundColor = Color.SteelBlue;
            dgvReservations.BorderStyle = BorderStyle.Fixed3D;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Location = new Point(735, 144);
            dgvReservations.MultiSelect = false;
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(445, 449);
            dgvReservations.TabIndex = 76;
            dgvReservations.CellContentClick += dgvReservations_CellContentClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(2, 84);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 570);
            panel2.TabIndex = 123;
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
            panel3.Controls.Add(SettingLink);
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
            // SettingLink
            // 
            SettingLink.AutoSize = true;
            SettingLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SettingLink.LinkBehavior = LinkBehavior.NeverUnderline;
            SettingLink.LinkColor = Color.White;
            SettingLink.Location = new Point(60, 491);
            SettingLink.Name = "SettingLink";
            SettingLink.Size = new Size(66, 20);
            SettingLink.TabIndex = 15;
            SettingLink.TabStop = true;
            SettingLink.Text = "Settings";
            SettingLink.LinkClicked += SettingLink_LinkClicked;
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
            // btnDelete
            // 
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.WhiteSmoke;
            btnDelete.Location = new Point(589, 542);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 51);
            btnDelete.TabIndex = 126;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Goldenrod;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.WhiteSmoke;
            btnUpdate.Location = new Point(434, 542);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 51);
            btnUpdate.TabIndex = 125;
            btnUpdate.Text = "Update ";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.WhiteSmoke;
            btnAdd.Location = new Point(276, 542);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 51);
            btnAdd.TabIndex = 124;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SteelBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.WhiteSmoke;
            btnSearch.Location = new Point(1063, 99);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 39);
            btnSearch.TabIndex = 128;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(735, 102);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search item";
            txtSearch.Size = new Size(288, 31);
            txtSearch.TabIndex = 127;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gainsboro;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(735, 604);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(200, 40);
            btnClear.TabIndex = 129;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // grpTimeline
            // 
            grpTimeline.Controls.Add(dtpEndTime);
            grpTimeline.Controls.Add(dtpStartTime);
            grpTimeline.Controls.Add(dtpEndDate);
            grpTimeline.Controls.Add(label5);
            grpTimeline.Controls.Add(label3);
            grpTimeline.Controls.Add(dtpStartDate);
            grpTimeline.Controls.Add(label4);
            grpTimeline.Controls.Add(label2);
            grpTimeline.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpTimeline.Location = new Point(276, 162);
            grpTimeline.Name = "grpTimeline";
            grpTimeline.Size = new Size(453, 127);
            grpTimeline.TabIndex = 132;
            grpTimeline.TabStop = false;
            grpTimeline.Text = "Booking Date";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "hh:mm tt";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(317, 72);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(114, 27);
            dtpEndTime.TabIndex = 140;
            dtpEndTime.ValueChanged += dateTimePicker4_ValueChanged;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "hh:mm tt";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(317, 28);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(114, 27);
            dtpStartTime.TabIndex = 139;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(99, 77);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(114, 27);
            dtpEndDate.TabIndex = 138;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(230, 77);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 137;
            label5.Text = "End Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 82);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 136;
            label3.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(99, 35);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(114, 27);
            dtpStartDate.TabIndex = 135;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(230, 35);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 134;
            label4.Text = "Start Time:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 133;
            label2.Text = "Start Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(276, 315);
            label6.Name = "label6";
            label6.Size = new Size(121, 20);
            label6.TabIndex = 133;
            label6.Text = "Approval Status";
            // 
            // cmbApprovalStatus
            // 
            cmbApprovalStatus.FormattingEnabled = true;
            cmbApprovalStatus.Items.AddRange(new object[] { "Approved ", "Pending", "Rejected" });
            cmbApprovalStatus.Location = new Point(277, 343);
            cmbApprovalStatus.Name = "cmbApprovalStatus";
            cmbApprovalStatus.Size = new Size(297, 28);
            cmbApprovalStatus.TabIndex = 134;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(276, 389);
            label7.Name = "label7";
            label7.Size = new Size(87, 20);
            label7.TabIndex = 135;
            label7.Text = "Select Item";
            // 
            // cmbItem
            // 
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.FormattingEnabled = true;
            cmbItem.Items.AddRange(new object[] { "Approved ", "Pending", "Rejected" });
            cmbItem.Location = new Point(277, 418);
            cmbItem.Name = "cmbItem";
            cmbItem.Size = new Size(297, 28);
            cmbItem.TabIndex = 136;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(276, 458);
            label8.Name = "label8";
            label8.Size = new Size(139, 20);
            label8.TabIndex = 137;
            label8.Text = "Quantity Reserved";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(277, 481);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(72, 27);
            numQuantity.TabIndex = 138;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbUser
            // 
            cmbUser.FormattingEnabled = true;
            cmbUser.Items.AddRange(new object[] { "Approved ", "Pending", "Rejected" });
            cmbUser.Location = new Point(515, 128);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(192, 28);
            cmbUser.TabIndex = 139;
            // 
            // Reservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1182, 653);
            Controls.Add(cmbUser);
            Controls.Add(numQuantity);
            Controls.Add(label8);
            Controls.Add(cmbItem);
            Controls.Add(label7);
            Controls.Add(cmbApprovalStatus);
            Controls.Add(label6);
            Controls.Add(grpTimeline);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(panel2);
            Controls.Add(dgvReservations);
            Controls.Add(panel1);
            Controls.Add(itemNameLbl);
            Controls.Add(idLbl);
            Controls.Add(txtBookingID);
            Name = "Reservation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reservation";
            Load += Reservation_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            grpTimeline.ResumeLayout(false);
            grpTimeline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label pairLbl;
        private Panel panel1;
        private Label itemNameLbl;
        private Label idLbl;
        private TextBox txtBookingID;
        private DataGridView dgvReservations;
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
        private LinkLabel SettingLink;
        private LinkLabel UserLink;
        private LinkLabel ReportsLink;
        private LinkLabel PerformanceLink;
        private LinkLabel BorrowReturnLink;
        private LinkLabel ReservationLink;
        private LinkLabel InventoryLink;
        private LinkLabel DashboardLink;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnClear;
        private Button logOut_btn;
        private GroupBox grpTimeline;
        private Label label4;
        private Label label2;
        private Label label5;
        private Label label3;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndDate;
        private Label label6;
        private ComboBox cmbApprovalStatus;
        private Label label7;
        private ComboBox cmbItem;
        private Label label8;
        private NumericUpDown numQuantity;
        private ComboBox cmbUser;
    }
}