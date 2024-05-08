using ResultPatternExample.Domain.ResultPattern;
using ResultPatternExample.Products.Entities;

namespace ResultPatternExample.Products.Services
{
    public interface IProductService
    {
        Result<ProductEntity> Find(string productId);
    }
}