using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Car_To_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 18 March 2017
            //https://judge.softuni.bg/Contests/Practice/Index/480#2

            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            //var budget = Math.Round(budgetInput, 2);

            if (budget <= 100)
            {
                var classtype = "Economy class";

                if (season == "Summer")
                {
                    var price = budget * 0.35;
                    Console.WriteLine(classtype);
                    Console.WriteLine("Cabrio"+" - "+"{0:f2}", price);
                }
                else if (season == "Winter")
                {
                    var price = budget * 0.65;
                    Console.WriteLine(classtype);
                    Console.WriteLine("Jeep" + " - " + "{0:f2}", price);
                }


            }
            if (budget > 101 && budget <= 500)
            {
                var classtype = "Compact class";

                if (season == "Summer")
                {
                    var price = budget * 0.45;
                    Console.WriteLine(classtype);
                    Console.WriteLine("Cabrio" + " - " + "{0:f2}", price);
                }
                else if (season == "Winter")
                {
                    var price = budget * 0.80;
                    Console.WriteLine(classtype);
                    Console.WriteLine("Jeep" + " - " + "{0:f2}", price);
                }
            }
            if (budget > 501)
            {
                var classtype = "Luxury class";

                if (season == "Summer")
                {
                    var price = budget * 0.90;
                    Console.WriteLine(classtype);
                    Console.WriteLine("Jeep" + " - " + "{0:f2}", price);
                }
                else if (season == "Winter")
                {
                    var price = budget * 0.90;
                    Console.WriteLine(classtype);
                    Console.WriteLine("Jeep" + " - " + "{0:f2}", price);
                }
            }

        }
    }
}
