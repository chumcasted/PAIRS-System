using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WinFormsApp2
{
    public static class PasswordValidator
    {
        public static bool ValidatePassword(string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Password cannot be empty.";
                return false;
            }

            // Rule 1: Minimum length of 12 characters
            if (password.Length < 12)
            {
                errorMessage = "Password must be at least 12 characters long.";
                return false;
            }

            // Rule 2: At least 1 uppercase letter
            if (!password.Any(char.IsUpper))
            {
                errorMessage = "Password must contain at least one uppercase letter (A-Z).";
                return false;
            }

            // Rule 3: At least 1 number
            if (!password.Any(char.IsDigit))
            {
                errorMessage = "Password must contain at least one numeric digit (0-9).";
                return false;
            }

            // Rule 4: At least 1 special character
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                errorMessage = "Password must contain at least one special character (e.g., !@#$%^&*).";
                return false;
            }

            return true;
        }
    }
}