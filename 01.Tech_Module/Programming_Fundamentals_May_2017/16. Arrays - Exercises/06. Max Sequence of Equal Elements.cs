using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            var startIndex = 0;                      
            var sequenceLength = 1;

            var bestStartIndex = 0;
            var bestSequenceLength = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    sequenceLength++;

                    if (sequenceLength > bestSequenceLength)
                    {
                        bestStartIndex = startIndex;
                        bestSequenceLength = sequenceLength;                        
                    }
                }
                else
                {
                    startIndex = i;
                    sequenceLength = 1;
                }
            }
            for (int i = bestStartIndex; i < bestStartIndex + bestSequenceLength; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

        }
    }
}