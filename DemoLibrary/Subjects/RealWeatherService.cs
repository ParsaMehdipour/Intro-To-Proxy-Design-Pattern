using DemoLibrary.Interfaces;

namespace DemoLibrary.Subjects;

/// <summary>
/// The RealSubject contains some core business logic. Usually, RealSubjects
/// are capable of doing some useful work which may also be very slow or
/// sensitive - e.g. correcting input data. A Proxy can solve these issues
/// without any changes to the RealSubject's code.
/// </summary>
public class RealWeatherService : IWeatherService
{
    public async Task<string> GetWeatherAsync(string city)
    {
        Console.WriteLine($"Calling weather API for {city}");
        await Task.Delay(2000); // Simulate API delay
        return $"Sunny in {city}";
    }

    public async Task<int> GetTemperatureAsync(string city)
    {
        Console.WriteLine($"Calling temperature API for {city}");
        await Task.Delay(1500); // Simulate API delay
        return new Random().Next(0, 35);
    }

    public async Task<List<string>> GetForecastAsync(string city)
    {
        Console.WriteLine($"Calling forecast API for {city}");
        await Task.Delay(3000); // Simulate API delay
        return new List<string> { "Monday: Sunny", "Tuesday: Cloudy", "Wednesday: Rainy" };
    }
}
