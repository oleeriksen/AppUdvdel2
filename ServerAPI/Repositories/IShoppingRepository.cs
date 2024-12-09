using Core;

namespace ServerAPI.Repositories
{
    /*
     * Repræsenterer en samling af ShoppingItems.
     */
    public interface IShoppingRepository
    {
        List<ShoppingList> GetAll();
        
        ShoppingList GetById(int id);
        
        void Add(ShoppingList sl);
        
        void UpdateShoppingItems(ShoppingList sl);
    }
}