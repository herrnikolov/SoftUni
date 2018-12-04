using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/499#0

            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());

            double faceDoor = 1.2 * 2;
            double faceWindows = 1.5 * 1.5 * 2;
            double faceWalls = ((x * x) * 2) + ((x * y) * 2);

            double wallsLessWindowsAndDoor = faceWalls - (faceDoor + faceWindows);
            double greenPaintRequred = wallsLessWindowsAndDoor / 3.4;
            Console.WriteLine("{0:f2}",greenPaintRequred);

            double roofSide = 2 * ((x * h) /2);
            double roofTop = 2 * (x * y);
            double roof = roofSide + roofTop;

            double redPaintRequired = roof / 4.3;
            Console.WriteLine("{0:f2}",redPaintRequired);



        }
    }
}
