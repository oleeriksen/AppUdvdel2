using Core;
namespace WebApp1.Service.Shopping;

public interface IShoppingService
{
    Task<List<ShoppingList>> GetAll();
    Task<ShoppingList> GetById(int id);
    Task Add(ShoppingList sl);
    Task UpdateShoppingItems(ShoppingList sl);
}