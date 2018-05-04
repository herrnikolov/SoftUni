using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:(?<bracket>{)|\[)[^0-9]*(?<digits>\d*)[^0-9]*(?(bracket)}|\])";

            int count = int.Parse(Console.ReadLine());

            StringBuilder builder = new StringBuilder();
            for (int counter = 0; counter < count; counter++)
            {
                builder.Append(Console.ReadLine());
            }
            var input = builder.ToString();

            MatchCollection matches = Regex.Matches(input, pattern);


        }
    }
}