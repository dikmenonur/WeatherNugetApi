namespace Atom.Weather
{
    using Atom.Weather.Entity;
    using Microsoft.Extensions.Configuration;
    using System;
    public class WeatherCore : IWeatherCore
    {
        private IConfiguration Configuration { get; set; }
        private string webUrl { get; set; }
        private string apiID { get; set; }
        private string location { get; set; }
        private string requestUrl { get; set; }

        public WeatherCore()
        {
            ConfigurationLoad();

            webUrl = Configuration["WeatherUrl"];
            apiID = Configuration["apiID"];
            location = Configuration["Location"];

            requestUrl = string.Format(webUrl, apiID, location);
        }

        public WeatherEntity SendRequest()
        {
            WebrequestCore core = new WebrequestCore();
            string appLoad = core.Get(new Uri(this.requestUrl));
            WeatherEntity wEntity = WeatherDTO.ParserJson(appLoad, Configuration);
            return wEntity;
        }

        private void ConfigurationLoad()
        {
            var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(@"Config.json");
            Configuration = configurationBuilder.Build();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public WeatherEntity SendRequest(string requestUrl)
        {
            throw new NotImplementedException();
        }
    }
}
