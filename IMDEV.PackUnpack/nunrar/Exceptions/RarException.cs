using System;

namespace NUnrar
{
    public class RarException : ApplicationException
    {
        public RarException(string message)
            : base(message)
        {
        }

        public RarException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
