using RestauranteSanduba.Core.Domain.Common.Exceptions;
using System.Collections;

namespace RestauranteSanduba.Core.Domain.Common.Assertions
{
    public static class AssertionConcern
    {
        public static void AssertArgumentLength(string stringValue, int maximum, string message)
        {
            AssertArgumentLength(stringValue, 0, maximum, message);
        }

        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue))
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentNotEmpty(ICollection collection, string message)
        {
            if (collection.Count < 1)
            {
                throw new DomainException(message);
            }
        }
    }
}
