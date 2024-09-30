using DemoLibrary.Interfaces;

namespace DemoLibrary.Proxies;

/// <summary>
/// The Proxy has an interface identical to the RealSubject.
/// </summary>
public class CachedWeatherService : IWeatherService
{
    private readonly IWeatherService _realService;
    private readonly Dictionary<string, string> _weatherCache = new Dictionary<string, string>();
    private readonly Dictionary<string, int> _temperatureCache = new Dictionary<string, int>();
    private readonly Dictionary<string, List<string>> _forecastCache = new Dictionary<string, List<string>>();

    public CachedWeatherService(IWeatherService realService)
    {
        _realService = realService;
    }

    // The most common applications of the Proxy pattern are lazy loading,
    // caching, controlling the access, logging, etc. A Proxy can perform
    // one of these things and then, depending on the result, pass the
    // execution to the same method in a linked RealSubject object.
    public async Task<string> GetWeatherAsync(string city)
    {
        if (!_weatherCache.ContainsKey(city))
        {
            _weatherCache[city] = await _realService.GetWeatherAsync(city);
        }
        return _weatherCache[city];
    }

    public async Task<int> GetTemperatureAsync(string city)
    {
        if (!_temperatureCache.ContainsKey(city))
        {
            _temperatureCache[city] = await _realService.GetTemperatureAsync(city);
        }
        return _temperatureCache[city];
    }

    public async Task<List<string>> GetForecastAsync(string city)
    {
        if (!_forecastCache.ContainsKey(city))
        {
            _forecastCache[city] = await _realService.GetForecastAsync(city);
        }
        return _forecastCache[city];
    }
}
