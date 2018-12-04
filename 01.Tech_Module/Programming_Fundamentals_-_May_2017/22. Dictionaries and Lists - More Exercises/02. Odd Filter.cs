using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Odd_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToList();

            var oddNumbers = numbers
                .Select(x => x > numbers.Average() ? ++x : --x)
                .ToList();

            Console.WriteLine(string.Join(" ", oddNumbers));
        }
    }
}
