using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Exceptions
{
    public class PasswordNotMatchingException : Exception
    {
        public PasswordNotMatchingException(string message):base(message) { }
    }
}
