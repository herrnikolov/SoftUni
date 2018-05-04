using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Dragon_Army
{
    public static void Main()
    {
        var pattern = @"(?<type>[a-zA-Z]*)\s*(?<name>[a-zA-Z]*)\s*(?<damage>(\d+)|(null))\s*(?<health>(\d+)|(null))\s*(?<armor>(\d+)|(null))";

        var dragons = new Dictionary<string, SortedDictionary<string, int[]>>();

        var dragonsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < dragonsCount; i++)
        {
            var dragonData = Console.ReadLine();

            var match = Regex.Match(dragonData, pattern);

            if (match.Success)
            {
                var dragonType = match.Groups["type"].Value;
                var dragonName = match.Groups["name"].Value;

                var dragonDamage = 0;
                var dragonHealth = 0;
                var dragonArmor = 0;

                dragonDamage = match.Groups["damage"].Value == "null" ? 45 : int.Parse(match.Groups["damage"].Value);
                dragonHealth = match.Groups["health"].Value == "null" ? 250 : int.Parse(match.Groups["health"].Value);
                dragonArmor = match.Groups["armor"].Value == "null" ? 10 : int.Parse(match.Groups["armor"].Value);


                if (!dragons.ContainsKey(dragonType))
                {
                    dragons[dragonType] = new SortedDictionary<string, int[]>();
                }

                if (!dragons[dragonType].ContainsKey(dragonName))
                {
                    dragons[dragonType][dragonName] = new int[]
                    {
                        dragonDamage,
                        dragonHealth,
                        dragonArmor
                    };
                }

                dragons[dragonType][dragonName][0] = dragonDamage;
                dragons[dragonType][dragonName][1] = dragonHealth;
                dragons[dragonType][dragonName][2] = dragonArmor;
            }
        }

        foreach (var types in dragons)
        {
            var Type = types.Key;

            var averageDamage = types.Value.Select(x => x.Value[0]).Average();
            var averageHealth = types.Value.Select(x => x.Value[1]).Average();
            var averageArmor = types.Value.Select(x => x.Value[2]).Average();

            Console.WriteLine($"{Type}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

            foreach (var dragonsNames in types.Value)
            {
                var Name = dragonsNames.Key;

                var damage = dragonsNames.Value[0];
                var health = dragonsNames.Value[1];
                var armor = dragonsNames.Value[2];

                Console.WriteLine($"-{Name} -> damage: {damage}, health: {health}, armor: {armor}");
            }
        }
    }
}