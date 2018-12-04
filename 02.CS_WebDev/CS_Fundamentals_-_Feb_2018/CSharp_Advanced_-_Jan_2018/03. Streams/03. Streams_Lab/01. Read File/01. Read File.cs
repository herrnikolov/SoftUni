using System;
using System.IO;

namespace _01._Read_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("01. Read File.cs"))
            {
                var lineNumber = 1;

                string line;

                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine($"Line {lineNumber}: "+ line);
                    lineNumber++;
                }
            }
        }
    }
}
