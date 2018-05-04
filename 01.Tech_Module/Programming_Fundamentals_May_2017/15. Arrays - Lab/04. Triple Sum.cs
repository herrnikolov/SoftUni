using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            bool foundSum = false;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (numbers[i] + numbers[j] == numbers[k])
                        {
                            Console.WriteLine($"{numbers[i]} + {numbers[j]} == {numbers[k]}");
                            foundSum = true;
                            break;
                        }
                    }
                }
            }
            if (!foundSum)
            {
                Console.WriteLine("No");
            }
        }
    }
}
