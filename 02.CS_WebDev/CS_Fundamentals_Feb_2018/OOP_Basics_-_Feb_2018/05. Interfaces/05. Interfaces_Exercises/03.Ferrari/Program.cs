using System;

class Program
{
    static void Main(string[] args)
    {
        var driverName = Console.ReadLine();

        IDriver driver = new Driver(driverName);

        ICar ferrari = new Ferrari(driver);

        Console.WriteLine(ferrari);
    }
}