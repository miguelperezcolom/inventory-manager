using System;
using System.Linq;
using Domain.InventoryAggregate;
using Infrastructure;
using Xunit;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void repo_add_item_item_added()
    {
        //given
        var repo = new InMemoryInventoryRepository();
        var name = "test";
        var expDate = new DateOnly(2022, 05, 13);
        var type = ItemType.Basic;
        
        //when
        var inventory = repo.Load();
        inventory.AddItem(name, expDate, type);
        repo.Save(inventory);
        
        //then
        var items = repo.Load().GetItems();
        Assert.NotEmpty(items.Where(item => item.Name.Equals(name)));
        var item = items.First(item => item.Name.Equals(name));
        Assert.Equal(name, item.Name);
        Assert.Equal(expDate, item.ExpirationDate);
        Assert.Equal(type, item.Type);
    }
    
    [Fact]
    public void repo_remove_item_item_removed()
    {
        //given
        var repo = new InMemoryInventoryRepository();
        var name = "test";
        var expDate = new DateOnly(2022, 05, 13);
        var type = ItemType.Basic;
        var inventory = repo.Load();
        inventory.AddItem(name, expDate, type);
        repo.Save(inventory);
        
        //when
        inventory = repo.Load();
        inventory.RemoveItem(name);
        repo.Save(inventory);
        
        //then
        var items = repo.Load().GetItems();
        Assert.Empty(items.Where(item => item.Name.Equals(name)));
    }
}