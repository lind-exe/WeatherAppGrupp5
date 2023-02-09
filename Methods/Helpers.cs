using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp5.Methods
{
    internal class Helpers
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
    }
}
