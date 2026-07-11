using System;
using System.Collections.Generic;
using System.Text;

namespace CAExceptions
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string message) :base(message)
        {
            
        }
    }
}
