using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Flower_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/359#1

            var magnolies = 3.25;
            var hyacinth = 4.00;
            var rouses = 3.50;
            var cactuses = 8.00;

            var countMagnolies = int.Parse(Console.ReadLine());
            var countHyacinth = int.Parse(Console.ReadLine());
            var countRouses = int.Parse(Console.ReadLine());
            var countCactuses = int.Parse(Console.ReadLine());
            var giftPrice = double.Parse(Console.ReadLine());

            var sum = countMagnolies * magnolies + countHyacinth * hyacinth + countRouses * rouses + countCactuses * cactuses;
            var result = sum * 0.95;
            // var tax = sum * 0.05;
            //var result = sum - tax;

            if (result >= giftPrice)
            {
                Console.WriteLine("She is left with {0} leva.", Math.Floor(result - giftPrice));
            }
            else
            {
                Console.WriteLine("She will have to borrow {0} leva.", Math.Ceiling(giftPrice - result));
            }
        }
    }
}
