namespace WinFormsApp2
{
    partial class Settings
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            pairLbl = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            txtContactEmail = new TextBox();
            cmbTimeZone = new ComboBox();
            txtOrganization = new TextBox();
            txtSystemName = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label3 = new Label();
            panel5 = new Panel();
            chkEnableLowStock = new CheckBox();
            numAutoCancel = new NumericUpDown();
            numMaxItems = new NumericUpDown();
            numBorrowDuration = new NumericUpDown();
            numLowStockThreshold = new NumericUpDown();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label4 = new Label();
            panel6 = new Panel();
            checkShowPass = new CheckBox();
            btnUpdatePassword = new Button();
            label21 = new Label();
            label20 = new Label();
            txtConfirmPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtCurrentPassword = new TextBox();
            txtUserName = new TextBox();
            label16 = new Label();
            label15 = new Label();
            label5 = new Label();
            panel7 = new Panel();
            txtTargetDatabase = new TextBox();
            txtLastBackup = new TextBox();
            btnBackupNow = new Button();
            btnBrowse = new Button();
            txtBackupLocation = new TextBox();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label6 = new Label();
            label2 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnResetDefaults = new Button();
            btnSaveChanges = new Button();
            btnCancel = new Button();
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
            logOut_btn = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAutoCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBorrowDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLowStockThreshold).BeginInit();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(147, 7);
            label1.Name = "label1";
            label1.Size = new Size(168, 54);
            label1.TabIndex = 2;
            label1.Text = "Settings";
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
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pairLbl);
            panel1.Location = new Point(2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1178, 78);
            panel1.TabIndex = 149;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gainsboro;
            panel4.Controls.Add(txtContactEmail);
            panel4.Controls.Add(cmbTimeZone);
            panel4.Controls.Add(txtOrganization);
            panel4.Controls.Add(txtSystemName);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(270, 140);
            panel4.Name = "panel4";
            panel4.Size = new Size(433, 220);
            panel4.TabIndex = 164;
            // 
            // txtContactEmail
            // 
            txtContactEmail.Location = new Point(119, 131);
            txtContactEmail.Name = "txtContactEmail";
            txtContactEmail.ReadOnly = true;
            txtContactEmail.Size = new Size(290, 27);
            txtContactEmail.TabIndex = 57;
            txtContactEmail.Text = "umatter@dmmmsu.edu.ph";
            txtContactEmail.TextChanged += txtContactEmail_TextChanged;
            // 
            // cmbTimeZone
            // 
            cmbTimeZone.FormattingEnabled = true;
            cmbTimeZone.Location = new Point(119, 177);
            cmbTimeZone.Name = "cmbTimeZone";
            cmbTimeZone.Size = new Size(290, 28);
            cmbTimeZone.TabIndex = 56;
            cmbTimeZone.SelectedIndexChanged += cmbTimeZone_SelectedIndexChanged;
            // 
            // txtOrganization
            // 
            txtOrganization.Location = new Point(119, 90);
            txtOrganization.Name = "txtOrganization";
            txtOrganization.ReadOnly = true;
            txtOrganization.Size = new Size(290, 27);
            txtOrganization.TabIndex = 6;
            txtOrganization.Text = "U-Matter Performing Arts";
            txtOrganization.TextChanged += textBox2_TextChanged;
            // 
            // txtSystemName
            // 
            txtSystemName.Location = new Point(119, 50);
            txtSystemName.Name = "txtSystemName";
            txtSystemName.ReadOnly = true;
            txtSystemName.Size = new Size(290, 27);
            txtSystemName.TabIndex = 5;
            txtSystemName.Text = "PAIRS - Performing Arts Inventory & Reservation System";
            txtSystemName.TextChanged += txtSystemName_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 177);
            label10.Name = "label10";
            label10.Size = new Size(80, 20);
            label10.TabIndex = 4;
            label10.Text = "Time Zone";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 134);
            label9.Name = "label9";
            label9.Size = new Size(101, 20);
            label9.TabIndex = 3;
            label9.Text = "Contact Email";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 93);
            label8.Name = "label8";
            label8.Size = new Size(95, 20);
            label8.TabIndex = 2;
            label8.Text = "Organization";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 53);
            label7.Name = "label7";
            label7.Size = new Size(100, 20);
            label7.TabIndex = 1;
            label7.Text = "System Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 14);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 0;
            label3.Text = "General Settings";
            label3.Click += label3_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Gainsboro;
            panel5.Controls.Add(chkEnableLowStock);
            panel5.Controls.Add(numAutoCancel);
            panel5.Controls.Add(numMaxItems);
            panel5.Controls.Add(numBorrowDuration);
            panel5.Controls.Add(numLowStockThreshold);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(723, 140);
            panel5.Name = "panel5";
            panel5.Size = new Size(433, 220);
            panel5.TabIndex = 165;
            panel5.Paint += panel5_Paint;
            // 
            // chkEnableLowStock
            // 
            chkEnableLowStock.AutoSize = true;
            chkEnableLowStock.Location = new Point(15, 51);
            chkEnableLowStock.Name = "chkEnableLowStock";
            chkEnableLowStock.Size = new Size(203, 24);
            chkEnableLowStock.TabIndex = 13;
            chkEnableLowStock.Text = "Low Stock Alert Threshold";
            chkEnableLowStock.UseVisualStyleBackColor = true;
            chkEnableLowStock.CheckedChanged += chkEnableLowStock_CheckedChanged;
            // 
            // numAutoCancel
            // 
            numAutoCancel.Location = new Point(296, 172);
            numAutoCancel.Name = "numAutoCancel";
            numAutoCancel.Size = new Size(64, 27);
            numAutoCancel.TabIndex = 12;
            numAutoCancel.ValueChanged += numAutoCancel_ValueChanged;
            // 
            // numMaxItems
            // 
            numMaxItems.Location = new Point(296, 127);
            numMaxItems.Name = "numMaxItems";
            numMaxItems.Size = new Size(64, 27);
            numMaxItems.TabIndex = 11;
            numMaxItems.ValueChanged += numMaxItems_ValueChanged;
            // 
            // numBorrowDuration
            // 
            numBorrowDuration.Location = new Point(296, 90);
            numBorrowDuration.Name = "numBorrowDuration";
            numBorrowDuration.Size = new Size(64, 27);
            numBorrowDuration.TabIndex = 10;
            numBorrowDuration.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // numLowStockThreshold
            // 
            numLowStockThreshold.Location = new Point(296, 50);
            numLowStockThreshold.Name = "numLowStockThreshold";
            numLowStockThreshold.Size = new Size(64, 27);
            numLowStockThreshold.TabIndex = 9;
            numLowStockThreshold.ValueChanged += numLowStockThreshold_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 177);
            label11.Name = "label11";
            label11.Size = new Size(273, 20);
            label11.TabIndex = 8;
            label11.Text = "Auto-Cancel Pending Reservation (days)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 134);
            label12.Name = "label12";
            label12.Size = new Size(166, 20);
            label12.TabIndex = 7;
            label12.Text = "Max Items Per Borrower";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 93);
            label13.Name = "label13";
            label13.Size = new Size(216, 20);
            label13.TabIndex = 6;
            label13.Text = "Default Borrow Duration ()days";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 14);
            label4.Name = "label4";
            label4.Size = new Size(230, 25);
            label4.TabIndex = 1;
            label4.Text = "Loan and Inventory Rules";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Gainsboro;
            panel6.Controls.Add(checkShowPass);
            panel6.Controls.Add(btnUpdatePassword);
            panel6.Controls.Add(label21);
            panel6.Controls.Add(label20);
            panel6.Controls.Add(txtConfirmPassword);
            panel6.Controls.Add(txtNewPassword);
            panel6.Controls.Add(txtCurrentPassword);
            panel6.Controls.Add(txtUserName);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(label15);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(270, 377);
            panel6.Name = "panel6";
            panel6.Size = new Size(433, 220);
            panel6.TabIndex = 165;
            // 
            // checkShowPass
            // 
            checkShowPass.AutoSize = true;
            checkShowPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkShowPass.Location = new Point(122, 188);
            checkShowPass.Name = "checkShowPass";
            checkShowPass.Size = new Size(140, 24);
            checkShowPass.TabIndex = 173;
            checkShowPass.Text = "Show Password";
            checkShowPass.UseVisualStyleBackColor = true;
            checkShowPass.CheckedChanged += check_CheckedChanged;
            // 
            // btnUpdatePassword
            // 
            btnUpdatePassword.BackColor = Color.Gray;
            btnUpdatePassword.FlatAppearance.BorderSize = 0;
            btnUpdatePassword.FlatStyle = FlatStyle.Flat;
            btnUpdatePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdatePassword.ForeColor = Color.White;
            btnUpdatePassword.Location = new Point(270, 184);
            btnUpdatePassword.Name = "btnUpdatePassword";
            btnUpdatePassword.Size = new Size(139, 33);
            btnUpdatePassword.TabIndex = 172;
            btnUpdatePassword.Text = "Update Password";
            btnUpdatePassword.UseVisualStyleBackColor = false;
            btnUpdatePassword.Click += btnUpdatePassword_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(14, 155);
            label21.Name = "label21";
            label21.Size = new Size(161, 20);
            label21.TabIndex = 72;
            label21.Text = "Confirm New Password";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(14, 122);
            label20.Name = "label20";
            label20.Size = new Size(104, 20);
            label20.TabIndex = 71;
            label20.Text = "New Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(203, 151);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(206, 27);
            txtConfirmPassword.TabIndex = 70;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(203, 117);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(206, 27);
            txtNewPassword.TabIndex = 69;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.TextChanged += txtNewPassword_TextChanged;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(203, 83);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.ReadOnly = true;
            txtCurrentPassword.Size = new Size(206, 27);
            txtCurrentPassword.TabIndex = 68;
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtCurrentPassword.TextChanged += txtCurrentPassword_TextChanged;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(203, 50);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(206, 27);
            txtUserName.TabIndex = 67;
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(14, 85);
            label16.Name = "label16";
            label16.Size = new Size(122, 20);
            label16.TabIndex = 58;
            label16.Text = "Current Password";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(13, 49);
            label15.Name = "label15";
            label15.Size = new Size(82, 20);
            label15.TabIndex = 3;
            label15.Text = "User Name";
            label15.Click += label15_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(13, 19);
            label5.Name = "label5";
            label5.Size = new Size(194, 25);
            label5.TabIndex = 2;
            label5.Text = "Account and Security";
            // 
            // panel7
            // 
            panel7.BackColor = Color.Gainsboro;
            panel7.Controls.Add(txtTargetDatabase);
            panel7.Controls.Add(txtLastBackup);
            panel7.Controls.Add(btnBackupNow);
            panel7.Controls.Add(btnBrowse);
            panel7.Controls.Add(txtBackupLocation);
            panel7.Controls.Add(label19);
            panel7.Controls.Add(label18);
            panel7.Controls.Add(label17);
            panel7.Controls.Add(label6);
            panel7.Location = new Point(723, 377);
            panel7.Name = "panel7";
            panel7.Size = new Size(433, 220);
            panel7.TabIndex = 165;
            // 
            // txtTargetDatabase
            // 
            txtTargetDatabase.Location = new Point(179, 57);
            txtTargetDatabase.Name = "txtTargetDatabase";
            txtTargetDatabase.Size = new Size(154, 27);
            txtTargetDatabase.TabIndex = 70;
            txtTargetDatabase.TextChanged += txtTargetDatabase_TextChanged;
            // 
            // txtLastBackup
            // 
            txtLastBackup.Location = new Point(179, 135);
            txtLastBackup.Name = "txtLastBackup";
            txtLastBackup.ReadOnly = true;
            txtLastBackup.Size = new Size(215, 27);
            txtLastBackup.TabIndex = 69;
            txtLastBackup.TextChanged += txtLastBackup_TextChanged;
            // 
            // btnBackupNow
            // 
            btnBackupNow.BackColor = Color.Firebrick;
            btnBackupNow.FlatAppearance.BorderSize = 0;
            btnBackupNow.FlatStyle = FlatStyle.Flat;
            btnBackupNow.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackupNow.ForeColor = Color.White;
            btnBackupNow.Location = new Point(15, 176);
            btnBackupNow.Name = "btnBackupNow";
            btnBackupNow.Size = new Size(118, 35);
            btnBackupNow.TabIndex = 68;
            btnBackupNow.Text = "Backup Now";
            btnBackupNow.UseVisualStyleBackColor = false;
            btnBackupNow.Click += button2_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.Goldenrod;
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Location = new Point(341, 94);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(79, 29);
            btnBrowse.TabIndex = 67;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += button1_Click;
            // 
            // txtBackupLocation
            // 
            txtBackupLocation.Location = new Point(179, 94);
            txtBackupLocation.Name = "txtBackupLocation";
            txtBackupLocation.Size = new Size(154, 27);
            txtBackupLocation.TabIndex = 66;
            txtBackupLocation.TextChanged += txtBackupLocation_TextChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(15, 97);
            label19.Name = "label19";
            label19.Size = new Size(118, 20);
            label19.TabIndex = 65;
            label19.Text = "Backup Location";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(15, 135);
            label18.Name = "label18";
            label18.Size = new Size(158, 20);
            label18.TabIndex = 64;
            label18.Text = "Last Successful Backup";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(15, 57);
            label17.Name = "label17";
            label17.Size = new Size(117, 20);
            label17.TabIndex = 63;
            label17.Text = "Target Database";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 19);
            label6.Name = "label6";
            label6.Size = new Size(228, 25);
            label6.TabIndex = 3;
            label6.Text = "Backup and Maintenance";
            label6.Click += label6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(270, 83);
            label2.Name = "label2";
            label2.Size = new Size(150, 46);
            label2.TabIndex = 166;
            label2.Text = "Settings";
            label2.Click += label2_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnResetDefaults
            // 
            btnResetDefaults.BackColor = Color.ForestGreen;
            btnResetDefaults.FlatAppearance.BorderSize = 0;
            btnResetDefaults.FlatStyle = FlatStyle.Flat;
            btnResetDefaults.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetDefaults.ForeColor = Color.White;
            btnResetDefaults.Location = new Point(270, 606);
            btnResetDefaults.Name = "btnResetDefaults";
            btnResetDefaults.Size = new Size(150, 35);
            btnResetDefaults.TabIndex = 69;
            btnResetDefaults.Text = "Reset to Defaults";
            btnResetDefaults.UseVisualStyleBackColor = false;
            btnResetDefaults.Click += btnResetDefaults_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackColor = Color.SteelBlue;
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(874, 606);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(139, 35);
            btnSaveChanges.TabIndex = 168;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gainsboro;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(1019, 606);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(139, 35);
            btnCancel.TabIndex = 169;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(2, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 570);
            panel2.TabIndex = 170;
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
            logOut_btn.TabIndex = 171;
            logOut_btn.UseVisualStyleBackColor = false;
            logOut_btn.Click += logOut_btn_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1182, 653);
            Controls.Add(logOut_btn);
            Controls.Add(panel2);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnResetDefaults);
            Controls.Add(label2);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            Load += Settings_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAutoCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBorrowDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLowStockThreshold).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label pairLbl;
        private Panel panel1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtOrganization;
        private TextBox txtSystemName;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cmbTimeZone;
        private NumericUpDown numBorrowDuration;
        private NumericUpDown numLowStockThreshold;
        private Label label15;
        private Label label16;
        private Label label19;
        private Label label18;
        private Label label17;
        private TextBox txtBackupLocation;
        private Button btnBrowse;
        private Button btnBackupNow;
        private Button btnResetDefaults;
        private Button btnSaveChanges;
        private Button btnCancel;
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
        private Button logOut_btn;
        private TextBox txtContactEmail;
        private NumericUpDown numAutoCancel;
        private NumericUpDown numMaxItems;
        private TextBox txtUserName;
        private Label label21;
        private Label label20;
        private TextBox txtConfirmPassword;
        private TextBox txtNewPassword;
        private TextBox txtCurrentPassword;
        private Button btnUpdatePassword;
        private TextBox txtTargetDatabase;
        private TextBox txtLastBackup;
        private CheckBox checkShowPass;
        private CheckBox chkEnableLowStock;
    }
}