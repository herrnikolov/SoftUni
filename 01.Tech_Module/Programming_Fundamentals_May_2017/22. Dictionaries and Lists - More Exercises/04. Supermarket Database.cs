using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Supermarket_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, decimal[]>();

            var line = Console.ReadLine();

            while (!line.Equals("stocked"))
            {
                var productData = line.Split();

                var productName = productData[0];
                var productPrice = decimal.Parse(productData[1]);
                var productQuantity = decimal.Parse(productData[2]);

                if (!products.ContainsKey(productName))
                {
                    products[productName] = new decimal[2];
                }

                products[productName][0] = productPrice;
                products[productName][1] += productQuantity;

                line = Console.ReadLine();
            }

            var grandTotalPrice = 0m;

            foreach (var kvp in products)
            {
                var name = kvp.Key;
                var price = kvp.Value[0];
                var quantity = kvp.Value[1];

                var totalPrice = price * quantity;

                Console.WriteLine($"{name}: ${price:F2} * {quantity} = ${totalPrice:F2}");

                grandTotalPrice += totalPrice;
            }

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Grand Total: ${grandTotalPrice:F2}");
        }
    }
}
