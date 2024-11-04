using Core;

namespace ServerAPI.Repositories;

public interface IWeatherRepo
{
    List<WeatherForecast> Get(int n);
}