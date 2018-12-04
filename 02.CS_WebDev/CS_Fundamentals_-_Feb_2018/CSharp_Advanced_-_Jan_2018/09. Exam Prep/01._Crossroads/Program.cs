using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            string input;

            Queue<string> lines = new Queue<string>();

            int totalCarsPassed = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    lines.Enqueue(input);
                    continue;
                }
                int currentGreenLight = greenLightDuration;
                string passingCar = null;

                while (currentGreenLight > 0 && lines.Any())
                {
                    passingCar = lines.Dequeue();
                    currentGreenLight -= passingCar.Length;
                    totalCarsPassed++;
                }

                int freeWindowsLeft = freeWindowDuration + currentGreenLight;
                if (freeWindowsLeft < 0)
                {
                    int charsLeft = Math.Abs(freeWindowsLeft);
                    int indexOfHitChar = passingCar.Length - charsLeft;
                    char symbolHit = passingCar[indexOfHitChar];

                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{passingCar} was hit at {symbolHit}.");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
