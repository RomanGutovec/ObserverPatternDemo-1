using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo
    {
        //TODO: implement IFormattable
        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int Pressure { get; set; }
    }
}