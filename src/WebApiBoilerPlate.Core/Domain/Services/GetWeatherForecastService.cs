using  Microsoft.Extensions.Logging;
    
using WebApiBoilerPlate.Core.Domain.Entities;
using WebApiBoilerPlate.Core.Domain.Repositories;
using WebApiBoilerPlate.Core.Domain.Services.Abstractions;

namespace WebApiBoilerPlate.Core.Domain.Services;

public class GetWeatherForecastService : IGetWeatherForecastService
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;
    private readonly ILogger _logger;

    public GetWeatherForecastService(
        IWeatherForecastRepository weatherForecastRepository, 
        ILogger<GetWeatherForecastService> logger)
    {
        _weatherForecastRepository = weatherForecastRepository 
                                     ?? throw new ArgumentNullException(nameof(weatherForecastRepository));
        _logger = logger 
                  ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public async Task<WeatherForecast> WithId(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        
        try
        {
            return await _weatherForecastRepository.GetByIdAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error getting weather forecast");
            throw;
        }
    }
}