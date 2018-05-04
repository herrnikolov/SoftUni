using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Choose_a_Drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());

            switch (profession)
            {
                case "Athlete":
                    Console.WriteLine("The {0} has to pay {1:F2}.", profession, (quantity * 0.70));
                    break;
                case "Businessman":
                case "Businesswoman":
                    Console.WriteLine("The {0} has to pay {1:F2}.", profession, (quantity * 1.00));
                    break;
                case "SoftUni Student":
                    Console.WriteLine("The {0} has to pay {1:F2}.", profession, (quantity * 1.70));
                    break;
                default:
                    Console.WriteLine("The {0} has to pay {1:F2}.", profession, (quantity * 1.20));
                    break;
            }
        }
    }
}
