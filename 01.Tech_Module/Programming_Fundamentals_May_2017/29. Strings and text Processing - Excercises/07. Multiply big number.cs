using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Multiply_big_number
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = Console.ReadLine().TrimStart('0');
            var secondNumber = Console.ReadLine();

            if (firstNumber == "0" || secondNumber == "0")
            {
                Console.WriteLine(0);
                return;
            }

            var inMind = 0;
            var remainder = 0;

            var result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                for (int j = secondNumber.Length - 1; j >= 0; j--)
                {
                    var parsedFirstNumber = int.Parse(firstNumber[i].ToString());
                    var parsedSecondNumber = int.Parse(secondNumber[j].ToString());

                    var sum = parsedFirstNumber * parsedSecondNumber + inMind;

                    inMind = sum / 10;
                    remainder = sum % 10;

                    result.Insert(0, remainder.ToString());

                    if (i == 0 && inMind != 0)
                    {
                        result.Insert(0, inMind.ToString());
                    }
                }

            }

            Console.WriteLine(result);
        }
    }
}
