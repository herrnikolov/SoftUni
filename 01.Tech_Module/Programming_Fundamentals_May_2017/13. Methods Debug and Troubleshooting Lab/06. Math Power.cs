using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Math_Power
{
    class Program
    {

        static double RaiseToPower(double number, int power)
        {            
            return Math.Pow(number,power);
        }
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            
            var result = RaiseToPower(number, power);

            Console.WriteLine(result);
        }
    }
}
