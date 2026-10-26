using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. FORM LOAD & INITIALIZATION
        // ==========================================
        private void Settings_Load(object sender, EventArgs e)
        {
            // Populate TimeZone dropdown items
            cmbTimeZone.Items.Clear();
            cmbTimeZone.Items.AddRange(new object[] {
                "UTC+08:00 (Manila, Beijing, Singapore)",
                "UTC+00:00 (London, GMT)",
                "UTC-05:00 (Eastern Time)",
                "UTC+09:00 (Tokyo, Seoul)"
            });
            if (cmbTimeZone.Items.Count > 0) cmbTimeZone.SelectedIndex = 0;

            // Set default numeric rule values
            numLowStockThreshold.Value = 2;
            numMaxItems.Value = 3;
            numAutoCancel.Value = 3;

            // 1. Display active user name
            string currentUserId = UserSession.UserID;
            string currentName = UserSession.FullName;

            if (!string.IsNullOrEmpty(currentUserId) && !string.IsNullOrEmpty(currentName))
            {
                txtUserName.Text = $"{currentUserId} - {currentName}";
            }
            else if (!string.IsNullOrEmpty(currentUserId))
            {
                txtUserName.Text = currentUserId;
            }
            else
            {
                txtUserName.Text = "U002 - Charles Tejano"; // Fallback matching active session
            }

            // 2. Fetch password directly from database and paste into txtCurrentPassword
            LoadUserCurrentPassword();

            // 3. Set initial password masking state based on Show Password checkbox
            bool isShowChecked = (checkShowPass != null && checkShowPass.Checked);
            SetPasswordMasking(!isShowChecked);

            // 4. Initialize default database name and backup path
            txtTargetDatabase.Text = "pairs_db";
            string defaultBackupFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PAIRS_Backups");
            txtBackupLocation.Text = defaultBackupFolder;
            txtLastBackup.Text = "Never";

            LoadCurrentSettingsFromDatabase();
        }

        // ==========================================
        // 2. FETCH PASSWORD FROM DATABASE
        // ==========================================
        private void LoadUserCurrentPassword()
        {
            string targetID = UserSession.UserID;

            // Extract ID from txtUserName if UserSession.UserID is unset (e.g. "U002 - Charles Tejano" -> "U002")
            if (string.IsNullOrWhiteSpace(targetID) && !string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                if (txtUserName.Text.Contains("-"))
                {
                    targetID = txtUserName.Text.Split('-')[0].Trim();
                }
                else
                {
                    targetID = txtUserName.Text.Trim();
                }
            }

            if (string.IsNullOrWhiteSpace(targetID))
            {
                targetID = "U002";
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Query password by UserID, FullName, or Email
                    string query = "SELECT Password FROM `user` WHERE UserID = @Target OR FullName = @Target OR Email = @Target LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Target", targetID);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            txtCurrentPassword.Text = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading password from database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 3. LOAD SETTINGS FROM MYSQL
        // ==========================================
        private void LoadCurrentSettingsFromDatabase()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM `settings` WHERE id = 1 LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["SystemName"] != DBNull.Value) txtSystemName.Text = reader["SystemName"].ToString();
                                if (reader["ContactEmail"] != DBNull.Value) txtContactEmail.Text = reader["ContactEmail"].ToString();
                                if (reader["TimeZone"] != DBNull.Value) cmbTimeZone.SelectedItem = reader["TimeZone"].ToString();

                                // Load Low Stock Checkbox & Threshold
                                bool isAlertEnabled = reader["IsLowStockAlertEnabled"] == DBNull.Value || Convert.ToBoolean(reader["IsLowStockAlertEnabled"]);
                                chkEnableLowStock.Checked = isAlertEnabled;
                                numLowStockThreshold.Enabled = isAlertEnabled;

                                if (reader["LowStockThreshold"] != DBNull.Value) numLowStockThreshold.Value = Convert.ToDecimal(reader["LowStockThreshold"]);
                                if (reader["MaxItemsPerBorrower"] != DBNull.Value) numMaxItems.Value = Convert.ToDecimal(reader["MaxItemsPerBorrower"]);
                                if (reader["AutoCancelDays"] != DBNull.Value) numAutoCancel.Value = Convert.ToDecimal(reader["AutoCancelDays"]);

                                if (reader["TargetDatabase"] != DBNull.Value) txtTargetDatabase.Text = reader["TargetDatabase"].ToString();
                                if (reader["BackupLocation"] != DBNull.Value) txtBackupLocation.Text = reader["BackupLocation"].ToString();
                                if (reader["LastSuccessfulBackup"] != DBNull.Value) txtLastBackup.Text = reader["LastSuccessfulBackup"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading settings: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetDefaultValues()
        {
            txtSystemName.Text = "PAIRS - Performing Arts Inventory & Reservation";
            txtContactEmail.Text = "umatter@dmmmsu.edu.ph";
            numLowStockThreshold.Value = 2;
            numMaxItems.Value = 3;
            numAutoCancel.Value = 3;
        }

        // ==========================================
        // 4. SHOW / HIDE PASSWORD TOGGLE (ALL 3 TEXTBOXES)
        // ==========================================
        private void check_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility(sender);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility(sender);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility(sender);
        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility(sender);
        }

        private void TogglePasswordVisibility(object sender)
        {
            if (sender is CheckBox cb)
            {
                SetPasswordMasking(!cb.Checked);
            }
        }

        private void SetPasswordMasking(bool hidePassword)
        {
            if (txtCurrentPassword != null) txtCurrentPassword.UseSystemPasswordChar = hidePassword;
            if (txtNewPassword != null) txtNewPassword.UseSystemPasswordChar = hidePassword;
            if (txtConfirmPassword != null) txtConfirmPassword.UseSystemPasswordChar = hidePassword;
        }

        // ==========================================
        // 5. UPDATE PASSWORD
        // ==========================================
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string oldPass = txtCurrentPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Please enter your current and new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // A. Validate new password policy (Min 12 chars, 1 uppercase, 1 digit, 1 special char)
            if (!ValidatePasswordPolicy(newPass, out string passwordError))
            {
                MessageBox.Show(passwordError, "Password Policy Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            // B. Validate password match
            if (newPass != confirmPass)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetID = UserSession.UserID;
            if (string.IsNullOrWhiteSpace(targetID) && txtUserName.Text.Contains("-"))
            {
                targetID = txtUserName.Text.Split('-')[0].Trim();
            }
            if (string.IsNullOrWhiteSpace(targetID)) targetID = "U002";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Verify old password
                    string checkQuery = "SELECT Password FROM `user` WHERE UserID = @UserID";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@UserID", targetID);
                        string dbPass = checkCmd.ExecuteScalar()?.ToString();

                        if (dbPass != oldPass)
                        {
                            MessageBox.Show("Current password is incorrect.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update database to new password
                    string updateQuery = "UPDATE `user` SET Password = @NewPassword WHERE UserID = @UserID";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@NewPassword", newPass);
                        updateCmd.Parameters.AddWithValue("@UserID", targetID);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Update displayed current password field to reflect the new database value
                        txtCurrentPassword.Text = newPass;
                        txtNewPassword.Clear();
                        txtConfirmPassword.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ==========================================
        // 6. DATABASE BACKUP & BROWSE
        // ==========================================
        private void button1_Click(object sender, EventArgs e)
        {
            BrowseBackupFolder();
        }

        private void BrowseBackupFolder()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select a folder location for database backups:";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtBackupLocation.Text = fbd.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExecuteDatabaseBackup();
        }

        private void ExecuteDatabaseBackup()
        {
            string backupDir = txtBackupLocation.Text.Trim();

            if (string.IsNullOrEmpty(backupDir))
            {
                MessageBox.Show("Please select a valid backup location.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(backupDir))
            {
                try
                {
                    Directory.CreateDirectory(backupDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not create directory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string dbName = string.IsNullOrWhiteSpace(txtTargetDatabase.Text) ? "pairs_db" : txtTargetDatabase.Text.Trim();
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string backupFileName = $"{dbName}_Backup_{timestamp}.sql";
            string fullPath = Path.Combine(backupDir, backupFileName);

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    StringBuilder dump = new StringBuilder();
                    dump.AppendLine($"-- PAIRS System Database Backup");
                    dump.AppendLine($"-- Backup Date: {DateTime.Now}");
                    dump.AppendLine($"-- Target Database: {dbName}\n");

                    DataTable tables = conn.GetSchema("Tables");
                    foreach (DataRow row in tables.Rows)
                    {
                        string tableName = row[2].ToString();
                        dump.AppendLine($"-- Dumping structure & records for table: `{tableName}`");

                        string query = $"SELECT * FROM `{tableName}`";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            using (MySqlDataReader r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    StringBuilder cols = new StringBuilder();
                                    StringBuilder vals = new StringBuilder();
                                    for (int i = 0; i < r.FieldCount; i++)
                                    {
                                        cols.Append($"`{r.GetName(i)}`, ");
                                        string val = r.GetValue(i)?.ToString() ?? "";
                                        vals.Append($"'{val.Replace("'", "''")}', ");
                                    }
                                    string colStr = cols.ToString().TrimEnd(',', ' ');
                                    string valStr = vals.ToString().TrimEnd(',', ' ');
                                    dump.AppendLine($"INSERT INTO `{tableName}` ({colStr}) VALUES ({valStr});");
                                }
                            }
                        }
                        dump.AppendLine();
                    }

                    File.WriteAllText(fullPath, dump.ToString());

                    string nowFormatted = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                    txtLastBackup.Text = nowFormatted;

                    MessageBox.Show($"Database backup successfully created!\n\nSaved to:\n{fullPath}", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Backup failed: " + ex.Message, "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 7. SAVE CHANGES & RESET DEFAULTS
        // ==========================================
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO `settings` 
                                (id, SystemName, ContactEmail, TimeZone, IsLowStockAlertEnabled, LowStockThreshold, MaxItemsPerBorrower, AutoCancelDays, TargetDatabase, BackupLocation, LastSuccessfulBackup) 
                             VALUES 
                                (1, @Sys, @Email, @TZ, @AlertEnabled, @Low, @Max, @Cancel, @DB, @Loc, @Last)
                             ON DUPLICATE KEY UPDATE 
                                SystemName = @Sys, 
                                ContactEmail = @Email, 
                                TimeZone = @TZ, 
                                IsLowStockAlertEnabled = @AlertEnabled, 
                                LowStockThreshold = @Low, 
                                MaxItemsPerBorrower = @Max, 
                                AutoCancelDays = @Cancel, 
                                TargetDatabase = @DB, 
                                BackupLocation = @Loc, 
                                LastSuccessfulBackup = @Last;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Sys", txtSystemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtContactEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@TZ", cmbTimeZone.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@AlertEnabled", chkEnableLowStock.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Low", numLowStockThreshold.Value);
                        cmd.Parameters.AddWithValue("@Max", numMaxItems.Value);
                        cmd.Parameters.AddWithValue("@Cancel", numAutoCancel.Value);
                        cmd.Parameters.AddWithValue("@DB", txtTargetDatabase.Text.Trim());
                        cmd.Parameters.AddWithValue("@Loc", txtBackupLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Last", txtLastBackup.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Settings saved successfully to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving settings: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetDefaults_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to reset all settings to defaults?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                SetDefaultValues();
                MessageBox.Show("Settings restored to defaults. Click 'Save Changes' to apply permanently.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnDashboard_Click(sender, e);
        }

        // ==========================================
        // 8. SIDEBAR NAVIGATION & LOGOUT
        // ==========================================
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnDashboard_Click(sender, e); }
        private void btnDashboard_Click(object sender, EventArgs e) { new Dashboard().Show(); this.Hide(); }

        private void InventoryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btninventory_Click(sender, e); }
        private void btninventory_Click(object sender, EventArgs e) { new InventoryPairs().Show(); this.Hide(); }

        private void ReservationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btreservations_Click(sender, e); }
        private void btreservations_Click(object sender, EventArgs e) { new Reservation().Show(); this.Hide(); }

        private void BorrowReturnLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnborrowreturn_Click(sender, e); }
        private void btnborrowreturn_Click(object sender, EventArgs e) { new BorrowReturnForm().Show(); this.Close(); }

        private void PerformanceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnperformances_Click(sender, e); }
        private void btnperformances_Click(object sender, EventArgs e) { new Performances().Show(); this.Hide(); }

        private void ReportsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnReports_Click(sender, e); }
        private void btnReports_Click(object sender, EventArgs e) { new Reports().Show(); this.Hide(); }

        private void UserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { btnUsers_Click(sender, e); }
        private void btnUsers_Click(object sender, EventArgs e) { new Users().Show(); this.Hide(); }

        private void SettingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void btnSettings_Click(object sender, EventArgs e) { }

        private void logOut_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out of PAIRS?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserSession.EndSession();

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        // --- UNUSED DESIGNER EVENT STUBS ---
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void panel5_Paint(object sender, PaintEventArgs e) { }
        private void txtLastBackup_TextChanged(object sender, EventArgs e) { }
        private void txtBackupLocation_TextChanged(object sender, EventArgs e) { }
        private void txtTargetDatabase_TextChanged(object sender, EventArgs e) { }
        private void numAutoCancel_ValueChanged(object sender, EventArgs e) { }
        private void numMaxItems_ValueChanged(object sender, EventArgs e) { }
        private void numLowStockThreshold_ValueChanged(object sender, EventArgs e) { }
        private void txtConfirmPassword_TextChanged(object sender, EventArgs e) { }
        private void txtNewPassword_TextChanged(object sender, EventArgs e) { }
        private void txtCurrentPassword_TextChanged(object sender, EventArgs e) { }
        private void txtUserName_TextChanged(object sender, EventArgs e) { }
        private void cmbTimeZone_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtContactEmail_TextChanged(object sender, EventArgs e) { }
        private void txtSystemName_TextChanged(object sender, EventArgs e) { }

        private void chkEnableLowStock_CheckedChanged(object sender, EventArgs e)
        {
            numLowStockThreshold.Enabled = chkEnableLowStock.Checked;
        }
    }
}