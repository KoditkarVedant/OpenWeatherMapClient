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
            apiKey = "60baf1c6122ae691dedf22a80cb3e02e";
            client = new OpenWeatherMapClient(apiKey);
        }

        [Test]
        public void ByCityName()
        {
            Assert.IsNotNull(client.currentWeather.ByCityName("london").Result);
        }
    }
}
