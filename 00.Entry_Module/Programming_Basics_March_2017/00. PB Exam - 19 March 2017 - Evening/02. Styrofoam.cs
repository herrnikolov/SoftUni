using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Styrofoam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/501#1

            var budget = double.Parse(Console.ReadLine());
            var houseArea = double.Parse(Console.ReadLine());
            var numberWindows = int.Parse(Console.ReadLine());
            var sqAreaPerPack = double.Parse(Console.ReadLine());
            var pricePerPack = double.Parse(Console.ReadLine());


            var houseAreaWithoutWindows = (houseArea - (numberWindows * 2.4)) * 1.1;
            var requiredPacks = Math.Ceiling(houseAreaWithoutWindows / sqAreaPerPack);
            var pricePerRequiredPacks = requiredPacks * pricePerPack;
                        
            var budgetLeft = Math.Abs(pricePerRequiredPacks - budget);
            var budgetShort = pricePerRequiredPacks - budget;
            

            if (budget >= pricePerRequiredPacks)
            {
                Console.WriteLine("Spent: {0:f2}", pricePerRequiredPacks);
                Console.WriteLine("Left: {0:f2}", budgetLeft);
            }
            if (budget < pricePerRequiredPacks)
            {
                Console.WriteLine("Need more: {0:f2}", budgetShort);
            }




        }
    }
}
