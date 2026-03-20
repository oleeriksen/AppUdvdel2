using Core.Model;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/bike")]
public class BikeController : ControllerBase
{
    private static readonly BikeRepositoryInMemory bikeRepo = new();

    [HttpGet]
    public Bike[] Get()
    {
        return bikeRepo.GetAll();
    }

    [HttpPost]
    public void Add(Bike bike)
    {
        bikeRepo.Add(bike);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public void Delete(int id)
    {
        bikeRepo.DeleteById(id);
    }

    [HttpDelete]
    [Route("delete")]
    public void DeleteByQuery([FromQuery] int id)
    {
        bikeRepo.DeleteById(id);
    }
}