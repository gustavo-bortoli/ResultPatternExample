using ResultPatternExample.Products.Entities;

namespace ResultPatternExample.Products.Repositories.Imp
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductEntity> _products =
            [
                new ProductEntity { ProductId = "1", ProductName = "Monitor"},
                new ProductEntity { ProductId = "2", ProductName = "Teclado"},
                new ProductEntity { ProductId = "3", ProductName = "Mouse"},
                new ProductEntity { ProductId = "4", ProductName = "Headset"},
            ];

        public ProductEntity? Find(string productId)
        {
            return _products.FirstOrDefault(x => productId.Equals(x.ProductId));
        }
    }
}
