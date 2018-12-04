using System;
using System.Collections.Generic;

namespace _08._Recursive_Fibonacci
{
    class Program
    {
        private static Dictionary<long, long> calculatedNumbers;
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            calculatedNumbers = new Dictionary<long, long>();

            var result = GetFibonacci(n);

            Console.WriteLine(result);
        }

        private static long GetFibonacci(long n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (calculatedNumbers.ContainsKey(n))
            {
                return calculatedNumbers[n];
            }

            var currentValue = GetFibonacci(n - 2) + GetFibonacci(n - 1);
            calculatedNumbers.Add(n, currentValue);

            return currentValue;
        }
    }
}
