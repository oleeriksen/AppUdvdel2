using Microsoft.AspNetCore.Components;

namespace WebApp1.Service;

public class LoginService
{
    [Inject] 
    private Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }

    public async Task<bool> IsUserLoggedIn() {
            var res = await localStorage.GetItemAsync<string>("user");
            return res != null;
        }

    public async Task<bool> Login(string username, string password)
    {
        if (username.Equals("peter") && password.Equals("1234"))
        {
            await localStorage.SetItemAsync("user", username);
            return true;
        }
        return false;


    }
}



