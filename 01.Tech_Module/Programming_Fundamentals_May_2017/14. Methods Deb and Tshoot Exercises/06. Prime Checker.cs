using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = long.Parse(Console.ReadLine());

            var isPrime = IsPrime(num);

            Console.WriteLine(isPrime);
        }
        private static bool IsPrime(long num)
        {
            if (num == 0 || num == 1)
            {
                return false;
            }
            if (num == 2)
            {
                return true;
            }
            var maxNum = Math.Sqrt(num);
            for (int currentNum = 2; currentNum <= maxNum; currentNum++)
            {
                if (num % currentNum == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
