﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherApp5.Data
{
    internal interface IWeatherDate
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string Location{ get; set; }
        public DateTime Date { get; set; }
    }
    internal class WeatherDate : IWeatherDate
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        
    }
}
