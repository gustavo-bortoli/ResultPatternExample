namespace ResultPatternExample.Products.Logging
{
    public static partial class LogEvents
    {
        public static class ProductLogEvents
        {
            public const int SearchingProductStarting = 1;
            public const int ProductNotFound = 2;
            public const int SearchingProductSuccess = 3;
        }
    }
}
