using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Bike_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/359#2

            var juniors = int.Parse(Console.ReadLine());
            var seniors = int.Parse(Console.ReadLine());
            var track = Console.ReadLine();

            var juniorTax = 0.0;
            var seniorsTax = 0.0;

            switch (track.ToLower())
            {
                case "trail":
                    juniorTax = 5.5;
                    seniorsTax = 7.00;
                    break;
                case "cross-country":
                    if (juniors + seniors >= 50)
                    {
                        juniorTax = 8.00 * 0.75;
                        seniorsTax = 9.50 * 0.75;
                    }
                    else
                    {
                        juniorTax = 8.00;
                        seniorsTax = 9.50;
                    }

                    break;
                case "downhill":
                    juniorTax = 12.25;
                    seniorsTax = 13.75;
                    break;
                case "road":
                    juniorTax = 20.00;
                    seniorsTax = 21.50;
                    break;        
                default:
                    break;
            }
            var sum = juniors * juniorTax + seniors * seniorsTax;
            sum = sum * 0.95;
            Console.WriteLine("{0:f2}", sum);
        }
    }
}
