using MySql.Data.MySqlClient;
using System;

namespace WinFormsApp2
{
    public static class UserSession
    {
        public static string CurrentSessionID { get; set; }
        public static string UserID { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }

        // Start session, set static variables, and record login in DB
        public static void StartSession(string userId, string fullName, string role, string sessionId = null)
        {
            UserID = userId;
            FullName = fullName;
            Role = role;
            CurrentSessionID = sessionId;
        }

        public static void EndSession()
        {
            if (!string.IsNullOrEmpty(CurrentSessionID))
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string updateQuery = @"UPDATE authentication_session 
                                               SET LogoutDateTime = NOW() 
                                               WHERE SessionID = @SessionID";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@SessionID", CurrentSessionID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error recording session logout: " + ex.Message);
                    }
                }
            }

            Clear();
        }

        public static void Clear()
        {
            CurrentSessionID = null;
            UserID = null;
            FullName = null;
            Role = null;
        }
    }
}