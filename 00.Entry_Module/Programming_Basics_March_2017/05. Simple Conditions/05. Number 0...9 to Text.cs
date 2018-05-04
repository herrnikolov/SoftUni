using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Number_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine("zero");
            }
            else if (number == 1)
            {
                Console.Write("one");
            }
            else if (number == 2)
            {
                Console.Write("two");
            }
            else if (number == 3)
            {
                Console.Write("three");
            }
            else if (number == 4)
            {
                Console.Write("four");
            }
            else if (number == 5)
            {
                Console.Write("five");
            }
            else if (number == 6)
            {
                Console.Write("six");
            }
            else if (number == 7)
            {
                Console.Write("seven");
            }
            else if (number == 8)
            {
                Console.Write("eigh");
            }
            else if (number == 9)
            {
                Console.Write("nine");
            }
            else
            {
                Console.WriteLine("number too big");
            }
        }
    }
}
