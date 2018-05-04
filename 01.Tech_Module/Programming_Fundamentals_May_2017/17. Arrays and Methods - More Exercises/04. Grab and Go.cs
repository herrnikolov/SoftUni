using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numToSearch = int.Parse(Console.ReadLine());
            int index = 0;
            bool isFound = false;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] == numToSearch)
                {
                    index = i;
                    isFound = true;
                    break;
                }
            }
            long sum = 0;
            if (isFound)
            {
                for (int j = 0; j < index; j++)
                {
                    sum += numbers[j];
                }
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }

        }
    }
}
