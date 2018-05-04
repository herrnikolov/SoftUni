using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Match_Hexadecimal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\b(?:0x)?[0-9A-F]+\b";
            var numbersString = Console.ReadLine();
            var numbers = Regex.Matches(numbersString, regex)
                .Cast<Match>()
                .Select(a => a.Value)
                .ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
