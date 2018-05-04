using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Cups
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/499#0
            double cupsToProduce = int.Parse(Console.ReadLine());
            var workers = int.Parse(Console.ReadLine());
            var workDays = int.Parse(Console.ReadLine());

            var manDays = workers * workDays * 8;
            double cupsProduced = manDays / 5;

            if(cupsToProduce > cupsProduced)
            {
                var shortageCups = (cupsToProduce - cupsProduced) * 4.2;
                Console.WriteLine("Losses: {0:f2}", shortageCups);
            }
            else if(cupsToProduce < cupsProduced)
            {
                var surplusCups = (cupsProduced - cupsToProduce) * 4.2;
                Console.WriteLine("{0:f2} extra money", surplusCups);
            }            
        }
    }
}
