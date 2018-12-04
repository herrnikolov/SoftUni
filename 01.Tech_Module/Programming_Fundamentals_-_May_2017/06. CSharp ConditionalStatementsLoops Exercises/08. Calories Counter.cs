using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Calories_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var numOfIngredients = int.Parse(Console.ReadLine());

            var calories = 0;

            for (int i = 0; i < numOfIngredients; i++)
            {
                var ingredient = Console.ReadLine().ToLower();

                switch (ingredient)
                {
                    case "cheese":
                        calories += 500;
                        break;
                    case "tomato sauce":
                        calories += 150;
                        break;
                    case "salami":
                        calories += 600;
                        break;
                    case "pepper":
                        calories += 50;
                        break;                        
                }
            }
            Console.WriteLine($"Total calories: {calories}");
        }
    }
}
