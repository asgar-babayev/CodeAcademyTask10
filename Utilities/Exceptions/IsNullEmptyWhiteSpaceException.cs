using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Exceptions
{
    public class IsNullEmptyWhiteSpaceException : Exception
    {
        public IsNullEmptyWhiteSpaceException(string message): base(message) { }
    }
}
