using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace _5._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split(' ');
            var toss = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(children);

            while (queue.Count!=1)
            {
                for (int tossCounter = 1; tossCounter < toss; tossCounter++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
