using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(n);

            var numbers = new List<long>();
            numbers.Add(n);

            while (numbers.Count < 50)
            {
                for (long i = 0; i < 3; i++)
                {
                    var currentNumber = queue.Dequeue();
                    var sumOne = currentNumber + 1;
                    var sumTwo = 2 * currentNumber + 1;
                    var sumThree = currentNumber + 2;

                    numbers.Add(sumOne);
                    numbers.Add(sumTwo);
                    numbers.Add(sumThree);

                    queue.Enqueue(sumOne);
                    queue.Enqueue(sumTwo);
                    queue.Enqueue(sumThree);
                }
            }

            var result = numbers.Take(50);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
