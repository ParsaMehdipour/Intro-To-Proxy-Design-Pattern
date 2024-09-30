using ConsoleUI;
using DemoLibrary.Interfaces;
using DemoLibrary.Proxies;
using DemoLibrary.Subjects;

IWeatherService realService = new RealWeatherService();
IWeatherService proxiedService = new CachedWeatherService(realService);

WeatherApp app = new WeatherApp(proxiedService);

Console.WriteLine("First call (uncached):");
var start = DateTime.Now;
await app.DisplayWeatherInfoAsync("New York");
Console.WriteLine($"Time taken: {(DateTime.Now - start).TotalSeconds} seconds");

Console.WriteLine("\nSecond call (cached):");
start = DateTime.Now;
await app.DisplayWeatherInfoAsync("New York");
Console.WriteLine($"Time taken: {(DateTime.Now - start).TotalSeconds} seconds");