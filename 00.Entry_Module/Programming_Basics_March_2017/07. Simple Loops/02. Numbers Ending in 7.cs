using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Numbers_Ending_in_7
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int number = 0; number < 1000; number++)
            {
                if (number % 10 == 7)
                {
                    Console.WriteLine(number);
                }
            }   
        
        }
    }
}
