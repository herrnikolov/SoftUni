using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;

            while (true)
            {
                var input = Console.ReadLine();
                var num = 0;

                var verifyNum = int.TryParse(input, out num);

                if (verifyNum)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
