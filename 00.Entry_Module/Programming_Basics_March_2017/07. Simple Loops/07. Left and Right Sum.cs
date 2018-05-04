using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());
            //var repeatCount = n * 2;

            //var leftSum = 0;
            //var rightSum = 0;

            //for (int i = 0; i < repeatCount; i++)
            //{
            //    var number = int.Parse(Console.ReadLine());
            //    leftSum += number;
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    var number = int.Parse(Console.ReadLine());
            //    rightSum += number;
            //}

            //if (leftSum == rightSum)
            //{
            //    Console.WriteLine("Yes, sum = {0}", leftSum);
            //}
            //else
            //{
            //    Console.WriteLine("No, diff = {0}", Math.Abs(leftSum - rightSum));
            //}


            //var n = int.Parse(Console.ReadLine());

            //var leftSum = 0;
            //var rightSum = 0;

            //for (var i = 0; i < n; i++)
            //{
            //    leftSum = leftSum + int.Parse(Console.ReadLine());
            //}         
            //for (int i = 0; i < n; i++)
            //{
            //    rightSum = rightSum + int.Parse(Console.ReadLine());
            //}
            //if (leftSum == rightSum){
            //    Console.WriteLine("Yes, sum = " + leftSum);
            //    }
            //else{
            //    Console.WriteLine("No, diff = " + Math.Abs(rightSum - leftSum));
            //    }

            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < 2 * n; i++)
            {
                if (i < n)
                {
                    int currentNumber = int.Parse(Console.ReadLine());
                    leftSum = leftSum + currentNumber;
                }
                else
                {
                    int currentNumber = int.Parse(Console.ReadLine());
                    rightSum = rightSum + currentNumber;
                }
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine("Yes, sum = {0}", leftSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}", Math.Abs(leftSum - rightSum));
            }


        }
    }
}
