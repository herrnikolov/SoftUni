using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var sum = 0;
            var currentNum = 0;

            for (int i = 1; i <= number; i++)
            {
                currentNum = i;

                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }

                var special = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{currentNum} -> {special}");

                sum = 0;
                i = currentNum;
            }
        }
    }
}
