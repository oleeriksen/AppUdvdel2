using System.Net.Http.Json;
using Core.Model;
using WebApp.Pages;


namespace WebApp.Service;

public class BikeServiceHttp : IBikeService
{
    
    private HttpClient client;
    
    public BikeServiceHttp(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<Bike>?> GetAll()
    {
        var data = await client.GetFromJsonAsync<List<Bike>?>($"{Config.ServerUrl}/api/bike");
        return data;
    }

    public async Task AddBike(Bike bike)
    {
        await client.PostAsJsonAsync($"{Config.ServerUrl}/api/bike", bike);
    }

    public async Task DeleteById(int id)
    {
        await client.DeleteAsync($"{Config.ServerUrl}/api/bike/delete?id={id}");
    }
}