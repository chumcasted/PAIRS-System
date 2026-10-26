using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace WinFormsApp2
{
    public static class DatabaseHelper
    {
        private static string connString = "Server=localhost; Database=pairs_db; Uid=root; Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}