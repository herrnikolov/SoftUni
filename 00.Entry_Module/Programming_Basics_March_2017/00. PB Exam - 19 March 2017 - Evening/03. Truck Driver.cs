using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Truck_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/501#2
            var seasson = Console.ReadLine();
            var km = double.Parse(Console.ReadLine());

            switch (seasson)
            {
                case "Spring":
                case "Autumn":
                    if (km <= 5000)
                        Console.WriteLine("{0:f2}", (km * 0.75 * 4) * 0.9);
                    if (km > 5001 && km <= 10000)
                        Console.WriteLine("{0:f2}", (km * 0.95 * 4) * 0.9);
                    if (km > 10001 && km <= 20000)
                        Console.WriteLine("{0:f2}", (km * 1.45 * 4) * 0.9);
                    break;
                case "Summer":
                    if (km <= 5000)
                        Console.WriteLine("{0:f2}", (km * 0.9 * 4) * 0.9);
                    if (km > 5001 && km <= 10000)
                        Console.WriteLine("{0:f2}", (km * 1.1 * 4) * 0.9);
                    if (km > 10001 && km <= 20000)
                        Console.WriteLine("{0:f2}", (km * 1.45 * 4) * 0.9);
                    break;
                case "Winter":
                    if (km <= 5000)
                        Console.WriteLine("{0:f2}", (km * 1.05 * 4) * 0.9);
                    if (km > 5001 && km <= 10000)
                        Console.WriteLine("{0:f2}", (km * 1.25 * 4) * 0.9);
                    if (km > 10001 && km <= 20000)
                        Console.WriteLine("{0:f2}", (km * 1.45 * 4) * 0.9);
                    break;
                default:
                    km = 0;
                    break;
            }


        }
    }
}
