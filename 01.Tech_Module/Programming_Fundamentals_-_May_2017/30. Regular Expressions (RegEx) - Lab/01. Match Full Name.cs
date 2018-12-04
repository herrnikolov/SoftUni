using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _06.Replace_a_Tag
{

    public class MatchFullName
    {
        public static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]+ [A-Z]{1}[a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection matchedNames = Regex.Matches(names, regex);
            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }
            Console.WriteLine();

        }
    }
}