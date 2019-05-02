using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.Weather.Entity
{
    public static class WeatherDTO
    {
        public static WeatherEntity ParserJson(string jsonData, IConfiguration Configuration)
        {
            var jObjectData = JObject.Parse(jsonData);
            WeatherEntity weatherEntity = new WeatherEntity
            {
                Id = jObjectData["location"]["localtime_epoch"].ToString(),
                WeatherType = jObjectData["current"]["condition"]["text"].ToString(),
                WeatherSymbol = Configuration["WeatherSymbol"],
                Weatherdegree = Convert.ToInt32(jObjectData["current"]["temp_c"].ToString()),
                Location = jObjectData["location"]["name"].ToString(),
                SiteLocation = Configuration["SiteLocation"],
                WeatherCode = jObjectData["current"]["condition"]["code"].ToString(),
                WeatherIcon = jObjectData["current"]["condition"]["icon"].ToString()
            };

            return weatherEntity;
        }
    }
}
