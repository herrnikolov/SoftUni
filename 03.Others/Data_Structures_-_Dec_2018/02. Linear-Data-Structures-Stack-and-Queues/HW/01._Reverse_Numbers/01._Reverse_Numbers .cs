using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var numbersStack = new Stack<int>(numbers);

            if (numbersStack.Count > 0)
            {
                Console.WriteLine(string.Join(" ", numbersStack));
            }
        }
    }
}
