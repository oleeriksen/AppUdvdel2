using Core;

namespace WebApp1.Service;

public class ShoppingServiceInMemory : IShoppingService
{
    private List<ShoppingList> mLists = new();

    public ShoppingServiceInMemory()
    {
        mLists.Add(new ShoppingList { Id = 1, ShoppingItems = new(), Name = "indkøb 1" });
        
    }

    public async Task<List<ShoppingList>> GetAll()
    {
        return mLists;
    }

    public async Task<ShoppingList> GetById(int id)
    {
        var theList = mLists.Find((sl) => sl.Id == id);
        return theList;
    }

    public Task Add(ShoppingList sl)
    {
        sl.Id = mLists.Count + 1; // fix me
        mLists.Add(sl);
        return Task.CompletedTask;
    }

    public Task AddItemToList(ShoppingList sl, ShoppingItem item)
    {
        item.Id = sl.ShoppingItems.Count + 1;
        sl.ShoppingItems.Add(item);
        return Task.CompletedTask;
    }

    public Task UpdateShoppingItem(ShoppingList sl, ShoppingItem item)
    {
        var theItem = sl.ShoppingItems.Find((it) => it.Id == item.Id);
        theItem.Done = item.Done;
        return Task.CompletedTask;
    }
}