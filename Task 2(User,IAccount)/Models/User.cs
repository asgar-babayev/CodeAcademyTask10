using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_User_IAccount_.Models
{
    class User : IAccount
    {
        private static int Id { get; set; }
        public static string FullName { get; set; }
        public static string Email { get; set; }
        public string Password { get; set; }

        public User(string email, string password)
        {
            Id++;
            Email = email;
            Password = password;
        }
        public User(string email, string password, string fullName) : this(email, password)
        {
            FullName = fullName;
        }
        public bool PasswordChecker(string password)
        {
            int upper = 0;
            int lower = 0;
            int number = 0;
            foreach (char enteredCharacters in password)
            {
                if (char.IsUpper(enteredCharacters))
                    upper++;
                else if (char.IsLower(enteredCharacters))
                    lower++;
                else if (char.IsDigit(enteredCharacters))
                    number++;
            }
            if (upper >= 1 && lower >= 1 && number >= 1 && password.Length >= 8)
            {
                return true;
            }
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine(@$"User Id - {Id}
Ad Soyad - {FullName}
Email - {Email}");
        }
    }
}
