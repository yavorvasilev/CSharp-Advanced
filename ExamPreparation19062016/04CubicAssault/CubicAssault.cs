namespace _04CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicAssault
    {
        public static void Main()
        {
            var regionsAndMeteors = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input != "Count em all")
            {
                var tokens = input.Split(new string[] { " -> " },StringSplitOptions.RemoveEmptyEntries);
                var region = tokens[0];
                var typeOfMeteor = tokens[1];
                var count = long.Parse(tokens[2]);

                CountStatistic(region, typeOfMeteor, count, regionsAndMeteors);


                input = Console.ReadLine();
            }
            PrintTheRegions(regionsAndMeteors);
        }

        private static void PrintTheRegions(Dictionary<string, Dictionary<string, long>> regionsAndMeteors)
        {
            foreach (var region in regionsAndMeteors.OrderByDescending(x => x.Value["Black"]).ThenBy(reg => reg.Key.Length).ThenBy(reg => reg.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var meteor in region.Value.OrderByDescending(count => count.Value).ThenBy(meteor => meteor.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }

        private static void CountStatistic(string region, string typeOfMeteor, long count, Dictionary<string, Dictionary<string, long>> regionsAndMeteors)
        {
            if (!regionsAndMeteors.ContainsKey(region))
            {
                regionsAndMeteors[region] = new Dictionary<string, long>();
                regionsAndMeteors[region]["Green"] = 0;
                regionsAndMeteors[region]["Red"] = 0;
                regionsAndMeteors[region]["Black"] = 0;
            }

            regionsAndMeteors[region][typeOfMeteor] += count;

            CombineMeteors(region, regionsAndMeteors);
        }

        private static void CombineMeteors(string region, Dictionary<string, Dictionary<string, long>> regionsAndMeteors)
        {
            if (regionsAndMeteors[region]["Green"] >= 1000000)
            {
                var remainder = regionsAndMeteors[region]["Green"] % 1000000;
                var newCount = regionsAndMeteors[region]["Green"] / 1000000;

                regionsAndMeteors[region]["Red"] += newCount;
                regionsAndMeteors[region]["Green"] = remainder;
            }

            if (regionsAndMeteors[region]["Red"] >= 1000000)
            {
                var remainder = regionsAndMeteors[region]["Red"] % 1000000;
                var newCount = regionsAndMeteors[region]["Red"] / 1000000;

                regionsAndMeteors[region]["Black"] += newCount;
                regionsAndMeteors[region]["Red"] = remainder;
            }
        }
    }
}
