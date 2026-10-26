namespace WinFormsApp2
{
    partial class MemberDashboard
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
            recent_lbl = new Label();
            panelPending = new Panel();
            dgvRecent = new DataGridView();
            dgvActiveLoans = new DataGridView();
            active_lbl = new Label();
            panelOverdue = new Panel();
            welcome_lbl = new Label();
            panel7 = new Panel();
            btnAccount = new Button();
            btnSchedule = new Button();
            btnBorrowed = new Button();
            btnReservations = new Button();
            btnEquipment = new Button();
            btnDashboard = new Button();
            AccountLink = new LinkLabel();
            ScheduleLink = new LinkLabel();
            BorrowedLink = new LinkLabel();
            ReservationsLink = new LinkLabel();
            EquipmentLink = new LinkLabel();
            DashboardLink = new LinkLabel();
            panel2 = new Panel();
            label5 = new Label();
            lblOverdueCount = new Label();
            panel6 = new Panel();
            panel1 = new Panel();
            logOut_btn = new Button();
            label1 = new Label();
            pairLbl = new Label();
            welcomeBackLbl = new Label();
            panel3 = new Panel();
            label2 = new Label();
            lblActiveLoans = new Label();
            lblPendingCount = new Label();
            panel4 = new Panel();
            label3 = new Label();
            lblReservedCount = new Label();
            panel5 = new Panel();
            label4 = new Label();
            panelPending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveLoans).BeginInit();
            panelOverdue.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // recent_lbl
            // 
            recent_lbl.BackColor = Color.DarkOliveGreen;
            recent_lbl.Dock = DockStyle.Top;
            recent_lbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            recent_lbl.ForeColor = Color.White;
            recent_lbl.Location = new Point(0, 0);
            recent_lbl.Name = "recent_lbl";
            recent_lbl.Padding = new Padding(10, 0, 0, 0);
            recent_lbl.Size = new Size(422, 32);
            recent_lbl.TabIndex = 128;
            recent_lbl.Text = "My Recent Reservations";
            recent_lbl.TextAlign = ContentAlignment.MiddleLeft;
            recent_lbl.Click += recent_lbl_Click;
            // 
            // panelPending
            // 
            panelPending.BorderStyle = BorderStyle.FixedSingle;
            panelPending.Controls.Add(dgvRecent);
            panelPending.Controls.Add(recent_lbl);
            panelPending.Location = new Point(732, 393);
            panelPending.Name = "panelPending";
            panelPending.Size = new Size(424, 249);
            panelPending.TabIndex = 136;
            // 
            // dgvRecent
            // 
            dgvRecent.AllowUserToAddRows = false;
            dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecent.BorderStyle = BorderStyle.None;
            dgvRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecent.EnableHeadersVisualStyles = false;
            dgvRecent.GridColor = Color.Silver;
            dgvRecent.Location = new Point(3, 35);
            dgvRecent.Name = "dgvRecent";
            dgvRecent.ReadOnly = true;
            dgvRecent.RowHeadersWidth = 30;
            dgvRecent.Size = new Size(416, 209);
            dgvRecent.TabIndex = 2;
            // 
            // dgvActiveLoans
            // 
            dgvActiveLoans.AllowUserToAddRows = false;
            dgvActiveLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActiveLoans.BorderStyle = BorderStyle.None;
            dgvActiveLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveLoans.EnableHeadersVisualStyles = false;
            dgvActiveLoans.GridColor = Color.Silver;
            dgvActiveLoans.Location = new Point(3, 35);
            dgvActiveLoans.Name = "dgvActiveLoans";
            dgvActiveLoans.ReadOnly = true;
            dgvActiveLoans.RowHeadersWidth = 30;
            dgvActiveLoans.Size = new Size(407, 209);
            dgvActiveLoans.TabIndex = 1;
            // 
            // active_lbl
            // 
            active_lbl.BackColor = Color.DarkOliveGreen;
            active_lbl.Dock = DockStyle.Top;
            active_lbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            active_lbl.ForeColor = Color.White;
            active_lbl.Location = new Point(0, 0);
            active_lbl.Name = "active_lbl";
            active_lbl.Padding = new Padding(10, 0, 0, 0);
            active_lbl.Size = new Size(413, 32);
            active_lbl.TabIndex = 0;
            active_lbl.Text = "My Active Loans";
            active_lbl.TextAlign = ContentAlignment.MiddleLeft;
            active_lbl.Click += active_lbl_Click;
            // 
            // panelOverdue
            // 
            panelOverdue.BorderStyle = BorderStyle.FixedSingle;
            panelOverdue.Controls.Add(dgvActiveLoans);
            panelOverdue.Controls.Add(active_lbl);
            panelOverdue.Location = new Point(278, 393);
            panelOverdue.Name = "panelOverdue";
            panelOverdue.Size = new Size(415, 249);
            panelOverdue.TabIndex = 135;
            // 
            // welcome_lbl
            // 
            welcome_lbl.AutoSize = true;
            welcome_lbl.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcome_lbl.Location = new Point(273, 86);
            welcome_lbl.Name = "welcome_lbl";
            welcome_lbl.Size = new Size(341, 60);
            welcome_lbl.TabIndex = 134;
            welcome_lbl.Text = "Welcome Back!";
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkOliveGreen;
            panel7.Controls.Add(btnAccount);
            panel7.Controls.Add(btnSchedule);
            panel7.Controls.Add(btnBorrowed);
            panel7.Controls.Add(btnReservations);
            panel7.Controls.Add(btnEquipment);
            panel7.Controls.Add(btnDashboard);
            panel7.Controls.Add(AccountLink);
            panel7.Controls.Add(ScheduleLink);
            panel7.Controls.Add(BorrowedLink);
            panel7.Controls.Add(ReservationsLink);
            panel7.Controls.Add(EquipmentLink);
            panel7.Controls.Add(DashboardLink);
            panel7.ForeColor = Color.Transparent;
            panel7.Location = new Point(23, 16);
            panel7.Name = "panel7";
            panel7.Size = new Size(198, 544);
            panel7.TabIndex = 0;
            // 
            // btnAccount
            // 
            btnAccount.BackColor = Color.DarkOliveGreen;
            btnAccount.FlatAppearance.BorderSize = 0;
            btnAccount.FlatStyle = FlatStyle.Flat;
            btnAccount.Image = Properties.Resources.users;
            btnAccount.Location = new Point(12, 413);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new Size(42, 39);
            btnAccount.TabIndex = 24;
            btnAccount.UseVisualStyleBackColor = false;
            btnAccount.Click += btnAccount_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.BackColor = Color.DarkOliveGreen;
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Image = Properties.Resources.performances;
            btnSchedule.Location = new Point(12, 335);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(42, 42);
            btnSchedule.TabIndex = 20;
            btnSchedule.UseVisualStyleBackColor = false;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // btnBorrowed
            // 
            btnBorrowed.BackColor = Color.DarkOliveGreen;
            btnBorrowed.FlatAppearance.BorderSize = 0;
            btnBorrowed.FlatStyle = FlatStyle.Flat;
            btnBorrowed.Image = Properties.Resources.borrow_return;
            btnBorrowed.Location = new Point(12, 255);
            btnBorrowed.Name = "btnBorrowed";
            btnBorrowed.Size = new Size(42, 42);
            btnBorrowed.TabIndex = 19;
            btnBorrowed.UseVisualStyleBackColor = false;
            btnBorrowed.Click += btnMemberBorrowed_Click;
            // 
            // btnReservations
            // 
            btnReservations.BackColor = Color.DarkOliveGreen;
            btnReservations.FlatAppearance.BorderSize = 0;
            btnReservations.FlatStyle = FlatStyle.Flat;
            btnReservations.Image = Properties.Resources.reservations;
            btnReservations.Location = new Point(12, 176);
            btnReservations.Name = "btnReservations";
            btnReservations.Size = new Size(42, 45);
            btnReservations.TabIndex = 18;
            btnReservations.UseVisualStyleBackColor = false;
            btnReservations.Click += btnReservations_Click;
            // 
            // btnEquipment
            // 
            btnEquipment.BackColor = Color.DarkOliveGreen;
            btnEquipment.FlatAppearance.BorderSize = 0;
            btnEquipment.FlatStyle = FlatStyle.Flat;
            btnEquipment.ForeColor = Color.Transparent;
            btnEquipment.Image = Properties.Resources.inventory;
            btnEquipment.Location = new Point(12, 96);
            btnEquipment.Name = "btnEquipment";
            btnEquipment.Size = new Size(42, 41);
            btnEquipment.TabIndex = 17;
            btnEquipment.UseVisualStyleBackColor = false;
            btnEquipment.Click += btnEquipment_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.DarkOliveGreen;
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
            // AccountLink
            // 
            AccountLink.AutoSize = true;
            AccountLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AccountLink.LinkBehavior = LinkBehavior.NeverUnderline;
            AccountLink.LinkColor = Color.White;
            AccountLink.Location = new Point(60, 422);
            AccountLink.Name = "AccountLink";
            AccountLink.Size = new Size(93, 20);
            AccountLink.TabIndex = 14;
            AccountLink.TabStop = true;
            AccountLink.Text = "My Account";
            AccountLink.LinkClicked += AccountLink_LinkClicked;
            // 
            // ScheduleLink
            // 
            ScheduleLink.AutoSize = true;
            ScheduleLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ScheduleLink.LinkBehavior = LinkBehavior.NeverUnderline;
            ScheduleLink.LinkColor = Color.White;
            ScheduleLink.Location = new Point(60, 346);
            ScheduleLink.Name = "ScheduleLink";
            ScheduleLink.Size = new Size(71, 20);
            ScheduleLink.TabIndex = 12;
            ScheduleLink.TabStop = true;
            ScheduleLink.Text = "Schedule";
            ScheduleLink.LinkClicked += ScheduleLink_LinkClicked;
            // 
            // BorrowedLink
            // 
            BorrowedLink.AutoSize = true;
            BorrowedLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BorrowedLink.LinkBehavior = LinkBehavior.NeverUnderline;
            BorrowedLink.LinkColor = Color.White;
            BorrowedLink.Location = new Point(60, 265);
            BorrowedLink.Name = "BorrowedLink";
            BorrowedLink.Size = new Size(104, 20);
            BorrowedLink.TabIndex = 11;
            BorrowedLink.TabStop = true;
            BorrowedLink.Text = "My Borrowed";
            BorrowedLink.LinkClicked += BorrowedLink_LinkClicked;
            // 
            // ReservationsLink
            // 
            ReservationsLink.AutoSize = true;
            ReservationsLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ReservationsLink.LinkBehavior = LinkBehavior.NeverUnderline;
            ReservationsLink.LinkColor = Color.White;
            ReservationsLink.Location = new Point(60, 188);
            ReservationsLink.Name = "ReservationsLink";
            ReservationsLink.Size = new Size(100, 20);
            ReservationsLink.TabIndex = 10;
            ReservationsLink.TabStop = true;
            ReservationsLink.Text = "Reservations";
            ReservationsLink.LinkClicked += ReservationsLink_LinkClicked;
            // 
            // EquipmentLink
            // 
            EquipmentLink.AutoSize = true;
            EquipmentLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            EquipmentLink.LinkBehavior = LinkBehavior.NeverUnderline;
            EquipmentLink.LinkColor = Color.White;
            EquipmentLink.Location = new Point(60, 106);
            EquipmentLink.Name = "EquipmentLink";
            EquipmentLink.Size = new Size(85, 40);
            EquipmentLink.TabIndex = 9;
            EquipmentLink.TabStop = true;
            EquipmentLink.Text = "Equipment\r\nCatalog";
            EquipmentLink.LinkClicked += EquipmentLink_LinkClicked;
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
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel7);
            panel2.Location = new Point(2, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 570);
            panel2.TabIndex = 133;
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
            lblOverdueCount.Location = new Point(73, 25);
            lblOverdueCount.Name = "lblOverdueCount";
            lblOverdueCount.Size = new Size(43, 41);
            lblOverdueCount.TabIndex = 3;
            lblOverdueCount.Text = "2 ";
            lblOverdueCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkOliveGreen;
            panel6.Controls.Add(label5);
            panel6.Controls.Add(lblOverdueCount);
            panel6.ForeColor = Color.White;
            panel6.Location = new Point(964, 179);
            panel6.Name = "panel6";
            panel6.Size = new Size(197, 176);
            panel6.TabIndex = 129;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(logOut_btn);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pairLbl);
            panel1.Controls.Add(welcomeBackLbl);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1178, 78);
            panel1.TabIndex = 128;
            // 
            // logOut_btn
            // 
            logOut_btn.BackColor = Color.DarkOliveGreen;
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
            label1.Size = new Size(385, 54);
            label1.TabIndex = 2;
            label1.Text = "Member Dashboard";
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
            panel3.BackColor = Color.DarkOliveGreen;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(lblActiveLoans);
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(278, 179);
            panel3.Name = "panel3";
            panel3.Size = new Size(197, 176);
            panel3.TabIndex = 130;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(3, 107);
            label2.Name = "label2";
            label2.Size = new Size(194, 41);
            label2.TabIndex = 1;
            label2.Text = "Active Loans";
            // 
            // lblActiveLoans
            // 
            lblActiveLoans.AutoSize = true;
            lblActiveLoans.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveLoans.Location = new Point(55, 25);
            lblActiveLoans.Name = "lblActiveLoans";
            lblActiveLoans.Size = new Size(69, 41);
            lblActiveLoans.TabIndex = 0;
            lblActiveLoans.Text = "128\r\n";
            lblActiveLoans.TextAlign = ContentAlignment.TopCenter;
            lblActiveLoans.Click += lblMembersCount_Click;
            // 
            // lblPendingCount
            // 
            lblPendingCount.AutoSize = true;
            lblPendingCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPendingCount.Location = new Point(75, 25);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(35, 41);
            lblPendingCount.TabIndex = 2;
            lblPendingCount.Text = "8\r\n";
            lblPendingCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkOliveGreen;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(lblReservedCount);
            panel4.ForeColor = Color.White;
            panel4.Location = new Point(507, 179);
            panel4.Name = "panel4";
            panel4.Size = new Size(197, 176);
            panel4.TabIndex = 131;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.Location = new Point(0, 107);
            label3.Name = "label3";
            label3.Size = new Size(199, 41);
            label3.TabIndex = 1;
            label3.Text = "My Reserved";
            // 
            // lblReservedCount
            // 
            lblReservedCount.AutoSize = true;
            lblReservedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReservedCount.Location = new Point(64, 25);
            lblReservedCount.Name = "lblReservedCount";
            lblReservedCount.Size = new Size(52, 41);
            lblReservedCount.TabIndex = 1;
            lblReservedCount.Text = "14\r\n";
            lblReservedCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkOliveGreen;
            panel5.Controls.Add(label4);
            panel5.Controls.Add(lblPendingCount);
            panel5.ForeColor = Color.White;
            panel5.Location = new Point(736, 179);
            panel5.Name = "panel5";
            panel5.Size = new Size(197, 176);
            panel5.TabIndex = 132;
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
            // MemberDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(panelPending);
            Controls.Add(panelOverdue);
            Controls.Add(welcome_lbl);
            Controls.Add(panel2);
            Controls.Add(panel6);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Name = "MemberDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Dashboard";
            Load += MemberDashboard_Load;
            panelPending.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveLoans).EndInit();
            panelOverdue.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label recent_lbl;
        private Panel panelPending;
        private DataGridView dgvRecent;
        private DataGridView dgvActiveLoans;
        private Label active_lbl;
        private Panel panelOverdue;
        private Label welcome_lbl;
        private Panel panel7;
        private Button btnSchedule;
        private Button btnBorrowed;
        private Button btnReservations;
        private Button btnEquipment;
        private Button btnDashboard;
        private LinkLabel AccountLink;
        private LinkLabel ScheduleLink;
        private LinkLabel BorrowedLink;
        private LinkLabel ReservationsLink;
        private LinkLabel EquipmentLink;
        private LinkLabel DashboardLink;
        private Panel panel2;
        private Label label5;
        private Label lblOverdueCount;
        private Panel panel6;
        private Panel panel1;
        private Button logOut_btn;
        private Label label1;
        private Label pairLbl;
        private Label welcomeBackLbl;
        private Panel panel3;
        private Label label2;
        private Label lblActiveLoans;
        private Label lblPendingCount;
        private Panel panel4;
        private Label label3;
        private Label lblReservedCount;
        private Panel panel5;
        private Label label4;
        private Button btnAccount;
    }
}