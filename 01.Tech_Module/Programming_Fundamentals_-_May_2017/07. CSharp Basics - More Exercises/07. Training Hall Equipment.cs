using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Training_Hall_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            var numOfItems = int.Parse(Console.ReadLine());

            double subTotal = 0.0;

            for (int i = 0; i < numOfItems; i++)
            {
                var itemName = Console.ReadLine();
                var itemPrice = double.Parse(Console.ReadLine());
                var itemCount = int.Parse(Console.ReadLine());

                var itemCost = itemPrice * itemCount;

                if (itemCount > 1)
                {
                    itemName += "s";
                }

                Console.WriteLine($"Adding {itemCount} {itemName} to cart.");
                subTotal += itemCost;
            }

            var transactionalBudget = budget - subTotal;

            Console.WriteLine($"Subtotal: ${subTotal:F2}");

            if (transactionalBudget >= 0)
            {
                Console.WriteLine($"Money left: ${transactionalBudget:F2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${Math.Abs(transactionalBudget):F2} more.");
            }
        }
    }
}
