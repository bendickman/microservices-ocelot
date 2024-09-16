using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Get Customers")]
    public ActionResult<IEnumerable<Customer>> List()
    {
        var customers = new List<Customer>
        {
            new Customer {
                Id = 1,
                Forename = "John",
                Surname = "Smith"
            },
            new Customer {
                Id = 2,
                Forename = "Jane",
                Surname = "Jones"
            },
            new Customer {
                Id = 3,
                Forename = "Fred",
                Surname = "Barrett"
            },
        };

        return Ok(customers);
    }
}
