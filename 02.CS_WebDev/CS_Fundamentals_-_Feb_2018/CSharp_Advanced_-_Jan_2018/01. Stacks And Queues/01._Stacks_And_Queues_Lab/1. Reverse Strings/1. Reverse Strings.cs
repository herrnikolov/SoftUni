using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            //var stack = new Stack<char>();

            //foreach (var character in input)
            //{
            //    stack.Push(character);
            //}

            var stack = new Stack<char>(input.ToCharArray());

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop().ToString());
            }

            Console.WriteLine();

            //Console.ReadKey();
        }
    }
}
