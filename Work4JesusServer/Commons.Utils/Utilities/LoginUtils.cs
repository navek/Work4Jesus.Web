using System;
using System.Text.RegularExpressions;

namespace Commons.Utils.Utilities
{
    /// <summary>
    /// </summary>
    public static class LoginUtils
    {
        //TODO set the method
        public static bool IsValid(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                return false;
            }
            try
            {
                var regex =
                    new Regex("^[a-zA-Z][a-zA-Z0-9._-]{0,21}([-.][^_]|[^-.]{2})$",
                        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
                return regex.IsMatch(login);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}