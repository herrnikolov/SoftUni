using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Two_Numbers_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/499#0

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = start; i >= end; i--)
            {
                for (int j = start; j >= end; j--)
                {
                    counter++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine("Combination N:{0} ({1} + {2} = {3})", counter, i, j, magicNumber);
                        return;
                    }
                }
            }
            Console.WriteLine("{0} combinations - neither equals {1}", counter, magicNumber);
        }
    }
}
