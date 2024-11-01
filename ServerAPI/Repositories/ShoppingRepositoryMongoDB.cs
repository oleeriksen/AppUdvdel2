using System;
using Core;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace ServerAPI.Repositories
{
	public class ShoppingRepositoryMongoDB : IShoppingRepository
	{
        private IMongoClient client;
        private IMongoCollection<ShoppingItem> collection;

        public ShoppingRepositoryMongoDB()
		{
            var password = "paste password here"; //add
            var mongoUri = $"mongodb+srv://olee58:{password}@cluster0.olmnqak.mongodb.net/?retryWrites=true&w=majority";

            

            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
                Console.WriteLine(e);
                Console.WriteLine();
                return;
            }

            // Provide the name of the database and collection you want to use.
            // If they don't already exist, the driver and Atlas will create them
            // automatically when you first write data.
            var dbName = "myDatabase";
            var collectionName = "shoppingitems";

            collection = client.GetDatabase(dbName)
               .GetCollection<ShoppingItem>(collectionName);

        }

        public void AddItem(ShoppingItem item)
        {
            var max = 0;
            if (collection.Count(Builders<ShoppingItem>.Filter.Empty) > 0)
            {
                max = collection.Find(Builders<ShoppingItem>.Filter.Empty).SortByDescending(r => r.Id).Limit(1).ToList()[0].Id;
            }
            item.Id = max + 1;
            collection.InsertOne(item);
           
        }

        public void DeleteById(int id){
            var deleteResult = collection
                .DeleteOne(Builders<ShoppingItem>.Filter.Where(r => r.Id == id));
        }

        public ShoppingItem[] GetAll()
        {
           return collection.Find(Builders<ShoppingItem>.Filter.Empty).ToList().ToArray();
        }

        /*public ShoppingItem[] GetAllByShop(string shop)
        {
            var filter = Builders<ShoppingItem>.Filter.Where(r => r.Shop.Equals(shop));
            return collection.Find(filter).ToList().ToArray();

        }*/

        public void UpdateItem(ShoppingItem item)
        {
            var updateDef = Builders<ShoppingItem>.Update
                 .Set(x => x.Amount, item.Amount)
                 .Set(x => x.Description, item.Description)
                 .Set(x => x.Done, item.Done);
            collection.UpdateOne(x => x.Id == item.Id, updateDef);
        }
    }
}

