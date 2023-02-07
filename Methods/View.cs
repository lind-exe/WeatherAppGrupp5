using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Text.RegularExpressions;
using WeatherApp5.Data;

namespace WeatherApp5.Methods
{
    internal class View
    {
        public static string path = "../../../Data/tempdata5-med-fel.txt";
        internal static void AverageTempPerDay(Data.WeatherData weatherData)
        {
            Console.Write("Enter month you wish to view average temps for: ");
            int month = int.Parse(Console.ReadLine());
            weatherData.Month = month;
            Console.Write("Enter day you wish to view average temps for: ");
            int day = int.Parse(Console.ReadLine());
            weatherData.Day = day;

            List<string> allData = File.ReadAllLines(path).ToList();
            Regex reg = new Regex(@$"2016-{month}-{day}");

            List<double> temps = new();
            foreach (var data in allData)
            {
                Match match = reg.Match(data);
                if (match.Success)
                {
                    Regex reg2 = new Regex(@"(?<=,)(-?\\s?\\d+.\\d)");
                    Match match2 = reg2.Match(data);
                    if (match.Success)
                    {
                        temps.Add(double.Parse(data));
                    }
                }
            }


            //WeatherData wD = new();
            //{
            //    wD.Year = weatherData.Year;
            //    wD.Month = File.ReadAllLines(path + new Regex(@$"2016-{month}"),
            //    wD.Day = File.ReadAllLines(path + new Regex(@$"2016-{month}-{day}")







            //};

        }

        internal static void AverageTempSorted()
        {
            //Console.WriteLine("Average temps sorted from highest to lowest: ");

            //List<double> list = new List<double>();
            //using (StreamReader r = new StreamReader("../../../Data/tempdata5-med fel.txt"))
            //{
            //    string content = r.ReadToEnd();

            //    foreach (Match m in Regex.Matches(content, "Inne,(-?\\s?\\d+.\\d)"))
            //    {
            //        foreach (Group g in m.Groups)
            //        {
            //            if (int.Parse(g.Name) == 1)
            //            {
            //                double temp = double.Parse(g.Value, System.Globalization.CultureInfo.InvariantCulture);
            //                list.Add(temp);

            //            }
            //        }
            //    }
            //}
            //list.Sort();
            //list.Reverse();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(list.Count());

            for (int i = 6; i <= 12; i++)
            {
                Console.WriteLine("\tMånad " + i);
                if (i < 10)
                {
                    for (int x = 1; x < 31; x++)
                    {
                        if (x < 10)
                        {
                            Regex regex = new Regex($"2016-0{i}-0{x}");
                            MatchCollection matches = regex.Matches(File.ReadAllText("../../../Data/tempdata5-med fel.txt"));
                            Console.WriteLine("dag " + x + ": " + matches.Count);
                        }
                        else
                        {
                            Regex regex2 = new Regex($"2016-0{i}-{x}");
                            MatchCollection matches = regex2.Matches(File.ReadAllText("../../../Data/tempdata5-med fel.txt"));
                            Console.WriteLine("dag " + x + ": " + matches.Count);
                        }
                    };
                }
                else
                {
                    for (int x = 1; x < 31; x++)
                    {
                        if (x < 10)
                        {
                            Regex regex = new Regex($"2016-{i}-0{x}");
                            MatchCollection matches = regex.Matches(File.ReadAllText("../../../Data/tempdata5-med fel.txt"));
                            Console.WriteLine("dag " + x + ": " + matches.Count);
                        }
                        else
                        {
                            Regex regex2 = new Regex($"2016-{i}-{x}");
                            MatchCollection matches = regex2.Matches(File.ReadAllText("../../../Data/tempdata5-med fel.txt"));
                            Console.WriteLine("dag " + x + ": " + matches.Count);
                        }
                    };
                }
            }
            Console.ReadLine();
        }

        internal static void HumiditySortedAndAverageHumitidy()
        {
            throw new NotImplementedException();
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
