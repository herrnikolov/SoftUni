using System;
using System.IO;

namespace _02._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("../text.txt"))
            {
                var lineCounter = 0;

                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    if (lineCounter % 2 != 0)
                    {
                        Console.WriteLine(currentLine);
                    }

                    lineCounter++;
                }
            }
        }
    }
}
