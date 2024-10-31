using System;
using Core;
//using Microsoft.Data.Sqlite;

namespace ServerAPI.Repositories
{
    public class ShoppingRepositorySQLite : IShoppingRepository
    {
        private const string connectionString = @"Data Source=Data/shopping.db";

        public ShoppingRepositorySQLite()
        {
        }

        public void AddItem(ShoppingItem item)
        {
            /*using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"INSERT INTO shoppingitem (Name, Price, Amount, Description, Done, Shop) VALUES ($name, $price, $amount, $description, $done, $shop)";
                command.Parameters.AddWithValue("$name", item.Name);
                command.Parameters.AddWithValue("$price", item.Price);
                command.Parameters.AddWithValue("$amount", item.Amount);
                command.Parameters.AddWithValue("$description", item.Description);
                command.Parameters.AddWithValue("$done", item.Done ? 1 : 0);
                command.ExecuteNonQuery();
            }*/
        }

        public void DeleteById(int id)
        {
            /*using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"DELETE FROM shoppingitem WHERE id = $id";
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }*/
        }

        public ShoppingItem[] GetAll()
        {
            /*
            var result = new List<ShoppingItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM shoppingitem";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var price = reader.GetDecimal(2);
                        var amount = reader.GetInt32(3);
                        var description = reader.GetString(4);
                        var done = reader.GetInt32(5) == 0 ? false : true;
                        var shop = reader.GetString(6);

                        var si = new ShoppingItem
                        {
                            Id = id,
                            Name = name,
                            Price = price,
                            Amount = amount,
                            Description = description,
                            Done = done
                          
                        };
                        result.Add(si);
                    }
                }
            }
            return result.ToArray();*/
            return null;
        }

      

        public void UpdateItem(ShoppingItem item)
        {
            /*
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"UPDATE shoppingitem SET Done = $done WHERE id = $id";
                command.Parameters.AddWithValue("$id", item.Id);
                command.Parameters.AddWithValue("$done", item.Done ? 1 : 0);
                command.ExecuteNonQuery();
            }*/
        }
    }
}



