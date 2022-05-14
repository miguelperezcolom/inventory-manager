using Application.Model;
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
    public void Add(Item item)
    {
    }
    
    [HttpGet]
    public Item Get()
    {
        return new Item();
    }
    
    [HttpDelete]
    public void Delete(Item item)
    {
    }
}
