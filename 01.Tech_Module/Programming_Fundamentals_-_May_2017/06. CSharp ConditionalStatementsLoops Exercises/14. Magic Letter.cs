using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Magic_Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLetter = char.Parse(Console.ReadLine());
            var secondLetter = char.Parse(Console.ReadLine());
            var noGoLetter = char.Parse(Console.ReadLine());

            for (int firstIndex = firstLetter; firstIndex <= secondLetter; firstIndex++)
            {
                for (int secondIndex = firstLetter; secondIndex <= secondLetter; secondIndex++)
                {
                    for (int thirdIndex = firstLetter; thirdIndex <= secondLetter; thirdIndex++)
                    {
                        if (firstIndex != noGoLetter && secondIndex != noGoLetter && thirdIndex != noGoLetter)
                        {
                            Console.Write($"{(char)firstIndex}{(char)secondIndex}{(char)thirdIndex} ");
                        }
                    }
                }
            }




        }
    }
}
