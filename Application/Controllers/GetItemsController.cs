using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/items")]
public class GetItemsController : ControllerBase
{
    private readonly ILogger<RemoveItemController> _logger;

    public GetItemsController(ILogger<RemoveItemController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        return "Hola!";
    }
}
