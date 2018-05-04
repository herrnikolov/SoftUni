using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SoftUni_Camp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/354#3

            var numberGroups = int.Parse(Console.ReadLine());

            var allPeople = 0;

            var counterCar = 0;
            var counterMiniBus = 0;
            var counterSmallBus = 0;
            var counterBigBus = 0;
            var counterTrain = 0;

            var sumCar = 0.0;
            var sumMiniBus = 0.0;
            var sumSmallBus = 0.0;
            var sumBigBus = 0.0;
            var sumTrain = 0.0;



            for (int i = 0; i < numberGroups; i++)
            {
                var group = int.Parse(Console.ReadLine());

                allPeople = allPeople + group;

                if (group <= 5)
                {
                    counterCar++;
                    sumCar = sumCar + group;
                }
                else if (group >= 6 && group <= 12)
                {
                    counterMiniBus++;
                    sumMiniBus = sumMiniBus + group;
                }
                else if (group >= 13 && group <= 25)
                {
                    counterSmallBus++;
                    sumSmallBus = sumSmallBus + group;
                }
                else if (group >= 26 && group <= 40)
                {
                    counterBigBus++;
                    sumBigBus = sumBigBus + group;
                }
                else if (group >= 41)
                {
                    counterTrain++;
                    sumTrain = sumTrain + group;
                }
            }
            Console.WriteLine("{0:f2}%", (sumCar / allPeople) * 100);
            Console.WriteLine("{0:f2}%", (sumMiniBus / allPeople) * 100);
            Console.WriteLine("{0:f2}%", (sumSmallBus / allPeople) * 100);
            Console.WriteLine("{0:f2}%", (sumBigBus / allPeople) * 100);
            Console.WriteLine("{0:f2}%", (sumTrain / allPeople) * 100);

        }
    }
}
