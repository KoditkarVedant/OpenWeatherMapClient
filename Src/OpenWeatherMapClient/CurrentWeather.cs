using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    public sealed class CurrentWeather
    {
        private string apiRootUrl;
        private string apiKey;
        private string uri;
        private TemperatureUnit unit;
        private HttpClient httpClient = new HttpClient();

        internal TemperatureUnit Unit
        {
            set
            {
                unit = value;
            }
        }

        public CurrentWeather(string apiRootUrl, string apiKey)
        {
            this.apiKey = apiKey;
            this.apiRootUrl = apiRootUrl;
            httpClient = new HttpClient();
        }

        public async Task<string> ByCityName(string cityName)
        {
            uri = $"{apiRootUrl}/weather?q={cityName}";

            return await RequestData(uri);
        }

        public async Task<string> ByCityName(string cityName, string countryCode)
        {
            uri = $"{apiRootUrl}/weather?q={cityName},{countryCode}";
            return await RequestData(uri);
        }

        public async Task<string> ByCityId(int cityId)
        {
            uri = $"{apiRootUrl}/weather?id={cityId}";

            return await RequestData(uri);
        }

        public async Task<string> ByGeographicCoordinates(int longitude, int latitude)
        {
            uri = $"{apiRootUrl}/weather?lat={latitude}&lon={longitude}";

            return await RequestData(uri);
        }

        public async Task<string> ByZIPCode(int zipCode)
        {
            uri = $"{apiRootUrl}/weather?zip={zipCode}";

            return await RequestData(uri);
        }

        public async Task<string> ByZIPCode(int zipCode, int countryCode)
        {
            uri = $"{apiRootUrl}/weather?zip={zipCode},{countryCode}";
            return await RequestData(uri);
        }

        public async Task<string> ForCitiesWithinRectangleZone(int longitudeLeft, int latitudeBottom, int longitudeRight, int latitudeTop, int zoom, bool cluster = true)
        {
            uri = $"{apiRootUrl}/box/city?bbox={longitudeLeft},{latitudeBottom},{longitudeRight},{latitudeTop},{zoom}&cluster={(cluster ? "yes" : "no")}";

            return await RequestData(uri);
        }

        public async Task<string> ForCitiesInCircle(int latitude, int longitude, int numberOfCities = 10)
        {
            uri = $"{apiRootUrl}/find?lat={latitude}&lon={longitude}&cnt={numberOfCities}";

            return await RequestData(uri);
        }

        public async Task<string> ForCitiesByIds(int[] cityIds)
        {
            uri = $"{apiRootUrl}/group?id={string.Join(",", cityIds)}";
            return await RequestData(uri);
        }

        private async Task<string> RequestData(string uri)
        {
            string uriWithKey = $"{uri}&units={unit.ToString()}&appid={apiKey}";

            var response = await httpClient.GetAsync(uriWithKey);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
