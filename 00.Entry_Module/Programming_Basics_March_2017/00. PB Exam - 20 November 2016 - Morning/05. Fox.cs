using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fox
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/354#4
            int n = int.Parse(Console.ReadLine());
            var cols = 2 * n + 3;
            var lines = n * 2 - 1;
            var betweeneyes = n + 1;
            var lines2 = n * 2 - 1;
            for (int i = 1; i <= n; i++)
            {
                if (i == n)
                {
                    Console.WriteLine("{0}\\-/{0}", new string('*', i), new string('*', i));
                }
                else
                {
                    Console.WriteLine("{0}\\{1}/{0}", new string('*', i), new string('-', (lines--) - i + 1), new string('*', i));
                }

            }
            for (int i = 1; i <= n / 3; i++)
            {
                Console.WriteLine("|{0}\\{1}/{0}|", new string('*', n / 2 - 1 + i), new string('*', (betweeneyes--) - i), new string('*', n / 2 - 1 + i));
            }
            for (int j = 1; j <= n; j++)
            {
                Console.WriteLine("{0}\\{1}/{0}", new string('-', j), new string('*', (lines2--) - j + 1), new string('-', j));
            }

        }
    }
}
