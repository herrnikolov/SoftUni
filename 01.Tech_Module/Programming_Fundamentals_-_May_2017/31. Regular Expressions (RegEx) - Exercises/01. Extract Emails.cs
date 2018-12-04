﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\s([A-Za-z0-9]+[\-\._]?[A-Za-z0-9]+@[a-z]+[\.\-?][a-z\.\-]+[a-z]+)";

            Regex extractEmail = new Regex(pattern);

            string inputText = Console.ReadLine();

            var matchedEmails = extractEmail.Matches(inputText);

            foreach (Match email in matchedEmails)
            {
                Console.WriteLine(email.Groups[1].Value.Trim().ToString());
            }
        }
    }
}