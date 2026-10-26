namespace WinFormsApp2
{
    partial class MemberAccount
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
            btnSaveProfile = new Button();
            txtRole = new TextBox();
            label16 = new Label();
            groupBox2 = new GroupBox();
            txtEmergencyPhone = new TextBox();
            lblem = new Label();
            txtEmergencyName = new TextBox();
            label15 = new Label();
            txtFullName = new TextBox();
            groupBox1 = new GroupBox();
            txtCollege = new TextBox();
            label12 = new Label();
            txtPhone = new TextBox();
            label11 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            label17 = new Label();
            label18 = new Label();
            txtUserID = new TextBox();
            panel3 = new Panel();
            label2 = new Label();
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
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            chkShowPassword = new CheckBox();
            btnUpdatePassword = new Button();
            txtConfirmPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtCurrentPassword = new TextBox();
            label5 = new Label();
            lstActivityOverview = new ListBox();
            label10 = new Label();
            label3 = new Label();
            logOut_btn = new Button();
            panel1 = new Panel();
            panel5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlDark;
            panel5.Controls.Add(btnSaveProfile);
            panel5.Controls.Add(txtRole);
            panel5.Controls.Add(label16);
            panel5.Controls.Add(groupBox2);
            panel5.Controls.Add(txtFullName);
            panel5.Controls.Add(groupBox1);
            panel5.Controls.Add(label17);
            panel5.Controls.Add(label18);
            panel5.Controls.Add(txtUserID);
            panel5.Location = new Point(258, 132);
            panel5.Name = "panel5";
            panel5.Size = new Size(621, 520);
            panel5.TabIndex = 155;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.BackColor = Color.DarkCyan;
            btnSaveProfile.FlatAppearance.BorderSize = 0;
            btnSaveProfile.FlatStyle = FlatStyle.Flat;
            btnSaveProfile.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveProfile.ForeColor = SystemColors.ButtonFace;
            btnSaveProfile.Location = new Point(82, 457);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(426, 52);
            btnSaveProfile.TabIndex = 14;
            btnSaveProfile.Text = "Save Profile Changes";
            btnSaveProfile.UseVisualStyleBackColor = false;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(135, 100);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(174, 27);
            txtRole.TabIndex = 25;
            txtRole.TextChanged += textBox4_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(44, 104);
            label16.Name = "label16";
            label16.Size = new Size(42, 20);
            label16.TabIndex = 24;
            label16.Text = "Role:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtEmergencyPhone);
            groupBox2.Controls.Add(lblem);
            groupBox2.Controls.Add(txtEmergencyName);
            groupBox2.Controls.Add(label15);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(29, 328);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(568, 106);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Emergency Contact";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // txtEmergencyPhone
            // 
            txtEmergencyPhone.Location = new Point(123, 69);
            txtEmergencyPhone.Name = "txtEmergencyPhone";
            txtEmergencyPhone.Size = new Size(343, 27);
            txtEmergencyPhone.TabIndex = 17;
            txtEmergencyPhone.TextChanged += txtEmergencyPhone_TextChanged;
            // 
            // lblem
            // 
            lblem.AutoSize = true;
            lblem.Font = new Font("Segoe UI", 9F);
            lblem.Location = new Point(15, 72);
            lblem.Name = "lblem";
            lblem.Size = new Size(108, 20);
            lblem.TabIndex = 16;
            lblem.Text = "Contact Phone:";
            // 
            // txtEmergencyName
            // 
            txtEmergencyName.Location = new Point(123, 31);
            txtEmergencyName.Name = "txtEmergencyName";
            txtEmergencyName.Size = new Size(343, 27);
            txtEmergencyName.TabIndex = 15;
            txtEmergencyName.TextChanged += txtEmergencyName_TextChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F);
            label15.Location = new Point(15, 34);
            label15.Name = "label15";
            label15.Size = new Size(107, 20);
            label15.TabIndex = 14;
            label15.Text = "Contact Name:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(135, 58);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(270, 27);
            txtFullName.TabIndex = 23;
            txtFullName.TextChanged += txtFullName_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCollege);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label6);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(29, 144);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(568, 170);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Contact Information";
            // 
            // txtCollege
            // 
            txtCollege.Location = new Point(106, 110);
            txtCollege.Name = "txtCollege";
            txtCollege.ReadOnly = true;
            txtCollege.Size = new Size(174, 27);
            txtCollege.TabIndex = 19;
            txtCollege.TextChanged += textBox3_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(15, 114);
            label12.Name = "label12";
            label12.Size = new Size(63, 20);
            label12.TabIndex = 18;
            label12.Text = "College:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(106, 68);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(270, 27);
            txtPhone.TabIndex = 17;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(15, 72);
            label11.Name = "label11";
            label11.Size = new Size(66, 20);
            label11.TabIndex = 16;
            label11.Text = "Phone #:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(106, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(270, 27);
            txtEmail.TabIndex = 15;
            txtEmail.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(15, 34);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 14;
            label6.Text = "Email:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(44, 62);
            label17.Name = "label17";
            label17.Size = new Size(79, 20);
            label17.TabIndex = 22;
            label17.Text = "Full Name:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(44, 24);
            label18.Name = "label18";
            label18.Size = new Size(56, 20);
            label18.TabIndex = 20;
            label18.Text = "UserID:";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(135, 20);
            txtUserID.Name = "txtUserID";
            txtUserID.ReadOnly = true;
            txtUserID.Size = new Size(270, 27);
            txtUserID.TabIndex = 21;
            txtUserID.TextChanged += textBox8_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(251, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(628, 48);
            panel3.TabIndex = 153;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label2.Location = new Point(213, 8);
            label2.Name = "label2";
            label2.Size = new Size(190, 28);
            label2.TabIndex = 2;
            label2.Text = "MEMBER PROFILE";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label4.Location = new Point(662, 6);
            label4.Name = "label4";
            label4.Size = new Size(242, 28);
            label4.TabIndex = 1;
            label4.Text = "RESERVATION DETAILS";
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
            label1.Size = new Size(240, 54);
            label1.TabIndex = 2;
            label1.Text = "My Account";
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
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(chkShowPassword);
            panel4.Controls.Add(btnUpdatePassword);
            panel4.Controls.Add(txtConfirmPassword);
            panel4.Controls.Add(txtNewPassword);
            panel4.Controls.Add(txtCurrentPassword);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(lstActivityOverview);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(885, 78);
            panel4.Name = "panel4";
            panel4.Size = new Size(295, 574);
            panel4.TabIndex = 154;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(31, 395);
            label9.Name = "label9";
            label9.Size = new Size(130, 20);
            label9.TabIndex = 180;
            label9.Text = "Confirm Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(31, 332);
            label8.Name = "label8";
            label8.Size = new Size(107, 20);
            label8.TabIndex = 179;
            label8.Text = "New Password:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 266);
            label7.Name = "label7";
            label7.Size = new Size(125, 20);
            label7.TabIndex = 26;
            label7.Text = "Current Password:";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkShowPassword.Location = new Point(31, 473);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(140, 24);
            chkShowPassword.TabIndex = 178;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnUpdatePassword
            // 
            btnUpdatePassword.BackColor = Color.Gray;
            btnUpdatePassword.FlatAppearance.BorderSize = 0;
            btnUpdatePassword.FlatStyle = FlatStyle.Flat;
            btnUpdatePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdatePassword.ForeColor = Color.White;
            btnUpdatePassword.Location = new Point(31, 515);
            btnUpdatePassword.Name = "btnUpdatePassword";
            btnUpdatePassword.Size = new Size(242, 48);
            btnUpdatePassword.TabIndex = 177;
            btnUpdatePassword.Text = "Update Password";
            btnUpdatePassword.UseVisualStyleBackColor = false;
            btnUpdatePassword.Click += btnUpdatePassword_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(47, 422);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(206, 27);
            txtConfirmPassword.TabIndex = 176;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(47, 356);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(206, 27);
            txtNewPassword.TabIndex = 175;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.TextChanged += txtNewPassword_TextChanged;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(47, 290);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.ReadOnly = true;
            txtCurrentPassword.Size = new Size(206, 27);
            txtCurrentPassword.TabIndex = 174;
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtCurrentPassword.TextChanged += txtCurrentPassword_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 227);
            label5.Name = "label5";
            label5.Size = new Size(198, 25);
            label5.TabIndex = 13;
            label5.Text = "Security and Password";
            // 
            // lstActivityOverview
            // 
            lstActivityOverview.BackColor = SystemColors.Info;
            lstActivityOverview.FormattingEnabled = true;
            lstActivityOverview.Location = new Point(21, 79);
            lstActivityOverview.Name = "lstActivityOverview";
            lstActivityOverview.Size = new Size(264, 124);
            lstActivityOverview.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(14, 51);
            label10.Name = "label10";
            label10.Size = new Size(162, 25);
            label10.TabIndex = 6;
            label10.Text = "Activity Overview:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label3.Location = new Point(47, 8);
            label3.Name = "label3";
            label3.Size = new Size(226, 28);
            label3.TabIndex = 0;
            label3.Text = "ACCOUNT SUMMARY";
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
            // MemberAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "MemberAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MemberAccount";
            Load += MemberAccount_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private Panel panel3;
        private Label label2;
        private Label label4;
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
        private Label label10;
        private Label label3;
        private Button logOut_btn;
        private Panel panel1;
        private TextBox txtRole;
        private Label label16;
        private GroupBox groupBox2;
        private TextBox txtEmergencyPhone;
        private Label lblem;
        private TextBox txtEmergencyName;
        private Label label15;
        private TextBox txtFullName;
        private GroupBox groupBox1;
        private TextBox txtCollege;
        private Label label12;
        private TextBox txtPhone;
        private Label label11;
        private TextBox txtEmail;
        private Label label6;
        private Label label17;
        private Label label18;
        private TextBox txtUserID;
        private Button btnSaveProfile;
        private Label label5;
        private ListBox lstActivityOverview;
        private Label label7;
        private CheckBox chkShowPassword;
        private Button btnUpdatePassword;
        private TextBox txtConfirmPassword;
        private TextBox txtNewPassword;
        private TextBox txtCurrentPassword;
        private Label label9;
        private Label label8;
    }
}