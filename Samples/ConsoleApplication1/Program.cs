using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeatherMap;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenWeatherMapClient client = new OpenWeatherMapClient("60baf1c6122ae691dedf22a80cb3e0e");
            string response = client.currentWeather.ByCityName("london").Result;
            Console.WriteLine(response);

            Console.ReadKey();
        }
    }
}
