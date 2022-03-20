using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_User_IAccount_.Models
{
    interface IAccount
    {
        bool PasswordChecker(string password);
        void ShowInfo();
    }
}
