using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/items")]
public class AddItemController : ControllerBase
{
    private readonly ILogger<AddItemController> _logger;

    public AddItemController(ILogger<AddItemController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public string Add()
    {
        return "Hola!";
    }
}
