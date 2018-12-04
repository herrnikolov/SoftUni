using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Christmas_Hat
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://judge.softuni.bg/Contests/368/Programming-Basics-Exam-18-December-2016
            //https://judge.softuni.bg/Contests/Practice/Index/368#4
            //https://softuni.bg/trainings/resources/video/13332/video-screen-11-march-2017-hristo-hentov-csharp-programming-basics-january-2017
            //https://softuni.bg/trainings/resources/video/13326/video-screen-11-march-2017-anton-petrov-csharp-programming-basics-january-2017

            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('.', n * 2 - 1) + "/|\\" + new string('.', n * 2 - 1));
            Console.WriteLine(new string('.', n * 2 - 1) + "\\|/" + new string('.', n * 2 - 1));
            var dotCount = n * 2 - 1;
            var dashCount = 0;
            for (int i = 0; i < n * 2; i++)
            {

                Console.WriteLine(new string('.', dotCount) + "*" + new string('-', dashCount) + "*" + new string('-', dashCount) + "*" + new string('.', dotCount));
                dotCount--;
                dashCount++;
            }
            Console.WriteLine(new string('*', 4 * n + 1));
            for (int i = 0; i < n * 2; i++)
            {
                Console.Write("*");
                if (i != n * 2)
                {
                    Console.Write(".");
                }
                if (i == n * 2 - 1)
                {
                    Console.WriteLine("*");
                }

            }
            Console.WriteLine(new string('*', 4 * n + 1));
        }


    }
 }
