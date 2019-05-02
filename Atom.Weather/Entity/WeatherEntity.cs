using System;

namespace Atom.Weather.Entity
{
    public class WeatherEntity
    {
        public string Id { get; set; }
        public string WeatherType { get; set; }
        public int Weatherdegree { get; set; }
        public string Location { get; set; }
        public string SiteLocation { get; set; }
        public string WeatherSymbol { get; set; }
        public string WeatherCode { get; set; }
        public string WeatherIcon { get; set; }

        public string ToJson()
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return jsonString;
        }
    }
}
