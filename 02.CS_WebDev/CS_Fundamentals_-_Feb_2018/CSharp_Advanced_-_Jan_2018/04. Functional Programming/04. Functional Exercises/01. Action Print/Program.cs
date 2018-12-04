using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> PrintSequenceOnNewLines =
                s => Console.WriteLine(s.Replace(" ", Environment.NewLine));

            PrintSequenceOnNewLines(Console.ReadLine());
        }
    }
}
