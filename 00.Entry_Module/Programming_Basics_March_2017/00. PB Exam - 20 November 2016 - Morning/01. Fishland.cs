using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/354#0

            double skumriqlPricePerKG = double.Parse(Console.ReadLine());
            double cacaPricePerKG = double.Parse(Console.ReadLine());
            double palamudKG = double.Parse(Console.ReadLine());
            double safridKG = double.Parse(Console.ReadLine());
            double midiKG= double.Parse(Console.ReadLine());

            var pricePalamudPerKG = skumriqlPricePerKG * 1.6;
            var palamudCost = pricePalamudPerKG * palamudKG;

            var priceSafridPerKG = cacaPricePerKG * 1.8;
            var safridCost = priceSafridPerKG * safridKG;

            var midiCost = midiKG * 7.50;

            var totalCost = palamudCost + safridCost + midiCost;

            Console.WriteLine("{0:f2}", totalCost);


        }
    }
}
