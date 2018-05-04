using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Multiply_Evens_by_Odds
{
    class Program
    {
        public static void Main()
        {
            var number = Math.Abs(int.Parse(Console.ReadLine()));

            var result = GetMultipleOfEvenAndOdds(number);

            Console.WriteLine($"{result}");

        }

        private static int SumOfEvenDigits(int n)
        {
            var sum = 0;

            while (n > 0)
            {
                var lastDigit = n % 10;

                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }

                n /= 10;
            }

            return sum;
        }

        private static int SumOfOddDigits(int n)
        {
            var sum = 0;

            while (n > 0)
            {
                int lastDigit = n % 10;

                if (lastDigit % 2 != 0)
                {
                    sum += lastDigit;
                }

                n /= 10;
            }

            return sum;
        }

        private static int GetMultipleOfEvenAndOdds(int n)
        {
            var evensSum = SumOfEvenDigits(n);
            var oddsSum = SumOfOddDigits(n);

            var multiplication = evensSum * oddsSum;

            return multiplication;
        }
    }
}
