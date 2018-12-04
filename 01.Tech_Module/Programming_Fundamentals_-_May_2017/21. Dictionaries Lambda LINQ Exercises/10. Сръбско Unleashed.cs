using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _10.Сръбско_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(?<singer>([a-zA-Z]{1,}\s)+)\@(?<venue>([a-zA-Z]{1,}\s)+)(?<ticketsPrice>\d+)\s(?<ticketsCount>\d+)";

            var greekConcerts = new Dictionary<string, Dictionary<string, int>>();

            var line = Console.ReadLine();

            while (!line.Equals("End"))
            {
                var match = Regex.Match(line, pattern);

                if (match.Success)
                {
                    var singer = match.Groups["singer"].Value.TrimEnd();
                    var venue = match.Groups["venue"].Value.TrimEnd();
                    var ticketsPrice = int.Parse(match.Groups["ticketsPrice"].Value);
                    var ticketsCount = int.Parse(match.Groups["ticketsCount"].Value);

                    var profit = ticketsPrice * ticketsCount;

                    if (!greekConcerts.ContainsKey(venue))
                    {
                        greekConcerts[venue] = new Dictionary<string, int>();
                    }

                    if (!greekConcerts[venue].ContainsKey(singer))
                    {
                        greekConcerts[venue][singer] = 0;
                    }

                    greekConcerts[venue][singer] += profit;
                }

                line = Console.ReadLine();
            }

            foreach (var greekConcert in greekConcerts)
            {
                var venue = greekConcert.Key;

                Console.WriteLine($"{venue}");

                foreach (var singers in greekConcert.Value.OrderByDescending(x => x.Value))
                {
                    var singer = singers.Key;
                    var profit = singers.Value;

                    Console.WriteLine($"#  {singer} -> {profit}");
                }
            }
        }
    }
}
