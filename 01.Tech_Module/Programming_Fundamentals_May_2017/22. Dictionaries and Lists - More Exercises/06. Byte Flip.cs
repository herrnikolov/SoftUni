using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Byte_Flip
{
    class Program
    {
        static void Main(string[] args)
        {
            var hexaDecimalBytes = Console.ReadLine()
                        .Split()
                        .Where(x => x.Length == 2)
                        .Reverse()
                        .ToList();

            for (int i = 0; i < hexaDecimalBytes.Count(); i++)
            {
                var reversedHexaDecimalByte = new string(hexaDecimalBytes[i]
                    .ToCharArray()
                    .Reverse()
                    .ToArray());

                var convertedHexaDecimalByte = (char)Int16.Parse(reversedHexaDecimalByte, NumberStyles.AllowHexSpecifier);

                hexaDecimalBytes[i] = convertedHexaDecimalByte.ToString();
            }

            Console.WriteLine(string.Join("", hexaDecimalBytes));
        }
    }
}
