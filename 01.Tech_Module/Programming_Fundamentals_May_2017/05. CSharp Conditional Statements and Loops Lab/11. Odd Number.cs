using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Math.Abs(int.Parse(Console.ReadLine()));
            while (true)
            {
                if (num % 2 == 1)
                {
                    break;
                    Console.WriteLine("Please write an odd number.");
                    num = Math.Abs(int.Parse(Console.ReadLine()));

                }
            }
            Console.WriteLine("The number is: {0}", num);
        }
    }
}



//var num = Math.Abs(int.Parse(Console.ReadLine()));
//            while (num % 2 != 1)
//            {                
//                    Console.WriteLine("Please write an odd number.");
//                    num = Math.Abs(int.Parse(Console.ReadLine()));

//            }
//            Console.WriteLine("The number is: {0}", num);
//        }