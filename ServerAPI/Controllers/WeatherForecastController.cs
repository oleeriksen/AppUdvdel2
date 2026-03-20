using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace ServerAPI.Controllers;

[ApiController]
[Route("vejr")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    public List<WeatherForecast> Get()
    {
        return GetByCount(10);
    }
    
    [HttpGet]
    [Route("{count:int}")]
    public List<WeatherForecast> GetByNumber(int count)
    {
        return GetByCount(count);
    }
    
    [HttpGet]
    [Route("interval/{min:int}/{max:int}")]
    public List<WeatherForecast> GetByInterval(int min, int max)
    {
        var all = GetByCount(1000);
        return all.Where(w => min <= w.TemperatureC && w.TemperatureC <= max).ToList();
    }
    
    [HttpGet]
    [Route("summary/{summary}")]
    public List<WeatherForecast> GetBySummary(string summary)
    {
        var all = GetByCount(1000);
        return all.Where(w => w.Summary.Equals(summary, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    private List<WeatherForecast> GetByCount(int count)
    {
        return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
    }
}