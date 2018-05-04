using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 18 December 2016
            //https://judge.softuni.bg/Contests/368/Programming-Basics-Exam-18-December-2016
            //https://judge.softuni.bg/Contests/Practice/Index/368#0


            var initialSpeed = int.Parse(Console.ReadLine());
            var initialTime = int.Parse(Console.ReadLine()) / 60.0;
            var secondTime = int.Parse(Console.ReadLine()) / 60.0;
            var thirdTime  = int.Parse(Console.ReadLine()) / 60.0;

            double distanceInitialSpeed = initialSpeed * initialTime;

            double aceleration = initialSpeed * 1.1 * secondTime;
            
            double deacceleration = (initialSpeed * 1.1) * 0.95 * thirdTime;
            
            double totoal = distanceInitialSpeed + aceleration + deacceleration;

            Console.WriteLine("{0:f2}",totoal);

        }
    }
}
