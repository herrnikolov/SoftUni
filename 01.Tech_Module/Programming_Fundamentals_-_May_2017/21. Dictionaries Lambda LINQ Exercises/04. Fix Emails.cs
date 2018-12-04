using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesEmails = new Dictionary<string, string>();
            var line = Console.ReadLine();

            while (line != "stop")
            {
                var name = line;
                var email = Console.ReadLine();

                namesEmails[name] = email;

                line = Console.ReadLine();
            }
            var fixedEmails = namesEmails.Where(kvp => !(kvp.Value.EndsWith("uk") || kvp.Value.EndsWith("us"))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var nameEmail in fixedEmails)
            {
                var name = nameEmail.Key;
                var email = nameEmail.Value;

                Console.WriteLine($"{name} -> {email}");
            }

            
        }
    }
}
