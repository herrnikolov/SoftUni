using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            var Phonebook = new SortedDictionary<string, string>();

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

                else if (tokens[0].Equals("S"))
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

                else
                {
                    foreach (var contact in Phonebook)
                    {
                        var contactName = contact.Key;
                        var contactPhoneNumber = contact.Value;

                        Console.WriteLine($"{contactName} -> {contactPhoneNumber}");
                    }
                }

                line = Console.ReadLine();
            }
        }
    }
}
