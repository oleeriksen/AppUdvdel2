using Core;
namespace WebApp1.Service;

public interface IShoppingService
{
    Task<List<ShoppingList>> GetAll();
    Task<ShoppingList> GetById(int id);
    Task Add(ShoppingList sl);
    Task AddItemToList(ShoppingList sl, ShoppingItem item);
    Task UpdateShoppingItem(ShoppingList sl, ShoppingItem item);
}