using System;
using Core;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace ServerAPI.Repositories
{
	public class ShoppingRepositoryMongoDB : IShoppingRepository
	{
        private IMongoClient client;
        private IMongoCollection<ShoppingList> collection;

        public ShoppingRepositoryMongoDB()
		{
            var password = "xl2GH1Uxztjtstwf"; //add
            var mongoUri = $"mongodb+srv://olee58:{password}@cluster0.olmnqak.mongodb.net/?retryWrites=true&w=majority";
            
            client = new MongoClient(mongoUri);
                
            // Provide the name of the database and collection you want to use.
            // If they don't already exist, the driver and Atlas will create them
            // automatically when you first write data.
            var dbName = "myDatabase";
            var collectionName = "shopping";

            collection = client.GetDatabase(dbName)
               .GetCollection<ShoppingList>(collectionName);

        }
        

        public List<ShoppingList> GetAll()
        {
           return collection.Find(Builders<ShoppingList>.Filter.Empty).ToList();
        }

        public ShoppingList GetById(int id)
        {
            var xx = collection.Find(Builders<ShoppingList>.Filter.Where((theList) => theList.Id == id));
            var theList = xx.ToList()[0];
            return theList;
        }

        public void Add(ShoppingList sl)
        {
            var max = 0;
            if (collection.Count(Builders<ShoppingList>.Filter.Empty) > 0)
            {
                
                max = collection.Find(Builders<ShoppingList>.Filter.Empty).SortByDescending(r => r.Id).Limit(1).ToList()[0].Id;
            }
            sl.Id = max + 1;
            collection.InsertOne(sl);
        }

        public void UpdateShoppingItems(ShoppingList sl)
        {
            var updateDef = Builders<ShoppingList>.Update
                .Set(x => x.ShoppingItems, sl.ShoppingItems);
            collection.UpdateOne(x => x.Id == sl.Id, updateDef);
        }

        /*public void UpdateItem(ShoppingItem item)
        {
            var updateDef = Builders<ShoppingList>.Update
                 .Set(x => x., item.Amount)
                 .Set(x => x.Description, item.Description)
                 .Set(x => x.Done, item.Done);
            collection.UpdateOne(x => x.Id == item.Id, updateDef);
        }*/
        
        
    }
}

