using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The temperature value in Celsius to Fahrenheit:");
        double fah = double.Parse(Console.ReadLine());

        double CtoF = (fah * 9 ) / 5 +32;
        Console.WriteLine("The Fahrenheit value is {0}: " , CtoF);

    }
}