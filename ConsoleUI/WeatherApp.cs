using DemoLibrary.Interfaces;

namespace ConsoleUI;

/// <summary>
/// The client code is supposed to work with all objects (both subjects
/// and proxies) via the Subject interface in order to support both real
/// subjects and proxies. In real life, however, clients mostly work with
/// their real subjects directly. In this case, to implement the pattern
/// more easily, you can extend your proxy from the real subject's class.
/// </summary>
public class WeatherApp
{
    private readonly IWeatherService _weatherService;

    public WeatherApp(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task DisplayWeatherInfoAsync(string city)
    {
        var weatherTask = _weatherService.GetWeatherAsync(city);
        var temperatureTask = _weatherService.GetTemperatureAsync(city);
        var forecastTask = _weatherService.GetForecastAsync(city);

        await Task.WhenAll(weatherTask, temperatureTask, forecastTask);

        Console.WriteLine($"Weather in {city}: {await weatherTask}");
        Console.WriteLine($"Temperature in {city}: {await temperatureTask}°C");
        Console.WriteLine($"Forecast for {city}:");
        foreach (var day in await forecastTask)
        {
            Console.WriteLine(day);
        }
    }
}
