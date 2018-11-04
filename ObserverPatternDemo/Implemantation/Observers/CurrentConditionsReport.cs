using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo currentWeather;
 
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException($"Incorrect data of {nameof(sender)}");
            }

            currentWeather = info ?? throw new ArgumentNullException($"Incorrect data of {nameof(info)}");
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Current condition Report\n" +
                $"current Temperature: {currentWeather.Temperature}" +
                $"current Humidity: {currentWeather.Humidity}" +
                $"current Pressure: {currentWeather.Pressure}";
        }
    }
}