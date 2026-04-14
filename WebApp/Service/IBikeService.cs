using Core.Model;

namespace WebApp.Service;


public interface IBikeService
{
    Task<List<Bike>> GetAll();
    Task DeleteById(int id);
    Task AddBike(Bike bike);
}