using System;
using System.Collections.Generic;
using System.Dynamic;

namespace _6._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsPerGreenLight = int.Parse(Console.ReadLine());
            
            var carsQueue = new Queue<string>();
            var carsThatPassedTotal = 0;

            var command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "green")
                {
                    var carsThatCanPass = Math.Min(carsQueue.Count, carsPerGreenLight);

                    for (int counter = 0; counter < carsThatCanPass; counter++)
                    {
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                        carsThatPassedTotal++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{carsThatPassedTotal} cars passed the crossroads.");
        }
    }
}