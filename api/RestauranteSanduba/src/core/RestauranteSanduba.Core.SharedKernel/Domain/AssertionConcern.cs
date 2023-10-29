namespace RestauranteSanduba.Core.Common.Domain
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

        public static void AsserArgumentNotEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue))
            {
                throw new DomainException(message);
            }
        }
    }
}
