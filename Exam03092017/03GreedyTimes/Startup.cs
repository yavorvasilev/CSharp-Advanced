
namespace _03GreedyTimes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Startup
    {
        public static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            long currentCapacity = 0;
            long goldCapacity = 0;
            long gemCapacity = 0;
            long cashCapacity = 0;

            var bag = new Dictionary<string, Dictionary<string, long>>() { };

            var inputTreasure = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputTreasure.Length; i += 2)
            {
                var element = inputTreasure[i];

                var value = int.Parse(inputTreasure[i + 1]);

                currentCapacity = goldCapacity + gemCapacity + cashCapacity;

                if (element == "Gold") // possible bug "gold"
                {
                    if (currentCapacity + value <= bagCapacity)
                    {
                        if (!bag.ContainsKey("Gold"))
                        {
                            bag["Gold"] = new Dictionary<string, long>();
                            bag["Gold"]["Gold"] = 0;
                        }
                        bag["Gold"]["Gold"] += value;
                        goldCapacity += value;
                    }
                }
                if (element.Length >= 4 && (element.EndsWith("gem") || element.EndsWith("Gem")))
                {
                    //var sumOfGold = bag["Gold"].Values.Sum();
                    //var sumOfGem = bag["Gem"].Values.Sum();

                    if (gemCapacity + value <= goldCapacity && currentCapacity + value <= bagCapacity)
                    {
                        if (!bag.ContainsKey("Gem"))
                        {
                            bag["Gem"] = new Dictionary<string, long>();
                        }

                        if (!bag["Gem"].ContainsKey(element))
                        {
                            bag["Gem"][element] = 0;
                        }
                        bag["Gem"][element] += value;
                        gemCapacity += value;
                    }
                }
                if (element.Length == 3)
                {
                    //var sumOfGem = bag["Gem"].Values.Sum();
                    //var sumOfCash = bag["Cash"].Values.Sum();

                    if (cashCapacity + value <= gemCapacity && currentCapacity + value <= bagCapacity)
                    {
                        if (!bag.ContainsKey("Cash"))
                        {
                            bag["Cash"] = new Dictionary<string, long>();
                        }

                        if (!bag["Cash"].ContainsKey(element))
                        {
                            bag["Cash"][element] = 0;
                        }
                        bag["Cash"][element] += value;
                        cashCapacity += value;
                    }
                }
            }

            foreach (var treasures in bag)
            {
                Console.WriteLine($"<{treasures.Key}> ${treasures.Value.Values.Sum()}");
                foreach (var type in treasures.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{type.Key} - {type.Value}");
                }
            }
        }
    }
}
