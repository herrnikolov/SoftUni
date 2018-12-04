using System;

namespace _01._Class_Box
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var length = decimal.Parse(Console.ReadLine());
            var width = decimal.Parse(Console.ReadLine());
            var height = decimal.Parse(Console.ReadLine());

            var box = new Box(length, width, height);

            Console.WriteLine(box.ToString());
        }
    }
}
