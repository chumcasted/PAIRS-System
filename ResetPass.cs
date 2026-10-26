using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class ResetPass : Form
    {
        // Properties to hold data passed from ForgotPassword.cs
        public string TargetUserID { get; private set; } = string.Empty;
        public string SecurityQuestion { get; private set; } = string.Empty;
        public string SecurityAnswer { get; private set; } = string.Empty;

        public ResetPass()
        {
            InitializeComponent();
        }

        public ResetPass(string userId, string question, string answer) : this()
        {
            TargetUserID = userId;
            SecurityQuestion = question;
            SecurityAnswer = answer;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pnlLoginCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void personal_cmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void answer_txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void enterPass_txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmPass_txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ResetPass_btn_Click(object sender, EventArgs e)
        {
            // A. Validate empty fields
            if (string.IsNullOrWhiteSpace(answer_txtBox.Text) ||
                string.IsNullOrWhiteSpace(enterPass_txtBox.Text) ||
                string.IsNullOrWhiteSpace(confirmPass_txtBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // B. Verify Security Answer (case-insensitive)
            if (!string.Equals(answer_txtBox.Text.Trim(), SecurityAnswer.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Incorrect answer to the personal question. Please try again.", "Security Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                answer_txtBox.Clear();
                answer_txtBox.Focus();
                return;
            }

            string newPassword = enterPass_txtBox.Text.Trim();

            // C. Validate password policy (Min 12 chars, 1 uppercase, 1 digit, 1 special char)
            if (!ValidatePasswordPolicy(newPassword, out string passwordError))
            {
                MessageBox.Show(passwordError, "Password Policy Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                enterPass_txtBox.Focus();
                return;
            }

            // D. Validate password match
            if (newPassword != confirmPass_txtBox.Text.Trim())
            {
                MessageBox.Show("Passwords do not match. Please re-enter your new password.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                confirmPass_txtBox.Clear();
                confirmPass_txtBox.Focus();
                return;
            }

            // E. Update Password in pairs_db
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE `user` SET Password = @Password WHERE UserID = @UserID;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@UserID", TargetUserID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your password has been reset successfully! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redirect back to Login Page (frmLogin)
                            frmLogin loginForm = new frmLogin();
                            loginForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to reset password. User record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- PASSWORD POLICY VALIDATION HELPER ---
        private bool ValidatePasswordPolicy(string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (password.Length < 12)
            {
                errorMessage = "Password must be at least 12 characters long.";
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                errorMessage = "Password must contain at least one uppercase letter (A-Z).";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                errorMessage = "Password must contain at least one numeric digit (0-9).";
                return false;
            }

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                errorMessage = "Password must contain at least one special character (e.g., !@#$%^&*).";
                return false;
            }

            return true;
        }

        private void BacktoLoginButton_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
        }

        private void ResetPass_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SecurityQuestion))
            {
                personal_cmbBox.Items.Clear();
                personal_cmbBox.Items.Add(SecurityQuestion);
                personal_cmbBox.SelectedIndex = 0; // Automatically displays the retrieved question
            }
        }
    }
}