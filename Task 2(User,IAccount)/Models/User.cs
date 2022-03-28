using System;
using System.Text.RegularExpressions;
using Utilities.Exceptions;

namespace Task_2_User_IAccount_.Models
{
    class User : IAccount
    {
        private static int _id;
        private string _password;
        private string _fullName;
        private string _email;
        public int Id { get; }
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    _fullName = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (EmailChecker(value)) _email = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (PasswordChecker(value)) _password = value;
            }
        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
            if (PasswordChecker(password))
                ++_id;
            Id = _id;
        }
        public User(string email, string password, string fullName) : this(email, password)
        {
            FullName = fullName;
        }

        //Password Checker
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
            throw new PasswordNotMatchingException(@"- şifrədə minimum 8 character olmalıdır
- şifrədə ən az 1 böyük hərf olmalıdır
- şifrədə ən az 1 kiçik hərf olmalıdır
- şifrədə ən az 1 rəqəm olmalıdır");
        }

        //Email Checker
        public static bool EmailChecker(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z]+[a-zA-z.!#$%&'*+-=?^`{|}~]{0,64})+[@]+[a-zA-z-]+[.]+[a-zA-z]+$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                throw new EmailNotMatchingException("Email formatı yanlışdır.");
        }

        //Check Full Name Input
        public static bool CheckFullName(ref string fullName)
        {
            if (String.IsNullOrEmpty(fullName) && String.IsNullOrWhiteSpace(fullName))
                throw new IsNullEmptyWhiteSpaceException("Ad Soyad daxil etmək məcburidir.");
            else
                return true;
        }

        //Show Info
        public void ShowInfo()
        {
            Console.WriteLine(@$"User Id - {Id}
Ad Soyad - {FullName}
Email - {Email}");
        }
    }
}
