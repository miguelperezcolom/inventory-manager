using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Mappers;
using Application.Model;
using Domain.Exceptions;
using Domain.InventoryAggregate;
using Domain.Services.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/items")]
public class ItemsAPIController : ControllerBase
{
    private readonly ILogger<ItemsAPIController> _logger;
    private readonly CommandFactory _commandFactory;


    public ItemsAPIController(ILogger<ItemsAPIController> logger, CommandFactory commandFactory)
    {
        _logger = logger;
        _commandFactory = commandFactory;
    }

    [HttpPost]
    public async Task<ActionResult<Item>> Add(Item item)
    {
        try
        {
            var command = _commandFactory.CreateAddItemCommand(item.Name, DateOnly.Parse(item.ExpirationDate), Enum.Parse<ItemType>(item.Type));
            var itemCreated = await command.RunAsync();
            var result = Mapper.MapToModel(itemCreated);      
            return Ok(result);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IList<Item>>> GetAll()
    {
        var command = _commandFactory.CreateGetItemsQuery();
        var items = await command.RunAsync();
        var result = Mapper.MapToModel(items);      
        return Ok(result);
     }
    
    [HttpGet]
    [Route("{itemId}")]
    public async Task<ActionResult<Item>> GetItem(
        [Required(AllowEmptyStrings = false)]
        [FromRoute] string itemId)
    {
        var command = _commandFactory.CreateGetItemQuery(itemId);
        var item = await command.RunAsync();
        if (item == null) return NotFound();
        var result = Mapper.MapToModel(item);      
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete(Item item)
    {
        var command = _commandFactory.CreateRemoveItemCommand(item.Name);
        await command.RunAsync();
        return NoContent();
    }
}