namespace WinFormsApp2
{
    partial class Dashboard
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
            panel1 = new Panel();
            logOut_btn = new Button();
            label1 = new Label();
            pairLbl = new Label();
            welcomeBackLbl = new Label();
            panel3 = new Panel();
            label2 = new Label();
            lblMembersCount = new Label();
            panel4 = new Panel();
            label3 = new Label();
            lblReservedCount = new Label();
            panel5 = new Panel();
            label4 = new Label();
            lblPendingCount = new Label();
            panel6 = new Panel();
            label5 = new Label();
            lblOverdueCount = new Label();
            panel2 = new Panel();
            panel7 = new Panel();
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
            welcome_lbl = new Label();
            panelOverdue = new Panel();
            dgvOverdue = new DataGridView();
            overdue_lbl = new Label();
            panelPending = new Panel();
            dgvPending = new DataGridView();
            pending_lbl = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panelOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).BeginInit();
            panelPending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPending).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Maroon;
            panel1.Controls.Add(logOut_btn);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pairLbl);
            panel1.Controls.Add(welcomeBackLbl);
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
            logOut_btn.Location = new Point(1107, 16);
            logOut_btn.Name = "logOut_btn";
            logOut_btn.Size = new Size(47, 45);
            logOut_btn.TabIndex = 51;
            logOut_btn.UseVisualStyleBackColor = false;
            logOut_btn.Click += logOut_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(147, 7);
            label1.Name = "label1";
            label1.Size = new Size(351, 54);
            label1.TabIndex = 2;
            label1.Text = "Admin Dashboard";
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
            // welcomeBackLbl
            // 
            welcomeBackLbl.AutoSize = true;
            welcomeBackLbl.BackColor = Color.Transparent;
            welcomeBackLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeBackLbl.ForeColor = Color.White;
            welcomeBackLbl.Location = new Point(285, 85);
            welcomeBackLbl.Name = "welcomeBackLbl";
            welcomeBackLbl.Size = new Size(310, 54);
            welcomeBackLbl.TabIndex = 50;
            welcomeBackLbl.Text = "Welcome Back!";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Maroon;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(lblMembersCount);
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(278, 178);
            panel3.Name = "panel3";
            panel3.Size = new Size(197, 176);
            panel3.TabIndex = 53;
            panel3.Paint += panel3_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(23, 107);
            label2.Name = "label2";
            label2.Size = new Size(150, 41);
            label2.TabIndex = 1;
            label2.Text = "Members";
            // 
            // lblMembersCount
            // 
            lblMembersCount.AutoSize = true;
            lblMembersCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMembersCount.Location = new Point(23, 24);
            lblMembersCount.Name = "lblMembersCount";
            lblMembersCount.Size = new Size(69, 41);
            lblMembersCount.TabIndex = 0;
            lblMembersCount.Text = "128\r\n";
            lblMembersCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Maroon;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(lblReservedCount);
            panel4.ForeColor = Color.White;
            panel4.Location = new Point(507, 178);
            panel4.Name = "panel4";
            panel4.Size = new Size(197, 176);
            panel4.TabIndex = 53;
            panel4.Paint += panel3_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.Location = new Point(26, 107);
            label3.Name = "label3";
            label3.Size = new Size(146, 41);
            label3.TabIndex = 1;
            label3.Text = "Reserved";
            // 
            // lblReservedCount
            // 
            lblReservedCount.AutoSize = true;
            lblReservedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReservedCount.Location = new Point(26, 24);
            lblReservedCount.Name = "lblReservedCount";
            lblReservedCount.Size = new Size(52, 41);
            lblReservedCount.TabIndex = 1;
            lblReservedCount.Text = "14\r\n";
            lblReservedCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Maroon;
            panel5.Controls.Add(label4);
            panel5.Controls.Add(lblPendingCount);
            panel5.ForeColor = Color.White;
            panel5.Location = new Point(736, 178);
            panel5.Name = "panel5";
            panel5.Size = new Size(197, 176);
            panel5.TabIndex = 53;
            panel5.Paint += panel3_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.Location = new Point(29, 107);
            label4.Name = "label4";
            label4.Size = new Size(134, 41);
            label4.TabIndex = 1;
            label4.Text = "Pending";
            // 
            // lblPendingCount
            // 
            lblPendingCount.AutoSize = true;
            lblPendingCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPendingCount.Location = new Point(29, 24);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(35, 41);
            lblPendingCount.TabIndex = 2;
            lblPendingCount.Text = "8\r\n";
            lblPendingCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Maroon;
            panel6.Controls.Add(label5);
            panel6.Controls.Add(lblOverdueCount);
            panel6.ForeColor = Color.White;
            panel6.Location = new Point(964, 178);
            panel6.Name = "panel6";
            panel6.Size = new Size(197, 176);
            panel6.TabIndex = 53;
            panel6.Paint += panel3_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.Location = new Point(28, 107);
            label5.Name = "label5";
            label5.Size = new Size(138, 41);
            label5.TabIndex = 1;
            label5.Text = "Overdue";
            // 
            // lblOverdueCount
            // 
            lblOverdueCount.AutoSize = true;
            lblOverdueCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOverdueCount.Location = new Point(28, 24);
            lblOverdueCount.Name = "lblOverdueCount";
            lblOverdueCount.Size = new Size(43, 41);
            lblOverdueCount.TabIndex = 3;
            lblOverdueCount.Text = "2 ";
            lblOverdueCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel7);
            panel2.Location = new Point(2, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 570);
            panel2.TabIndex = 123;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Maroon;
            panel7.Controls.Add(btnSettings);
            panel7.Controls.Add(btnUsers);
            panel7.Controls.Add(btnReports);
            panel7.Controls.Add(btnperformances);
            panel7.Controls.Add(btnborrowreturn);
            panel7.Controls.Add(btreservations);
            panel7.Controls.Add(btninventory);
            panel7.Controls.Add(btnDashboard);
            panel7.Controls.Add(SettingLink);
            panel7.Controls.Add(UserLink);
            panel7.Controls.Add(ReportsLink);
            panel7.Controls.Add(PerformanceLink);
            panel7.Controls.Add(BorrowReturnLink);
            panel7.Controls.Add(ReservationLink);
            panel7.Controls.Add(InventoryLink);
            panel7.Controls.Add(DashboardLink);
            panel7.ForeColor = Color.Transparent;
            panel7.Location = new Point(23, 16);
            panel7.Name = "panel7";
            panel7.Size = new Size(198, 544);
            panel7.TabIndex = 0;
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
            InventoryLink.LinkClicked += InventoryLink_LinkClicked_1;
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
            // welcome_lbl
            // 
            welcome_lbl.AutoSize = true;
            welcome_lbl.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcome_lbl.Location = new Point(273, 85);
            welcome_lbl.Name = "welcome_lbl";
            welcome_lbl.Size = new Size(341, 60);
            welcome_lbl.TabIndex = 125;
            welcome_lbl.Text = "Welcome Back!";
            welcome_lbl.Click += welcome_lbl_Click;
            // 
            // panelOverdue
            // 
            panelOverdue.BorderStyle = BorderStyle.FixedSingle;
            panelOverdue.Controls.Add(dgvOverdue);
            panelOverdue.Controls.Add(overdue_lbl);
            panelOverdue.Location = new Point(278, 392);
            panelOverdue.Name = "panelOverdue";
            panelOverdue.Size = new Size(415, 249);
            panelOverdue.TabIndex = 126;
            // 
            // dgvOverdue
            // 
            dgvOverdue.AllowUserToAddRows = false;
            dgvOverdue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOverdue.BorderStyle = BorderStyle.None;
            dgvOverdue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOverdue.EnableHeadersVisualStyles = false;
            dgvOverdue.GridColor = Color.Silver;
            dgvOverdue.Location = new Point(3, 35);
            dgvOverdue.Name = "dgvOverdue";
            dgvOverdue.ReadOnly = true;
            dgvOverdue.RowHeadersWidth = 30;
            dgvOverdue.Size = new Size(407, 209);
            dgvOverdue.TabIndex = 1;
            dgvOverdue.CellContentClick += dgvOverdue_CellContentClick;
            dgvOverdue.RowPostPaint += dgv_RowPostPaint;
            // 
            // overdue_lbl
            // 
            overdue_lbl.BackColor = Color.Maroon;
            overdue_lbl.Dock = DockStyle.Top;
            overdue_lbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            overdue_lbl.ForeColor = Color.White;
            overdue_lbl.Location = new Point(0, 0);
            overdue_lbl.Name = "overdue_lbl";
            overdue_lbl.Padding = new Padding(10, 0, 0, 0);
            overdue_lbl.Size = new Size(413, 32);
            overdue_lbl.TabIndex = 0;
            overdue_lbl.Text = "Overdue Items";
            overdue_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelPending
            // 
            panelPending.BorderStyle = BorderStyle.FixedSingle;
            panelPending.Controls.Add(dgvPending);
            panelPending.Controls.Add(pending_lbl);
            panelPending.Location = new Point(732, 392);
            panelPending.Name = "panelPending";
            panelPending.Size = new Size(424, 249);
            panelPending.TabIndex = 127;
            // 
            // dgvPending
            // 
            dgvPending.AllowUserToAddRows = false;
            dgvPending.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPending.BorderStyle = BorderStyle.None;
            dgvPending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPending.EnableHeadersVisualStyles = false;
            dgvPending.GridColor = Color.Silver;
            dgvPending.Location = new Point(3, 35);
            dgvPending.Name = "dgvPending";
            dgvPending.ReadOnly = true;
            dgvPending.RowHeadersWidth = 30;
            dgvPending.Size = new Size(416, 209);
            dgvPending.TabIndex = 2;
            dgvPending.RowPostPaint += dgv_RowPostPaint;
            // 
            // pending_lbl
            // 
            pending_lbl.BackColor = Color.Maroon;
            pending_lbl.Dock = DockStyle.Top;
            pending_lbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pending_lbl.ForeColor = Color.White;
            pending_lbl.Location = new Point(0, 0);
            pending_lbl.Name = "pending_lbl";
            pending_lbl.Padding = new Padding(10, 0, 0, 0);
            pending_lbl.Size = new Size(422, 32);
            pending_lbl.TabIndex = 128;
            pending_lbl.Text = "Pending Items";
            pending_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1182, 653);
            Controls.Add(panelPending);
            Controls.Add(panelOverdue);
            Controls.Add(welcome_lbl);
            Controls.Add(panel2);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panelOverdue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).EndInit();
            panelPending.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPending).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Label pairLbl;
        private Label welcomeBackLbl;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label lblMembersCount;
        private Label lblReservedCount;
        private Label lblPendingCount;
        private Label lblOverdueCount;
        private Panel panel2;
        private Panel panel7;
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
        private Label welcome_lbl;
        private Button logOut_btn;
        private Panel panelOverdue;
        private Panel panelPending;
        private Label overdue_lbl;
        private DataGridView dgvOverdue;
        private Label pending_lbl;
        private DataGridView dgvPending;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}