using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal USD = decimal.Parse(Console.ReadLine()) * 1.79549M;
            // decimal BGN = decimal.Parse(Console.ReadLine());

            Console.WriteLine("{0} BGN", Math.Round(USD, 2));
        }
    }
}
