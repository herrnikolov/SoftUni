using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());

            var combinations = 0;
            var sum = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    var number = (i * j) * 3;                    
                    sum += number;
                    combinations++;

                    if (sum >= max)
                    {
                        Console.WriteLine($"{combinations} combinations");
                        Console.WriteLine($"Sum: {sum} >= {max}");

                        return;
                    }
                }
            }

            Console.WriteLine($"{combinations} combinations");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
