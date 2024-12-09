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

    public Task UpdateShoppingItems(ShoppingList sl)
    {
        throw new NotImplementedException();
    }
}