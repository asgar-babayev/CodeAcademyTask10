using System;
using Task_2_User_IAccount_.Models;

namespace Task_2_User_IAccount_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int choise;
            bool result;
            do
            {
                Console.WriteLine(@"0-Proqrami sonlandir
1-Hesab yarat
");
                Console.Write("Seçim edin: ");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 0:
                        Console.WriteLine("Proqram dayandirildi");
                        break;
                    case 1:
                        Console.Write("Ad Soyad daxil edin: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Email daxil edin: ");
                        string email = Console.ReadLine();
                        do
                        {
                            Console.Write("Şifrəni daxil edin: ");
                            string password = Console.ReadLine();
                            User user = new User(email, password, fullName);
                            result = user.PasswordChecker(password);
                            CheckPasswordResult(result);
                            if (result)
                                user.ShowInfo();
                        } while (!result);
                        Console.WriteLine("Hesab yaradıldı");
                        Console.WriteLine("----------------------------------");
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }

        static void CheckPasswordResult(bool result)
        {
            if (!result)
                Console.WriteLine(@"- şifrədə minimum 8 character olmalıdır
- şifrədə ən az 1 böyük hərf olmalıdır
- şifrədə ən az 1 kiçik hərf olmalıdır
- şifrədə ən az 1 rəqəm olmalıdır");
        }

    }
}
