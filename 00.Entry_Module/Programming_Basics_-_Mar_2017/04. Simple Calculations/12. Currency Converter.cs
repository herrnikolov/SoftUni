using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal moneyToString = decimal.Parse(Console.ReadLine());
            string firstcurrency = Console.ReadLine();
            string secondcurrency = Console.ReadLine();
            decimal firstRate = 0.0m;
            decimal secondRate = 0.0m;

            if (firstcurrency == "BGN")
            {
                firstRate = 1;
            }
            else if (firstcurrency == "USD")
            {
                firstRate = 1.79549m;
            }
            else if (firstcurrency == "EUR")
            {
                firstRate = 1.95583m;
            }
            else if (firstcurrency == "GBP")
            {
                firstRate = 2.53405m;
            }
            if (secondcurrency == "BGN")
            {
                secondRate = 1;
            }
            else if (secondcurrency == "USD")
            {
                secondRate = 1.79549m;
            }
            else if (secondcurrency == "EUR")
            {
                secondRate = 1.95583m;
            }
            else if (secondcurrency == "GBP")
            {
                secondRate = 2.53405m;
            }

            decimal result = moneyToString * (firstRate / secondRate);

            Console.WriteLine("{0} {1}", Math.Round(result, 2), secondcurrency);


            //https://softuni.bg/forum/8067/homework-currency-converter-help
            //decimal moneyToConvert = decimal.Parse(Console.ReadLine());
            //string firstCurrency = Console.ReadLine();
            //string secondCurrency = Console.ReadLine();
            //Dictionary<string, decimal> currencies = new Dictionary<string, decimal>() { { "BGN", 1 }, { "USD", 1.79549m }, { "EUR", 1.95583m }, { "GBP", 2.53405m } };
            //decimal result = moneyToConvert * (currencies[firstCurrency] / currencies[secondCurrency]);
            //Console.WriteLine("{0} {1}", Math.Round(result, 2), secondCurrency);


            //static double convert(string a)
            //{
            //    switch (a)
            //    {
            //        case "BGN":
            //            return 1;
            //            break;
            //        case "USD":
            //            return 1.79549;
            //            break;
            //        case "EUR":
            //            return 1.95583;
            //        case "GBP":
            //            return 2.53405;
            //            break;
            //        default:
            //            return 1;
            //            break;
            //    }
            //}
            //static void Main()
            //{
            //    var amount = double.Parse(Console.ReadLine());
            //    string currency_1 = Console.ReadLine();
            //    string currency_2 = Console.ReadLine();

            //    double value1 = convert(currency_1);
            //    double value2 = convert(currency_2);

            //    double result = (value1 / value2) * amount;
            //    Console.WriteLine(Math.Round(result, 2) + " " + currency_2);






        }
    }
}
