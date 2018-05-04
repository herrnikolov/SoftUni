using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstWord = Console.ReadLine();
            var secondWord = Console.ReadLine();

            firstWord = firstWord.ToLower();
            secondWord = secondWord.ToLower();

            if (firstWord == secondWord)
            {
                Console.WriteLine("yes");
            }
            else if (firstWord != secondWord)
            {
                Console.WriteLine("no");
            }

        }
    }
}
