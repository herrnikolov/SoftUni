using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Min__Max__Sum__Average
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                numbers.Add(currentNumber);

            }

            var minNumber = numbers.Min();
            var maxNumber = numbers.Max();
            var numberSum = numbers.Sum();
            var averageNubmer = numbers.Average();

            Console.WriteLine($"Sum = {numberSum}");
            Console.WriteLine($"Min = {minNumber}");
            Console.WriteLine($"Max = {maxNumber}");
            Console.WriteLine($"Average = {averageNubmer}");
        }
    }
}
