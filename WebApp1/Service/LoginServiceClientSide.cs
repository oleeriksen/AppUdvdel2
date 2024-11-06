using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using Core;

namespace WebApp1.Service;

public class LoginServiceClientSide : ILoginService  {
    
    private ILocalStorageService localStorage { get; set; }
    
    public LoginServiceClientSide(ILocalStorageService ls) {
        localStorage = ls;
    }
    public async Task<User?> GetUserLoggedIn() {
            var res = await localStorage.GetItemAsync<User>("user");
            return res;
    }
    public async Task<bool> Login(string username, string password) {
        if (username.Equals("peter") && password.Equals("1234"))
        {
            User user = new User { Username = username, Password = "verfied", Role = "admin" };
            
            await localStorage.SetItemAsync("user", user);
            return true;
        }
        return false;
    }
}



