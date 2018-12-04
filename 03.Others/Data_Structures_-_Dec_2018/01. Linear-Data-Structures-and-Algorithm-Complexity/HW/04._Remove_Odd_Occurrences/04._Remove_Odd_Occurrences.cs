using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._Remove_Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            // Soliton 01
            var occurences = numbers
                .Where(n => numbers.Count(e => e == n) % 2 == 0)
                .ToList();

            Console.WriteLine(string.Join(" ", occurences));

            // Solution 02
            var occurences2 = new Dictionary<int, int>();
            foreach (var num in numbers)
            {
                if (!occurences2.ContainsKey(num))
                {
                    occurences2[num] = 1;
                }
                else
                {
                    occurences2[num] += 1;
                }
            }
            Console.WriteLine(string.Join(" ", numbers.Where(n => occurences2[n] % 2 == 0)));
        }
    }
}
