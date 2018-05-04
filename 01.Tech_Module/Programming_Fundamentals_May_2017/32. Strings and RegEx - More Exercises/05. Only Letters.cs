using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.Only_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            Regex findSequence = new Regex(@"(\d+)([A-Za-z])");

            var matchedSequences = findSequence.Matches(message);

            foreach (Match sequence in matchedSequences)
            {
                message = Regex.Replace(
                    message,
                    sequence.Groups[1].Value.ToString(),
                    sequence.Groups[2].Value.ToString()
                );
            };


            Console.WriteLine(message);
        }
    }
}
