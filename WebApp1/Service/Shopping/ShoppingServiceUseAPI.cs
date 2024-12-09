using System.Net.Http.Json;
using Core;

namespace WebApp1.Service.Shopping;

public class ShoppingServiceUseAPI : IShoppingService
{
    private HttpClient http;
    private string serverUrl = $"{ServerConfig.ServerUrl}/api/shopping";
    
    
    public ShoppingServiceUseAPI(HttpClient http)
    {
        this.http = http;
    }

    public async Task<List<ShoppingList>> GetAll()
    {
        var result = await http.GetFromJsonAsync<List<ShoppingList>>($"{serverUrl}/getall");
        return result;
    }

    public async Task<ShoppingList> GetById(int id)
    {
        var result = await http.GetFromJsonAsync<ShoppingList>($"{serverUrl}/getbyid/{id}");
        return result;
    }

    public async Task Add(ShoppingList sl)
    {
        await http.PostAsJsonAsync($"{serverUrl}/add", sl);
    }

    public async Task UpdateShoppingItems(ShoppingList sl)
    {
        await http.PutAsJsonAsync($"{serverUrl}/update", sl);
    }
}