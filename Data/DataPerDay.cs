using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp5.Data
{
    internal class DataPerDay
    {
        public DateTime? Date { get; set; }

        public List<double>? Temperatures { get; set; }
    }
}
