using ResultPatternExample.Domain.ResultPattern;
using ResultPatternExample.Products.Entities;
using ResultPatternExample.Products.Logging;
using ResultPatternExample.Products.Repositories;
using ResultPatternExample.Utilities.GeneratedRegex;

namespace ResultPatternExample.Products.Services.Imp
{
    public class ProductService(IProductRepository repository, ILogger<ProductService> logger) : IProductService
    {
        private readonly ILogger<ProductService> _logger = logger;
        private readonly IProductRepository _repository = repository;

        public Result<ProductEntity> Find(string productId)
        {
            _logger.StartingToSearchProduct(productId);

            if (string.IsNullOrEmpty(productId))
                return Error.NullOrEmpty(nameof(productId));

            if (!productId.IsOnlyNumbers())
                return Error.OnlyNumbersAccepted(nameof(productId));

            var product = _repository.Find(productId);

            if (product is null)
            {
                _logger.ProductNotFound(productId);
                return Error.ProductNotFound(productId);
            }

            _logger.SuccessOnSearchingProduct(productId);
            return product;
        }
    }
}
