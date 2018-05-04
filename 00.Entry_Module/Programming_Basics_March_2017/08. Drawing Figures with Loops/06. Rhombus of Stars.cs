using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());

            //var hight = n * 2 - 1; 
            //var width = n * 2 - 1;

            ////upper part
            //for (int i = 1; i <= n; i++)
            //{
            //    var line = new string(' ', n - i);

            //    for (int j = 1; j <= i; j++)
            //    {
            //        line += "*";
            //        line += " ";
            //    }

            //    Console.WriteLine(line);
            //}
            //// lower part
            //for (int i = 0; i < n - 1; i++)
            //{
            //    var line = new string(' ', i + 1) + "*";

            //    for (int j = n - (2 + i); j > 0; j--)
            //    {
            //        line += " ";
            //        line += "*";
            //    }

            //    Console.WriteLine(line);
            //}

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                var line = new string(' ', n - i) + "*";
                for (int j = 1; j < i; j++)
                {
                    line += " *";
                }
                Console.WriteLine(line);
            }

            for (int i = n - 1; i > 0; i--)
            {
                var line = new string(' ', n - i) + "* ";
                for (int j = 1; j < i; j++)
                {
                    line += "* ";
                }
                Console.WriteLine(line);
            }



            //var text = magixString("* ", 5);
            //Console.WriteLine(text);

            //public static string magicString(string text, int repeatCount)
            //{
            //    string outputText = "";

            //    for (int i = 0; i < repeatCount; i++)
            //    {
            //        outputText = outputText + text;
            //    }

            //    return outputText
            //}

        }
    }
}
