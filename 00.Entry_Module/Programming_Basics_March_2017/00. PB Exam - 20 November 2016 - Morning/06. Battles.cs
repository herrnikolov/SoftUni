using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Combination
{
    class Program
    {
        static void Main(string[] args)
        {


            var p1Pokemons = int.Parse(Console.ReadLine());
            var p2Pokemons = int.Parse(Console.ReadLine());
            var battles = int.Parse(Console.ReadLine());

            var counter = 0;

            var mustBreak = false;

            for (int i = 1; i <= p1Pokemons; i++)
            {
                for (int j = 1; j <= p2Pokemons; j++)
                {
                    Console.Write("({0} <-> {1}) ", i, j);
                    counter++;
                    if (counter == battles)
                    {
                        mustBreak = true;
                        break;
                    }
                }
                if (mustBreak)
                {
                    break;
                }
            }
        }
    }
}
