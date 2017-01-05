using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace OpenWeatherMap
{
    public class OpenWeatherMapClient
    {
        private string apiRootUrl = "http://api.openweathermap.org/data/2.5";
        private string apiKey;
        
        public CurrentWeather currentWeather;
        private TemperatureUnit unit;
        public TemperatureUnit Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
                currentWeather.Unit = value;
            }
        }

        public OpenWeatherMapClient(string apiKey) : this(apiKey, TemperatureUnit.standard)
        {
        }

        public OpenWeatherMapClient(string apiKey, TemperatureUnit temperatureUnit)
        {
            currentWeather = new CurrentWeather(apiRootUrl, apiKey);

            this.apiKey = apiKey;
            Unit = temperatureUnit;

        }

    }
}
