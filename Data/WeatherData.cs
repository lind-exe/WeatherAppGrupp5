using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherApp5.Data
{
    internal class WeatherData
    {
        public int Year = 2016;
        public int Month { get; set; }
        public int Day { get; set; }
        public List<double> Temperature { get; set; }
        public List<double> Humidity { get; set; }
        public bool Inside { get; set; }

    }
}
