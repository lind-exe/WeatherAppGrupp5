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
            List<DataPerDay> listDataPerDay = new();

            DateTime StartDate = new DateTime(2016, 6, 1);
            DateTime EndDate = new DateTime(2016, 12, 31);
            int DayInterval = 1;

            Console.WriteLine("Inne eller Ute? ");
            string inOrOut = Console.ReadLine();

            List<DateTime> dateList = new List<DateTime>();
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
                    Console.WriteLine(StartDate.ToString("yyyy-MM-dd") + "- medeltemp: " + Math.Round(result, 1) + "°");

                }

                StartDate = StartDate.AddDays(DayInterval);
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
