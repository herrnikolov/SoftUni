using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/359#5

            var from = int.Parse(Console.ReadLine());
            var to = int.Parse(Console.ReadLine());
            var count = int.Parse(Console.ReadLine());

            var counter = 0;

            var mustBreak = false;

            for (int i = from; i <= to; i++)
            {
                for (int j = from; j <= to; j++)
                {
                    Console.Write("<{0}-{1}>",i,j);
                    counter++;
                    if (counter == count)
                    {
                        mustBreak = true;
                        break;
                    }
                }
                if (mustBreak)
                {
                    break;
                }
            }
        }
    }
}
