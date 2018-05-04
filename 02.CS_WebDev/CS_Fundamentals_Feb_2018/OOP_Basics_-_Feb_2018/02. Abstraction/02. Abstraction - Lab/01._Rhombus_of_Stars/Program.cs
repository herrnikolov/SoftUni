using System;

namespace _01._Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            PrintRow(size);
        }

        private static void PrintRow(int size)
        {
            int rows = 2 * size - 1;

             for (int row = 1; row <= size; row++)
            {
                var currentRow = new string(' ', size - row);
                for (int i = 1; i <= row; i++)
                {
                    currentRow += "* ";
                }
                Console.WriteLine(currentRow);
            }

            for (int downRow = size - 1; downRow >= 1; downRow--)
            {
                var currentRow = new string(' ', size - downRow);
                for (int i = 0; i < downRow; i++)
                {
                    currentRow += "* ";
                }
                Console.WriteLine(currentRow);
            }
        }
    }
}
