using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyMaterials = new Dictionary<string, int>();

            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            var junkItems = new SortedDictionary<string, int>();

            var hasObtained = false;

            while (!hasObtained)
            {
                var command = Console.ReadLine()
                    .ToLower()
                    .Split();

                for (int i = 0; i < command.Length; i += 2)
                {
                    var quantity = int.Parse(command[i]);
                    var material = command[i + 1];

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials.Values.Any(x => x >= 250))
                        {
                            keyMaterials[material] -= 250;

                            var obtainedItem = string.Empty;

                            switch (material)
                            {
                                case "shards":
                                    obtainedItem = "Shadowmourne";
                                    break;

                                case "fragments":
                                    obtainedItem = "Valanyr";
                                    break;

                                case "motes":
                                    obtainedItem = "Dragonwrath";
                                    break;
                            }

                            hasObtained = true;

                            Console.WriteLine($"{obtainedItem} obtained!");

                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(material))
                        {
                            junkItems.Add(material, 0);
                        }

                        junkItems[material] += quantity;
                    }
                }
            }

            var remainingShards = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            foreach (var kvp in remainingShards)
            {
                var material = kvp.Key;
                var quantity = kvp.Value;

                Console.WriteLine($"{material}: {quantity}");
            }

            foreach (var kvp in junkItems)
            {
                var material = kvp.Key;
                var quantity = kvp.Value;

                Console.WriteLine($"{material}: {quantity}");
            }
        }
    }
}
