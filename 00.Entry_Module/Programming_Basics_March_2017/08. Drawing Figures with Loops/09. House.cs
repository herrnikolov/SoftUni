using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.House
{
    class Program
    {
        static void Main(string[] args)
        {
        int n = int.Parse(Console.ReadLine());

        int roofHeight = (n + 1) / 2;

        Console.WriteLine("{0}{1}{0}", new string('.', n /2), new string('*', 1));
        for (int i = 0; i < (n / 2) - 1; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i + j == (n / 2) - 1 || i - j == - (n / 2) - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
                
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('*', n));
        int length = n - (n / 2) - 2;
        for (int i = 0; i < length; i++)
        {
            Console.Write(new string('.', n / 4));
            Console.Write("*");
            Console.Write(new string('.', n - (2 * (n/ 4) + 2)));
            Console.Write("*");
            Console.WriteLine(new string('.', n / 4));
        }
        Console.WriteLine("{0}{1}{0}", new string('.', n / 4), new string('*', n - (2 * (n / 4))));

        }
    }
}
