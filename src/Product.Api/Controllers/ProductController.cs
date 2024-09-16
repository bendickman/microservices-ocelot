using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = new List<Product>()
        {
            new Product {
                Id = 1,
                Name = "Phone",
                Sku = "abc123",
            },
            new Product {
                Id = 2,
                Name = "Computer",
                Sku = "def456",
            },
        };

        return Ok(products);
    }
}
