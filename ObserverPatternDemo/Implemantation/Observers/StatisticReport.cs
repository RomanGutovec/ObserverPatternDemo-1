using System;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> historyWeather;

        public StatisticReport()
        {
            historyWeather = new List<WeatherInfo>();
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException($"Incorrect data of {nameof(sender)}");
            }

            if (info == null)
            {
                throw new ArgumentNullException($"Incorrect data of {nameof(info)}");
            }

            historyWeather.Add(info);
            WeatherInfo averageData = CalculateWeatherData(info);
            Console.WriteLine($"\nCurrent Statistic Report\n" +
                $"average Temperature: {averageData.Temperature}" +
                $"average Humidity: {info.Humidity} " +
                $"average Pressure: {averageData.Pressure} ");
        }

        private WeatherInfo CalculateWeatherData(WeatherInfo info)
        {
            int averageTemperature = 0;
            int averageHumidity = 0;
            int averagePressure = 0;

            foreach (var weather in historyWeather)
            {
                averageTemperature += weather.Temperature;
                averageHumidity += weather.Humidity;
                averagePressure += weather.Pressure;
            }

            averageTemperature /= historyWeather.Count;
            averageHumidity /= historyWeather.Count;
            averagePressure /= historyWeather.Count;
            WeatherInfo averageData = new WeatherInfo()
            {
                Temperature = averageTemperature,
                Humidity = averageHumidity,
                Pressure = averagePressure
            };
            return averageData;
        }
    }
}
