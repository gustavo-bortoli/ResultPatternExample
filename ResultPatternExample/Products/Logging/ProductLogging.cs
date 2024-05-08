namespace ResultPatternExample.Products.Logging
{
    public static partial class Log
    {
        [LoggerMessage(
            EventId = LogEvents.ProductLogEvents.SearchingProductStarting,
            Level = LogLevel.Information,
            Message = "Buscando produto {ProductId}.")]
        public static partial void StartingToSearchProduct(this ILogger logger, string productId);

        [LoggerMessage(
            EventId = LogEvents.ProductLogEvents.ProductNotFound,
            Level = LogLevel.Error,
            Message = "Produto {ProductId} não encontrado!")]
        public static partial void ProductNotFound(this ILogger logger, string productId);

        [LoggerMessage(
            EventId = LogEvents.ProductLogEvents.SearchingProductSuccess,
            Level = LogLevel.Information,
            Message = "Produto {ProductId} encontrado com sucesso!")]
        public static partial void SuccessOnSearchingProduct(this ILogger logger, string productId);
    }
}
