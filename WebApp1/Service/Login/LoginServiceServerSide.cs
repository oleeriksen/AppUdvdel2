using System.Net.Http.Json;
using Blazored.LocalStorage;
using Core;

namespace WebApp1.Service.Login;

public class LoginServiceServerSide : LoginServiceClientSide
{
    private HttpClient http;
    
    private string serverUrl = "http://localhost:5151";
    public LoginServiceServerSide(ILocalStorageService ls, HttpClient http) : base(ls)
    {
        this.http = http;
        
    }

    protected override async Task<bool> Validate(string username, string password)
    {
        User user = new User() { Username = username, Password = password , Role= new Role{Id=0, Name = "admin"}};
        var res = await http.PostAsJsonAsync<User>($"{serverUrl}/api/login/validate", user);
        var body = await res.Content.ReadAsStringAsync();
        return body.Equals("true");
    }
}