using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            var stack = new Stack<string>();

            foreach (var num in input)
            {
                stack.Push(num);
            }

            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop().ToString()} ");
            }

            Console.WriteLine();
        }
    }
}
