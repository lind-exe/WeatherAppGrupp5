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
            Dictionary<string, double> temps = new Dictionary<string, double>();
            string month = "";
            string day = "";
            string text = File.ReadAllText("../../../Data/tempdata5-med-fel.txt");
            int y = 0;
            for (int i = 6; i <= 12; i++)
            {
                y = 0;
                //Console.WriteLine("\tMånad " + i);
                if (i < 10)
                {
                    month = "0" + i;
                }
                else
                {
                    month = i.ToString();
                }
                for (int x = 0; x < 31; x++)
                {
                    if (x < 10)
                    {
                        day = "0" + x;
                    }
                    else
                    {
                        day = x.ToString();
                    }
                    string pattern = $"2016-{month}-{day}\\s(?:\\d+:\\d+:\\d+),Inne,(-?\\s?\\d+.\\d)";
                    foreach (Match m in Regex.Matches(text, pattern))
                    {
                        foreach (Group group in m.Groups)
                        {
                            if (int.Parse(group.Name) == 1)
                            {
                                Console.WriteLine("dag " + day + ": " + group.Value);                               
                                y++;
                                
                            }
                        }
                    }
                }
                Console.WriteLine("Matches: " + y++);
                Console.ReadLine();
                Console.Clear();

            }
            



            //for (int i = 6; i <= 12; i++)
            //{
            //    Console.WriteLine("\tMånad " + i);
            //    if (i < 10)
            //    {
            //        for (int x = 1; x < 31; x++)
            //        {
            //            if (x < 10)
            //            {
            //                string text = File.ReadAllText("../../../Data/tempdata5-med-fel.txt");
            //                string pattern = $"2016-0{i}-0{x}\\s(?:\\d+:\\d+:\\d+),Inne,(-?\\s?\\d+.\\d)";
            //                foreach (Match m in Regex.Matches(text, pattern))
            //                {
            //                    foreach (Group group in m.Groups)
            //                    {
            //                        if (int.Parse(group.Name) == 1)
            //                        {
            //                            Console.WriteLine("dag " + x + ": " + group.Name + " " + group.Value);
            //                            test.Add(group.Value);
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                string text = File.ReadAllText("../../../Data/tempdata5-med-fel.txt");
            //                string pattern = $"2016-0{i}-{x}\\s(?:\\d+:\\d+:\\d+),Inne,(-?\\s?\\d+.\\d)";
            //                foreach (Match m in Regex.Matches(text, pattern))
            //                {
            //                    foreach (Group group in m.Groups)
            //                    {
            //                        if (int.Parse(group.Name) == 1)
            //                        {
            //                            Console.WriteLine("dag " + x + ": " + group.Name + " " + group.Value);
            //                        }
            //                    }
            //                }
            //            }
            //        };
            //    }
            //    else
            //    {
            //        for (int x = 1; x < 31; x++)
            //        {
            //            if (x < 10)
            //            {
            //                string text = File.ReadAllText("../../../Data/tempdata5-med-fel.txt");
            //                string pattern = $"2016-{i}-0{x}\\s(?:\\d+:\\d+:\\d+),Inne,(-?\\s?\\d+.\\d)";
            //                foreach (Match m in Regex.Matches(text, pattern))
            //                {
            //                    foreach (Group group in m.Groups)
            //                    {
            //                        if (int.Parse(group.Name) == 1)
            //                        {
            //                            Console.WriteLine("dag " + x + ": " + group.Name + " " + group.Value);


            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                string text = File.ReadAllText("../../../Data/tempdata5-med-fel.txt");
            //                string pattern = $"2016-{i}-{x}\\s(?:\\d+:\\d+:\\d+),Inne,(-?\\s?\\d+.\\d)";
            //                foreach (Match m in Regex.Matches(text, pattern))
            //                {
            //                    foreach (Group group in m.Groups)
            //                    {
            //                        if (int.Parse(group.Name) == 1)
            //                        {
            //                            Console.WriteLine("dag " + x + ": " + group.Name + " " + group.Value);
            //                        }
            //                    }
            //                }
            //            }
            //        };
            //    }
            //    Console.ReadLine();
            //}         
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
