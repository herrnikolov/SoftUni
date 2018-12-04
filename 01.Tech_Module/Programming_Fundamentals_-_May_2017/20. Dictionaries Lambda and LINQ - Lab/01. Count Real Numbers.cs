using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .OrderBy(x => x)
                .ToArray();
            foreach (var number in numbers.Distinct())
            {
                Console.WriteLine(string.Join(" -> ", 
                                  number, 
                                  numbers.Count(x => x == number)));
            }
        }
    }
}
