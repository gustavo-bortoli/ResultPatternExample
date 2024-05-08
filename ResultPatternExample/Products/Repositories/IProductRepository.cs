using ResultPatternExample.Products.Entities;

namespace ResultPatternExample.Products.Repositories
{
    public interface IProductRepository
    {
        ProductEntity? Find(string productId);
    }
}
