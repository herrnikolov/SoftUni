using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../text.txt"))
            {
                using (var writer = new StreamWriter("../output-text.txt"))
                {
                    int lineNumber = 1;
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {lineNumber}: {currentLine}");

                        lineNumber++;
                    }
                }
            }
        }
    }
}
