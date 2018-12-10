﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._Count_of_Occurrences
{
    class Program
    {
        private const string Message = "{0} -> {1} times";

        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var uniqueNumbers = numbers
                .Distinct()
                .OrderBy(n => n)
                .ToList();

            var builder = new StringBuilder();

            foreach (var number in uniqueNumbers)
            {
                builder.AppendLine(string.Format(
                    Message,
                    number,
                    numbers.Count(n => n == number)));
            }
            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
