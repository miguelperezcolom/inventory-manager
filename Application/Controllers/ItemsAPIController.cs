using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/v1/items")]
public class ItemsAPIController : ControllerBase
{
    private readonly ILogger<ItemsAPIController> _logger;

    public ItemsAPIController(ILogger<ItemsAPIController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public string Add()
    {
        return "Hola!";
    }
    
    [HttpGet]
    public string Get()
    {
        return "Hola!";
    }
    
    [HttpDelete]
    public string Delete()
    {
        return "Hola!";
    }
}
