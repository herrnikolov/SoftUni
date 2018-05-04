using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Work_hours
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 18 March 2017
            //https://judge.softuni.bg/Contests/Practice/Index/480#1

            var requiredHours = int.Parse(Console.ReadLine());
            var numWorkers = int.Parse(Console.ReadLine());
            var workDays = int.Parse(Console.ReadLine());

            var workerHours = (numWorkers * workDays) * 8;
            var differenceHours = Math.Abs(requiredHours - workerHours);

            if (requiredHours < workerHours)
            {
                Console.WriteLine("{0} hours left", differenceHours);
            }
            else
            {
                Console.WriteLine("{0} overtime", differenceHours);
                Console.WriteLine("Penalties: {0}", differenceHours * workDays );
            }
        }
    }
}
