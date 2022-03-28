using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Exceptions
{
    public class NotAvailableException : Exception
    {
        public NotAvailableException(string message) : base(message) { }

    }
}
