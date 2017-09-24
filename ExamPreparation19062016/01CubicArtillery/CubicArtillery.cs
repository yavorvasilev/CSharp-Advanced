namespace _01CubicArtillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicArtillery
    {
        private static int capacityOfBunker;
        private static int maxCapacity;
        private static int weapon;
        private static bool isSaved;
        public static void Main()
        {
            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();

            maxCapacity = int.Parse(Console.ReadLine());
            capacityOfBunker = maxCapacity;

            var line = Console.ReadLine();

            while (line != "Bunker Revision")
            {
                var tokens = line.Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int i = 0; i < tokens.Length; i++)
                {
                    isSaved = false;
                    var isBunker = int.TryParse(tokens[i], out weapon);
                    if (!isBunker)
                    {
                        bunkers.Enqueue(tokens[i]);
                    }
                    else
                    {
                        while (bunkers.Count > 1)
                        {
                            if (TryFitWeaponInBunker(weapons))
                            {
                                break;
                            }
                            else
                            {
                                PrintLastBunker(bunkers, weapons);
                            }
                        }
                        if (!isSaved)
                        {
                            CanYouFitWeaponInLastBunker(weapons);
                        }
                    }
                }
                line = Console.ReadLine();
            }
        }

        private static void CanYouFitWeaponInLastBunker(Queue<int> weapons)
        {
            if (weapon <= maxCapacity)
            {
                while (capacityOfBunker < weapon)
                {
                    capacityOfBunker += weapons.Dequeue();
                }
                weapons.Enqueue(weapon);
                capacityOfBunker -= weapon;
            }
        }

        private static void PrintLastBunker(Queue<string> bunkers, Queue<int> weapons)
        {
            if (weapons.Count > 0)
            {
                Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");
                weapons.Clear();
                capacityOfBunker = maxCapacity;
            }
            else
            {
                Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
            }
        }

        private static bool TryFitWeaponInBunker(Queue<int> weapons)
        {
            if (capacityOfBunker >= weapon)
            {
                weapons.Enqueue(weapon);
                capacityOfBunker -= weapon;
                isSaved = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
