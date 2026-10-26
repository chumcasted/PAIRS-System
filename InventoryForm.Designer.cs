namespace WinFormsApp2
{
    partial class InventoryPairs
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
            label1 = new Label();
            pairLbl = new Label();
            txtItemID = new TextBox();
            txtItemName = new TextBox();
            txtLocation = new TextBox();
            cmbStatus = new ComboBox();
            cmbCategory = new ComboBox();
            numQuantity = new NumericUpDown();
            idLbl = new Label();
            itemNameLbl = new Label();
            statusLbl = new Label();
            quantityLbl = new Label();
            categoryLbl = new Label();
            label7 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            linkLabel5 = new LinkLabel();
            linkLabel6 = new LinkLabel();
            linkLabel7 = new LinkLabel();
            linkLabel8 = new LinkLabel();
            clearButton = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvInventory = new DataGridView();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            inchargelbl = new Label();
            txtInCharge = new TextBox();
            grpImagePreview = new GroupBox();
            btnRemoveImage = new Button();
            btnBrowseImage = new Button();
            picItemImage = new PictureBox();
            logOut_btn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            grpImagePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picItemImage).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Maroon;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pairLbl);
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1178, 78);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(10, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 570);
            panel2.TabIndex = 123;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Firebrick;
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
            btnSettings.BackColor = Color.Firebrick;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Image = Properties.Resources.settings;
            btnSettings.Location = new Point(3, 480);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(51, 52);
            btnSettings.TabIndex = 23;
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.Firebrick;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Image = Properties.Resources.users;
            btnUsers.Location = new Point(12, 426);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(42, 39);
            btnUsers.TabIndex = 22;
            btnUsers.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.Firebrick;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Image = Properties.Resources.reports;
            btnReports.Location = new Point(12, 342);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(42, 52);
            btnReports.TabIndex = 21;
            btnReports.UseVisualStyleBackColor = false;
            // 
            // btnperformances
            // 
            btnperformances.BackColor = Color.Firebrick;
            btnperformances.FlatAppearance.BorderSize = 0;
            btnperformances.FlatStyle = FlatStyle.Flat;
            btnperformances.Image = Properties.Resources.performances;
            btnperformances.Location = new Point(12, 278);
            btnperformances.Name = "btnperformances";
            btnperformances.Size = new Size(42, 42);
            btnperformances.TabIndex = 20;
            btnperformances.UseVisualStyleBackColor = false;
            // 
            // btnborrowreturn
            // 
            btnborrowreturn.BackColor = Color.Firebrick;
            btnborrowreturn.FlatAppearance.BorderSize = 0;
            btnborrowreturn.FlatStyle = FlatStyle.Flat;
            btnborrowreturn.Image = Properties.Resources.borrow_return;
            btnborrowreturn.Location = new Point(12, 215);
            btnborrowreturn.Name = "btnborrowreturn";
            btnborrowreturn.Size = new Size(42, 42);
            btnborrowreturn.TabIndex = 19;
            btnborrowreturn.UseVisualStyleBackColor = false;
            // 
            // btreservations
            // 
            btreservations.BackColor = Color.Firebrick;
            btreservations.FlatAppearance.BorderSize = 0;
            btreservations.FlatStyle = FlatStyle.Flat;
            btreservations.Image = Properties.Resources.reservations;
            btreservations.Location = new Point(12, 144);
            btreservations.Name = "btreservations";
            btreservations.Size = new Size(42, 45);
            btreservations.TabIndex = 18;
            btreservations.UseVisualStyleBackColor = false;
            // 
            // btninventory
            // 
            btninventory.BackColor = Color.Firebrick;
            btninventory.FlatAppearance.BorderSize = 0;
            btninventory.FlatStyle = FlatStyle.Flat;
            btninventory.ForeColor = Color.Transparent;
            btninventory.Image = Properties.Resources.inventory;
            btninventory.Location = new Point(12, 82);
            btninventory.Name = "btninventory";
            btninventory.Size = new Size(42, 41);
            btninventory.TabIndex = 17;
            btninventory.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Firebrick;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.Image = Properties.Resources.dashboard;
            btnDashboard.Location = new Point(12, 13);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(42, 43);
            btnDashboard.TabIndex = 16;
            btnDashboard.UseVisualStyleBackColor = false;
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
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Maroon;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(147, 7);
            label1.Name = "label1";
            label1.Size = new Size(441, 54);
            label1.TabIndex = 2;
            label1.Text = "Inventory Maintenance";
            label1.Click += label1_Click_1;
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
            pairLbl.Click += label1_Click;
            // 
            // txtItemID
            // 
            txtItemID.Location = new Point(272, 378);
            txtItemID.Name = "txtItemID";
            txtItemID.Size = new Size(192, 27);
            txtItemID.TabIndex = 1;
            txtItemID.TextChanged += textBox1_TextChanged;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(272, 438);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(192, 27);
            txtItemName.TabIndex = 2;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(526, 500);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(192, 27);
            txtLocation.TabIndex = 3;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Available", "Archived", "Borrowed", "Reserved", "Damaged", "Maintenance" });
            cmbStatus.Location = new Point(272, 500);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(192, 28);
            cmbStatus.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Audio", "Lighting", "Musical Instruments", "Costumes & Apparel", "Props", "Stage Equipment", "General" });
            cmbCategory.Location = new Point(526, 437);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(192, 28);
            cmbCategory.TabIndex = 5;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(526, 378);
            numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(192, 27);
            numQuantity.TabIndex = 6;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // idLbl
            // 
            idLbl.AutoSize = true;
            idLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            idLbl.Location = new Point(272, 345);
            idLbl.Name = "idLbl";
            idLbl.Size = new Size(62, 20);
            idLbl.TabIndex = 7;
            idLbl.Text = "Item ID";
            // 
            // itemNameLbl
            // 
            itemNameLbl.AutoSize = true;
            itemNameLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            itemNameLbl.Location = new Point(272, 409);
            itemNameLbl.Name = "itemNameLbl";
            itemNameLbl.Size = new Size(88, 20);
            itemNameLbl.TabIndex = 8;
            itemNameLbl.Text = "Item Name";
            itemNameLbl.Click += label3_Click;
            // 
            // statusLbl
            // 
            statusLbl.AutoSize = true;
            statusLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            statusLbl.Location = new Point(272, 472);
            statusLbl.Name = "statusLbl";
            statusLbl.Size = new Size(53, 20);
            statusLbl.TabIndex = 9;
            statusLbl.Text = "Status";
            statusLbl.Click += statusLbl_Click;
            // 
            // quantityLbl
            // 
            quantityLbl.AutoSize = true;
            quantityLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            quantityLbl.Location = new Point(526, 345);
            quantityLbl.Name = "quantityLbl";
            quantityLbl.Size = new Size(70, 20);
            quantityLbl.TabIndex = 10;
            quantityLbl.Text = "Quantity";
            // 
            // categoryLbl
            // 
            categoryLbl.AutoSize = true;
            categoryLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            categoryLbl.Location = new Point(528, 409);
            categoryLbl.Name = "categoryLbl";
            categoryLbl.Size = new Size(73, 20);
            categoryLbl.TabIndex = 11;
            categoryLbl.Text = "Category";
            categoryLbl.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(527, 472);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 12;
            label7.Text = "Location";
            label7.Click += label7_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(224, 224, 224);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(2, 80);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 570);
            panel4.TabIndex = 123;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Maroon;
            panel5.Controls.Add(button1);
            panel5.Controls.Add(button2);
            panel5.Controls.Add(button3);
            panel5.Controls.Add(button4);
            panel5.Controls.Add(button5);
            panel5.Controls.Add(button6);
            panel5.Controls.Add(button7);
            panel5.Controls.Add(button8);
            panel5.Controls.Add(linkLabel1);
            panel5.Controls.Add(linkLabel2);
            panel5.Controls.Add(linkLabel3);
            panel5.Controls.Add(linkLabel4);
            panel5.Controls.Add(linkLabel5);
            panel5.Controls.Add(linkLabel6);
            panel5.Controls.Add(linkLabel7);
            panel5.Controls.Add(linkLabel8);
            panel5.ForeColor = Color.Transparent;
            panel5.Location = new Point(23, 16);
            panel5.Name = "panel5";
            panel5.Size = new Size(198, 544);
            panel5.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Maroon;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.settings;
            button1.Location = new Point(3, 480);
            button1.Name = "button1";
            button1.Size = new Size(51, 52);
            button1.TabIndex = 23;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Maroon;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = Properties.Resources.users;
            button2.Location = new Point(12, 426);
            button2.Name = "button2";
            button2.Size = new Size(42, 39);
            button2.TabIndex = 22;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Maroon;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = Properties.Resources.reports;
            button3.Location = new Point(12, 342);
            button3.Name = "button3";
            button3.Size = new Size(42, 52);
            button3.TabIndex = 21;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Maroon;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = Properties.Resources.performances;
            button4.Location = new Point(12, 278);
            button4.Name = "button4";
            button4.Size = new Size(42, 42);
            button4.TabIndex = 20;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Maroon;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = Properties.Resources.borrow_return;
            button5.Location = new Point(12, 215);
            button5.Name = "button5";
            button5.Size = new Size(42, 42);
            button5.TabIndex = 19;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Maroon;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = Properties.Resources.reservations;
            button6.Location = new Point(12, 144);
            button6.Name = "button6";
            button6.Size = new Size(42, 45);
            button6.TabIndex = 18;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Maroon;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.Transparent;
            button7.Image = Properties.Resources.inventory;
            button7.Location = new Point(12, 82);
            button7.Name = "button7";
            button7.Size = new Size(42, 41);
            button7.TabIndex = 17;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Maroon;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Image = Properties.Resources.dashboard;
            button8.Location = new Point(12, 13);
            button8.Name = "button8";
            button8.Size = new Size(42, 43);
            button8.TabIndex = 16;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel1.LinkColor = Color.White;
            linkLabel1.Location = new Point(60, 491);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(66, 20);
            linkLabel1.TabIndex = 15;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Settings";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel2.LinkColor = Color.White;
            linkLabel2.Location = new Point(60, 435);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(48, 20);
            linkLabel2.TabIndex = 14;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Users";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLabel3.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel3.LinkColor = Color.White;
            linkLabel3.Location = new Point(60, 360);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(64, 20);
            linkLabel3.TabIndex = 13;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Reports";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLabel4.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel4.LinkColor = Color.White;
            linkLabel4.Location = new Point(60, 289);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(106, 20);
            linkLabel4.TabIndex = 12;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Performances";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLabel5.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel5.LinkColor = Color.White;
            linkLabel5.Location = new Point(60, 225);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(124, 20);
            linkLabel5.TabIndex = 11;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "Borrow / Return";
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLabel6.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel6.LinkColor = Color.White;
            linkLabel6.Location = new Point(60, 156);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new Size(100, 20);
            linkLabel6.TabIndex = 10;
            linkLabel6.TabStop = true;
            linkLabel6.Text = "Reservations";
            linkLabel6.LinkClicked += linkLabel6_LinkClicked;
            // 
            // linkLabel7
            // 
            linkLabel7.AutoSize = true;
            linkLabel7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLabel7.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel7.LinkColor = Color.White;
            linkLabel7.Location = new Point(60, 92);
            linkLabel7.Name = "linkLabel7";
            linkLabel7.Size = new Size(78, 20);
            linkLabel7.TabIndex = 9;
            linkLabel7.TabStop = true;
            linkLabel7.Text = "Inventory";
            linkLabel7.LinkClicked += linkLabel7_LinkClicked;
            // 
            // linkLabel8
            // 
            linkLabel8.AutoSize = true;
            linkLabel8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel8.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel8.LinkColor = Color.White;
            linkLabel8.Location = new Point(60, 22);
            linkLabel8.Name = "linkLabel8";
            linkLabel8.Size = new Size(85, 20);
            linkLabel8.TabIndex = 8;
            linkLabel8.TabStop = true;
            linkLabel8.Text = "Dashboard";
            linkLabel8.LinkClicked += linkLabel8_LinkClicked;
            // 
            // clearButton
            // 
            clearButton.BackColor = Color.Gainsboro;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            clearButton.ForeColor = Color.Black;
            clearButton.Location = new Point(740, 595);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(200, 40);
            clearButton.TabIndex = 127;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SteelBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.WhiteSmoke;
            btnSearch.Location = new Point(1068, 91);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 39);
            btnSearch.TabIndex = 126;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(740, 96);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search item";
            txtSearch.Size = new Size(200, 31);
            txtSearch.TabIndex = 125;
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.BackgroundColor = Color.SteelBlue;
            dgvInventory.BorderStyle = BorderStyle.Fixed3D;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.GridColor = Color.White;
            dgvInventory.Location = new Point(740, 136);
            dgvInventory.MultiSelect = false;
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(433, 449);
            dgvInventory.TabIndex = 124;
            dgvInventory.CellClick += dgvInventory_CellClick;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.WhiteSmoke;
            btnDelete.Location = new Point(580, 592);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 51);
            btnDelete.TabIndex = 131;
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
            btnUpdate.Location = new Point(425, 592);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 51);
            btnUpdate.TabIndex = 130;
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
            btnAdd.Location = new Point(267, 592);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 51);
            btnAdd.TabIndex = 129;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // inchargelbl
            // 
            inchargelbl.AutoSize = true;
            inchargelbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            inchargelbl.Location = new Point(272, 531);
            inchargelbl.Name = "inchargelbl";
            inchargelbl.Size = new Size(131, 20);
            inchargelbl.TabIndex = 9;
            inchargelbl.Text = "Person-in-Charge";
            // 
            // txtInCharge
            // 
            txtInCharge.Location = new Point(275, 557);
            txtInCharge.Name = "txtInCharge";
            txtInCharge.Size = new Size(192, 27);
            txtInCharge.TabIndex = 3;
            // 
            // grpImagePreview
            // 
            grpImagePreview.Controls.Add(btnRemoveImage);
            grpImagePreview.Controls.Add(btnBrowseImage);
            grpImagePreview.Controls.Add(picItemImage);
            grpImagePreview.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpImagePreview.Location = new Point(289, 96);
            grpImagePreview.Name = "grpImagePreview";
            grpImagePreview.Size = new Size(419, 229);
            grpImagePreview.TabIndex = 132;
            grpImagePreview.TabStop = false;
            grpImagePreview.Text = "Equipment Image Preview";
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.BackColor = Color.Firebrick;
            btnRemoveImage.ForeColor = SystemColors.ControlLightLight;
            btnRemoveImage.Location = new Point(237, 169);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(129, 43);
            btnRemoveImage.TabIndex = 2;
            btnRemoveImage.Text = "Remove Image";
            btnRemoveImage.UseVisualStyleBackColor = false;
            btnRemoveImage.Click += btnRemoveImage_Click;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.BackColor = Color.FromArgb(0, 192, 192);
            btnBrowseImage.ForeColor = SystemColors.ControlLightLight;
            btnBrowseImage.Location = new Point(46, 169);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(129, 43);
            btnBrowseImage.TabIndex = 1;
            btnBrowseImage.Text = "Browse Image...";
            btnBrowseImage.UseVisualStyleBackColor = false;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // picItemImage
            // 
            picItemImage.BorderStyle = BorderStyle.FixedSingle;
            picItemImage.Location = new Point(26, 26);
            picItemImage.Name = "picItemImage";
            picItemImage.Size = new Size(367, 137);
            picItemImage.SizeMode = PictureBoxSizeMode.Zoom;
            picItemImage.TabIndex = 0;
            picItemImage.TabStop = false;
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
            logOut_btn.TabIndex = 133;
            logOut_btn.UseVisualStyleBackColor = false;
            logOut_btn.Click += logOut_btn_Click;
            // 
            // InventoryPairs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1182, 653);
            Controls.Add(logOut_btn);
            Controls.Add(grpImagePreview);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(clearButton);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvInventory);
            Controls.Add(panel4);
            Controls.Add(label7);
            Controls.Add(categoryLbl);
            Controls.Add(quantityLbl);
            Controls.Add(inchargelbl);
            Controls.Add(statusLbl);
            Controls.Add(itemNameLbl);
            Controls.Add(idLbl);
            Controls.Add(numQuantity);
            Controls.Add(cmbCategory);
            Controls.Add(cmbStatus);
            Controls.Add(txtInCharge);
            Controls.Add(txtLocation);
            Controls.Add(txtItemName);
            Controls.Add(txtItemID);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "InventoryPairs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InventoryForm";
            Load += InventoryPairs_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            grpImagePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picItemImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label pairLbl;
        private Label label1;
        private TextBox txtItemID;
        private TextBox txtItemName;
        private TextBox txtLocation;
        private ComboBox cmbStatus;
        private ComboBox cmbCategory;
        private NumericUpDown numQuantity;
        private Label idLbl;
        private Label itemNameLbl;
        private Label statusLbl;
        private Label quantityLbl;
        private Label categoryLbl;
        private Label label7;
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
        private Panel panel4;
        private Panel panel5;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel6;
        private LinkLabel linkLabel7;
        private LinkLabel linkLabel8;
        private Button clearButton;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView dgvInventory;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label inchargelbl;
        private TextBox txtInCharge;
        private GroupBox grpImagePreview;
        private Button btnRemoveImage;
        private Button btnBrowseImage;
        private PictureBox picItemImage;
        private Button logOut_btn;
    }
}