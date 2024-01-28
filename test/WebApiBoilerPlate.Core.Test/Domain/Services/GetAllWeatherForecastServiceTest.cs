using Microsoft.Extensions.Logging;
using Moq;

using WebApiBoilerPlate.Core.Domain.Repositories;
using WebApiBoilerPlate.Core.Domain.Services;

namespace WebApiBoilerPlate.Test.Domain.Services;

public class GetAllWeatherForecastServiceTest
{
      [Fact]
      [Trait("Category", "UnitTest")]
      public void Ctor_WhenWeatherForecastRepositoryIsNull_ThrowsArgumentNullException()
      {
            var weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            ILogger<GetAllWeatherForecastService> logger = null!;
            
            Assert.Throws<ArgumentNullException>(() => 
                  new GetAllWeatherForecastService(weatherForecastRepository.Object, logger));
      }
      
      [Fact]
      [Trait("Category", "UnitTest")]
      public void Ctor_WhenLoggerIsNull_ThrowsArgumentNullException()
      {
            ILogger<GetAllWeatherForecastService> logger = null!;
            var weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            
            Assert.Throws<ArgumentNullException>(() => 
                  new GetAllWeatherForecastService(weatherForecastRepository.Object, logger));
      }
      
      [Fact] 
      [Trait("Category", "UnitTest")]
      public async Task Do_WhenCalled_ShouldCallGetAllAsync()
      {
            var weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            var logger = new Mock<ILogger<GetAllWeatherForecastService>>();
            var getAllWeatherForecastService = new GetAllWeatherForecastService(
                  weatherForecastRepository.Object, 
                  logger.Object);
            
            _ = await getAllWeatherForecastService.Do();
            
            weatherForecastRepository.Verify(x => x.GetAllAsync(), Times.Once);
      }
}