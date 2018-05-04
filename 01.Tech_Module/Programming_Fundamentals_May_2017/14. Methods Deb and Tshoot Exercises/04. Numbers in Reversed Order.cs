using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = decimal.Parse(Console.ReadLine());

            var reversedNum = ReverseNumDigits(num);

            Console.WriteLine(reversedNum);
        }

        private static decimal ReverseNumDigits(decimal num)
        {

//            var numToString = new string(num.ToString().Reverse().ToArray());
            var numToString = num.ToString();

            var result = string.Empty;

            for (int i = numToString.Length - 1; i >= 0; i--)
            {
                result += numToString[i];
            }

            //return decimal.Parse(numToString);
            return decimal.Parse(result);
        }
    }
}
