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
            
            string input = Helpers.SelectedLocation();

            var chosenData = weatherData.Where(x => x.Date.Date == DateTime.Parse(date)).Where(x => x.Location == input).ToList();
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

            string input = Helpers.SelectedLocation();
            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                var chosenData = weatherData.Where(x => x.Date.Date == StartDate).Where(x => x.Location == input).ToList();
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
            List<WeatherData> weatherData = RegexData.GetData();
            Dictionary<string, double> data = new Dictionary<string, double>();

            DateTime StartDate = new DateTime(2016, 6, 1);
            DateTime EndDate = new DateTime(2016, 12, 31);
            int DayInterval = 1;

            string input = Helpers.SelectedLocation();
            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                var chosenData = weatherData.Where(x => x.Date.Date == StartDate).Where(x => x.Location == input).ToList();
                double counter = 0;

                foreach (var c in chosenData)
                {
                    counter += c.Humidity;
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
            Console.WriteLine("Fuktigaste dagarna:");
            foreach (var key in topTenWarmest)
            {
                Console.WriteLine(key.Key + " " + key.Value);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("Torraste dagarna:");
            var topTenColdest = data.OrderBy(x => x.Value).Take(10);
            foreach (var key in topTenColdest)
            {
                Console.WriteLine(key.Key + " " + key.Value);
            }

        }

        internal static void MoldRisk()
        {
            //List<WeatherData> weatherData = RegexData.GetData();

            //DateTime StartDate = new DateTime(2016, 6, 1);
            //DateTime EndDate = new DateTime(2016, 12, 31);
            //int DayInterval = 1;

            //string input = Helpers.SelectedLocation();
            //while (StartDate.AddDays(DayInterval) <= EndDate)
            //{
            //    var chosenData = weatherData.Where(x => x.Date.Date == StartDate).Where(x => x.Location == input).ToList();
            //    double result = 0;
            //    double temp = 0;
            //    double humidity = 0;
            //    foreach (var c in chosenData)
            //    {                    
            //        temp += c.Temperature;
            //        humidity += c.Humidity;
            //    }
            //    //double result = counter / chosenData.Count;

            //    if (!double.IsNaN(result))
            //    {
            //        //Console.WriteLine(StartDate.ToString("yyyy-MM-dd") + " - Medeltemp: " + Math.Round(result, 1) + "°");
            //        data.Add(StartDate.ToString("yyyy-MM-dd"), Math.Round(result, 1));
            //    }

            //    StartDate = StartDate.AddDays(DayInterval);
            //}
        }
        internal static void MeterologicDates()
        {
            List<WeatherData> weatherData = RegexData.GetData();
            Dictionary<string, double> data = new Dictionary<string, double>();

            DateTime StartDate = new DateTime(2016, 8, 1);
            DateTime EndDate = new DateTime(2016, 12, 31);
            int DayInterval = 1;

            
            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                var chosenData = weatherData.Where(x => x.Date.Date == StartDate).Where(x => x.Location == "Ute").ToList();
                double counter = 0;

                foreach (var c in chosenData)
                {
                    counter += c.Temperature;
                }
                double result = counter / chosenData.Count;

                if (!double.IsNaN(result))
                {
                    data.Add(StartDate.ToString("yyyy-MM-dd"), Math.Round(result, 1));
                }

                StartDate = StartDate.AddDays(DayInterval);
            }

            var dataList = data.OrderBy(x => x.Key).ToList();

            int i = 0;
            Console.WriteLine("1. Visa meterologisk höst\n2. Visa meterologisk vinter");
            int input = Helpers.TryNumber(2, 1);
            switch (input)
            {
                case 1:
                    while (i < dataList.Count)
                    {
                        if (dataList[i].Value < 10 && dataList[i - 1].Value < 10 && dataList[i - 2].Value < 10 && dataList[i - 3].Value < 10 && dataList[i - 4].Value < 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(dataList[i - 5].Key + " " + dataList[i - 5].Value + " °C");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(dataList[i - 4].Key + " " + dataList[i - 4].Value + " °C" + " meterologisk höst för 2016 inträffar detta datum");
                            Console.WriteLine(dataList[i - 3].Key + " " + dataList[i - 3].Value + " °C");
                            Console.WriteLine(dataList[i - 2].Key + " " + dataList[i - 2].Value + " °C");
                            Console.WriteLine(dataList[i - 1].Key + " " + dataList[i - 1].Value + " °C");
                            Console.WriteLine(dataList[i].Key + " " + dataList[i].Value + " °C");
                            Console.ResetColor();
                            break;
                        }
                        i++;
                    }
                    break;
                case 2:
                    while (i < dataList.Count)
                    {
                        if (dataList[i].Value < 0 && dataList[i - 1].Value < 0 && dataList[i - 2].Value < 0 && dataList[i - 3].Value < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(dataList[i - 4].Key + " " + dataList[i - 4].Value + " °C");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(dataList[i - 3].Key + " " + dataList[i - 3].Value + " °C" + " meterologisk vinter för 2016 inträffar detta datum, ish");
                            Console.WriteLine(dataList[i - 2].Key + " " + dataList[i - 2].Value + " °C");
                            Console.WriteLine(dataList[i - 1].Key + " " + dataList[i - 1].Value + " °C");
                            Console.WriteLine(dataList[i].Key + " " + dataList[i].Value + " °C");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(dataList[i + 1].Key + " " + dataList[i + 1].Value + " °C");
                            Console.ResetColor();
                            break;
                        }
                        i++;
                    }
                    break;
            } 
        }
    }
}
