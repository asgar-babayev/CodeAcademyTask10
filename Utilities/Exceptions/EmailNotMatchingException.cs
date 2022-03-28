using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Exceptions
{
    public class EmailNotMatchingException : Exception
    {
        public EmailNotMatchingException(string message) : base(message) { }
    }
}
