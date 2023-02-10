using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WeatherApp5.Data;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherApp5.Methods
{
    internal static class Helpers
    {
        public static int TryNumber(int maxValue, int minValue)
        {
            int number = 0;
            bool correctInput = false;
            while (!correctInput)
            {
                if (!int.TryParse(Console.ReadLine(), out number) || number > maxValue || number < minValue)
                {
                    Console.Write("Wrong input, try again: ");

                }
                else
                {
                    correctInput = true;
                }
            }
            return number;
        }
        public static string SelectedLocation()
        {
            Console.WriteLine("1.Inne\n2.Ute ");
            int inOrOut = Helpers.TryNumber(2, 1);
            string input = "";
            switch (inOrOut)
            {
                case 1:
                    input = "Inne";
                    break;
                case 2:
                    input = "Ute";
                    break;
            }
            return input;
        }
        internal static void WrongInput()
        {
            Console.Clear();
            Console.SetCursorPosition(2, 2);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("WRONGINPUT");
            Thread.Sleep(500);
            Console.ResetColor();
            Console.Clear();
            Menus.Show("Main");
        }
        internal static void SaveTempsToFile(int month, int startDay, int endDay, string location, string monthName)
        {
            string path = "../../../Data/";

            List<WeatherData> weatherData = RegexData.GetData();
            Dictionary<string, double> data = new Dictionary<string, double>();


            DateTime StartDate = new DateTime(2016, month, startDay);
            DateTime EndDate = new DateTime(2016, month, endDay);
            int DayInterval = 1;

            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                var chosenData = weatherData.Where(x => x.Date.Date == StartDate).Where(x => x.Location == location).ToList();
                double tempCounter = 0;
                

                foreach (var c in chosenData)
                {
                    tempCounter += c.Temperature;
                    
                }
                double tempResult = tempCounter / chosenData.Count;
                

                if (!double.IsNaN(tempResult))
                {
                    data.Add(StartDate.ToString("yyyy-MM-dd"), Math.Round(tempResult, 1));
                }

                StartDate = StartDate.AddDays(DayInterval);
            }

            double monthTempCounter = 0;

            foreach (var c in data)
            {
                monthTempCounter += c.Value;
            }
            double monthAvrg = monthTempCounter / data.Count();
            
            File.AppendAllText(path + "Log.txt", $"{monthName}s medeltemp {location} är: {Math.Round(monthAvrg, 1)}\n");
            
        }
        internal static void SaveHumidityToFile(int month, int startDay, int endDay, string location, string monthName)
        {
            string path = "../../../Data/";

            List<WeatherData> weatherData = RegexData.GetData();
            Dictionary<string, double> data = new Dictionary<string, double>();


            DateTime StartDate = new DateTime(2016, month, startDay);
            DateTime EndDate = new DateTime(2016, month, endDay);
            int DayInterval = 1;

            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                var chosenData = weatherData.Where(x => x.Date.Date == StartDate).Where(x => x.Location == location).ToList();
                double humidityCounter = 0;


                foreach (var c in chosenData)
                {
                    humidityCounter += c.Humidity;

                }
                double humidityResult = humidityCounter / chosenData.Count;


                if (!double.IsNaN(humidityResult))
                {
                    data.Add(StartDate.ToString("yyyy-MM-dd"), Math.Round(humidityResult, 1));
                }

                StartDate = StartDate.AddDays(DayInterval);
            }

            double monthTempCounter = 0;

            foreach (var c in data)
            {
                monthTempCounter += c.Value;
            }
            double monthAvrg = monthTempCounter / data.Count();

            File.AppendAllText(path + "Log.txt", $"{monthName}s medelfuktighet {location} är: {Math.Round(monthAvrg, 1)}%\n");

        }
        internal static void SaveFiles()
        {
            //Helpers.SaveTempsToFile(6, 1, 30, "Inne", "Juni");
            //Helpers.SaveTempsToFile(6, 1, 30, "Ute", "Juni");
            //Helpers.SaveTempsToFile(7, 1, 31, "Inne", "Juli");
            //Helpers.SaveTempsToFile(7, 1, 31, "Ute", "Juli");
            //Helpers.SaveTempsToFile(8, 1, 31, "Inne", "Augusti");
            //Helpers.SaveTempsToFile(8, 1, 31, "Ute", "Augusti");
            //Helpers.SaveTempsToFile(9, 1, 30, "Inne", "September");
            //Helpers.SaveTempsToFile(9, 1, 30, "Ute", "September");
            //Helpers.SaveTempsToFile(10, 1, 31, "Inne", "Oktober");
            //Helpers.SaveTempsToFile(10, 1, 31, "Ute", "Oktober");
            //Helpers.SaveTempsToFile(11, 1, 30, "Inne", "November");
            //Helpers.SaveTempsToFile(11, 1, 30, "Ute", "November");
            //Helpers.SaveTempsToFile(12, 1, 31, "Inne", "December");
            //Helpers.SaveTempsToFile(12, 1, 31, "Ute", "December");
            //Helpers.SaveHumidityToFile(6, 1, 30, "Inne", "Juni");
            //Helpers.SaveHumidityToFile(6, 1, 30, "Ute", "Juni");
            //Helpers.SaveHumidityToFile(7, 1, 31, "Inne", "Juli");
            //Helpers.SaveHumidityToFile(7, 1, 31, "Ute", "Juli");
            //Helpers.SaveHumidityToFile(8, 1, 31, "Inne", "Augusti");
            //Helpers.SaveHumidityToFile(8, 1, 31, "Ute", "Augusti");
            //Helpers.SaveHumidityToFile(9, 1, 30, "Inne", "September");
            //Helpers.SaveHumidityToFile(9, 1, 30, "Ute", "September");
            //Helpers.SaveHumidityToFile(10, 1, 31, "Inne", "Oktober");
            //Helpers.SaveHumidityToFile(10, 1, 31, "Ute", "Oktober");
            //Helpers.SaveHumidityToFile(11, 1, 30, "Inne", "November");
            //Helpers.SaveHumidityToFile(11, 1, 30, "Ute", "November");
            //Helpers.SaveHumidityToFile(12, 1, 31, "Inne", "December");
            //Helpers.SaveHumidityToFile(12, 1, 31, "Ute", "December");
            Helpers.SaveMoldRiskToFile(6, 1, 30, "Juni");
            Helpers.SaveMoldRiskToFile(7, 1, 31, "Juli");
            Helpers.SaveMoldRiskToFile(8, 1, 31, "Augusti");
            Helpers.SaveMoldRiskToFile(9, 1, 30, "September");
            Helpers.SaveMoldRiskToFile(10, 1, 31, "Oktober");
            Helpers.SaveMoldRiskToFile(11, 1, 30, "November");
            Helpers.SaveMoldRiskToFile(12, 1, 31, "December");
            Helpers.SaveMoldFormulaToFile();
            
        }
        internal static void SaveMoldRiskToFile(int month, int startDay, int endDay, string monthName)
        {
            string path = "../../../Data/";

            List<WeatherData> weatherData = RegexData.GetData();
            Dictionary<string, double> data = new Dictionary<string, double>();


            DateTime StartDate = new DateTime(2016, month, startDay);
            DateTime EndDate = new DateTime(2016, month, endDay);
            int DayInterval = 1;

            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                var chosenData = weatherData.Where(x => x.Date.Date == StartDate).Where(x => x.Location == "Ute").Where(x => x.Temperature > 0 && x.Humidity > 70).ToList();
                double moldResult = 0;


                foreach (var c in chosenData)
                {
                    moldResult = (c.Temperature + c.Humidity) / 2;

                }



                if (moldResult != 0)
                {
                    data.Add(StartDate.ToString("yyyy-MM-dd"), Math.Round(moldResult, 1));
                }

                StartDate = StartDate.AddDays(DayInterval);
            }

            double monthMoldRisk = 0;

            foreach (var c in data)
            {
                monthMoldRisk += c.Value;
            }
            double monthAvrg = monthMoldRisk / data.Count;

            File.AppendAllText(path + "Log.txt", $"{monthName}s risk för mögel ute är: {Math.Round(monthAvrg, 1)} på en skala 0 till 100\n");
        }
        internal static void SaveMoldFormulaToFile()
        {
            string path = "../../../Data/";
            string text = "((Luftfuktighet > 70%) + (Temperatur > 0) / 2) * 1.33 För att få en skala 0 - 100";
            File.AppendAllText(path + "Log.txt", text);
        }
        public static void ViewBox(this string input)
        {
            Console.WriteLine(new String('-', input.Length + 4));
            Console.WriteLine("| " + input + " |");
            Console.WriteLine(new String('-', input.Length + 4));
        }
    }
}
