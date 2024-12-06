using Core;

namespace ServerAPI.Repositories
{
    public class ShoppingRepositoryInMemory : IShoppingRepository
    {
        private List<ShoppingList> mLists = new();

        public ShoppingRepositoryInMemory()
        {
            mLists.Add(new ShoppingList { Id = 1, ShoppingItems = new(), Name = "indkøb 1" });
        
        }

        public List<ShoppingList> GetAll()
        {
            return mLists;
        }

        public ShoppingList GetById(int id)
        {
            var theList = mLists.Find((sl) => sl.Id == id);
            return theList;
        }

        public void Add(ShoppingList sl)
        {
            sl.Id = mLists.Count + 1; // fix me
            mLists.Add(sl);
        }

        public void AddItemToList(ShoppingList sl, ShoppingItem item)
        {
            item.Id = sl.ShoppingItems.Count + 1;
            sl.ShoppingItems.Add(item);
        }

        public void UpdateShoppingItem(ShoppingList sl, ShoppingItem item)
        {
            var theItem = sl.ShoppingItems.Find((it) => it.Id == item.Id);
            theItem.Done = item.Done;
        }
    }
}

