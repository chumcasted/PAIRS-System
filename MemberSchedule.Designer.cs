namespace WinFormsApp2
{
    partial class MemberSchedule
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
            txtEventID = new TextBox();
            txtStatus = new Label();
            label10 = new Label();
            label9 = new Label();
            panel2 = new Panel();
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
            label11 = new Label();
            txtEventType = new TextBox();
            label6 = new Label();
            txtTitle = new TextBox();
            panel4 = new Panel();
            txtVenue = new TextBox();
            label8 = new Label();
            txtTime = new TextBox();
            txtStatus3 = new TextBox();
            btnExportData = new Button();
            label3 = new Label();
            logOut_btn = new Button();
            panel1 = new Panel();
            label1 = new Label();
            pairLbl = new Label();
            panel5 = new Panel();
            dgvSchedule = new DataGridView();
            label4 = new Label();
            label13 = new Label();
            label2 = new Label();
            cmbFilter = new ComboBox();
            cmbMonth = new ComboBox();
            panel3 = new Panel();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtEventID
            // 
            txtEventID.Location = new Point(105, 54);
            txtEventID.Name = "txtEventID";
            txtEventID.ReadOnly = true;
            txtEventID.Size = new Size(174, 27);
            txtEventID.TabIndex = 12;
            txtEventID.TextChanged += txtEventID_TextChanged_1;
            // 
            // txtStatus
            // 
            txtStatus.AutoSize = true;
            txtStatus.Location = new Point(7, 239);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(52, 20);
            txtStatus.TabIndex = 5;
            txtStatus.Text = "Status:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(6, 57);
            label10.Name = "label10";
            label10.Size = new Size(72, 20);
            label10.TabIndex = 6;
            label10.Text = "Event ID:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(6, 92);
            label9.Name = "label9";
            label9.Size = new Size(42, 20);
            label9.TabIndex = 11;
            label9.Text = "Title:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel7);
            panel2.Location = new Point(2, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 570);
            panel2.TabIndex = 157;
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
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 202);
            label11.Name = "label11";
            label11.Size = new Size(44, 20);
            label11.TabIndex = 18;
            label11.Text = "Date:";
            // 
            // txtEventType
            // 
            txtEventType.Location = new Point(105, 127);
            txtEventType.Name = "txtEventType";
            txtEventType.ReadOnly = true;
            txtEventType.Size = new Size(128, 27);
            txtEventType.TabIndex = 16;
            txtEventType.TextChanged += txtEventType_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 130);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 15;
            label6.Text = "Event Type:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(105, 91);
            txtTitle.Name = "txtTitle";
            txtTitle.ReadOnly = true;
            txtTitle.Size = new Size(174, 27);
            txtTitle.TabIndex = 14;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(txtVenue);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(txtTime);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(txtEventType);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtTitle);
            panel4.Controls.Add(txtStatus3);
            panel4.Controls.Add(txtEventID);
            panel4.Controls.Add(txtStatus);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(btnExportData);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(885, 78);
            panel4.Name = "panel4";
            panel4.Size = new Size(295, 574);
            panel4.TabIndex = 159;
            // 
            // txtVenue
            // 
            txtVenue.Location = new Point(105, 162);
            txtVenue.Name = "txtVenue";
            txtVenue.ReadOnly = true;
            txtVenue.Size = new Size(176, 27);
            txtVenue.TabIndex = 82;
            txtVenue.TextChanged += txtVenue_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 165);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 81;
            label8.Text = "Venue:";
            // 
            // txtTime
            // 
            txtTime.Location = new Point(105, 199);
            txtTime.Name = "txtTime";
            txtTime.ReadOnly = true;
            txtTime.Size = new Size(176, 27);
            txtTime.TabIndex = 80;
            txtTime.TextChanged += txtTime_TextChanged;
            // 
            // txtStatus3
            // 
            txtStatus3.BackColor = SystemColors.Info;
            txtStatus3.Location = new Point(105, 236);
            txtStatus3.Name = "txtStatus3";
            txtStatus3.ReadOnly = true;
            txtStatus3.Size = new Size(128, 27);
            txtStatus3.TabIndex = 13;
            txtStatus3.TextChanged += txtStatus3_TextChanged_1;
            // 
            // btnExportData
            // 
            btnExportData.BackColor = Color.LightSeaGreen;
            btnExportData.FlatAppearance.BorderSize = 0;
            btnExportData.FlatStyle = FlatStyle.Flat;
            btnExportData.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportData.ForeColor = SystemColors.ButtonFace;
            btnExportData.Location = new Point(10, 296);
            btnExportData.Name = "btnExportData";
            btnExportData.Size = new Size(271, 61);
            btnExportData.TabIndex = 6;
            btnExportData.Text = "Export Data";
            btnExportData.UseVisualStyleBackColor = false;
            btnExportData.Click += btnExport_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label3.Location = new Point(67, 8);
            label3.Name = "label3";
            label3.Size = new Size(166, 28);
            label3.TabIndex = 0;
            label3.Text = "EVENT DETAILS";
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
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1178, 78);
            panel1.TabIndex = 156;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(147, 7);
            label1.Name = "label1";
            label1.Size = new Size(392, 54);
            label1.TabIndex = 2;
            label1.Text = "Schedule and Events";
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
            // panel5
            // 
            panel5.Controls.Add(dgvSchedule);
            panel5.Location = new Point(258, 132);
            panel5.Name = "panel5";
            panel5.Size = new Size(621, 520);
            panel5.TabIndex = 160;
            // 
            // dgvSchedule
            // 
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.BackgroundColor = Color.LightGray;
            dgvSchedule.BorderStyle = BorderStyle.Fixed3D;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Location = new Point(3, 0);
            dgvSchedule.MultiSelect = false;
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersWidth = 51;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.Size = new Size(615, 517);
            dgvSchedule.TabIndex = 77;
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
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(11, 13);
            label13.Name = "label13";
            label13.Size = new Size(60, 20);
            label13.TabIndex = 79;
            label13.Text = "Month:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(271, 13);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 4;
            label2.Text = "Filter:";
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(326, 8);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(178, 28);
            cmbFilter.TabIndex = 3;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // cmbMonth
            // 
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(72, 8);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(176, 28);
            cmbMonth.TabIndex = 78;
            cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(cmbMonth);
            panel3.Controls.Add(cmbFilter);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(251, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(929, 48);
            panel3.TabIndex = 158;
            // 
            // MemberSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Name = "MemberSchedule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MemberSchedule";
            Load += MemberSchedule_Load;
            panel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtEventID;
        private Label txtStatus;
        private Label label10;
        private Label label9;
        private Panel panel2;
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
        private Label label11;
        private TextBox txtEventType;
        private Label label6;
        private TextBox txtTitle;
        private Panel panel4;
        private Button btnExportData;
        private Label label3;
        private Button logOut_btn;
        private Panel panel1;
        private Label label1;
        private Label pairLbl;
        private Panel panel5;
        private DataGridView dgvSchedule;
        private TextBox txtTime;
        private Label label4;
        private Label label13;
        private Label label2;
        private ComboBox cmbFilter;
        private ComboBox cmbMonth;
        private Panel panel3;
        private TextBox txtStatus3;
        private TextBox txtVenue;
        private Label label8;
    }
}