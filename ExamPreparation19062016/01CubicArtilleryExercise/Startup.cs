namespace _01CubicArtilleryExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static int maximumCapacity;

        public static void Main()
        {
            maximumCapacity = int.Parse(Console.ReadLine());

            var bunkers = new Queue<KeyValuePair<string, Queue<int>>>();

            string input;

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var inputTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in inputTokens)
                {
                    int weaponCapacity;
                    if (!int.TryParse(item, out weaponCapacity))
                    {
                        bunkers.Enqueue(new KeyValuePair<string, Queue<int>>(item, new Queue<int>()));
                    }
                    else
                    {
                        if (bunkers.Count > 0)
                        {
                            TryPutTheWeaponsInBunkers(weaponCapacity, bunkers);
                        }
                    }
                }
            }
        }

        private static void TryPutTheWeaponsInBunkers(int weaponCapacity, Queue<KeyValuePair<string, Queue<int>>> bunkers)
        {
            var firstBunker = bunkers.Peek();

            if (maximumCapacity - firstBunker.Value.Sum() >= weaponCapacity)
            {
                firstBunker.Value.Enqueue(weaponCapacity);
            }
            else
            {
                if (bunkers.Count > 1)
                {
                    firstBunker = bunkers.Dequeue();
                    if (firstBunker.Value.Count > 0)
                    {
                        Console.WriteLine($"{firstBunker.Key} -> {string.Join(", ", firstBunker.Value)}");
                    }
                    else
                    {
                        Console.WriteLine($"{firstBunker.Key} -> Empty");
                    }

                    while (bunkers.Count > 1)
                    {
                        var bunker = bunkers.Peek();

                        if (maximumCapacity - bunker.Value.Sum() >= weaponCapacity)
                        {
                            bunker.Value.Enqueue(weaponCapacity);
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{bunkers.Dequeue().Key} -> Empty");
                        }
                    }
                }
                if (bunkers.Count == 1)
                {
                    var bunker = bunkers.Peek().Value;
                    if (weaponCapacity <= maximumCapacity)
                    {
                        while (bunker.Sum() > weaponCapacity)
                        {
                            bunker.Dequeue();
                        }
                        bunker.Enqueue(weaponCapacity);
                    }
                }
            }
        }
    }
}
