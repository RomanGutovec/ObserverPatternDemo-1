using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create Current Conditions Report");
            CurrentConditionsReport conditionsReport = new CurrentConditionsReport();
            Console.WriteLine("Create Statistic Report");
            StatisticReport statisticReport = new StatisticReport();
            Console.WriteLine("Create observable object: Weather data");
            WeatherData weatherData = new WeatherData(50, 2);
            Console.WriteLine("Register observers Current Conditions Report and Statistic Report");
            weatherData.Register(conditionsReport);
            weatherData.Register(statisticReport);

            WeatherInfo dataAboutWeather = new WeatherInfo()
            { Humidity = 80, Pressure = 750, Temperature = 18 };
            weatherData.Notify(weatherData, dataAboutWeather);

            weatherData.StartMeasure();
            Console.ReadLine();
        }
    }
}