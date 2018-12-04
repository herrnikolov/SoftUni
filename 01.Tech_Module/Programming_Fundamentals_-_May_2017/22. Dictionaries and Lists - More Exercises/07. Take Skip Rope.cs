using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedMessage = Console.ReadLine();

            var numbers = encryptedMessage
                .Where(s => char.IsDigit(s))
                .Select(s => int.Parse(s.ToString()))
                .ToList();

            var nonNumbers = encryptedMessage
                .Where(s => !char.IsDigit(s))
                .ToList();

            var takeList = numbers
                .Where((d, i) => i % 2 == 0)
                .ToList();

            var skipList = numbers
                .Where((d, i) => i % 2 != 0)
                .ToList();

            var decryptedMessage = new StringBuilder();

            var totalSkipCount = 0;

            for (int i = 0; i < skipList.Count; i++)
            {
                var skipCount = skipList[i];
                var takeCount = takeList[i];

                var currentDecryptedPart = new string(nonNumbers.Skip(totalSkipCount).Take(takeCount).ToArray());

                decryptedMessage.Append(currentDecryptedPart);

                totalSkipCount += (skipCount + takeCount);
            }

            Console.WriteLine(decryptedMessage.ToString());
        }
    }
}
