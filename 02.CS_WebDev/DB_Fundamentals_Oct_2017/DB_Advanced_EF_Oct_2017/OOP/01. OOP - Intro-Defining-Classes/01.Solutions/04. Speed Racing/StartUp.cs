using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    static void Main()
    {
        var count = int.Parse(Console.ReadLine());

        var cars = new List<Car>();

        for (int i = 0; i < count; i++)
        {
            var input = Console.ReadLine().Split();
            var model = input[0];
            var fuel = double.Parse(input[1]);
            var consumption = double.Parse(input[2]);

            if (!cars.Any(c => c.Model == model))
            {
                var newCar = new Car(model, fuel, consumption);
                cars.Add(newCar);
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var args = command.Split();
            var model = args[1];
            var distance = double.Parse(args[2]);

            Car car = cars.Find(c => c.Model == model);
            bool isMoved = car.Move(distance);
            if (!isMoved)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }

        foreach (var c in cars)
        {
            Console.WriteLine($"{c.Model} {c.Fuel:F2} {c.DistanceTravelled}");
        }
    }
}
