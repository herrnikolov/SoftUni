using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var volume = int.Parse(Console.ReadLine());
            var energyContent = double.Parse(Console.ReadLine());
            var sugarContent = double.Parse(Console.ReadLine());

            var energyContentTotal = (volume * energyContent) / 100;
            double sugarContentTotal = (double)(volume * sugarContent) / 100;
            //double sugarContentTotal = volume * sugarContent) / 100d;

            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine($"{energyContentTotal}kcal, {sugarContentTotal}g sugars");


        }
    }
}