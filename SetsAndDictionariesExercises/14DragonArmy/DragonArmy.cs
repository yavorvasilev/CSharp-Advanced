namespace _14DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DragonArmy
    {
        public static void Main()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, decimal[]>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var type = tokens[0];
                var name = tokens[1];

                var demage = 0m;
                if (tokens[2] != "null")
                {
                    demage = decimal.Parse(tokens[2]);
                }
                else
                {
                    demage = 45;
                }

                var health = 0m;
                if (tokens[3] != "null")
                {
                    health = decimal.Parse(tokens[3]);
                }
                else
                {
                    health = 250;
                }

                var armor = 0m;
                if (tokens[4] != "null")
                {
                    armor = decimal.Parse(tokens[4]);
                }
                else
                {
                    armor = 10;
                }


                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new SortedDictionary<string, decimal[]>();
                }

                dragons[type][name] = new decimal[] { demage, health, armor };
            }

            foreach (var type in dragons)
            {
                var typeName = type.Key;
                var dragonsByType = type.Value;

                var averageDemage = dragonsByType.Values.Average(a => a[0]);
                var averageHealth = dragonsByType.Values.Average(a => a[1]);
                var averageArmot = dragonsByType.Values.Average(a => a[2]);

                Console.WriteLine($"{typeName}::({averageDemage:F2}/{averageHealth:F2}/{averageArmot:F2})");

                foreach (var dragon in dragonsByType)
                {
                    var name = dragon.Key;
                    var stats = dragon.Value;
                    var damage = stats[0];
                    var health = stats[1];
                    var armor = stats[2];

                    Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}
