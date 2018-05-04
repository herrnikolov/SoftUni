using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            var startNum = int.Parse(Console.ReadLine());
            var endNum = int.Parse(Console.ReadLine());

            var primes = FindPrimesInRange(startNum, endNum);



            Console.WriteLine(string.Join(", ", primes));
        }

        private static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            var primes = new List<int>();

            for (int currentNum = startNum; currentNum <= endNum; currentNum++)
            {
                if (IsPrime(currentNum))
                {
                    primes.Add(currentNum);
                }
            }
            return primes;
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
