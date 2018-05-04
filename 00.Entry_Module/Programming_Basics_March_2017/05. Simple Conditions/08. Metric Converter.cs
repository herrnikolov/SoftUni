using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double numbersToConvert = double.Parse(Console.ReadLine());
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            var currencies = new Dictionary<string, double>()
                {
                    {"mm", 1000 },
                    {"cm", 100 },
                    {"mi", 0.000621371192},
                    {"in", 39.3700787},
                    {"m", 1},
                    {"km", 0.001},
                    {"ft", 3.2808399},
                    {"yd", 1.0936133}
                };
            double result = numbersToConvert / currencies[firstNumber] * currencies[secondNumber];

            Console.WriteLine("{0} {1}", result, secondNumber);
            }
    }
}
