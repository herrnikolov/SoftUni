using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Magic_exchangeable_words
{
    class Program
    {
        static void Main(string[] args)
        {
            var letters = new Dictionary<char, char>();

            var strings = Console.ReadLine()
                .Split();

            var firstString = strings[0];
            var secondString = strings[1];

            var minLength = Math.Min(firstString.Length, secondString.Length);

            var isExchangeable = IsExchangeable(firstString, secondString, minLength, letters)
                .ToString()
                .ToLower();

            Console.WriteLine(isExchangeable);
        }
        private static bool IsExchangeable(string firstString, string secondString, int minLength, Dictionary<char, char> letters)
        {
            var IsExchangeable = true;

            for (int i = 0; i < minLength; i++)
            {
                var firstStringLetter = firstString[i];
                var secondStringLetter = secondString[i];

                if (!letters.ContainsKey(firstStringLetter))
                {
                    if (letters.ContainsValue(secondStringLetter))
                    {
                        IsExchangeable = false;
                        break;
                    }

                    letters[firstStringLetter] = secondStringLetter;
                }

                else if (letters[firstStringLetter] != secondStringLetter)
                {
                    IsExchangeable = false;
                }
            }

            if (firstString.Length != secondString.Length)
            {
                var longestString = firstString.Length > secondString.Length ? firstString : secondString;

                var remainingLetters = longestString
                    .Substring(Math.Min(firstString.Length, secondString.Length));

                foreach (char letter in remainingLetters)
                {
                    if (!letters.ContainsKey(letter) && !letters.ContainsValue(letter))
                    {
                        IsExchangeable = false;
                    }
                }
            }

            return IsExchangeable;
        }
    }
}
