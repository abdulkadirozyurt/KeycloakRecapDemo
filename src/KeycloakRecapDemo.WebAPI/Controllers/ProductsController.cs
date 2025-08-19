
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakRecapDemo.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
public class ProductsController : ControllerBase
{
    private static readonly string[] Products = new[]
    {
        "Product A", "Product B", "Product C"
    };

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return Products;
    }
}
