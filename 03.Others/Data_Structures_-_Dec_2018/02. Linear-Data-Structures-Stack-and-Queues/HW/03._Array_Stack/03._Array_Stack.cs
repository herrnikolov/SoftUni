using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._Array_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new ArrayStack<int>();

            for (int i = 1; i < 20; i++)
            {
                stack.Push(i);
                Console.WriteLine(stack.Peek());
            }
            Console.WriteLine("================");

            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine($"Count {stack.Count}");
            Console.WriteLine("================");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Removed {stack.Pop()}");

                Console.WriteLine(string.Join(", ", stack.ToArray()));
                Console.WriteLine($"Count {stack.Count}");
                Console.WriteLine("================");
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
