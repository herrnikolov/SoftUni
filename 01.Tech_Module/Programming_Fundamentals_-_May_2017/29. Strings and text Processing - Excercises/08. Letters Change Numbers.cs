using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringsSequence = Console.ReadLine().Split("\t ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var totalSum = 0m;

            for (int i = 0; i < stringsSequence.Length; i++)
            {
                var leftLetter = char.Parse(stringsSequence[i].Substring(0, 1));
                var rightLetter = char.Parse(stringsSequence[i].Substring(stringsSequence[i].Length - 1));
                var number = decimal.Parse(stringsSequence[i].Substring(1, stringsSequence[i].Length - 2));

                if (char.IsUpper(leftLetter))
                {
                    number /= (leftLetter - 64);
                }

                else if (char.IsLower(leftLetter))
                {
                    number *= (leftLetter - 96);
                }

                if (char.IsUpper(rightLetter))
                {
                    number -= (rightLetter - 64);
                }

                else if (char.IsLower(rightLetter))
                {
                    number += (rightLetter - 96);
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:F2} ");
        }
    }
}
