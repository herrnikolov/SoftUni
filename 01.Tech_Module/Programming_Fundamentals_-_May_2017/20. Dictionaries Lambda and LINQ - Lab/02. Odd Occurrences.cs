using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().ToLower().Split().ToArray();
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict[word] = 1;
                }
            }
            
            bool fist = true;
            foreach (var p in dict)
            {
                if (p.Value % 2 == 1)
                {
                    if (!fist) Console.Write(", ");
                    Console.Write(p.Key);
                    fist = false;
                }
                
            }
            Console.WriteLine();

            // Alternative Pring
            //var output = new List<string>();
            //foreach (var p in dict)
            //{
            //    if (p.Value % 2 == 1)
            //        output.Add(p.Key);
            //}
            //Console.WriteLine(string.Join(", ", output));
        }
    }
}
