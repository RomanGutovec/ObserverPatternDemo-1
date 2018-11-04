using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;
        private WeatherInfo currentWeather;

        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
            currentWeather = new WeatherInfo();
        }

        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            currentWeather = info;
            foreach (var observer in observers)
            {
                observer.Update(sender, currentWeather);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException($"Observer {nameof(observer)} inputed incorrect");
            }

            observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException($"Observer {nameof(observer)} inputed incorrect");
            }

            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}
