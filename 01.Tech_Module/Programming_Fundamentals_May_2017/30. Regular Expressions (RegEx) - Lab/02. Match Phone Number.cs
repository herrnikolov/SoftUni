using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace _02.Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //var regex = @"\+359(-| )\d{1}\1\d{3}\1\d{4}\b";
            var regex = @"\+359 2 \d{3} \d{4}\b|\+\d{3}-\d-\d{3}-\d{4}\b";


            var phones = Console.ReadLine();

            var phoneMatches = Regex.Matches(phones, regex);

            var matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
