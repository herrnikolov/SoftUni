using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/499#0

            double budgetInput = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            var budget = Math.Round(budgetInput,2);
            
            if (budget <= 1000)
            {
                var accomodation = "Camp";

                if (season == "Summer")
                {
                    var price = budget * 0.65;
                    Console.WriteLine("Alaska"+" - "+ "{0}" + " - " + "{1:f2}", accomodation, price);
                }
                else if (season == "Winter")
                {
                    var price = budget * 0.45;
                    Console.WriteLine("Morocco" + " - " + "{0}" + " - " + "{1:f2}", accomodation, price);
                }
                
                  
            }
            if (budget > 1001 && budget <= 3000)
            {
                var accomodation = "Hut";

                if (season == "Summer")
                {
                    var price = budget * 0.80;
                    Console.WriteLine("Alaska" + " - " + "{0}" + " - " + "{1:f2}", accomodation, price);
                }
                else if (season == "Winter")
                {
                    var price = budget * 0.60;
                    Console.WriteLine("Morocco" + " - " + "{0}" + " - " + "{1:f2}", accomodation, price);
                }
            }
            if (budget > 3001)
            {
                var accomodation = "Hotel";

                if (season == "Summer")
                {
                    var price = budget * 0.90;
                    Console.WriteLine("Alaska" + " - " + "{0}" + " - " + "{1:f2}", accomodation, price);
                }
                else if (season == "Winter")
                {
                    var price = budget * 0.90;
                    Console.WriteLine("Morocco" + " - " + "{0}" + " - " + "{1:f2}", accomodation, price);
                }
            }
            
        }
    }
}
