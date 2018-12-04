using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Parallelepiped
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/501#4
            int n = int.Parse(Console.ReadLine());

            int width = n * 3 + 1;
            int height = 4 * n + 4;
            int length = 2 * n + 1;

            int rightDots = length;
            int leftDots = 0;

            Console.WriteLine('+' + new string('~', width - rightDots - 2) + '+' + new string('.', rightDots));
            rightDots--;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine('|' + new string('.', leftDots) + '\\' + new string('~', width - rightDots - leftDots - 3) + '\\' + new string('.', rightDots));
                rightDots--;
                leftDots++;
            }

            leftDots--;
            rightDots++;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(new string('.', rightDots) + '\\' + new string('.', leftDots) + '|' + new string('~', width - leftDots - rightDots - 3) + '|');
                rightDots++;
                leftDots--;
            }

            leftDots++;

            Console.WriteLine(new string('.', rightDots) + new string('.', leftDots) + '+' + new string('~', width - leftDots - rightDots - 2) + '+');

        }
    }
}
