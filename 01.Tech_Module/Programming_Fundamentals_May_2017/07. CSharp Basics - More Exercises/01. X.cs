﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.X
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', i), new string(' ', n - (2 + i * 2)));
            }

            Console.WriteLine("{0}x{0}", new string(' ', n / 2));

            for (int i = n / 2; i > 0; i--)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', i - 1), new string(' ', n - 2 * i));
            }
        }
    }
}
