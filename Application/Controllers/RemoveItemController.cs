using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/items")]
public class RemoveItemController : ControllerBase
{
    private readonly ILogger<RemoveItemController> _logger;

    public RemoveItemController(ILogger<RemoveItemController> logger)
    {
        _logger = logger;
    }

    [HttpDelete]
    public string Delete()
    {
        return "Hola!";
    }
}
