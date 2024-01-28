using Microsoft.Extensions.Logging;
using Moq;

using WebApiBoilerPlate.Core.Domain.Repositories;
using WebApiBoilerPlate.Core.Domain.Services;

namespace WebApiBoilerPlate.Test.Domain.Services;

public class GetWeatherForecastServiceTest
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Ctor_WhenWeatherForecastRepositoryIsNull_ThrowsArgumentNullException()
    {
        var weatherForecastRepository = new Mock<IWeatherForecastRepository>();
        ILogger<GetWeatherForecastService> logger = null!;
            
        Assert.Throws<ArgumentNullException>(() => 
            new GetWeatherForecastService(weatherForecastRepository.Object, logger));
    }
      
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Ctor_WhenLoggerIsNull_ThrowsArgumentNullException()
    {
        ILogger<GetWeatherForecastService> logger = null!;
        var weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            
        Assert.Throws<ArgumentNullException>(() => 
            new GetWeatherForecastService(weatherForecastRepository.Object, logger));
    }
    
    [Fact]
    [Trait("Category", "UnitTest")]
    public async Task WithId_WhenIdIsLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException()
    {
        var weatherForecastRepository = new Mock<IWeatherForecastRepository>();
        var logger = new Mock<ILogger<GetWeatherForecastService>>();
        var getWeatherForecastService = new GetWeatherForecastService(
            weatherForecastRepository.Object, 
            logger.Object);
        
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => 
            getWeatherForecastService.WithId(0));
    }
    
    [Fact]
    [Trait("Category", "UnitTest")]
    public async Task WithId_WhenCalled_ShouldCallGetByIdAsync()
    {
        var weatherForecastRepository = new Mock<IWeatherForecastRepository>();
        var logger = new Mock<ILogger<GetWeatherForecastService>>();
        var getWeatherForecastService = new GetWeatherForecastService(
            weatherForecastRepository.Object, 
            logger.Object);
        
        _ = await getWeatherForecastService.WithId(1);
        
        weatherForecastRepository.Verify(x => 
            x.GetByIdAsync(It.IsAny<int>()), Times.Once);
    }

}