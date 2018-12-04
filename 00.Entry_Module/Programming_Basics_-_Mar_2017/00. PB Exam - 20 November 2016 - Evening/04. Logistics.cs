using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/359#3

            var count = int.Parse(Console.ReadLine());

            var loadSum = 0;

            var loadWithBus = 0.0;
            var loadWithTruck = 0.0;
            var loadWithTrain = 0.0;


            for (int i = 0; i < count; i++)
            {
                var load = int.Parse(Console.ReadLine());
                loadSum += load;

                if (load < 4)
                {
                    loadWithBus += load;
                }
                else if (load > 3 && load < 12)
                {
                    loadWithTruck += load;
                }
                else
                {
                    loadWithTrain += load;
                }
            }

            var average = (loadWithBus * 200 + loadWithTruck * 175 + loadWithTrain * 120) / loadSum;

            Console.WriteLine("{0:f2}", average);

            Console.WriteLine("{0:f2}%", loadWithBus / loadSum * 100);
            Console.WriteLine("{0:f2}%", loadWithTruck / loadSum * 100);
            Console.WriteLine("{0:f2}%", loadWithTrain / loadSum * 100);
        }
    }
}
