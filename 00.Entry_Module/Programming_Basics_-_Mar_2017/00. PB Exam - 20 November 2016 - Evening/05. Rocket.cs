using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/359#4
                    
            var n = int.Parse(Console.ReadLine());
            
            var outerDots = ((3 * n) - 2) / 2;
            var innerSpaces = 0;

            //first part
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', outerDots), new string(' ',innerSpaces));
                innerSpaces += 2;
                outerDots--;                
            }
            //second part
            outerDots = n / 2;
            innerSpaces = (3 * n) - n;
            Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', innerSpaces));
            //third part
            for (int i = 0; i < 2 * n; i++)
            {
                Console.WriteLine("{0}|{1}|{0}", new string('.', outerDots), new string('\\', innerSpaces - 2));
            }
            //fourth part
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', outerDots -i), new string('*', innerSpaces - 2));
                innerSpaces += 2;
            }
        }
    }
}
