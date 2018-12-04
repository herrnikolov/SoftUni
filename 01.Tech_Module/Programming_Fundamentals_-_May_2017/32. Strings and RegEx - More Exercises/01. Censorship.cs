using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Censorship
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToReplace = Console.ReadLine();
            string text = Console.ReadLine();

            text = Regex.Replace(text, wordToReplace, new string('*', wordToReplace.Length));

            Console.WriteLine(text);
        }
    }
}
