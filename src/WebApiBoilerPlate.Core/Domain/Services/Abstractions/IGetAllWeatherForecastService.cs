using WebApiBoilerPlate.Core.Domain.Entities;

namespace WebApiBoilerPlate.Core.Domain.Services.Abstractions;

public interface IGetAllWeatherForecastService
{
    public  Task<IEnumerable<WeatherForecast>> Do();
}