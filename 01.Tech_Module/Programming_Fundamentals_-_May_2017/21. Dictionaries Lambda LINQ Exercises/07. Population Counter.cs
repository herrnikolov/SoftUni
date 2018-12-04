using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var populationCounter = new Dictionary<string, Dictionary<string, long>>();

            var line = Console.ReadLine();

            while (!line.Equals("report"))
            {
                var tokens = line.Split('|');

                var city = tokens[0];
                var country = tokens[1];
                var population = long.Parse(tokens[2]);

                if (!populationCounter.ContainsKey(country))
                {
                    populationCounter[country] = new Dictionary<string, long>();
                }

                if (!populationCounter[country].ContainsKey(city))
                {
                    populationCounter[country][city] = 0L;
                }

                populationCounter[country][city] += population;

                line = Console.ReadLine();
            }

            populationCounter = populationCounter
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in populationCounter)
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
