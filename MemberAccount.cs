using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MemberAccount : Form
    {
        public MemberAccount()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. FORM LOAD & INITIALIZATION
        // ==========================================
        private void MemberAccount_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            CheckBox chkShow = GetControl<CheckBox>("chkShowPassword") ?? GetControl<CheckBox>("chkShowPass");
            if (chkShow != null)
            {
                chkShow.CheckedChanged -= chkShowPassword_CheckedChanged;
                chkShow.CheckedChanged += chkShowPassword_CheckedChanged;
            }

            Button btnSave = GetControl<Button>("btnSaveProfile") ?? GetControl<Button>("btnSave");
            if (btnSave != null)
            {
                btnSave.Click -= btnSaveProfile_Click;
                btnSave.Click += btnSaveProfile_Click;
            }

            Button btnUpdatePass = GetControl<Button>("btnUpdatePassword") ?? GetControl<Button>("btnChangePassword");
            if (btnUpdatePass != null)
            {
                btnUpdatePass.Click -= btnUpdatePassword_Click;
                btnUpdatePass.Click += btnUpdatePassword_Click;
            }

            SetPasswordMasking(!(chkShow?.Checked ?? false));
            LoadUserProfile();
            LoadActivityOverview();
        }

        // ==========================================
        // 2. LOAD USER PROFILE & PASSWORD FROM MYSQL
        // ==========================================
        private void LoadUserProfile()
        {
            string currentUserId = UserSession.UserID ?? "U001";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT 
                                        u.UserID, 
                                        COALESCE(u.FullName, '') AS FullName, 
                                        COALESCE(u.Role, 'Member') AS Role, 
                                        COALESCE(u.Email, '') AS Email, 
                                        COALESCE(u.Password, '') AS UserPassword,
                                        COALESCE(up.PhoneNumber, '') AS Phone, 
                                        COALESCE(u.College, 'CAS') AS College,
                                        COALESCE(ue.ContactName, '') AS EmergencyName,
                                        COALESCE(ue.ContactPhone, '') AS EmergencyPhone
                                     FROM user u 
                                     LEFT JOIN user_phone up ON u.UserID = up.UserID
                                     LEFT JOIN user_emergency ue ON u.UserID = ue.UserID
                                     WHERE u.UserID = @UserID;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserId);

                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                SetControlText("txtUserID", "textBox1", r["UserID"].ToString());
                                SetControlText("txtFullName", "textBox2", r["FullName"].ToString());
                                SetControlText("txtRole", "textBox3", r["Role"].ToString());
                                SetControlText("txtEmail", "textBox4", r["Email"].ToString());
                                SetControlText("txtPhone", "textBox5", r["Phone"].ToString());
                                SetControlText("txtCollege", "textBox6", r["College"].ToString());

                                Control ctrlEmgName = GetControl<Control>("txtEmergencyName") ?? GetControl<Control>("txtContactName") ?? GetControl<Control>("textBox7");
                                if (ctrlEmgName != null) ctrlEmgName.Text = r["EmergencyName"].ToString();

                                Control ctrlEmgPhone = GetControl<Control>("txtEmergencyPhone") ?? GetControl<Control>("txtContactPhone") ?? GetControl<Control>("textBox8");
                                if (ctrlEmgPhone != null) ctrlEmgPhone.Text = r["EmergencyPhone"].ToString();

                                SetControlText("txtCurrentPassword", "txtCurrentPass", r["UserPassword"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading account details: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 3. LOAD RECENT ACTIVITY OVERVIEW
        // ==========================================
        private void LoadActivityOverview()
        {
            ListBox lstActivity = GetControl<ListBox>("lstActivityOverview") ?? GetControl<ListBox>("lstActivity") ?? FindControl<ListBox>(this);
            if (lstActivity == null) return;

            lstActivity.Items.Clear();
            string currentUserId = UserSession.UserID ?? "U001";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string borrowQuery = @"SELECT b.BorrowID, b.Status, DATE_FORMAT(b.BorrowDate, '%b %d, %Y') AS BDate
                                           FROM borrow b
                                           WHERE b.UserID = @UserID
                                           ORDER BY b.BorrowDate DESC LIMIT 3;";

                    using (MySqlCommand cmd = new MySqlCommand(borrowQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                lstActivity.Items.Add($"• Borrow {r["BorrowID"]}: {r["Status"]} ({r["BDate"]})");
                            }
                        }
                    }

                    string resQuery = @"SELECT r.BookingID, r.Status, DATE_FORMAT(r.StartDate, '%b %d, %Y') AS RDate
                                        FROM reservation r
                                        WHERE r.UserID = @UserID
                                        ORDER BY r.StartDate DESC LIMIT 3;";

                    using (MySqlCommand cmd = new MySqlCommand(resQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                lstActivity.Items.Add($"• Booking {r["BookingID"]}: {r["Status"]} ({r["RDate"]})");
                            }
                        }
                    }

                    if (lstActivity.Items.Count == 0)
                    {
                        lstActivity.Items.Add("• No recent activity recorded.");
                    }
                }
                catch
                {
                    // Clean failover
                }
            }
        }

        // ==========================================
        // 4. SAVE PROFILE CHANGES HANDLER
        // ==========================================
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string currentUserId = UserSession.UserID ?? "U001";
            string email = GetControlText("txtEmail", "textBox4");
            string phone = GetControlText("txtPhone", "textBox5");
            string college = GetControlText("txtCollege", "textBox6");

            string emergencyName = GetControlText("txtEmergencyName") ?? GetControlText("txtContactName", "textBox7");
            string emergencyPhone = GetControlText("txtEmergencyPhone") ?? GetControlText("txtContactPhone", "textBox8");

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string updateUserQuery = @"UPDATE user 
                                                SET Email = @Email, 
                                                    College = @College 
                                                WHERE UserID = @UserID;";

                    using (MySqlCommand cmd = new MySqlCommand(updateUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserId);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@College", college);
                        cmd.ExecuteNonQuery();
                    }

                    string updatePhoneQuery = @"INSERT INTO user_phone (PhoneID, UserID, PhoneNumber)
                                                VALUES (CONCAT('PH_', @UserID), @UserID, @Phone)
                                                ON DUPLICATE KEY UPDATE PhoneNumber = @Phone;";

                    using (MySqlCommand phoneCmd = new MySqlCommand(updatePhoneQuery, conn))
                    {
                        phoneCmd.Parameters.AddWithValue("@UserID", currentUserId);
                        phoneCmd.Parameters.AddWithValue("@Phone", phone);
                        phoneCmd.ExecuteNonQuery();
                    }

                    string updateEmergencyQuery = @"INSERT INTO user_emergency (EmergencyID, UserID, ContactName, ContactPhone)
                                                    VALUES (CONCAT('EMG_', @UserID), @UserID, @EmergencyName, @EmergencyPhone)
                                                    ON DUPLICATE KEY UPDATE 
                                                        ContactName = @EmergencyName, 
                                                        ContactPhone = @EmergencyPhone;";

                    using (MySqlCommand emgCmd = new MySqlCommand(updateEmergencyQuery, conn))
                    {
                        emgCmd.Parameters.AddWithValue("@UserID", currentUserId);
                        emgCmd.Parameters.AddWithValue("@EmergencyName", emergencyName);
                        emgCmd.Parameters.AddWithValue("@EmergencyPhone", emergencyPhone);
                        emgCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Profile details updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUserProfile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating profile: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 5. UPDATE PASSWORD HANDLER & VALIDATION
        // ==========================================
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string currentUserId = UserSession.UserID ?? "U001";
            string currentPassInput = GetControlText("txtCurrentPassword", "txtCurrentPass");
            string newPass = GetControlText("txtNewPassword", "txtNewPass");
            string confirmPass = GetControlText("txtConfirmPassword", "txtConfirmPass");

            if (string.IsNullOrWhiteSpace(currentPassInput) || string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Please fill in all password fields.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("New password and confirmation password do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ENFORCE PASSWORD COMPLEXITY RULES
            if (!IsPasswordComplex(newPass))
            {
                MessageBox.Show(
                    "Password does not meet complexity requirements.\n\nYour new password must contain at least:\n• 1 Uppercase letter (A-Z)\n• 1 Lowercase letter (a-z)\n• 1 Number (0-9)\n• 1 Special character (!@#$%^&* etc.)",
                    "Password Requirements",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string verifyQuery = "SELECT Password FROM user WHERE UserID = @UserID;";
                    using (MySqlCommand verifyCmd = new MySqlCommand(verifyQuery, conn))
                    {
                        verifyCmd.Parameters.AddWithValue("@UserID", currentUserId);
                        object actualPassObj = verifyCmd.ExecuteScalar();

                        if (actualPassObj == null || actualPassObj.ToString() != currentPassInput)
                        {
                            MessageBox.Show("Incorrect current password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string updatePassQuery = "UPDATE user SET Password = @NewPass WHERE UserID = @UserID;";
                    using (MySqlCommand updateCmd = new MySqlCommand(updatePassQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@UserID", currentUserId);
                        updateCmd.Parameters.AddWithValue("@NewPass", newPass);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Password updated successfully!", "Security Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadUserProfile();
                        SetControlText("txtNewPassword", "txtNewPass", string.Empty);
                        SetControlText("txtConfirmPassword", "txtConfirmPass", string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsPasswordComplex(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        // ==========================================
        // 6. PASSWORD MASK / SHOW TOGGLE
        // ==========================================
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            SetPasswordMasking(!(chk?.Checked ?? false));
        }

        private void SetPasswordMasking(bool hidePassword)
        {
            string[] passControls = { "txtCurrentPassword", "txtCurrentPass", "txtNewPassword", "txtNewPass", "txtConfirmPassword", "txtConfirmPass" };
            foreach (string name in passControls)
            {
                TextBox tb = GetControl<TextBox>(name);
                if (tb != null)
                {
                    tb.UseSystemPasswordChar = hidePassword;
                }
            }
        }

        // ==========================================
        // 7. HELPER METHODS FOR DYNAMIC CONTROL LOOKUP
        // ==========================================
        private T GetControl<T>(string name) where T : Control
        {
            if (string.IsNullOrEmpty(name)) return null;
            Control[] found = Controls.Find(name, true);
            return (found.Length > 0 && found[0] is T ctrl) ? ctrl : null;
        }

        private string GetControlText(string primaryName, string fallbackName = null)
        {
            Control ctrl = GetControl<Control>(primaryName) ?? GetControl<Control>(fallbackName);
            return ctrl?.Text.Trim() ?? string.Empty;
        }

        private void SetControlText(string primaryName, string fallbackName, string text)
        {
            Control ctrl = GetControl<Control>(primaryName) ?? GetControl<Control>(fallbackName);
            if (ctrl != null) ctrl.Text = text ?? string.Empty;
        }

        private T FindControl<T>(Control parent) where T : Control
        {
            foreach (Control c in parent.Controls)
            {
                if (c is T typedControl)
                    return typedControl;

                T child = FindControl<T>(c);
                if (child != null)
                    return child;
            }
            return null;
        }

        // Preserved Exact Designer Event Handler Stubs
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void textBox8_TextChanged(object sender, EventArgs e) { }
        private void txtCurrentPassword_TextChanged(object sender, EventArgs e) { }
        private void txtNewPassword_TextChanged(object sender, EventArgs e) { }
        private void txtConfirmPassword_TextChanged(object sender, EventArgs e) { }
        private void txtEmergencyName_TextChanged(object sender, EventArgs e) { }
        private void txtEmergencyPhone_TextChanged(object sender, EventArgs e) { }
        private void txtFullName_TextChanged(object sender, EventArgs e) { }

        // ==========================================
        // 8. MEMBER SIDEBAR NAVIGATION HANDLERS
        // ==========================================
        private void DashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnDashboard_Click(sender, e);
        private void btnDashboard_Click(object sender, EventArgs e) { new MemberDashboard().Show(); this.Hide(); }

        private void EquipmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnEquipment_Click(sender, e);
        private void btnEquipment_Click(object sender, EventArgs e) { new EquipmentCatalog().Show(); this.Hide(); }

        private void ReservationsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnReservations_Click(sender, e);
        private void btnReservations_Click(object sender, EventArgs e) { new MemberReservation().Show(); this.Hide(); }

        private void BorrowedLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnBorrowed_Click(sender, e);
        private void btnBorrowed_Click(object sender, EventArgs e) { new MemberBorrowed().Show(); this.Hide(); }

        private void ScheduleLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnSchedule_Click(sender, e);
        private void btnSchedule_Click(object sender, EventArgs e) { new MemberSchedule().Show(); this.Hide(); }

        private void AccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => btnAccount_Click(sender, e);
        private void btnAccount_Click(object sender, EventArgs e) { } // Already on MemberAccount


        private void logOut_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out of PAIRS?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserSession.EndSession();
                new frmLogin().Show();
                this.Close();
            }
        }
    }
}