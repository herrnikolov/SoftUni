using System;
using System.Dynamic;
using System.Linq;

namespace _3._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            var sizes = new int[3];

            foreach (var number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }

            int[][] JaggedArray = new int[3][];

            for (int counter = 0; counter < sizes.Length; counter++)
            {
                JaggedArray[counter] = new int[sizes[counter]];
            }

            int[] index = new int[3];
            foreach (var number in numbers)
            {
                var remainder = Math.Abs(number % 3);
                JaggedArray[remainder] [index[remainder]] = number;
                index[remainder]++;
            }

            for (int rows = 0; rows < JaggedArray.Length; rows++)
            {
                for (int columns = 0; columns < JaggedArray[rows].Length; columns++)
                {
                    Console.Write(JaggedArray[rows][columns] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
