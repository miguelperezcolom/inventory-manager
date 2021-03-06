using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.InventoryAggregate;
using Domain.Services.Factories;
using FluentAssertions;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Item = Application.Model.Item;

namespace Tests.Application;

public class ApiTests
{

    [Fact]
    public async Task api_post_item_created()
    {
        // given
        var mock = new Mock<ILogger<ItemsApiController>>();
        ILogger<ItemsApiController> logger = mock.Object;
        var controller = new ItemsApiController(logger, new CommandFactory(
            new InMemoryInventoryRepository(), new SimpleEventBus()));
        var item = new Item()
        {
            Name = "test",
            ExpirationDate = "2022-05-14",
            Type = ItemType.Box.ToString()
        };

        // when
        var result = await controller.Add(item);
        var okResult = result.Result as OkObjectResult;

        // then
        Assert.NotNull(okResult);
        Assert.NotNull(okResult.Value);
        var returnedItem = okResult.Value as Item;
        item.Should().BeEquivalentTo(returnedItem);
    }
    
    [Fact]
    public async Task api_get_items_returned()
    {
        // given
        var mock = new Mock<ILogger<ItemsApiController>>();
        ILogger<ItemsApiController> logger = mock.Object;
        var controller = new ItemsApiController(logger, new CommandFactory(
            new InMemoryInventoryRepository(), new SimpleEventBus()));
        var item1 = new Item()
        {
            Name = "test1",
            ExpirationDate = "2022-05-14",
            Type = ItemType.Box.ToString()
        };
        await controller.Add(item1);
        var item2 = new Item()
        {
            Name = "test2",
            ExpirationDate = "2022-05-14",
            Type = ItemType.Document.ToString()
        };
        await controller.Add(item2);
        var items = new List<Item>()
        {
            item1, item2
        };
        
        // when
        var result = await controller.GetAll();
        var okResult = result.Result as OkObjectResult;

        // then
        Assert.NotNull(okResult);
        Assert.NotNull(okResult.Value);
        var returnedItems = okResult.Value as IList<Item>;
        items.Should().BeEquivalentTo(returnedItems);       
    }
    
    [Fact]
    public async Task api_get_item_returned()
    {
        // given
        var mock = new Mock<ILogger<ItemsApiController>>();
        ILogger<ItemsApiController> logger = mock.Object;
        var controller = new ItemsApiController(logger, new CommandFactory(
            new InMemoryInventoryRepository(), new SimpleEventBus()));
        var item = new Item()
        {
            Name = "test",
            ExpirationDate = "2022-05-14",
            Type = ItemType.Box.ToString()
        };
        await controller.Add(item);

        // when
        var result = await controller.GetItem("test");
        var okResult = result.Result as OkObjectResult;

        // then
        Assert.NotNull(okResult);
        Assert.NotNull(okResult.Value);
        var returnedItem = okResult.Value as Item;
        item.Should().BeEquivalentTo(returnedItem);       
    }
    
    [Fact]
    public async Task api_delete_item_removed()
    {
        // given
        var mock = new Mock<ILogger<ItemsApiController>>();
        ILogger<ItemsApiController> logger = mock.Object;
        var controller = new ItemsApiController(logger, new CommandFactory(
            new InMemoryInventoryRepository(), new SimpleEventBus()));
        var item = new Item()
        {
            Name = "test",
            ExpirationDate = "2022-05-14",
            Type = ItemType.Box.ToString()
        };
        await controller.Add(item);

        // when
        var result = await controller.Delete(item);
        var ncResult = result as NoContentResult;

        // then
        Assert.NotNull(ncResult);
        var result2 = await controller.GetItem("test");
        var nfResult = result2.Result as NotFoundResult;
        Assert.NotNull(nfResult);
    }

}