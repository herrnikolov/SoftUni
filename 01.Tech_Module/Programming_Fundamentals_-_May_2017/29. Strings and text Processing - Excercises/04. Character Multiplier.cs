using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = Console.ReadLine().Split();

            var firstString = strings[0];
            var secondString = strings[1];

            var maxLength = Math.Max(firstString.Length, secondString.Length);

            var totalCharactersSum = CalculateCharactersSum(firstString, secondString, maxLength);

            Console.WriteLine(totalCharactersSum);
        }
        private static long CalculateCharactersSum(string firstString, string secondString, int maxLength)
        {
            var totalSum = 0L;

            for (int i = 0; i < maxLength; i++)
            {
                if (firstString.Length < i + 1)
                {
                    totalSum += secondString[i];
                }

                else if (secondString.Length < i + 1)
                {
                    totalSum += firstString[i];
                }

                else
                {
                    totalSum += firstString[i] * secondString[i];
                }
            }

            return totalSum;
        }

    }
}
