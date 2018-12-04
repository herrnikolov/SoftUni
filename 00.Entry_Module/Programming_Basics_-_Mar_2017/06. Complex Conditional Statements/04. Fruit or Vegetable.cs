using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruitorvegitable = Console.ReadLine();

            if (fruitorvegitable == "banana" ||
                fruitorvegitable == "apple" ||
                fruitorvegitable == "kiwi" ||
                fruitorvegitable == "cherry" ||
                fruitorvegitable == "lemon" ||
                fruitorvegitable == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (fruitorvegitable == "tomato" ||
                    fruitorvegitable == "cucumber" ||
                    fruitorvegitable == "pepper" ||
                    fruitorvegitable == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }

        }
    }
}
