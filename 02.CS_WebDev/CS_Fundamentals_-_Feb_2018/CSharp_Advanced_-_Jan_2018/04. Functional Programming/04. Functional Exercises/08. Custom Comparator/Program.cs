using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, MyCompare);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int MyCompare(int x, int y)
        {
            Func<int, int> reminder = n => Math.Abs(n % 2);

            int result = reminder(x) != reminder(y)
                ? reminder(x).CompareTo(reminder(y))
                : x.CompareTo(y);

            return result;
        }
    }
}
