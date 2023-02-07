using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WeatherApp5.Methods
{
    internal class RegexData
    {
        public static string path = "../../../Data/tempdata5-med-fel.txt";
        internal static List<double> GetData(string pattern)
        {
            Regex regex = new Regex(pattern);
            var specificDay = File.ReadAllLines(path)
                .Where(path => regex.IsMatch(path))
                .ToList();

            Regex regexTemp = new Regex(@"(?<=,)(-?\\s?\\d+.\\d)");

            List<double> result = new List<double>();

            foreach (var day in specificDay)
            {
                Match match = regexTemp.Match(day);
                if (match.Success)
                {
                    result.Add(Convert.ToDouble(day));
                }
            }

            return result;
        }
    }
}
