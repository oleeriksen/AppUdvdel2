using System;
using Core;
using Microsoft.Data.Sqlite;

namespace ServerAPI.Repositories
{
    public class LoginRepositorySQLite : ILoginRepository
    {
        private const string connectionString = @"Data Source=Data/logindb.db";

        private User[]? users;

        public LoginRepositorySQLite()
        {
            users = GetAll();
        }

        private User[] GetAll()
        {
            Role[]? roles = null;

            var result = new List<User>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                roles = LoadRoles(connection);
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM User";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var username = reader.GetString(1);
                        var password = reader.GetString(2);
                        var email = reader.GetString(3); // not used
                      
                        var roleId = reader.GetInt32(4);

                        var user = new User
                        {
                            Id = id,
                            Username = username,
                            Password = password,
                            Role = roles.Where(r => r.Id == roleId).Single<Role>()
                        };
                        result.Add(user);
                    }
                }
            }
            return result.ToArray();
        }

        private Role[] LoadRoles(SqliteConnection connection) {
            var res = new List<Role>();
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Role";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);

                    var role = new Role
                    {
                        Id = id,
                        Name = name
                    };
                    res.Add(role);
                }
            }
            return res.ToArray();
        }

        public bool IsValid(User user)
        {
            var theUser = users.Where( u => u.Username.Equals(user.Username,StringComparison.OrdinalIgnoreCase) &&
                                               u.Password.Equals(user.Password));

            return (theUser != null && theUser.Count() == 1);
        }

        public User GetUserByUserName(string username)
        {
            var theUser = users.Where(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            return theUser.Single<User>();
        }
    }
}

