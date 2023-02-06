using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp5.Methods
{
    internal class Menus
    {
        enum Main
        {
            Average_Temp_Per_Day = 1,
            Average_Temp_Sorted,
            Humidity_Sorted_And_Average_Humidity,
            Mold_Risk,
            Meterologic_Dates
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
                        //Helpers.WrongInput();
                    }
                    switch (menu)
                    {
                        case Main.Average_Temp_Per_Day:
                            View.AverageTempPerDay();

                            goMain = false;
                            break;
                        case Main.Average_Temp_Sorted:
                            View.AverageTempSorted();

                            
                            goMain = false;
                            break;
                        case Main.Humidity_Sorted_And_Average_Humidity:
                            View.HumiditySortedAndAverageHumitidy();

                            goMain = false;
                            break;
                        case Main.Mold_Risk:
                            View.MoldRisk();

                            goMain = false;
                            break;
                        case Main.Meterologic_Dates:
                            View.MeterologicDates();

                            goMain = false;
                            break;
                    }
                }
            }
        }
    }
}
