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

        public void AddItemToList(int id, ShoppingItem item)
        {
            var theList = GetById(id);
            item.Id = theList.ShoppingItems.Count + 1;
            theList.ShoppingItems.Add(item);
        }

        public void UpdateShoppingItems(ShoppingList sl)
        {
            var theItem = mLists.Find((x) => x.Id == sl.Id);
            theItem.ShoppingItems = sl.ShoppingItems;
        }
    }
}

