using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var k = arr.Length / 4;

            var leftArr = new int[k];
            var middleArr = new int[2 * k];
            var rightArr = new int[k];

            var resultArray = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                leftArr[i] = arr[i];
                rightArr[i] = arr[3 * k + i];
            }
            for (int i = 0; i < 2 * k; i++)
            {
                middleArr[i] = arr[k + i];
            }

            Array.Reverse(leftArr);
            Array.Reverse(rightArr);

            for (int i = 0; i <  k; i++)
            {
                resultArray[i] += middleArr[i] + leftArr[i];

                resultArray[i + k] += middleArr[i + k] + rightArr[i];

            }



            Console.WriteLine(string.Join(" ", resultArray));

        }
    }
}
