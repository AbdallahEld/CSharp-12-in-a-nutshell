using System;
using System.Collections.Generic;
using System.Text;

namespace CAExceptions
{
    internal class AccidentException : Exception
    {
        public string Location { get; set; }
        public AccidentException(string location, string message) : base(message) 
        {
            Location = location;
        }
    }
}
