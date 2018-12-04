using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("radians = ");
            var radians = double.Parse(Console.ReadLine());
            var degreess = Math.Round(radians / (Math.PI / 180.0));
            Console.Write("degrees = ");
            Console.WriteLine(degreess);
        }
    }
}
