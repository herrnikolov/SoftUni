using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var countOfElementsToEnueue = parameters[0];
            var countOfElementsToDequeue = parameters[1];
            var neededElement = parameters[2];

            var elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbers = new Queue<int>(elements.Take(countOfElementsToEnueue));

            for (int counter = 0; counter < countOfElementsToDequeue; counter++)
            {
                numbers.Dequeue();
            }

            Console.WriteLine(numbers.Contains(neededElement)
                ? "true"
                : numbers.Any()
                    ? numbers.Min().ToString()
                    : "0");
        }
    }
}
