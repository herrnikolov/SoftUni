using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Dog_House
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 18 March 2017
            //https://judge.softuni.bg/Contests/Practice/Index/480#0

            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());

            var sides = a * (a / 2) * 2;
            var backwall = ((a / 2) * (a / 2)) + (((a / 2) * (b - a / 2)) / 2);
            var entrance = (a / 5) * (a / 5);
            var frontwall = backwall - entrance;
            var wallsArea = sides + backwall + frontwall;
            var greenPaint = wallsArea / 3;
            var roof = a * (a / 2) * 2;
            var redPaint = roof / 5;

            Console.WriteLine("{0:f2}",greenPaint);
            Console.WriteLine("{0:f2}",redPaint);

        }
    }
}
