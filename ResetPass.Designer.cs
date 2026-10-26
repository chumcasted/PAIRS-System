namespace WinFormsApp2
{
    partial class ResetPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPass));
            labelpairs2 = new Label();
            lblTitle = new Label();
            pnlLoginCard = new Panel();
            BacktoLoginButton = new Button();
            answer_txtBox = new TextBox();
            chooseLbl = new Label();
            confirmPass_txtBox = new TextBox();
            enterPass_txtBox = new TextBox();
            personal_cmbBox = new ComboBox();
            ResetPass_btn = new Button();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            pairsLogo = new PictureBox();
            label6 = new Label();
            label5 = new Label();
            panelLeft = new Panel();
            labelpair3 = new Label();
            panelRight = new Panel();
            label8 = new Label();
            label7 = new Label();
            pnlLoginCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pairsLogo).BeginInit();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();
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
            pnlLoginCard.Controls.Add(BacktoLoginButton);
            pnlLoginCard.Controls.Add(answer_txtBox);
            pnlLoginCard.Controls.Add(chooseLbl);
            pnlLoginCard.Controls.Add(confirmPass_txtBox);
            pnlLoginCard.Controls.Add(enterPass_txtBox);
            pnlLoginCard.Controls.Add(personal_cmbBox);
            pnlLoginCard.Controls.Add(ResetPass_btn);
            pnlLoginCard.Controls.Add(label1);
            pnlLoginCard.Location = new Point(118, 109);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(383, 501);
            pnlLoginCard.TabIndex = 0;
            pnlLoginCard.Paint += pnlLoginCard_Paint;
            // 
            // BacktoLoginButton
            // 
            BacktoLoginButton.BackColor = Color.DarkOliveGreen;
            BacktoLoginButton.FlatStyle = FlatStyle.Popup;
            BacktoLoginButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BacktoLoginButton.ForeColor = Color.White;
            BacktoLoginButton.Location = new Point(35, 392);
            BacktoLoginButton.Name = "BacktoLoginButton";
            BacktoLoginButton.Size = new Size(286, 42);
            BacktoLoginButton.TabIndex = 18;
            BacktoLoginButton.Text = "Back To Login";
            BacktoLoginButton.UseVisualStyleBackColor = false;
            BacktoLoginButton.Click += BacktoLoginButton_Click;
            // 
            // answer_txtBox
            // 
            answer_txtBox.Location = new Point(35, 159);
            answer_txtBox.Name = "answer_txtBox";
            answer_txtBox.PlaceholderText = "Answer";
            answer_txtBox.Size = new Size(286, 27);
            answer_txtBox.TabIndex = 17;
            answer_txtBox.TextChanged += answer_txtBox_TextChanged;
            // 
            // chooseLbl
            // 
            chooseLbl.AutoSize = true;
            chooseLbl.Location = new Point(32, 73);
            chooseLbl.Name = "chooseLbl";
            chooseLbl.Size = new Size(195, 20);
            chooseLbl.TabIndex = 14;
            chooseLbl.Text = "Choose a personal question.";
            // 
            // confirmPass_txtBox
            // 
            confirmPass_txtBox.Location = new Point(35, 270);
            confirmPass_txtBox.Name = "confirmPass_txtBox";
            confirmPass_txtBox.PlaceholderText = "Confirm Password";
            confirmPass_txtBox.Size = new Size(286, 27);
            confirmPass_txtBox.TabIndex = 12;
            confirmPass_txtBox.TextChanged += confirmPass_txtBox_TextChanged;
            // 
            // enterPass_txtBox
            // 
            enterPass_txtBox.Location = new Point(35, 216);
            enterPass_txtBox.Name = "enterPass_txtBox";
            enterPass_txtBox.PlaceholderText = "Enter your new Password";
            enterPass_txtBox.Size = new Size(286, 27);
            enterPass_txtBox.TabIndex = 11;
            enterPass_txtBox.TextChanged += enterPass_txtBox_TextChanged;
            // 
            // personal_cmbBox
            // 
            personal_cmbBox.FormattingEnabled = true;
            personal_cmbBox.Items.AddRange(new object[] { "What is your favorite color?", "Where is your birthplace?", "What is your favorite book?", "Who is your favorite singe?", "What is your favorite song?" });
            personal_cmbBox.Location = new Point(32, 110);
            personal_cmbBox.Name = "personal_cmbBox";
            personal_cmbBox.Size = new Size(289, 28);
            personal_cmbBox.TabIndex = 9;
            personal_cmbBox.SelectedIndexChanged += personal_cmbBox_SelectedIndexChanged;
            // 
            // ResetPass_btn
            // 
            ResetPass_btn.BackColor = Color.Firebrick;
            ResetPass_btn.FlatStyle = FlatStyle.Popup;
            ResetPass_btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ResetPass_btn.ForeColor = Color.White;
            ResetPass_btn.Location = new Point(35, 333);
            ResetPass_btn.Name = "ResetPass_btn";
            ResetPass_btn.Size = new Size(286, 53);
            ResetPass_btn.TabIndex = 4;
            ResetPass_btn.Text = "Reset Password";
            ResetPass_btn.UseVisualStyleBackColor = false;
            ResetPass_btn.Click += ResetPass_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(229, 41);
            label1.TabIndex = 1;
            label1.Text = "Reset Password";
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
            // pairsLogo
            // 
            pairsLogo.Anchor = AnchorStyles.None;
            pairsLogo.BackColor = Color.Transparent;
            pairsLogo.Image = (Image)resources.GetObject("pairsLogo.Image");
            pairsLogo.Location = new Point(604, 77);
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
            panelLeft.TabIndex = 4;
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
            // panelRight
            // 
            panelRight.BackColor = Color.LightGray;
            panelRight.Controls.Add(label8);
            panelRight.Controls.Add(label7);
            panelRight.Controls.Add(pairsLogo);
            panelRight.Controls.Add(label6);
            panelRight.Controls.Add(label5);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(1182, 653);
            panelRight.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Firebrick;
            label8.Location = new Point(807, 495);
            label8.Name = "label8";
            label8.Size = new Size(197, 41);
            label8.TabIndex = 3;
            label8.Text = "Starts Here.\"";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Firebrick;
            label7.Location = new Point(663, 443);
            label7.Name = "label7";
            label7.Size = new Size(473, 82);
            label7.TabIndex = 2;
            label7.Text = "   \"Managing Every Performance\n\n";
            // 
            // ResetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(panelLeft);
            Controls.Add(panelRight);
            Name = "ResetPass";
            Text = "Forgot2";
            Load += ResetPass_Load;
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pairsLogo).EndInit();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelpairs2;
        private Label lblTitle;
        private Panel pnlLoginCard;
        private Button ResetPass_btn;
        private Label label1;
        private Label label4;
        private Label label2;
        private PictureBox pairsLogo;
        private Label label6;
        private Label label5;
        private Panel panelLeft;
        private Label labelpair3;
        private Panel panelRight;
        private Label label7;
        private Label label8;
        private TextBox confirmPass_txtBox;
        private TextBox enterPass_txtBox;
        private ComboBox personal_cmbBox;
        private Label chooseLbl;
        private TextBox answer_txtBox;
        private Button BacktoLoginButton;
    }
}