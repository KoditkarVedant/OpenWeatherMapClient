using System;
using NUnit.Framework;
using OpenWeatherMap;

namespace OpenWeatherMapTests
{
    [TestFixture]
    public class CurrentWeatherApiTests
    {
        private OpenWeatherMapClient client;
        private string apiKey;


        [SetUp]
        public void SetUp()
        {
            apiKey = "";
            client = new OpenWeatherMapClient(apiKey);
        }

        [Test]
        public void ByCityName()
        {
            Assert.IsNotNull(client.currentWeather.ByCityName("london").Result);
        }
    }
}
