using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Text.RegularExpressions;
using WeatherApp5.Data;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace WeatherApp5.Methods
{
    internal class View
    {
        public static string path = "../../../Data/tempdata5-med-fel.txt";
        internal static void AverageTempPerDay()
        {
            List<string> allData = RegexData.GetData("(?<dateTime>\\d+-\\d{2}-\\d{1,2}\\s\\d{2}:\\d{2}:\\d{2}),(?<location>\\w{3,4}),\\s*(?<temp>-?\\d+.\\d),(?<humidity>\\d+)");
            string pattern = "(?<dateTime>\\d+-\\d{2}-\\d{1,2}\\s\\d{2}:\\d{2}:\\d{2}),(?<location>\\w{3,4}),\\s*(?<temp>-?\\d+.\\d),(?<humidity>\\d+)";
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
                                weatherData.Date = DateTime.Parse(g.Value);
                            }
                        }
                    }
                   
                }
            }
        }

        internal static void AverageTempSorted()
        {
            
        }

        internal static void HumiditySortedAndAverageHumitidy()
        {
           
        }
        internal static void MeterologicDates()
        {
            throw new NotImplementedException();
        }

        internal static void MoldRisk()
        {
            throw new NotImplementedException();
        }
    }
}
