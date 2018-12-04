using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var fibonacciStack = new Stack<long>();

            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            for (int counter = 0; counter < n - 1; counter++)
            {
                var lastElement = fibonacciStack.Pop();
                var preLastElement = fibonacciStack.Peek();
                var currentElement = lastElement + preLastElement;

                fibonacciStack.Push(lastElement);
                fibonacciStack.Push(currentElement);
            }

            Console.WriteLine(fibonacciStack.Peek());
        }
    }
}
