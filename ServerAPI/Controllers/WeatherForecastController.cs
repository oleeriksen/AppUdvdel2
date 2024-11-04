using Microsoft.AspNetCore.Mvc;
using Core;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/vejr")]
public class WeatherForecastController : ControllerBase
{
    private IWeatherRepo mRepo;
    
    public WeatherForecastController(IWeatherRepo repo)
    {
        mRepo = repo;
    }

    [HttpGet]
    [Route("get5")]
    public List<WeatherForecast> Get()
    {
        return mRepo.Get(5);
    }
    
    [HttpGet]
    [Route("getmore/{n:int}")]
    public List<WeatherForecast> GetMore(int n)
    {
        return mRepo.Get(n);
    }
}