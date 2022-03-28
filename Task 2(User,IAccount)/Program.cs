using System;
using Task_2_User_IAccount_.Models;
using Utilities.Exceptions;

namespace Task_2_User_IAccount_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            User[] users = new User[0];
            int choise = 0;
            string fullName = "";
            string email = "";
            string password = "";
            bool resultFullname;
            bool resultPassword;
            bool resultEmail;

            do
            {
                Console.WriteLine(@"0 - Proqrami sonlandir
1 - Hesab yarat
2 - Hesaba giriş et
3 - Informasiya Al
");
            Start:
                Console.Write("Seçim edin: ");
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ancaq rəqəm daxil edə bilərsiniz");
                    goto Start;
                }

                switch (choise)
                {
                    case 0:
                        Console.WriteLine("Proqram dayandirildi");
                        break;
                    case 1:
                    SetFullName:
                        try
                        {
                            SetFullNameInput(ref fullName);
                            resultFullname = User.CheckFullName(ref fullName);
                            if (!resultFullname)
                                goto SetFullName;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto SetFullName;
                        }


                    SetEmail:
                        try
                        {
                            SetEmailInput(ref email);
                            resultEmail = User.EmailChecker(email);
                            if (!resultEmail)
                                goto SetEmail;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto SetEmail;
                        }
                    SetPassword:
                        try
                        {
                            SetPasswordInput(ref password);
                            User user = new User(email, password, fullName);
                            resultPassword = user.PasswordChecker(password);
                            if (!resultPassword)
                                goto SetPassword;
                            Array.Resize(ref users, users.Length + 1);
                            users[users.Length - 1] = user;
                            Console.WriteLine("Hesab yaradıldı");
                            Console.WriteLine("----------------------------------");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto SetPassword;
                        }
                        break;
                    case 2:
                        SetEmailInput(ref email);
                        SetPasswordInput(ref password);
                        bool isOk = false;
                        try
                        {
                            foreach (User item in users)
                            {
                                while (item != null && item.Email == email && item.Password == password)
                                {
                                    Console.WriteLine($"Id-{item.Id}: {item.FullName} hesabına giriş etdiniz.");
                                    Console.WriteLine("----------------------------------------------------------");
                                    isOk = true;
                                    break;
                                }
                            }
                            if (isOk == false)
                                throw new NotAvailableException("Belə hesab mövcud deyil");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        foreach (var u in users)
                        {
                            if (u != null)
                            {
                                u.ShowInfo();
                            }
                            else
                                break;
                        }
                        Console.WriteLine("----------------------------------");
                        break;
                    default:
                        Console.WriteLine("Yanlış məlumat daxil edildi");
                        break;
                }
            } while (choise != 0);
        }

        //Set FullName Input
        static void SetFullNameInput(ref string fullname)
        {
            Console.Write("Ad Soyad daxil edin: ");
            fullname = Console.ReadLine().Trim();
        }

        //Set Email Input
        static void SetEmailInput(ref string email)
        {
            Console.Write("Email daxil edin: ");
            email = Console.ReadLine().Trim().Replace(" ", String.Empty);
        }

        //Set Password Input
        static void SetPasswordInput(ref string password)
        {
            Console.Write("Şifrəni daxil edin: ");
            password = Console.ReadLine().Trim().Replace(" ", String.Empty);
        }
    }
}
