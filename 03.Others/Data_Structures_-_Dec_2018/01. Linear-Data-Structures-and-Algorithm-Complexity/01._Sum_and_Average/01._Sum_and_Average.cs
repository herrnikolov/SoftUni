using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._Sum_and_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            string[] input = Console.ReadLine().Split();

            if (input.Length == 0)
            {
                Console.WriteLine("Sum=0; Average=0.00");
            }
            else
            {
                foreach (var number in input)
                {
                    numbers.Add(int.Parse(number));
                }

                Console.WriteLine($"Sum={numbers.Sum()}; Average={numbers.Average():f2}");
            }
        }
    }
}
