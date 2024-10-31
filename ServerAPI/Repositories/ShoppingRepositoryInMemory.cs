using Core;

namespace ServerAPI.Repositories
{
    public class ShoppingRepositoryInMemory : IShoppingRepository
    {
        private List<ShoppingItem> mProducts = new() {
                  new ShoppingItem { Id = 1, Name = "bananer", Price = 12, Done = true },
                  new ShoppingItem { Id = 2, Name = "Æbler", Price = 14, Done = false  }
        };

        public void AddItem(ShoppingItem item){
            int newId = mProducts.Select(x => x.Id).Max() + 1;
            item.Id = newId;
            mProducts.Add(item);
        }

        public void DeleteById(int id) {
            mProducts.RemoveAll((item) => item.Id == id);
        }

        public ShoppingItem[] GetAll() => mProducts.ToArray();

        

        public void UpdateItem(ShoppingItem item){
            DeleteById(item.Id);
            mProducts.Add(item);
        }
    }
}

