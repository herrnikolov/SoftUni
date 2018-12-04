using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringInput = Console.ReadLine();

            var unicodeCharacterLiterals = stringInput
                .Select(x => $"\\u{(int)(x):x4}")
                .ToList();

            Console.WriteLine(string.Join("", unicodeCharacterLiterals));
        }
    }
}
