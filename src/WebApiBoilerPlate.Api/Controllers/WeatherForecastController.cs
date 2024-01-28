using Microsoft.AspNetCore.Mvc;
using WebApiBoilerPlate.Api.Models;
using WebApiBoilerPlate.Core.Domain.Services.Abstractions;

namespace WebApiBoilerPlate.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IGetAllWeatherForecastService _getAllWeatherForecastService;

    public WeatherForecastController(
        IGetAllWeatherForecastService getAllWeatherForecastService, 
        ILogger<WeatherForecastController> logger)
    {
        _getAllWeatherForecastService = getAllWeatherForecastService 
                                        ?? throw new ArgumentNullException(nameof(getAllWeatherForecastService));
        _logger = logger 
                  ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet(Name = "GetAllWeatherForecast", Order = 1)]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecastDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> GetAllWeatherForecast()
    {
        try
        {
            var response= await _getAllWeatherForecastService.Do();

            if (response is null) return NotFound();
            
            var weatherForecasts = response.ToList();
            
            return weatherForecasts.Any() 
                ? new OkObjectResult(weatherForecasts
                    .ToList()
                    .Select(item => WeatherForecastDto.FromWeatherForecast(item)))
                : NotFound();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error getting all weather forecast");
            
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}