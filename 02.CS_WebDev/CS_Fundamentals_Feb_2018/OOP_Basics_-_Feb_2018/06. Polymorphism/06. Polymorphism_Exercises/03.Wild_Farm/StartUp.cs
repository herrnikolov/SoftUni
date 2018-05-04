﻿using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var allAnimals = new List<Animal>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            try
            {
                var animalArgs = inputLine.Split();

                var animalType = animalArgs.First();
                var animalParams = animalArgs.Skip(1).ToArray();

                Animal animal = null;

                switch (animalType)
                {
                    case "Tiger":
                    case "Cat":
                        if (animalType == "Cat")
                        {
                            animal = new Cat(animalParams[0], double.Parse(animalParams[1]), animalParams[2], animalParams[3]);
                        }
                        else
                        {
                            animal = new Tiger(animalParams[0], double.Parse(animalParams[1]), animalParams[2], animalParams[3]);
                        }
                        break;
                    case "Owl":
                    case "Hen":

                        if (animalType == "Owl")
                        {
                            animal = new Owl(animalParams[0], double.Parse(animalParams[1]), double.Parse(animalParams[2]));
                        }
                        else
                        {
                            animal = new Hen(animalParams[0], double.Parse(animalParams[1]), double.Parse(animalParams[2]));
                        }
                        break;
                    case "Mouse":
                    case "Dog":
                        if (animalType == "Dog")
                        {
                            animal = new Dog(animalParams[0], double.Parse(animalParams[1]), animalParams[2]);
                        }
                        else
                        {
                            animal = new Mouse(animalParams[0], double.Parse(animalParams[1]), animalParams[2]);
                        }
                        break;
                    default:
                        break;
                }

                var foodArgs = Console.ReadLine().Split();
                var foodType = foodArgs.First();
                var foodQty = int.Parse(foodArgs.Last());

                allAnimals.Add(animal);

                Food food = null;

                switch (foodType)
                {
                    case "Fruit":
                        food = new Fruit(foodQty);
                        break;
                    case "Meat":
                        food = new Meat(foodQty);
                        break;
                    case "Seeds":
                        food = new Seeds(foodQty);
                        break;
                    case "Vegetable":
                        food = new Vegetable(foodQty);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(animal.ProduceSound());
                animal.Eat(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        allAnimals.ForEach(a => Console.WriteLine(a));

    }
}