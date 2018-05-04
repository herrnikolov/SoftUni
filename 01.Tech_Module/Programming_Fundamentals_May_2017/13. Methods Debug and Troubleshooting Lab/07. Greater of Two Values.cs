using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {

            var type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    GetGreaterInt();
                    break;

                case "string":
                    GetGreaterString();
                    break;

                case "char":
                    GetGreaterChar();
                    break;
            }
        }

        private static void GetGreaterChar()
        {
            var greaterChar = '\0';

            var firstChar = char.Parse(Console.ReadLine());
            var secondChar = char.Parse(Console.ReadLine());

            if (firstChar > secondChar)
                greaterChar = firstChar;

            else
                greaterChar = secondChar;

            Console.WriteLine(greaterChar);
        }

        private static void GetGreaterString()
        {
            var firstString = Console.ReadLine();
            var secondString = Console.ReadLine();

            var greaterString = string.Empty;

            if (firstString.CompareTo(secondString) >= 0)
                greaterString = firstString;

            else
                greaterString = secondString;

            Console.WriteLine(greaterString);
        }

        private static void GetGreaterInt()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            var greaterNumber = Math.Max(firstNumber, secondNumber);

            Console.WriteLine(greaterNumber);
        }
    }
}