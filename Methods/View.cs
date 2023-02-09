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
using System.Runtime.Intrinsics.Arm;
using System.Reflection;

namespace WeatherApp5.Methods
{
    internal class View
    {
        public static string path = "../../../Data/tempdata5-med-fel.txt";
        internal static void AverageTempPerDay()
        {
            List<WeatherData> weatherData = RegexData.GetData();

            Console.Write("Välj en dag för att kolla medeltemp: (YYYY-MM-DD): ");
            string date = Console.ReadLine();
            Console.Write("Inne eller ute: ");
            string inOrOut = Console.ReadLine();

            var chosenData = weatherData.Where(x => x.Date.Date == DateTime.Parse(date)).Where(x => x.Location == inOrOut).ToList();
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
            List<WeatherData> weatherData = RegexData.GetData();
            Dictionary<string, double> data = new Dictionary<string, double>();

            DateTime StartDate = new DateTime(2016, 6, 1);
            DateTime EndDate = new DateTime(2016, 12, 31);
            int DayInterval = 1;

            Console.WriteLine("Inne eller Ute? ");
            string inOrOut = Console.ReadLine();

            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                var chosenData = weatherData.Where(x => x.Date.Date == StartDate).Where(x => x.Location == inOrOut).ToList();
                double counter = 0;

                foreach (var c in chosenData)
                {
                    counter += c.Temperature;
                }
                double result = counter / chosenData.Count;

                if (!double.IsNaN(result))
                {
                    //Console.WriteLine(StartDate.ToString("yyyy-MM-dd") + " - Medeltemp: " + Math.Round(result, 1) + "°");
                    data.Add(StartDate.ToString("yyyy-MM-dd"), Math.Round(result, 1));
                }

                StartDate = StartDate.AddDays(DayInterval);
            }
            var topTenWarmest = data.OrderByDescending(x => x.Value).Take(10);
            Console.WriteLine("Varmaste dagarna:");
            foreach (var key in topTenWarmest)
            {
                Console.WriteLine(key.Key + " " + key.Value);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("Kallaste dagarna:");
            var topTenColdest = data.OrderBy(x => x.Value).Take(10);
            foreach (var key in topTenColdest)
            {
                Console.WriteLine(key.Key + " " + key.Value);
            }

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
