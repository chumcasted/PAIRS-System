using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp2
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        // --- 1. PROCEED BUTTON (resetLinkButton): FETCH QUESTION FROM user_security ---
        private void resetLinkButton_Click(object sender, EventArgs e)
        {
            // A. Validate email input
            if (string.IsNullOrWhiteSpace(emailForgot_txtBox.Text))
            {
                MessageBox.Show("Please enter your registered email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = emailForgot_txtBox.Text.Trim();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // B. Fetch security details from the new normalized user_security table
                    string query = @"SELECT u.UserID, s.SecurityQuestion, s.SecurityAnswer 
                                     FROM user u
                                     INNER JOIN user_security s ON u.UserID = s.UserID
                                     WHERE u.Email = @Email LIMIT 1;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userId = reader["UserID"].ToString();
                                string question = reader["SecurityQuestion"]?.ToString() ?? "";
                                string answer = reader["SecurityAnswer"]?.ToString() ?? "";

                                if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
                                {
                                    MessageBox.Show("No security question is set up for this account. Please contact an administrator.", "Recovery Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                // C. Open ResetPass and pass security details
                                ResetPass resetPassForm = new ResetPass(userId, question, answer);
                                resetPassForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("No account was found with that email address.", "Email Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 2. BACK TO LOGIN BUTTON ---
        private void BacktoLoginButton_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        // --- 3. SIGN UP / CONTACT LINK ---
        private void contactlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAcc createAcc = new CreateAcc();
            createAcc.Show();
            this.Close();
        }

        // --- 4. FORM DESIGNER EVENT HANDLERS ---
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void pairsLogo_Click(object sender, EventArgs e) { }
        private void labelpairs2_Click(object sender, EventArgs e) { }
        private void ForgotPassword_Load(object sender, EventArgs e) { }
    }
}