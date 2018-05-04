using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersList = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

            var numbersArray = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var takeNumbersCount = numbersArray[0];
            var skipNumbersCount = numbersArray[1];
            var searchNumber = numbersArray[2];

            numbersList = numbersList.Take(takeNumbersCount).Skip(skipNumbersCount).ToList();

            if (numbersList.Contains(searchNumber))
            {
                Console.WriteLine("YES!");
            }

            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
