using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace _00._Linq_to_Object_Pref_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 100_000_000);
            var timer = System.Diagnostics.Stopwatch.StartNew();
            //var filtered = numbers
            //    .Where(n => n % 1 == 0) // 100 mil
            //    .Where(n => n % 2 == 0) // 100 mil
            //    .Where(n => n % 3 == 0) // 50 mil
            //    .Where(n => n % 5 == 0) // 20 mil
            //    .Where(n => n % 7 == 0)
            //    .ToList();
            // 1 - 7 268 Mil cycles 
            // reverse 116 Mil cycles
            //below  
            var filtered = numbers
                .Where(n => n % 1 == 0 && n % 2 == 0 && n % 3 == 0 && n % 5 == 0 && n % 7 == 0)
                .ToList();                          

            Console.WriteLine(filtered.Count);
            Console.WriteLine(timer.Elapsed);
        }
    }
}
