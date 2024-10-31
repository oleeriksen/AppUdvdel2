using Core;

namespace ServerAPI.Repositories
{
    public interface IShoppingRepository
    {
        //Tildeler item en unik id og tilføjer den.
        void AddItem(ShoppingItem item);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes sker ingenting
        void DeleteById(int id);

        ShoppingItem[] GetAll();

        
        // Opdaterer element med Id = item.Id.
        void UpdateItem(ShoppingItem item);
    }
}