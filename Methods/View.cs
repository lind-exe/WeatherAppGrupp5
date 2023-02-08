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
using System.Security.Cryptography.X509Certificates;

namespace WeatherApp5.Methods
{
    internal class View
    {
        public static string path = "../../../Data/tempdata5-med-fel.txt";
        internal static void AverageTempPerDay()
        {
            List<WeatherData> weatherData = RegexData.GetData();
            
            Console.Write("Choose a day to check averagetemp (YYYY-MM-DD): ");
            string date = Console.ReadLine();

            var chosenData = weatherData.Where(x => x.Date.Date == DateTime.Parse(date)).Where(x => x.Location == "Inne").ToList();
            double counter = 0;

            
            foreach (var c in chosenData)
            {
                    Console.WriteLine(c.Date + " " + c.Location + " " + c.Temperature + " " + c.Humidity);
                    counter += c.Temperature;
            }
            double result = counter / chosenData.Count;
            Console.WriteLine();
            Console.WriteLine("Antal data: " + chosenData.Count);
            Console.WriteLine("Medeltemp: " + result);


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
