using System;

namespace UniverseKino.Services.Exceptions
{
    public class EntityIsNotExistException : Exception
    {
        public EntityIsNotExistException()
            : base() { }

        public EntityIsNotExistException(string message)
            : base(message) { }
    }
}
