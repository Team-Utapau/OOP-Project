using System;

namespace Utrepalo.Game.Exceptions
{
    public class InvalidObjectParametarException : ArgumentOutOfRangeException
    {
        public InvalidObjectParametarException(string paramName, string message) : base(paramName, message)
        {
        }
    }
}
