using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var magicNum = int.Parse(Console.ReadLine());

            var validNumOne = 0;
            var validNumTwo = 0;
            var killSwitch = false;
            var counterCombinations = 0;

            for (int i = n; i <= m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    if (i + j == magicNum)
                    {
                        validNumOne = i;
                        validNumTwo = j;
                        killSwitch = true;
                    }
                    counterCombinations++;
                }
            }
            
            if (killSwitch)
            {
                Console.WriteLine($"Number found! {validNumOne} + {validNumTwo} = {magicNum}");
            }
            else
            {
                Console.WriteLine($"{counterCombinations} combinations - neither equals {magicNum}");
            }
        }
    }
}
