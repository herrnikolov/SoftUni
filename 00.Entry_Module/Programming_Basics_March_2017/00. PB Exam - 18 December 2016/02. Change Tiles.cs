using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Change_Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 18 December 2016
            //https://judge.softuni.bg/Contests/368/Programming-Basics-Exam-18-December-2016
            //https://judge.softuni.bg/Contests/Practice/Index/368#1
            //https://softuni.bg/trainings/resources/video/13332/video-screen-11-march-2017-hristo-hentov-csharp-programming-basics-january-2017
            //https://softuni.bg/trainings/resources/video/13326/video-screen-11-march-2017-anton-petrov-csharp-programming-basics-january-2017

            double budget = double.Parse(Console.ReadLine());
            double widtFloor = double.Parse(Console.ReadLine());
            double heighFloor = double.Parse(Console.ReadLine());
            double sideOfTriangle = double.Parse(Console.ReadLine());
            double heithOfTriangle = double.Parse(Console.ReadLine());
            double pricePerTile = double.Parse(Console.ReadLine());
            double PriceWorker = double.Parse(Console.ReadLine());

            var areaFloor = widtFloor * heighFloor;
            var areaTile = (sideOfTriangle * heithOfTriangle) / 2;
            var tilesRequired = Math.Ceiling((areaFloor / areaTile) + 5);
            var costs = (tilesRequired * pricePerTile) + PriceWorker;
            var difference = Math.Abs(costs - budget);

            if (costs <= budget)
            {
                Console.WriteLine("{0:f2} lv left.", difference);
            }
            else
            {
                Console.WriteLine("You'll need {0:f2} lv more.", difference);
            }
            




        }
    }
}
