using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberCount = int.Parse(Console.ReadLine());

            var smallestNum = int.MaxValue;

            for (int i = 0; i < numberCount; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (number < smallestNum)
                {
                    smallestNum = number;
                }

            }

            Console.WriteLine(smallestNum);
        }
    }
}
