using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Grape_and_Rakia
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/501#0

            var vineyardArea = double.Parse(Console.ReadLine());
            var yieldPersqmeter = double.Parse(Console.ReadLine());
            var waste = double.Parse(Console.ReadLine());

            var yieldTotal = (vineyardArea * yieldPersqmeter) - waste;

            var grapeForRakia = yieldTotal * 0.45;
            var rakiaLiters = grapeForRakia / 7.5;
            var rakiaIncome = rakiaLiters * 9.8;
            Console.WriteLine("{0:f2}", rakiaIncome);

            var grapeForSale = yieldTotal * 0.55;
            var grapeIncome = grapeForSale * 1.5;
            Console.WriteLine("{0:f2}", grapeIncome);


        }
    }
}
