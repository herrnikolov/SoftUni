using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Hello__Name_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GreetingGenerator(Console.ReadLine()));
        }

        static string GreetingGenerator(string name)
        {
            string greeting = $"Hello, {name}!";
            return greeting;
        }
    }
}
