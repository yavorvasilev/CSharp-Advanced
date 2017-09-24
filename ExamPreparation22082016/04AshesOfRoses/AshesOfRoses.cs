namespace _04AshesOfRoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class AshesOfRoses
    {
        public static void Main()
        {
            var icarusRoses = new Dictionary<string, Dictionary<string,long>>();

            var input = Console.ReadLine();

            while (input != "Icarus, Ignite!")
            {
                var tokens = Regex.Match(input, @"\b^Grow\s\<([A-Z][a-z]*)\>\s\<([A-Za-z0-9]+)\>\s([1-9][0-9]*$)");
                if (tokens.Success)
                {
                    var region = tokens.Groups[1].Value;
                    var color = tokens.Groups[2].Value;
                    var count = long.Parse(tokens.Groups[3].Value);
                    CountingRoses(region, color, count, icarusRoses);
                }
                input = Console.ReadLine();
            }

            PrintingRoses(icarusRoses);
        }

        private static void PrintingRoses(Dictionary<string, Dictionary<string, long>> icarusRoses)
        {
            foreach (var region in icarusRoses.OrderByDescending(x => x.Value.Sum(y => y.Value)).ThenBy(r => r.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var color in region.Value.OrderBy(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }
        }

        private static void CountingRoses(string region, string color, long count, Dictionary<string, Dictionary<string, long>> icarusRoses)
        {
            if (!icarusRoses.ContainsKey(region))
            {
                icarusRoses[region] = new Dictionary<string, long>();
            }
            if (!icarusRoses[region].ContainsKey(color))
            {
                icarusRoses[region][color] = 0;
            }
            icarusRoses[region][color] += count;
        }
    }
}
