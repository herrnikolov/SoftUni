using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine().ToLower();
            var town = Console.ReadLine().ToLower();
            var quantitiy = double.Parse(Console.ReadLine());

            if (town == "sofia")
            {
                if (product == "coffee") Console.WriteLine(0.50 * quantitiy);
                else if (product == "water") Console.WriteLine(0.80 * quantitiy);
                else if (product == "beer") Console.WriteLine(1.20 * quantitiy);
                else if (product == "sweets") Console.WriteLine(1.45 * quantitiy);
                else if (product == "peanuts") Console.WriteLine(1.60 * quantitiy);
            }
            if (town == "plovdiv")
            {
                if (product == "coffee") Console.WriteLine(0.40 * quantitiy);
                else if (product == "water") Console.WriteLine(0.70 * quantitiy);
                else if (product == "beer") Console.WriteLine(1.15 * quantitiy);
                else if (product == "sweets") Console.WriteLine(1.30 * quantitiy);
                else if (product == "peanuts") Console.WriteLine(1.50 * quantitiy);
            }
            if (town == "varna")
            {
                if (product == "coffee") Console.WriteLine(0.45 * quantitiy);
                else if (product == "water") Console.WriteLine(0.70 * quantitiy);
                else if (product == "beer") Console.WriteLine(1.10 * quantitiy);
                else if (product == "sweets") Console.WriteLine(1.35 * quantitiy);
                else if (product == "peanuts") Console.WriteLine(1.55 * quantitiy);
            }
        }
    }
}
