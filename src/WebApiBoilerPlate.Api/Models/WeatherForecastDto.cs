using WebApiBoilerPlate.Core.Domain.Entities;

namespace WebApiBoilerPlate.Api.Models;

public class WeatherForecastDto
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF { get; set; }
    public string? Summary { get; set; }
    
    public static WeatherForecastDto FromWeatherForecast(WeatherForecast weatherForecast)
    {
        return new WeatherForecastDto
        {
            Id = weatherForecast.Id,
            Date = weatherForecast.Date,
            TemperatureC = weatherForecast.TemperatureC,
            TemperatureF = weatherForecast.TemperatureF,
            Summary = weatherForecast.Summary
        };
    }
}