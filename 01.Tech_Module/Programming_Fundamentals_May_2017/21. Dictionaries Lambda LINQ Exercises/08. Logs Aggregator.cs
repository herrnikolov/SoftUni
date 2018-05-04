using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesIpsDurations = new SortedDictionary<string, SortedDictionary<string, int>>();
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine();
                var tokens = line.Split();
                var name = tokens[1];
                var ip = tokens[0];
                var duration = int.Parse(tokens[2]);

                if (!namesIpsDurations.ContainsKey(name))
                {
                    namesIpsDurations[name] = new SortedDictionary<string, int>();
                }
                if (!namesIpsDurations[name].ContainsKey(ip))
                {
                    namesIpsDurations[name][ip] = 0;
                }

                namesIpsDurations[name][ip] += duration;
            }
            foreach (var nameIpsDurations in namesIpsDurations)
            {
                var name = nameIpsDurations.Key;
                var ipsDurations = nameIpsDurations.Value;


                var totalDuration = ipsDurations.Sum(a => a.Value);
                var ips = ipsDurations.Select(a => a.Key).ToArray();

                Console.WriteLine($"{name}: {totalDuration} [{string.Join(", ", ips)}]");
            }

        }
    }
}
