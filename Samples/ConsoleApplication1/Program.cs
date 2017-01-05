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
            OpenWeatherMapClient client = new OpenWeatherMapClient("");
            string response = client.currentWeather.ByCityName("london").Result;
            Console.WriteLine(response);

            Console.ReadKey();
        }
    }
}
