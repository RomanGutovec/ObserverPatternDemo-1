using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;
        private WeatherInfo currentWeather;
        private int measurePeriodSeconds;
        private int intervaMeasurelSeconds;

        public WeatherData(int measurePeriodSeconds, int intervalSeconds)
        {
            observers = new List<IObserver<WeatherInfo>>();
            currentWeather = new WeatherInfo();
            IntervaMeasurelSeconds = intervalSeconds;
            MeasurePeriodSeconds = measurePeriodSeconds;
        }

        public int MeasurePeriodSeconds
        {
            get
            {
                return measurePeriodSeconds;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"Incorrect inputed value");
                }

                measurePeriodSeconds = value;
            }
        }

        public int IntervaMeasurelSeconds
        {
            get
            {
                return intervaMeasurelSeconds;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"Incorrect inputed value");
                }

                intervaMeasurelSeconds = value;
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

        void IObservable<WeatherInfo>.Notify(WeatherInfo info) => Notify(info);

        protected virtual void Notify(WeatherInfo info)
        {
            currentWeather = info;
            foreach (var observer in observers)
            {
                observer.Update(this, currentWeather);
            }
        }

        public void StartMeasure()
        {
            for (int i = 0; i < measurePeriodSeconds / IntervaMeasurelSeconds; i++)
            {
                Console.WriteLine($"\nNew weather data...\n");
                Notify(GetNewWeather());
                Console.WriteLine(new string('-', 70));
                Thread.Sleep(IntervaMeasurelSeconds * 1000);
            }
        }

        private WeatherInfo GetNewWeather()
        {
            Random random = new Random();
            WeatherInfo newWeather = new WeatherInfo()
            {
                Temperature = random.Next(10, 20),
                Humidity = random.Next(60, 100),
                Pressure = random.Next(600, 700)
            };

            return newWeather;
        }
    }
}
