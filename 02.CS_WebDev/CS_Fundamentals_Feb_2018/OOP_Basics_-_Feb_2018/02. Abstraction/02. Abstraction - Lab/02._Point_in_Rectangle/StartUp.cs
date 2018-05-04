using System;

namespace _02._Point_in_Rectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(Console.ReadLine());
            var pointsCount = int.Parse(Console.ReadLine());
            for (int pointsCounter = 0; pointsCounter < pointsCount; pointsCounter++)
            {
                var point = new Point(Console.ReadLine);
                var containsPoint = rectangle.Contains(point);
                Console.WriteLine(containsPoint);
            }
        }
    }
}
