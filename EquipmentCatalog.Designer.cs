namespace WinFormsApp2
{
    partial class EquipmentCatalog
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
            panel2 = new Panel();
            panel7 = new Panel();
            DashboardLink = new LinkLabel();
            panel3 = new Panel();
            label2 = new Label();
            cmbCategory = new ComboBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            panel4 = new Panel();
            panel6 = new Panel();
            dtpEndDate = new DateTimePicker();
            btnClearCart = new Button();
            btnSubmitReservation = new Button();
            label5 = new Label();
            label6 = new Label();
            dtpStartDate = new DateTimePicker();
            lstCart = new ListBox();
            lblCartCount = new Label();
            label3 = new Label();
            panel5 = new Panel();
            flpCatalog = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
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
            panel1.TabIndex = 137;
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
            label1.Size = new Size(368, 54);
            label1.TabIndex = 2;
            label1.Text = "Equipment Catalog";
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
            btnBorrowed.Click += btnBorrowed_Click;
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
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel7);
            panel2.Location = new Point(2, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 570);
            panel2.TabIndex = 142;
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
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(cmbCategory);
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(txtSearch);
            panel3.Location = new Point(251, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(929, 48);
            panel3.TabIndex = 143;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(383, 14);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 4;
            label2.Text = "Category:";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(454, 10);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(176, 28);
            cmbCategory.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SteelBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = SystemColors.ButtonFace;
            btnSearch.Location = new Point(294, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(23, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search equipment...";
            txtSearch.Size = new Size(267, 27);
            txtSearch.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(lstCart);
            panel4.Controls.Add(lblCartCount);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(885, 78);
            panel4.Name = "panel4";
            panel4.Size = new Size(295, 574);
            panel4.TabIndex = 144;
            // 
            // panel6
            // 
            panel6.Controls.Add(dtpEndDate);
            panel6.Controls.Add(btnClearCart);
            panel6.Controls.Add(btnSubmitReservation);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(dtpStartDate);
            panel6.Location = new Point(0, 208);
            panel6.Name = "panel6";
            panel6.Size = new Size(295, 375);
            panel6.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(96, 84);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(126, 27);
            dtpEndDate.TabIndex = 7;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.Gray;
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearCart.ForeColor = SystemColors.ButtonFace;
            btnClearCart.Location = new Point(14, 292);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(271, 35);
            btnClearCart.TabIndex = 6;
            btnClearCart.Text = "Clear Cart";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // btnSubmitReservation
            // 
            btnSubmitReservation.BackColor = Color.SeaGreen;
            btnSubmitReservation.FlatAppearance.BorderSize = 0;
            btnSubmitReservation.FlatStyle = FlatStyle.Flat;
            btnSubmitReservation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmitReservation.ForeColor = SystemColors.ButtonFace;
            btnSubmitReservation.Location = new Point(14, 230);
            btnSubmitReservation.Name = "btnSubmitReservation";
            btnSubmitReservation.Size = new Size(271, 55);
            btnSubmitReservation.TabIndex = 5;
            btnSubmitReservation.Text = "Submit Reservation Request";
            btnSubmitReservation.UseVisualStyleBackColor = false;
            btnSubmitReservation.Click += btnSubmitReservation_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 42);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 4;
            label5.Text = "Start Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 89);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 5;
            label6.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(96, 42);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(126, 27);
            dtpStartDate.TabIndex = 0;
            // 
            // lstCart
            // 
            lstCart.BackColor = SystemColors.Info;
            lstCart.FormattingEnabled = true;
            lstCart.Location = new Point(22, 71);
            lstCart.Name = "lstCart";
            lstCart.Size = new Size(246, 124);
            lstCart.TabIndex = 2;
            // 
            // lblCartCount
            // 
            lblCartCount.AutoSize = true;
            lblCartCount.Location = new Point(21, 44);
            lblCartCount.Name = "lblCartCount";
            lblCartCount.Size = new Size(119, 20);
            lblCartCount.TabIndex = 1;
            lblCartCount.Text = "X Items Selected";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label3.Location = new Point(54, 8);
            label3.Name = "label3";
            label3.Size = new Size(214, 28);
            label3.TabIndex = 0;
            label3.Text = "RESERVATION CART";
            // 
            // panel5
            // 
            panel5.Controls.Add(flpCatalog);
            panel5.Location = new Point(258, 132);
            panel5.Name = "panel5";
            panel5.Size = new Size(621, 520);
            panel5.TabIndex = 145;
            // 
            // flpCatalog
            // 
            flpCatalog.AutoScroll = true;
            flpCatalog.BackColor = Color.FromArgb(235, 235, 235);
            flpCatalog.Location = new Point(3, 3);
            flpCatalog.Name = "flpCatalog";
            flpCatalog.Padding = new Padding(10);
            flpCatalog.Size = new Size(615, 506);
            flpCatalog.TabIndex = 0;
            // 
            // EquipmentCatalog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "EquipmentCatalog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EquipmentCatalog";
            Load += EquipmentCatalog_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button logOut_btn;
        private Label label1;
        private Label pairLbl;
        private Label welcomeBackLbl;
        private Button btnAccount;
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
        private Panel panel2;
        private Panel panel7;
        private LinkLabel DashboardLink;
        private Panel panel3;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label2;
        private ComboBox cmbCategory;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Button btnClearCart;
        private Button btnSubmitReservation;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpStartDate;
        private ListBox lstCart;
        private Label lblCartCount;
        private Label label3;
        private FlowLayoutPanel flpCatalog;
        private DateTimePicker dtpEndDate;
    }
}