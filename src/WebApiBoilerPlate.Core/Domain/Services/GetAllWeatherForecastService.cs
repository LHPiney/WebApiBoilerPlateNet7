using Microsoft.Extensions.Logging;
using WebApiBoilerPlate.Core.Domain.Entities;
using WebApiBoilerPlate.Core.Domain.Repositories;
using WebApiBoilerPlate.Core.Domain.Services.Abstractions;

namespace WebApiBoilerPlate.Core.Domain.Services;

public class GetAllWeatherForecastService : IGetAllWeatherForecastService
{ 
    private readonly IWeatherForecastRepository _weatherForecastRepository;
    private readonly ILogger _logger;

    public GetAllWeatherForecastService(
        IWeatherForecastRepository weatherForecastRepository,
        ILogger<GetAllWeatherForecastService> logger)
    {
        _weatherForecastRepository = weatherForecastRepository
                                     ?? throw new ArgumentNullException(nameof(weatherForecastRepository));
        _logger = logger;
    }
    
    public async Task<IEnumerable<WeatherForecast>> Do()
    {
        try
        {
            return await _weatherForecastRepository.GetAllAsync();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error getting all weather forecast");
            throw;
        }
    }

}