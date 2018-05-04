using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Christmas_Tree
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var text = magicString("*", 5);
        //    Console.WriteLine(text);
        //}

        //public static string magicString(string text, int repeatCount)
        //{
        //    string outputText = "";

        //    for (int i = 0; i < repeatCount; i++)
        //    {
        //        outputText = outputText + text;
        //    }

        //    return outputText;
        //}

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var rows = n + 1;
            var width = n*2 + 3;

            for (int i = 0; i < rows; i++)
            {
                var row = new string(' ', n - i) + new string('*', i) + " | " + new string('*', i);
                Console.WriteLine(row);
            }

        }


    }
}
