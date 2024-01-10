using WebApiBoilerPlate.Core.Domain.Entities;

namespace WebApiBoilerPlate.Core.Domain.Services.Abstractions;

public interface IGetWeatherForecastService
{
    public Task<WeatherForecast> WithId(int id);
}