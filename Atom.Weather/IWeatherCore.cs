using Atom.Weather.Entity;
using Microsoft.Extensions.Configuration;

namespace Atom.Weather
{
    public interface IWeatherCore
    {
        bool Equals(object obj);
        int GetHashCode();
        WeatherEntity SendRequest(string requestUrl);
        WeatherEntity SendRequest();
    }
}