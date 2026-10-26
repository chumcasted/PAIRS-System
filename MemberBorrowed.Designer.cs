namespace WinFormsApp2
{
    partial class MemberBorrowed
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
            panel5 = new Panel();
            dgvMemberBorrowed = new DataGridView();
            cmbFilter = new ComboBox();
            label2 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panel3 = new Panel();
            label4 = new Label();
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
            label1 = new Label();
            pairLbl = new Label();
            welcomeBackLbl = new Label();
            panel4 = new Panel();
            label13 = new Label();
            label12 = new Label();
            cmbIssuedCondition = new ComboBox();
            dtpDueDate = new DateTimePicker();
            label11 = new Label();
            label7 = new Label();
            txtQuantity = new TextBox();
            label6 = new Label();
            txtEquipments = new TextBox();
            txtBorrowID = new TextBox();
            dtpBorrowDate = new DateTimePicker();
            txtStatus = new Label();
            label10 = new Label();
            label9 = new Label();
            btnSubmitReturn = new Button();
            label8 = new Label();
            label3 = new Label();
            logOut_btn = new Button();
            panel1 = new Panel();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMemberBorrowed).BeginInit();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Controls.Add(dgvMemberBorrowed);
            panel5.Controls.Add(cmbFilter);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(txtSearch);
            panel5.Controls.Add(btnSearch);
            panel5.Location = new Point(258, 132);
            panel5.Name = "panel5";
            panel5.Size = new Size(621, 520);
            panel5.TabIndex = 155;
            // 
            // dgvMemberBorrowed
            // 
            dgvMemberBorrowed.AllowUserToAddRows = false;
            dgvMemberBorrowed.AllowUserToDeleteRows = false;
            dgvMemberBorrowed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMemberBorrowed.BackgroundColor = Color.LightGray;
            dgvMemberBorrowed.BorderStyle = BorderStyle.Fixed3D;
            dgvMemberBorrowed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMemberBorrowed.Location = new Point(3, 47);
            dgvMemberBorrowed.MultiSelect = false;
            dgvMemberBorrowed.Name = "dgvMemberBorrowed";
            dgvMemberBorrowed.ReadOnly = true;
            dgvMemberBorrowed.RowHeadersWidth = 51;
            dgvMemberBorrowed.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMemberBorrowed.Size = new Size(615, 470);
            dgvMemberBorrowed.TabIndex = 77;
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(403, 8);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(176, 28);
            cmbFilter.TabIndex = 3;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(355, 14);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 4;
            label2.Text = "Filter:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(7, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search Booking ID";
            txtSearch.Size = new Size(232, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SteelBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = SystemColors.ButtonFace;
            btnSearch.Location = new Point(245, 7);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(label4);
            panel3.Location = new Point(251, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(929, 48);
            panel3.TabIndex = 153;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label4.Location = new Point(692, 9);
            label4.Name = "label4";
            label4.Size = new Size(194, 28);
            label4.TabIndex = 1;
            label4.Text = "BORROW DETAILS";
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
            panel2.TabIndex = 152;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(147, 7);
            label1.Name = "label1";
            label1.Size = new Size(268, 54);
            label1.TabIndex = 2;
            label1.Text = "My Borrowed";
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
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(cmbIssuedCondition);
            panel4.Controls.Add(dtpDueDate);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(txtQuantity);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtEquipments);
            panel4.Controls.Add(txtBorrowID);
            panel4.Controls.Add(dtpBorrowDate);
            panel4.Controls.Add(txtStatus);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(btnSubmitReturn);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(885, 78);
            panel4.Name = "panel4";
            panel4.Size = new Size(295, 574);
            panel4.TabIndex = 154;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 277);
            label13.Name = "label13";
            label13.Size = new Size(52, 20);
            label13.TabIndex = 80;
            label13.Text = "Status:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label12.Location = new Point(6, 486);
            label12.Name = "label12";
            label12.Size = new Size(281, 40);
            label12.TabIndex = 79;
            label12.Text = "* Hand in equipment at the Cultural office \r\nfor custodian inspection.";
            // 
            // cmbIssuedCondition
            // 
            cmbIssuedCondition.FormattingEnabled = true;
            cmbIssuedCondition.Location = new Point(28, 341);
            cmbIssuedCondition.Name = "cmbIssuedCondition";
            cmbIssuedCondition.Size = new Size(176, 28);
            cmbIssuedCondition.TabIndex = 78;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(105, 229);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(126, 27);
            dtpDueDate.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 236);
            label11.Name = "label11";
            label11.Size = new Size(75, 20);
            label11.TabIndex = 18;
            label11.Text = "Due Date:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 183);
            label7.Name = "label7";
            label7.Size = new Size(61, 40);
            label7.TabIndex = 17;
            label7.Text = "Borrow \r\nDate:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(105, 146);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.ReadOnly = true;
            txtQuantity.Size = new Size(128, 27);
            txtQuantity.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 146);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 15;
            label6.Text = "Quantity:";
            // 
            // txtEquipments
            // 
            txtEquipments.Location = new Point(105, 110);
            txtEquipments.Name = "txtEquipments";
            txtEquipments.ReadOnly = true;
            txtEquipments.Size = new Size(174, 27);
            txtEquipments.TabIndex = 14;
            // 
            // txtBorrowID
            // 
            txtBorrowID.Location = new Point(105, 73);
            txtBorrowID.Name = "txtBorrowID";
            txtBorrowID.ReadOnly = true;
            txtBorrowID.Size = new Size(174, 27);
            txtBorrowID.TabIndex = 12;
            // 
            // dtpBorrowDate
            // 
            dtpBorrowDate.Format = DateTimePickerFormat.Short;
            dtpBorrowDate.Location = new Point(105, 183);
            dtpBorrowDate.Name = "dtpBorrowDate";
            dtpBorrowDate.Size = new Size(126, 27);
            dtpBorrowDate.TabIndex = 0;
            // 
            // txtStatus
            // 
            txtStatus.BorderStyle = BorderStyle.FixedSingle;
            txtStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtStatus.Location = new Point(105, 277);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(99, 20);
            txtStatus.TabIndex = 5;
            txtStatus.Text = "Status:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(6, 76);
            label10.Name = "label10";
            label10.Size = new Size(85, 20);
            label10.TabIndex = 6;
            label10.Text = "Borrow ID:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(6, 111);
            label9.Name = "label9";
            label9.Size = new Size(93, 20);
            label9.TabIndex = 11;
            label9.Text = "Equipments:";
            // 
            // btnSubmitReturn
            // 
            btnSubmitReturn.BackColor = Color.LightSeaGreen;
            btnSubmitReturn.FlatAppearance.BorderSize = 0;
            btnSubmitReturn.FlatStyle = FlatStyle.Flat;
            btnSubmitReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmitReturn.ForeColor = SystemColors.ButtonFace;
            btnSubmitReturn.Location = new Point(14, 411);
            btnSubmitReturn.Name = "btnSubmitReturn";
            btnSubmitReturn.Size = new Size(271, 61);
            btnSubmitReturn.TabIndex = 6;
            btnSubmitReturn.Text = "Submit Return Request";
            btnSubmitReturn.UseVisualStyleBackColor = false;
            btnSubmitReturn.Click += btnSubmitReturn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 315);
            label8.Name = "label8";
            label8.Size = new Size(122, 20);
            label8.TabIndex = 10;
            label8.Text = "Issued Condition:";
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
            panel1.TabIndex = 151;
            // 
            // MemberBorrowed
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "MemberBorrowed";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MemberBorrowed";
            Load += MemberBorrowed_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMemberBorrowed).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private DataGridView dgvMemberBorrowed;
        private Label label2;
        private Panel panel3;
        private Label label4;
        private ComboBox cmbFilter;
        private Button btnSearch;
        private TextBox txtSearch;
        private Panel panel7;
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
        private LinkLabel DashboardLink;
        private Panel panel2;
        private Label label1;
        private Label pairLbl;
        private Label welcomeBackLbl;
        private Panel panel4;
        private TextBox txtBorrowID;
        private DateTimePicker dtpBorrowDate;
        private Label txtStatus;
        private Label label10;
        private Label label9;
        private Button btnSubmitReturn;
        private Label label8;
        private Label label3;
        private Button logOut_btn;
        private Panel panel1;
        private TextBox txtQuantity;
        private Label label6;
        private TextBox txtEquipments;
        private DateTimePicker dtpDueDate;
        private Label label11;
        private Label label7;
        private Label label12;
        private ComboBox cmbIssuedCondition;
        private Label label13;
    }
}