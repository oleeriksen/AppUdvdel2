using Core;

namespace WebApp1.Service;

public interface ILoginService
{
    // return true iff a user is logged in
    Task<User> GetUserLoggedIn();
    
    // Try to login the user in. If
    // user is valid the function will return true and the
    // user is set to be logged in.
    Task<bool> Login(string username, string password);
}