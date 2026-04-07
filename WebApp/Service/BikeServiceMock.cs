using Core.Model;

namespace WebApp.Service;

public class BikeServiceMock : IBikeService
{
    private List<Bike> mBikes = new();
    
    
    public async Task<List<Bike>> GetAll()
    {
        return mBikes;
    }

    public Task DeleteById(int id)
    {
        mBikes.RemoveAll(b => b.Id == id);
        return Task.CompletedTask;
    }

    public Task AddBike(Bike bike)
    {
        bike.Id = Random.Shared.Next();
        mBikes.Add(bike);
        return Task.CompletedTask;
    }
}