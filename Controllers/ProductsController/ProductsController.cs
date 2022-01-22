using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;
using TestApplication.Services;

namespace TestApplication.ProductsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // Getters and setters are set. This is a class variable.
        public IJsonFileProductService ProductService { get; }

        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        // [HttpPatch]
        // [HttpPost]
        [Route("rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string productId, [FromQuery] int rating)
        {
            ProductService.AddRatings(productId, rating);

            return Ok();
        }
    }
}
