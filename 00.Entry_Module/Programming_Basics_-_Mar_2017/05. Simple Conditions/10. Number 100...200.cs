﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Number_100._._._200
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());

            if (num >= 200)
            {
                Console.WriteLine("Greater than 200");
            }
            if ((num >= 100) && (num <= 200))
            {
                Console.WriteLine("Between 100 and 200");
            }
            if (num <= 100)
            {
                Console.WriteLine("Less than 100");
            }
        }
    }
}
