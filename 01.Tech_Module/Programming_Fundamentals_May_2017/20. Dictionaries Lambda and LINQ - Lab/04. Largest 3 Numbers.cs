using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().
                Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            var largestTreeNumbers = numbers
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();
            Console.WriteLine(string.Join(" ", largestTreeNumbers));
        }
    }
}
