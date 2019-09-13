using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public static class Validations
    {
        //validates email using regex
        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^[a-zA-z][a-zA-Z0-9_]{0,64}@[a-zA-z_][a-zA-z0-9]{0,64}.[a-zA-z]{1,64}$");
            return regex.IsMatch(email);
        }

        //validates password using regex
        public static bool ValidatePassword(string password)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_]{8,64}$");
            return regex.IsMatch(password);
        }

        //validates name using regex
        public static bool ValidateName(string name)
        {
            Regex regex = new Regex(@"^[a-zA-z]{1,32}$");
            return regex.IsMatch(name);
        }
    }
}
