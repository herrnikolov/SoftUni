    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace _02.Pets
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Programming Basics Exam - 20 November 2016 - Morning
                //https://judge.softuni.bg/Contests/Practice/Index/354#1

                var daysVacantion = int.Parse(Console.ReadLine());
                var foodLeft = int.Parse(Console.ReadLine());
                var dogFoodPerDayInKG = double.Parse(Console.ReadLine());
                var catFoodPerDayInKG = double.Parse(Console.ReadLine());
                var tortuseFoodPerDayInKG = double.Parse(Console.ReadLine())/ 1000;

                var requredFoodForDog = daysVacantion * dogFoodPerDayInKG;
                var requredFoodForCat = daysVacantion * catFoodPerDayInKG;
                var requiredFoodForTortuse = daysVacantion * tortuseFoodPerDayInKG;

                var totalFoodForAllAnimals = requredFoodForDog + requredFoodForCat + requiredFoodForTortuse;
                var foodDifference = Math.Abs(foodLeft - totalFoodForAllAnimals);


                if (foodLeft >= totalFoodForAllAnimals)
                {
                    Console.WriteLine("{0} kilos of food left.",Math.Floor(foodDifference));
                }
                if (foodLeft < totalFoodForAllAnimals)
                {
                    Console.WriteLine("{0} more kilos of food are needed.",Math.Ceiling(foodDifference));
                }

            }
        }
    }
