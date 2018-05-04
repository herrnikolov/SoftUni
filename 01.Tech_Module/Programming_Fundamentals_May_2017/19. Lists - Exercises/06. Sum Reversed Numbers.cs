using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Split().Select(a => int.Parse(new string(a.Reverse().ToArray()))).Sum());

            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                var currentNum = arr[i];
                var currentNumToStr = currentNum.ToString();
                var reversedArray = currentNumToStr.Reverse().ToArray();
                var reversedNum = new string(reversedArray);
                arr[i] = int.Parse(reversedNum);
            }
            Console.WriteLine(arr.Sum());
        }
    }
}
