using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 18 December 2016
            //https://judge.softuni.bg/Contests/368/Programming-Basics-Exam-18-December-2016
            //https://judge.softuni.bg/Contests/Practice/Index/368#2
            //https://softuni.bg/trainings/resources/video/13332/video-screen-11-march-2017-hristo-hentov-csharp-programming-basics-january-2017
            //https://softuni.bg/trainings/resources/video/13326/video-screen-11-march-2017-anton-petrov-csharp-programming-basics-january-2017


            var chrysanthemumsCount = int.Parse(Console.ReadLine());
            var rosesCount = int.Parse(Console.ReadLine());
            var tulipCount = int.Parse(Console.ReadLine());
            string seasson = Console.ReadLine();
            //char isHoliday = char.Parse(Console.ReadLine());
            bool isHoliday = Console.ReadLine() == "Y";

            double flowersCost = 0.0;

            if (seasson == "Spring" || seasson == "Summer")
            {
                flowersCost = 
                    chrysanthemumsCount * 2.0 + 
                    rosesCount * 4.1 + 
                    tulipCount * 2.5;

                if (tulipCount > 7 && seasson =="Spring")
                {
                    flowersCost *= 0.95;
                }

            }
            else
            {
                flowersCost =
                    chrysanthemumsCount * 3.75 +
                    rosesCount * 4.5 +
                    tulipCount * 4.15;

                if (rosesCount >= 10 && seasson == "Winter")
                {
                    flowersCost *= 0.9;
                }
            }

            if (isHoliday)
            {
                flowersCost *= 1.15;
            }
            if (chrysanthemumsCount + rosesCount + tulipCount > 20)
            {
                flowersCost *= 0.8;
            }

            flowersCost += 2;

            Console.WriteLine("{0:f2}", flowersCost);
        }
    }
}
