using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            var digit = double.Parse(Console.ReadLine());
            if (digit % 2 ==0)
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }
        }
    }
}
