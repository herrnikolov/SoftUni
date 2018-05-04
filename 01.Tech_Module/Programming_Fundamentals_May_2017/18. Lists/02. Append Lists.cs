using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var resultList = new List<string>();

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                var num = numbers[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                resultList.AddRange(num);
            }

            foreach (var number in resultList)
            {
                Console.Write(" " + number);
            }
            Console.WriteLine();
        }
    }
}
