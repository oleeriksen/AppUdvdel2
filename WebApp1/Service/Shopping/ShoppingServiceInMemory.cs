using Core;

namespace WebApp1.Service.Shopping;

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

    public Task UpdateShoppingItems(ShoppingList sl)
    {
        var theList =mLists.Find((x) => x.Id == sl.Id);
        theList.ShoppingItems = sl.ShoppingItems;
        return Task.CompletedTask;
    }
}