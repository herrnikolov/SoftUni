using System;
using System.Numerics;

public class Number_Checker
{
    public static void Main()
    {
        var number = Console.ReadLine();

        BigInteger integerNumber = 0;
        var isInteger = BigInteger.TryParse(number, out integerNumber);

        if (isInteger)
        {
            Console.WriteLine("integer");
        }

        else
        {
            Console.WriteLine("floating-point");
        }
    }
}