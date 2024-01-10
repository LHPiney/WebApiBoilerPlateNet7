namespace WebApiBoilerPlate.Core.Domain.Entities;

public class WeatherForecast
{
    public int Id { get; init; }
    public DateOnly Date { get; init; }

    public int TemperatureC { get; init; }

    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

    public string? Summary { get; init; }
}