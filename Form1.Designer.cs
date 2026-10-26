namespace WinFormsApp2
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            panelLeft = new Panel();
            labelpair3 = new Label();
            labelpairs2 = new Label();
            lblTitle = new Label();
            pnlLoginCard = new Panel();
            forgetLink = new LinkLabel();
            contactlink = new LinkLabel();
            label3 = new Label();
            needlabel = new Label();
            dividerlabel = new Label();
            exitButton = new Button();
            loginbutton = new Button();
            password_txtBox = new TextBox();
            email_txtBox = new TextBox();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            panelRight = new Panel();
            pairsLogo = new PictureBox();
            label6 = new Label();
            label5 = new Label();
            panelLeft.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pairsLogo).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.Gray;
            panelLeft.Controls.Add(labelpair3);
            panelLeft.Controls.Add(labelpairs2);
            panelLeft.Controls.Add(lblTitle);
            panelLeft.Controls.Add(pnlLoginCard);
            panelLeft.Controls.Add(label4);
            panelLeft.Controls.Add(label2);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(604, 653);
            panelLeft.TabIndex = 0;
            panelLeft.Paint += panel1_Paint;
            // 
            // labelpair3
            // 
            labelpair3.AutoSize = true;
            labelpair3.BackColor = Color.Transparent;
            labelpair3.Font = new Font("Bebas Neue", 13.8F);
            labelpair3.Location = new Point(221, 64);
            labelpair3.Name = "labelpair3";
            labelpair3.Size = new Size(194, 30);
            labelpair3.TabIndex = 2;
            labelpair3.Text = "and Reservation System";
            labelpair3.Click += label1_Click_1;
            // 
            // labelpairs2
            // 
            labelpairs2.AutoSize = true;
            labelpairs2.Font = new Font("Bebas Neue", 13.8F);
            labelpairs2.Location = new Point(221, 34);
            labelpairs2.Name = "labelpairs2";
            labelpairs2.Size = new Size(219, 30);
            labelpairs2.TabIndex = 2;
            labelpairs2.Text = "Performing Arts Inventory";
            labelpairs2.Click += label1_Click_1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Bebas Neue", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Maroon;
            lblTitle.Location = new Point(118, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(112, 61);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "PAIRS";
            lblTitle.Click += label1_Click;
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.BackColor = Color.LightGray;
            pnlLoginCard.BorderStyle = BorderStyle.FixedSingle;
            pnlLoginCard.Controls.Add(forgetLink);
            pnlLoginCard.Controls.Add(contactlink);
            pnlLoginCard.Controls.Add(label3);
            pnlLoginCard.Controls.Add(needlabel);
            pnlLoginCard.Controls.Add(dividerlabel);
            pnlLoginCard.Controls.Add(exitButton);
            pnlLoginCard.Controls.Add(loginbutton);
            pnlLoginCard.Controls.Add(password_txtBox);
            pnlLoginCard.Controls.Add(email_txtBox);
            pnlLoginCard.Controls.Add(label1);
            pnlLoginCard.Location = new Point(118, 109);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(383, 501);
            pnlLoginCard.TabIndex = 0;
            pnlLoginCard.Paint += pnlLoginCard_Paint;
            // 
            // forgetLink
            // 
            forgetLink.AutoSize = true;
            forgetLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            forgetLink.LinkBehavior = LinkBehavior.NeverUnderline;
            forgetLink.LinkColor = Color.Firebrick;
            forgetLink.Location = new Point(211, 406);
            forgetLink.Name = "forgetLink";
            forgetLink.Size = new Size(76, 20);
            forgetLink.TabIndex = 8;
            forgetLink.TabStop = true;
            forgetLink.Text = "Click here";
            forgetLink.LinkClicked += linkLabel1_LinkClicked;
            // 
            // contactlink
            // 
            contactlink.AutoSize = true;
            contactlink.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contactlink.LinkBehavior = LinkBehavior.NeverUnderline;
            contactlink.LinkColor = Color.Firebrick;
            contactlink.Location = new Point(211, 368);
            contactlink.Name = "contactlink";
            contactlink.Size = new Size(63, 20);
            contactlink.TabIndex = 7;
            contactlink.TabStop = true;
            contactlink.Text = "Sign Up";
            contactlink.LinkClicked += contactlink_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 406);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 6;
            label3.Text = "Forgot Password?";
            label3.Click += needlabel_Click;
            // 
            // needlabel
            // 
            needlabel.AutoSize = true;
            needlabel.Location = new Point(88, 368);
            needlabel.Name = "needlabel";
            needlabel.Size = new Size(128, 20);
            needlabel.TabIndex = 6;
            needlabel.Text = "Need an account?";
            needlabel.Click += needlabel_Click;
            // 
            // dividerlabel
            // 
            dividerlabel.AutoSize = true;
            dividerlabel.Location = new Point(102, 333);
            dividerlabel.Name = "dividerlabel";
            dividerlabel.Size = new Size(165, 20);
            dividerlabel.TabIndex = 5;
            dividerlabel.Text = "──────── OR ────────";
            dividerlabel.Click += dividerlabel_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.Firebrick;
            exitButton.FlatStyle = FlatStyle.Popup;
            exitButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = Color.White;
            exitButton.Location = new Point(41, 268);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(275, 42);
            exitButton.TabIndex = 4;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += button3_Click;
            // 
            // loginbutton
            // 
            loginbutton.BackColor = Color.Firebrick;
            loginbutton.FlatStyle = FlatStyle.Popup;
            loginbutton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginbutton.ForeColor = Color.White;
            loginbutton.Location = new Point(41, 220);
            loginbutton.Name = "loginbutton";
            loginbutton.Size = new Size(275, 42);
            loginbutton.TabIndex = 4;
            loginbutton.Text = "Login";
            loginbutton.UseVisualStyleBackColor = false;
            loginbutton.Click += loginbutton_Click;
            // 
            // password_txtBox
            // 
            password_txtBox.Location = new Point(41, 168);
            password_txtBox.Name = "password_txtBox";
            password_txtBox.PasswordChar = '*';
            password_txtBox.PlaceholderText = "Password";
            password_txtBox.Size = new Size(270, 27);
            password_txtBox.TabIndex = 3;
            password_txtBox.TextChanged += textBox1_TextChanged;
            // 
            // email_txtBox
            // 
            email_txtBox.Location = new Point(41, 120);
            email_txtBox.Name = "email_txtBox";
            email_txtBox.PlaceholderText = "Email";
            email_txtBox.Size = new Size(270, 27);
            email_txtBox.TabIndex = 3;
            email_txtBox.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(70, 27);
            label1.Name = "label1";
            label1.Size = new Size(226, 41);
            label1.TabIndex = 1;
            label1.Text = "Welcome Back!";
            label1.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(281, 627);
            label4.Name = "label4";
            label4.Size = new Size(88, 17);
            label4.TabIndex = 2;
            label4.Text = "© 2026 PAIRS";
            label4.Click += label4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(207, 627);
            label2.Name = "label2";
            label2.Size = new Size(72, 17);
            label2.TabIndex = 2;
            label2.Text = "Version 1.0";
            label2.Click += label2_Click;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.Gainsboro;
            panelRight.Controls.Add(pairsLogo);
            panelRight.Controls.Add(label6);
            panelRight.Controls.Add(label5);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(604, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(578, 653);
            panelRight.TabIndex = 1;
            // 
            // pairsLogo
            // 
            pairsLogo.Anchor = AnchorStyles.None;
            pairsLogo.BackColor = Color.Transparent;
            pairsLogo.Image = (Image)resources.GetObject("pairsLogo.Image");
            pairsLogo.Location = new Point(0, 77);
            pairsLogo.Name = "pairsLogo";
            pairsLogo.Size = new Size(578, 371);
            pairsLogo.SizeMode = PictureBoxSizeMode.CenterImage;
            pairsLogo.TabIndex = 0;
            pairsLogo.TabStop = false;
            pairsLogo.Click += pairsLogo_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Firebrick;
            label6.Location = new Point(203, 495);
            label6.Name = "label6";
            label6.Size = new Size(197, 41);
            label6.TabIndex = 1;
            label6.Text = "Starts Here.\"";
            label6.Click += label1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Firebrick;
            label5.Location = new Point(59, 443);
            label5.Name = "label5";
            label5.Size = new Size(473, 82);
            label5.TabIndex = 1;
            label5.Text = "   \"Managing Every Performance\n\n";
            label5.Click += label1_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PAIRS Beta";
            Load += frmLogin_Load;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pairsLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Panel panelRight;
        private Label lblTitle;
        private Panel pnlLoginCard;
        private Label labelpairs2;
        private Label labelpair3;
        private Label label1;
        private Label label2;
        private TextBox email_txtBox;
        private TextBox password_txtBox;
        private Button loginbutton;
        private Button exitButton;
        private Label dividerlabel;
        private Label needlabel;
        private LinkLabel contactlink;
        private Label label3;
        private Label label4;
        private PictureBox pairsLogo;
        private Label label5;
        private Label label6;
        private LinkLabel forgetLink;
    }
}
