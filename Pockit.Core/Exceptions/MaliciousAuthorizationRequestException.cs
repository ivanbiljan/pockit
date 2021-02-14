using System;

namespace Pockit.Core.Exceptions
{
    internal sealed class MaliciousAuthorizationRequestException : Exception
    {
        public MaliciousAuthorizationRequestException()
        {
        }

        public MaliciousAuthorizationRequestException(string message) : base(message)
        {
        }

        public MaliciousAuthorizationRequestException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}