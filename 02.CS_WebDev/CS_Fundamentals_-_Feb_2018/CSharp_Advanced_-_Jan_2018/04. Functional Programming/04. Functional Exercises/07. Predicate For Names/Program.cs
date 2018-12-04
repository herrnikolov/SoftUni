using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxNameLength = int.Parse(Console.ReadLine());

            Predicate<string> nameFilter = s => s.Length <= maxNameLength;

            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => nameFilter(n));

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
