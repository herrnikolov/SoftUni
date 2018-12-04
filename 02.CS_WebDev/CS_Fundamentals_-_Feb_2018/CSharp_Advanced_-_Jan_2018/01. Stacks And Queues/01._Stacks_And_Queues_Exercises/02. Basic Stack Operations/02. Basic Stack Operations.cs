using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var elementsToPush = command[0];
            var elementsToPop = command[1];
            var neededElement = command[2];

            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(numbers);

            for (int counter = 0; counter < elementsToPop; counter++)
            {
                stack.Pop();
            }

            Console.WriteLine(stack.Contains(neededElement)
                ? "true"
                : stack.Any()
                    ? stack.Min().ToString()
                    : "0");

        }
    }
}
