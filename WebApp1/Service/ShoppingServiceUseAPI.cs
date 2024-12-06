using Core;

namespace WebApp1.Service;

public class ShoppingServiceUseAPI : IShoppingService
{
    public Task<List<ShoppingList>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingList> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(ShoppingList sl)
    {
        throw new NotImplementedException();
    }

    public Task AddItemToList(ShoppingList sl, ShoppingItem item)
    {
        throw new NotImplementedException();
    }

    public Task UpdateShoppingItem(ShoppingList sl, ShoppingItem item)
    {
        throw new NotImplementedException();
    }
}