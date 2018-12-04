using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var Phonebook = new Dictionary<string, string>();

            var line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                var tokens = line.Split().ToArray();

                if (tokens[0].Equals("A"))
                {
                    var name = tokens[1];
                    var phoneNumber = tokens[2];

                    if (!Phonebook.ContainsKey(name))
                    {
                        Phonebook[name] = string.Empty;
                    }

                    Phonebook[name] = phoneNumber;
                }
                else
                {
                    var name = tokens[1];

                    if (Phonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {Phonebook[name]}");
                    }

                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }

                line = Console.ReadLine();
            }
        }
    }
}
