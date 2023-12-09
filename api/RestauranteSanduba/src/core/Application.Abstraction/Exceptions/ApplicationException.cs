using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Exceptions
{
    public class ApplicationException : Exception
    {
        internal protected ApplicationException() { }
        internal protected ApplicationException(string message) : base(message) { }
        internal protected ApplicationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
