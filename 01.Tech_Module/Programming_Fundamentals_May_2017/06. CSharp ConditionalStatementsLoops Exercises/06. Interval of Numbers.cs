using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNum = int.Parse(Console.ReadLine());
            var secondNum = int.Parse(Console.ReadLine());

            var startingNum = Math.Min(firstNum, secondNum);
            var ednignNum = Math.Max(firstNum, secondNum);

            for (int i = startingNum; i <= ednignNum; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
