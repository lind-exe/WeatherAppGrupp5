using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp5.Methods
{
    internal class Menus
    {
        public delegate double MyDelegate (double temp, double hum);
        enum Main
        {
            Average_Temp_Per_Day = 1,
            Average_Temp_Sorted,
            Humidity_Sorted_And_Average_Humidity,
            Mold_Risk, 
            Save_Temps_And_Humidity_To_File,
            Show_And_Save_Meterologic_Dates_To_File,
        }
        public static void Show(string value)
        {
            bool goMain = true;

            if (value == "Main")
            {
                while (goMain)
                {
                    foreach (int i in Enum.GetValues(typeof(Main)))
                    {
                        Console.WriteLine($"{i}. {Enum.GetName(typeof(Main), i).Replace("_", " ")}");
                    }

                    int nr;
                    Main menu = (Main)99; //Default
                    if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr) || nr > Enum.GetNames(typeof(Main)).Length - 1)
                    {
                        menu = (Main)nr;
                        Console.Clear();
                    }
                    else
                    {
                        Helpers.WrongInput();
                    }
                    switch (menu)
                    {
                        case Main.Average_Temp_Per_Day:
                            View.AverageTempPerDay();
                            break;
                        case Main.Average_Temp_Sorted:
                            View.AverageTempSorted();
                            break;
                        case Main.Humidity_Sorted_And_Average_Humidity:
                            View.HumiditySortedAndAverageHumitidy();
                            break;
                        case Main.Mold_Risk:
                            MyDelegate del = MoldIndex;
                            View.MoldRisk(del);
                            break;
                        case Main.Save_Temps_And_Humidity_To_File:
                            Helpers.SaveFiles();

                            break;
                        case Main.Show_And_Save_Meterologic_Dates_To_File:
                            View.MeterologicDates();
                            break;
                        
                    }
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
        public static double MoldIndex(double temp, double hum)
        {
            double result = (temp + hum) / 2;
            return result;
        }
    }
}
