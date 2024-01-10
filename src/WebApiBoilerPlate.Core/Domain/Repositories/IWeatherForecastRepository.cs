using WebApiBoilerPlate.Core.Domain.Entities;

namespace WebApiBoilerPlate.Core.Domain.Repositories;

public interface IWeatherForecastRepository
{
    public Task<IEnumerable<WeatherForecast>> GetAllAsync();
    public Task<WeatherForecast> GetByIdAsync(int id);
}