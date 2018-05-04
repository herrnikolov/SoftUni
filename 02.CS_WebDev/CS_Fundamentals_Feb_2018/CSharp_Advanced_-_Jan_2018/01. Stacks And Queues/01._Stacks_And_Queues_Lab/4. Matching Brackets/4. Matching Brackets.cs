using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stackOpenBracketIndexes = new Stack<int>();
            for (int counter = 0; counter < input.Length; counter++)
            {
                if (input[counter] == '(')
                {
                    stackOpenBracketIndexes.Push(counter);
                }

                if (input[counter] == ')')
                {
                    var openBracketIndex = stackOpenBracketIndexes.Pop();
                    var length = counter - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, length));
                }
            }
        }
    }
}
