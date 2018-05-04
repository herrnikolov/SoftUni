using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Speed_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());


            if (num > 1000)
            {
                Console.WriteLine("extremely fast");
            }
            else if ((num > 150) && (num <= 1000))
            {
                Console.WriteLine("ultra fast");
            }
            else if ((num > 50) && (num <= 150))
            {
                Console.WriteLine("fast");
            }
            else if ((num > 10) && (num <= 50))
            {
                Console.WriteLine("average");
            }
            else if (num <= 10)
            {
                Console.WriteLine("slow");
            }


        }
    }
}
