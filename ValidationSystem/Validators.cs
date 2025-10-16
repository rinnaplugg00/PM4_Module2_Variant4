using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ValidationSystem
{
    public static class Validators
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string pattern = @"^[\w\.\-]+@[a-zA-Z\d\-]+(\.[a-zA-Z]{2,})+$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            string cleaned = Regex.Replace(phone, @"[\s\-\(\)]", "");
            string pattern = @"^(\+7|8)\d{10}$";
            return Regex.IsMatch(cleaned, pattern);
        }

        public static bool IsValidDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date)) return false;
            return DateTime.TryParseExact(date, "dd.MM.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        public static bool IsStrongPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            string pattern = @"^[A-Za-z0-9_]{3,16}$";
            return Regex.IsMatch(username, pattern);
        }

        public static bool IsValidPostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode)) return false;
            string pattern = @"^\d{6}$";
            return Regex.IsMatch(postalCode, pattern);
        }
    }
}
