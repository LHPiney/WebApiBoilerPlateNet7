using WebApiBoilerPlate.Core.Domain.Repositories;
using WebApiBoilerPlate.Core.Domain.Services;
using WebApiBoilerPlate.Core.Domain.Services.Abstractions;
using WebApiBoilerPlate.Core.Infrastructure.InMemory;

namespace WebApiBoilerPlate.Api.Extensions;

public static class WebApiBoilerPlateExtensions
{ 
    public static IServiceCollection AddWebApiBoilerPlate(this IServiceCollection services)
    {
        //Add your repositories here
        services.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();
        
        // Add your services here
        services.AddScoped<IGetAllWeatherForecastService, GetAllWeatherForecastService>();
        services.AddScoped<IGetWeatherForecastService, GetWeatherForecastService>();
        
        
        return services;
    } 
}