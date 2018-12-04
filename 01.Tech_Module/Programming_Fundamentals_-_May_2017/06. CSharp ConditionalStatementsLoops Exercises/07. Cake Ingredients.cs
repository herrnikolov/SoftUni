using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Cake_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingreadient = Console.ReadLine();

            var ingredientCount = 0;

            while (ingreadient != "Bake!")
            {
                Console.WriteLine($"Adding ingredient {ingreadient}.");
                ingredientCount++;
                ingreadient = Console.ReadLine();
            }

            Console.WriteLine($"Preparing cake with {ingredientCount} ingredients.");
        }
    }
}
