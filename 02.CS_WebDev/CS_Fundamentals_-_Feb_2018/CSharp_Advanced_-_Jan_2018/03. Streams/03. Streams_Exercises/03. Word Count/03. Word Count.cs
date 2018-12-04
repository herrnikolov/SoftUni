using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsToCount = new HashSet<string>();

            var wordsByCount = new Dictionary<string, int>();

            using (var reader = new StreamReader("../words.txt"))
            {
                string currentWord;
                while ((currentWord = reader.ReadLine()) != null)
                {
                    wordsToCount.Add(currentWord.ToLower());
                }
            }

            using (var streamReader = new StreamReader("../text.txt"))
            {
                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    var matches = Regex.Matches(currentLine, "[A-Za-z']+");

                    foreach (Match match in matches)
                    {
                        string currentWord = match.Value.ToLower();

                        if (wordsToCount.Contains(currentWord))
                        {
                            if (!wordsByCount.ContainsKey(currentWord))
                            {
                                wordsByCount[currentWord] = 0;
                            }
                            wordsByCount[currentWord]++;
                        }
                    }
                }
            }

            using (var streamWriter = new StreamWriter("../results.txt"))
            {
                foreach (var word in wordsByCount.OrderByDescending(w => w.Value))
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
