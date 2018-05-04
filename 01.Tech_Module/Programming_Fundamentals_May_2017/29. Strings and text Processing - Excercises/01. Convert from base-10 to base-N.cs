using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Convert_from_base_10_to_base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();

            var baseToConvert = BigInteger.Parse(numbers[0]);
            var numberToConvert = BigInteger.Parse(numbers[1]);

            var covertedToBaseN = ConvertBase10ToBaseN(baseToConvert, numberToConvert);

            Console.WriteLine(covertedToBaseN);
        }

        private static string ConvertBase10ToBaseN(BigInteger baseToConvert, BigInteger numberToConvert)
        {
            var result = string.Empty;

            while (numberToConvert > 0)
            {
                var remainder = numberToConvert % baseToConvert;

                result = remainder.ToString() + result;
                numberToConvert /= baseToConvert;
            }

            return result;
        }
    }
}
