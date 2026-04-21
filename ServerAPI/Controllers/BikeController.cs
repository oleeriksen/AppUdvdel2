using Core.Model;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/bike")]
public class BikeController : ControllerBase
{
    private IBikeRepository bikeRepo;

    public BikeController(IBikeRepository repo)
    {
        bikeRepo = repo;
    }

    /// <summary>
    /// Get an array of all bike objects.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Bike[] Get()
    {
        return bikeRepo.GetAll();
    }

    /// <summary>
    /// Add  a bike - a unique id will be assigned
    /// </summary>
    /// <param name="bike">the object to be added - </param>
    [HttpPost]
    public void Add(Bike bike)
    {
        bikeRepo.Add(bike);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public void Delete(int id)
    {
        bikeRepo.Delete(id);
    }

    [HttpDelete]
    [Route("delete")]
    public void DeleteByQuery([FromQuery] int id)
    {
        bikeRepo.Delete(id);
    }
}