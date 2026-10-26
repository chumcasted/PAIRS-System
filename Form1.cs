using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.AcceptButton = loginbutton;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void pnlLoginCard_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void contactlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAcc createAcc = new CreateAcc();
            createAcc.Show();
            this.Hide();
        }

        private void needlabel_Click(object sender, EventArgs e) { }
        private void dividerlabel_Click(object sender, EventArgs e) { }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            // A. Validate empty fields
            if (string.IsNullOrWhiteSpace(email_txtBox.Text) || string.IsNullOrWhiteSpace(password_txtBox.Text))
            {
                MessageBox.Show("Please enter both your email and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = email_txtBox.Text.Trim();
            string password = password_txtBox.Text.Trim();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // B. Query user details
                    string query = "SELECT UserID, FullName, Password, Role FROM `user` WHERE Email = @Email LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userId = reader["UserID"].ToString();
                                string fullName = reader["FullName"].ToString();
                                string dbPassword = reader["Password"].ToString();
                                string role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : "Member";

                                // C. Verify password
                                if (password == dbPassword)
                                {
                                    reader.Close();

                                    // D. Generate Session ID & Store in memory
                                    string sessionId = $"S{DateTime.Now:yyyyMMddHHmmss}";

                                    UserSession.CurrentSessionID = sessionId;
                                    UserSession.UserID = userId;
                                    UserSession.FullName = fullName;
                                    UserSession.Role = role;

                                    // E. Record session log in MySQL
                                    RecordSession(conn, sessionId, userId, "Successful");

                                    MessageBox.Show($"Welcome back, {fullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // F. Open Dashboard based on Role
                                    if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Dashboard adminDashboard = new Dashboard(userId, fullName);
                                        adminDashboard.Show();
                                    }
                                    else
                                    {
                                        MemberDashboard memberDashboard = new MemberDashboard();
                                        memberDashboard.Show();
                                    }

                                    this.Hide();
                                }
                                else
                                {
                                    reader.Close();
                                    string sessionId = $"S{DateTime.Now:yyyyMMddHHmmss}";
                                    RecordSession(conn, sessionId, userId, "Failed Password");
                                    MessageBox.Show("Incorrect password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No account found with this email address.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Single Unified Session log recorder
        private void RecordSession(MySqlConnection conn, string sessionId, string userId, string status)
        {
            string logQuery = @"INSERT INTO authentication_session 
                                (SessionID, UserID, LoginDateTime, LogoutDateTime, LoginAttempt, Status) 
                                VALUES 
                                (@SessionID, @UserID, NOW(), NULL, 1, @Status)";

            using (MySqlCommand cmd = new MySqlCommand(logQuery, conn))
            {
                cmd.Parameters.AddWithValue("@SessionID", sessionId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.ExecuteNonQuery();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            CreateAcc createAccForm = new CreateAcc();
            createAccForm.Show();
            this.Hide();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassForm = new ForgotPassword();
            forgotPassForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void pairsLogo_Click(object sender, EventArgs e) { }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed: " + ex.Message);
                }
            }
        }
    }
}