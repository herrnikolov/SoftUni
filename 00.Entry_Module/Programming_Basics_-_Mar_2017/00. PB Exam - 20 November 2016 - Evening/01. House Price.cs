using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.House_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/359#0

            var smallestRoom = double.Parse(Console.ReadLine());
            var kitchen = double.Parse(Console.ReadLine());
            var price = double.Parse(Console.ReadLine());

            //var secondRoom = smallestRoom + (10 * smallestRoom) / 100;
            var secondRoom = smallestRoom * 1.1;
            var thirdRoom = secondRoom * 1.1;
            var bathRoom = smallestRoom / 2;

            var area = kitchen + smallestRoom + secondRoom + thirdRoom + bathRoom;
            area = area + (5 * area) / 100;

            var finalePrice = area * price;

            Console.WriteLine("{0:f2}", finalePrice);

        }
    }
}
