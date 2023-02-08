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
        internal static List<string> GetData(string pattern)
        {
            Regex regex = new Regex(pattern);
            var allData = File.ReadAllLines(path)
                .Where(path => regex.IsMatch(path))
                .ToList();

            

 

            return allData;
        }
    }
}
