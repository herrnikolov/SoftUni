using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Func<string, int> parser = n => int.Parse(n);

            int[] numbers = input
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            //var numbers = Console.ReadLine()
            //    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(parser)
            //    .ToList();
            //Console.WriteLine(numbers.Count);

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
