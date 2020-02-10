using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseKino.Services.Exceptions
{
    public class InvalidAuthenticateException : Exception
    {
        public InvalidAuthenticateException()
            : base() { }

        public InvalidAuthenticateException(string message)
            : base(message) { }
    }
}
