using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using WeatherApp5.Data;

namespace WeatherApp5.Methods
{
    internal class RegexData
    {
        public static string path = "../../../Data/tempdata5-med-fel.txt";
        internal static List<WeatherData> GetData()
        {
            string pattern = "(?<dateTime>\\d+-\\d{2}-\\d{1,2}\\s\\d{2}:\\d{2}:\\d{2}),(?<location>\\w{3,4}),\\s*(?<temp>-?\\d+.\\d),(?<humidity>\\d+)";
            
            Regex regex = new Regex(pattern);
            var allData = File.ReadAllLines(path)
                .Where(path => regex.IsMatch(path))
                .ToList();

            List<WeatherData> allWeatherData = new();

            foreach (var data in allData)
            {
                WeatherData weatherData = new WeatherData();
                foreach (Match m in Regex.Matches(data, pattern))
                {
                    if (m.Groups.Count > 0)
                    {
                        foreach (Group g in m.Groups)
                        {
                            if (g.Name == "dateTime")
                            {
                                try
                                {
                                    weatherData.Date = DateTime.Parse(g.Value);
                                }
                                catch (FormatException fe)
                                {

                                }

                            }
                            else if (g.Name == "location")
                            {
                                weatherData.Location = g.Value;
                            }
                            else if (g.Name == "temp")
                            {
                                weatherData.Temperature = double.Parse(g.Value, System.Globalization.CultureInfo.InvariantCulture);
                            }
                            else if (g.Name == "humidity")
                            {
                                weatherData.Humidity = double.Parse(g.Value);
                            }
                        }
                    }

                }
                allWeatherData.Add(weatherData);
            }

            return allWeatherData;
        }
        
    }
}
