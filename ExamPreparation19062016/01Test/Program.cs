namespace _01CubicArtillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CubicArtillery
    {
        private static int capacityOfBunker;
        private static int maxCapacity;
        private static int weapon;
        public static void Main()
        {
            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();

            maxCapacity = int.Parse(Console.ReadLine());
            capacityOfBunker = maxCapacity;

            var line = Console.ReadLine();

            while (line != "Bunker Revision")
            {
                var tokens = line.Split();

                for (int i = 0; i < tokens.Length; i++)
                {
                    weapon = -1;
                    var isBunker = int.TryParse(tokens[i], out weapon);
                    if (!isBunker)
                    {
                        bunkers.Enqueue(tokens[i]);
                    }
                    else
                    {
                        if (TryFitWeaponInBunker(weapons))
                        {
                            continue;
                        }
                        else if (bunkers.Count > 1)
                        {
                            PrintLastBunker(bunkers, weapons);
                        }
                    }
                }

                line = Console.ReadLine();
            }
        }

        private static void PrintLastBunker(Queue<string> bunkers, Queue<int> weapons)
        {
            if (weapons.Count > 0)
            {
                Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");
                weapons.Clear();
                capacityOfBunker = maxCapacity;
                var a = TryFitWeaponInBunker(weapons);
            }
            else
            {
                Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
            }
        }

        private static bool TryFitWeaponInBunker(Queue<int> weapons)
        {
            if (capacityOfBunker >= weapon && weapon != -1)
            {
                weapons.Enqueue(weapon);
                capacityOfBunker -= weapon;
                return true;
            }
            else if (capacityOfBunker == 0)
            {
                return false;
            }
            else
            {
                if (weapons.Count > 0 && weapon < maxCapacity)
                {
                    while (capacityOfBunker < weapon)
                    {
                        capacityOfBunker += weapons.Dequeue();
                    }
                    weapons.Enqueue(weapon);
                    capacityOfBunker -= weapon;
                    return true;
                }
                else
                {
                    weapon = -1;
                    return false;
                }
                
            }
        }
    }
}
