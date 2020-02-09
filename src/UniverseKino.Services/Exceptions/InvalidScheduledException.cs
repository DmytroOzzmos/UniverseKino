using System;

namespace UniverseKino.Services.Exceptions
{
    public class InvalidScheduledException : Exception
    {
        public InvalidScheduledException()
            : base() { }

        public InvalidScheduledException(string message)
            : base(message) { }
    }
}
