using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Debit_Card_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var int1 = int.Parse(Console.ReadLine());
            var int2 = int.Parse(Console.ReadLine());
            var int3 = int.Parse(Console.ReadLine());
            var int4 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{int1:D4} {int2:D4} {int3:D4} {int4:D4}");
        }
    }
}
