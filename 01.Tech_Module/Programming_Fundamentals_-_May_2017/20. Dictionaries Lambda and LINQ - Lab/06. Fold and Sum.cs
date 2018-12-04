using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int k = numbers.Length / 4;
            int [] innerNumbers = numbers.Skip(k).Take(2 * k).ToArray();
            int[] outerNumbers = numbers.Take(k).Reverse().Concat(numbers.Reverse().Take(k)).ToArray();
            int[] foldedSums = innerNumbers.Select((x, i) => x + outerNumbers[i]).ToArray();
            Console.WriteLine(string.Join(" ", foldedSums));

        }
    }
}
