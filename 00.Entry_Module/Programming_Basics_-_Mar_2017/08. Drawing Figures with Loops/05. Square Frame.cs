using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Square_Frame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var row = "+";
            var innterLine = "|";

            for (int i = 1; i <= n -2; i++)
            {
                row = row + " -";
            }
            
            row = row + " +";
            Console.WriteLine(row);

            for (int i = 1; i <= n -2; i++)
            {
                innterLine = innterLine + " -";
            }

            innterLine = innterLine + " |";
            
            for (int i = 1; i <= n - 2; i++)
            {
                Console.WriteLine(innterLine);
            }
            
            Console.WriteLine(row);
        }
    }
}
