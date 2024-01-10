using WebApiBoilerPlate.Core.Domain.Entities;
using WebApiBoilerPlate.Core.Domain.Repositories;

namespace WebApiBoilerPlate.Core.Infrastructure.InMemory;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", 
        "Cool", "Mild", "Warm", "Balmy",
        "Hot", "Sweltering", "Scorching"
    };
    
    private readonly WeatherForecast[] _weatherForecasts;
    public WeatherForecastRepository()
    {
        //Load data
        _weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        
    }
    public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
    {
        return await Task.FromResult(_weatherForecasts);
    }

    public async Task<WeatherForecast> GetByIdAsync(int id)
    {
        return await Task.FromResult(_weatherForecasts.FirstOrDefault(x => x.Id == id));
    }
}