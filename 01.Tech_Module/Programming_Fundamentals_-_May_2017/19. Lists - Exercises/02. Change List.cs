using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

            var line = Console.ReadLine();

            while (!line.Equals("Even") && !line.Equals("Odd"))
            {
                var command = line.Split();

                if (command[0].Equals("Delete"))
                {
                    var element = int.Parse(command[1]);

                    numbers = numbers.Where(x => x != element).ToList();
                }

                else if (command[0].Equals("Insert"))
                {
                    var element = int.Parse(command[1]);
                    var position = int.Parse(command[2]);

                    numbers.Insert(position, element);
                }

                line = Console.ReadLine();
            }

            if (line.Equals("Even"))
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0).ToList()));
            }

            else
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0).ToList()));
            }
        }
    }
}
