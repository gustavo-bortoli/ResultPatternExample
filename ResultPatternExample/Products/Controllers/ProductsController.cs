using Microsoft.AspNetCore.Mvc;
using ResultPatternExample.Products.Services;

namespace ResultPatternExample.Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(IProductService service) : ControllerBase
    {
        private readonly IProductService _productService = service;

        [HttpGet("{productId}", Name = "GetProduct")]
        public ActionResult GetById(string productId)
        {
            return _productService.Find(productId);
        }
    }
}
