using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02.Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();

            var baseToConvert = BigInteger.Parse(numbers[0]);
            var numberToConvert = BigInteger.Parse(numbers[1]);

            var sum = ConvertBaseNToBase10(baseToConvert, numberToConvert);

            Console.WriteLine(sum);
        }
        private static BigInteger ConvertBaseNToBase10(BigInteger baseToConvert, BigInteger numberToConvert)
        {
            BigInteger sum = 0;
            var counter = 0;

            while (numberToConvert != 0)
            {
                var lastDigit = numberToConvert % 10;

                var currentNumber = BigInteger.Multiply(lastDigit, BigInteger.Pow(baseToConvert, counter));

                sum += currentNumber;
                numberToConvert /= 10;

                counter++;
            }

            return sum;
        }
    }
}
