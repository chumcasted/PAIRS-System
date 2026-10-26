using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class CreateAcc : Form
    {
        public CreateAcc()
        {
            InitializeComponent();
        }

        // --- 1. GREEN BUTTON (createButton): ACCOUNT REGISTRATION ---
        private void createButton_Click(object sender, EventArgs e)
        {
            // A. Validate empty fields
            if (string.IsNullOrWhiteSpace(email_txtBox.Text) ||
                string.IsNullOrWhiteSpace(phone_txtBox.Text) ||
                string.IsNullOrWhiteSpace(fullname_txtBox.Text) ||
                string.IsNullOrWhiteSpace(enterPass_txtBox.Text) ||
                string.IsNullOrWhiteSpace(confirmpass_txtBox.Text) ||
                college_cmbBox.SelectedIndex == -1 ||
                personal_cmbBox.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(answer_txtBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = enterPass_txtBox.Text.Trim();

            // B. Validate password policy (Min 12 chars, 1 uppercase, 1 digit, 1 special char)
            if (!ValidatePasswordPolicy(password, out string passwordError))
            {
                MessageBox.Show(passwordError, "Password Policy Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                enterPass_txtBox.Focus();
                return;
            }

            // C. Validate password match
            if (enterPass_txtBox.Text != confirmpass_txtBox.Text)
            {
                MessageBox.Show("Passwords do not match. Please re-enter your password.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                confirmpass_txtBox.Clear();
                confirmpass_txtBox.Focus();
                return;
            }

            string email = email_txtBox.Text.Trim();
            string phoneNum = phone_txtBox.Text.Trim();
            string fullName = fullname_txtBox.Text.Trim();
            string college = college_cmbBox.SelectedItem.ToString();
            string securityQuestion = personal_cmbBox.SelectedItem.ToString();
            string securityAnswer = answer_txtBox.Text.Trim();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // D. Auto-generate the next UserID (e.g., U001, U002)
                    string newUserId = GenerateNextUserID(conn);

                    // E. Use a MySqlTransaction to insert into all three tables safely
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insert into `user` table
                            string userQuery = @"INSERT INTO `user` (UserID, FullName, Email, Password, College) 
                                                 VALUES (@UserID, @FullName, @Email, @Password, @College);";

                            using (MySqlCommand cmdUser = new MySqlCommand(userQuery, conn, transaction))
                            {
                                cmdUser.Parameters.AddWithValue("@UserID", newUserId);
                                cmdUser.Parameters.AddWithValue("@FullName", fullName);
                                cmdUser.Parameters.AddWithValue("@Email", email);
                                cmdUser.Parameters.AddWithValue("@Password", password);
                                cmdUser.Parameters.AddWithValue("@College", college);
                                cmdUser.ExecuteNonQuery();
                            }

                            // 2. Insert into `user_phone` table
                            string phoneQuery = @"INSERT INTO user_phone (PhoneID, UserID, PhoneNumber) 
                                                  VALUES (@PhoneID, @UserID, @PhoneNum)
                                                  ON DUPLICATE KEY UPDATE PhoneNumber = @PhoneNum;";

                            using (MySqlCommand cmdPhone = new MySqlCommand(phoneQuery, conn, transaction))
                            {
                                cmdPhone.Parameters.AddWithValue("@PhoneID", "PH_" + newUserId);
                                cmdPhone.Parameters.AddWithValue("@UserID", newUserId);
                                cmdPhone.Parameters.AddWithValue("@PhoneNum", phoneNum);
                                cmdPhone.ExecuteNonQuery();
                            }

                            // 3. Insert into `user_security` table (or user_emergency)
                            string securityQuery = @"INSERT INTO user_security (UserID, SecurityQuestion, SecurityAnswer) 
                                                     VALUES (@UserID, @SecurityQuestion, @SecurityAnswer)
                                                     ON DUPLICATE KEY UPDATE SecurityQuestion = @SecurityQuestion, SecurityAnswer = @SecurityAnswer;";

                            using (MySqlCommand cmdSecurity = new MySqlCommand(securityQuery, conn, transaction))
                            {
                                cmdSecurity.Parameters.AddWithValue("@UserID", newUserId);
                                cmdSecurity.Parameters.AddWithValue("@SecurityQuestion", securityQuestion);
                                cmdSecurity.Parameters.AddWithValue("@SecurityAnswer", securityAnswer);
                                cmdSecurity.ExecuteNonQuery();
                            }

                            // Commit transaction if all inserts succeed
                            transaction.Commit();

                            MessageBox.Show($"Account created successfully!\nYour assigned User ID is: {newUserId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redirect back to Login Page (frmLogin)
                            frmLogin loginForm = new frmLogin();
                            loginForm.Show();
                            this.Close();
                        }
                        catch (Exception)
                        {
                            // Roll back all changes if any single insert fails
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        if (ex.Message.IndexOf("Email", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            MessageBox.Show("An account with this email address already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Primary key or duplicate constraint error: " + ex.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- 2. PASSWORD POLICY VALIDATION HELPER ---
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

        // --- 3. AUTOMATIC USER ID GENERATOR ---
        private string GenerateNextUserID(MySqlConnection conn)
        {
            string nextId = "U001";
            // Uses CAST to ensure proper numerical ordering instead of alphabetical string sorting
            string query = @"SELECT UserID 
                            FROM `user` 
                            WHERE UserID LIKE 'U%' 
                            ORDER BY CAST(SUBSTRING(UserID, 2) AS UNSIGNED) DESC 
                            LIMIT 1;";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string lastId = result.ToString();
                    if (lastId.Length > 1 && int.TryParse(lastId.Substring(1), out int numericPart))
                    {
                        nextId = "U" + (numericPart + 1).ToString("D3");
                    }
                }
            }
            return nextId;
        }

        // --- 4. RED BUTTON (exitButton): RETURN TO LOGIN ---
        private void exitButton_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
        }

        private void CreateAcc_Load(object sender, EventArgs e)
        {

        }
    }
}