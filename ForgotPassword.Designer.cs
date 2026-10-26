namespace WinFormsApp2
{
    partial class ForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
            panelRight = new Panel();
            pairsLogo = new PictureBox();
            label6 = new Label();
            label5 = new Label();
            panelLeft = new Panel();
            labelpair3 = new Label();
            labelpairs2 = new Label();
            lblTitle = new Label();
            pnlLoginCard = new Panel();
            label3 = new Label();
            contactlink = new LinkLabel();
            needlabel = new Label();
            dividerlabel = new Label();
            BacktoLoginButton = new Button();
            resetLinkButton = new Button();
            emailForgot_txtBox = new TextBox();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pairsLogo).BeginInit();
            panelLeft.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.LightGray;
            panelRight.Controls.Add(pairsLogo);
            panelRight.Controls.Add(label6);
            panelRight.Controls.Add(label5);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(604, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(578, 653);
            panelRight.TabIndex = 3;
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
            panelLeft.TabIndex = 2;
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
            labelpairs2.Click += labelpairs2_Click;
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
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.BackColor = Color.LightGray;
            pnlLoginCard.BorderStyle = BorderStyle.FixedSingle;
            pnlLoginCard.Controls.Add(label3);
            pnlLoginCard.Controls.Add(contactlink);
            pnlLoginCard.Controls.Add(needlabel);
            pnlLoginCard.Controls.Add(dividerlabel);
            pnlLoginCard.Controls.Add(BacktoLoginButton);
            pnlLoginCard.Controls.Add(resetLinkButton);
            pnlLoginCard.Controls.Add(emailForgot_txtBox);
            pnlLoginCard.Controls.Add(label1);
            pnlLoginCard.Location = new Point(118, 109);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(383, 501);
            pnlLoginCard.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(46, 87);
            label3.Name = "label3";
            label3.Size = new Size(260, 60);
            label3.TabIndex = 8;
            label3.Text = "Enter your registered email \r\naddress. We'll send you instructions to\r\nreset your password.\r\n";
            label3.Click += label3_Click;
            // 
            // contactlink
            // 
            contactlink.AutoSize = true;
            contactlink.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contactlink.LinkBehavior = LinkBehavior.NeverUnderline;
            contactlink.LinkColor = Color.Firebrick;
            contactlink.Location = new Point(211, 420);
            contactlink.Name = "contactlink";
            contactlink.Size = new Size(63, 20);
            contactlink.TabIndex = 7;
            contactlink.TabStop = true;
            contactlink.Text = "Sign Up";
            contactlink.LinkClicked += contactlink_LinkClicked;
            // 
            // needlabel
            // 
            needlabel.AutoSize = true;
            needlabel.Location = new Point(88, 420);
            needlabel.Name = "needlabel";
            needlabel.Size = new Size(128, 20);
            needlabel.TabIndex = 6;
            needlabel.Text = "Need an account?";
            // 
            // dividerlabel
            // 
            dividerlabel.AutoSize = true;
            dividerlabel.Location = new Point(102, 385);
            dividerlabel.Name = "dividerlabel";
            dividerlabel.Size = new Size(165, 20);
            dividerlabel.TabIndex = 5;
            dividerlabel.Text = "──────── OR ────────";
            // 
            // BacktoLoginButton
            // 
            BacktoLoginButton.BackColor = Color.Firebrick;
            BacktoLoginButton.FlatStyle = FlatStyle.Popup;
            BacktoLoginButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BacktoLoginButton.ForeColor = Color.White;
            BacktoLoginButton.Location = new Point(46, 296);
            BacktoLoginButton.Name = "BacktoLoginButton";
            BacktoLoginButton.Size = new Size(275, 42);
            BacktoLoginButton.TabIndex = 4;
            BacktoLoginButton.Text = "Back To Login";
            BacktoLoginButton.UseVisualStyleBackColor = false;
            BacktoLoginButton.Click += BacktoLoginButton_Click;
            // 
            // resetLinkButton
            // 
            resetLinkButton.BackColor = Color.Firebrick;
            resetLinkButton.FlatStyle = FlatStyle.Popup;
            resetLinkButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resetLinkButton.ForeColor = Color.White;
            resetLinkButton.Location = new Point(46, 248);
            resetLinkButton.Name = "resetLinkButton";
            resetLinkButton.Size = new Size(275, 42);
            resetLinkButton.TabIndex = 4;
            resetLinkButton.Text = "Proceed to the Next Window";
            resetLinkButton.UseVisualStyleBackColor = false;
            resetLinkButton.Click += resetLinkButton_Click;
            // 
            // emailForgot_txtBox
            // 
            emailForgot_txtBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailForgot_txtBox.Location = new Point(46, 201);
            emailForgot_txtBox.Name = "emailForgot_txtBox";
            emailForgot_txtBox.PlaceholderText = "Enter your Email";
            emailForgot_txtBox.Size = new Size(275, 27);
            emailForgot_txtBox.TabIndex = 3;
            emailForgot_txtBox.TextChanged += textBox1_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(70, 27);
            label1.Name = "label1";
            label1.Size = new Size(246, 41);
            label1.TabIndex = 1;
            label1.Text = "Forgot Password";
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
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1182, 653);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            MaximizeBox = false;
            Name = "ForgotPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPassword";
            Load += ForgotPassword_Load;
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pairsLogo).EndInit();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRight;
        private PictureBox pairsLogo;
        private Label label6;
        private Label label5;
        private Panel panelLeft;
        private Label labelpair3;
        private Label labelpairs2;
        private Label lblTitle;
        private Panel pnlLoginCard;
        private LinkLabel forgetLink;
        private LinkLabel contactlink;
        private Label needlabel;
        private Label dividerlabel;
        private Button exitButton;
        private Button clearButton;
        private Button resetLinkButton;
        private Label label1;
        private Label label4;
        private Label label2;
        private Button BacktoLoginButton;
        internal TextBox emailForgot_txtBox;
        private Label label3;
    }
}