using Core;

namespace ServerAPI.Repositories;

public class LoginRepositoryInMemory: ILoginRepository
{
    private List<User> users = new()
    {
        new User { Username = "rip", Password = "1234", Role = "admin" },
        new User { Username = "rap", Password = "2345", Role="worker"},
        new User { Username = "rup", Password = "3456", Role="guest"}
    };


    public bool IsValid(User user)
    {
        return users.Count((u) => user.Username == u.Username && user.Password == u.Password) > 0;
    }
}