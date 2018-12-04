using System;
using System.Numerics;

namespace _03.Big_Factorial  

{
    public class Big_Factorial
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger nFactorial = 1;
            for (int i = 2; i <= n; i++)
                nFactorial *= i;
            Console.WriteLine(nFactorial);
        }
    }
}