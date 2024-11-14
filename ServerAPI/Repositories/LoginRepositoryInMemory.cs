using Core;

namespace ServerAPI.Repositories;

public class LoginRepositoryInMemory: ILoginRepository
{
    private List<User> users = new()
    {
        new User { Username = "rip", Password = "1234", Role = new Role {Id=1, Name="admin"} },
        new User { Username = "rap", Password = "2345", Role = new Role {Id = 2, Name = "worker"}},
        new User { Username = "rup", Password = "3456", Role = new Role {Id = 3, Name = "guest"}}
    };


    public bool IsValid(User user)
    {
        return users.Count((u) => user.Username == u.Username && user.Password == u.Password) > 0;
    }
}