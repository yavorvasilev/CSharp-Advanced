namespace _09QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class QueryMess
    {
        public static void Main()
        {
            var keyValueDictionary = new Dictionary<string, List<string>>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                input = Regex.Replace(input, @"%20|\+", " ");
                input = Regex.Replace(input, @"\s+", " ");
                var pattern = new Regex(@"[^&?]+");
                var validFragmentPattern = new Regex(@"(.*?)=(.*)");

                var keyValueFragment = pattern.Matches(input);

                foreach (var item in keyValueFragment)
                {
                    var keyValuePair = validFragmentPattern.Match(item.ToString());
                    if (keyValuePair.Success)
                    {
                        var key = keyValuePair.Groups[1].Value.Trim();
                        var value = keyValuePair.Groups[2].Value.Trim();

                        if (!keyValueDictionary.ContainsKey(key))
                        {
                            keyValueDictionary[key] = new List<string>();
                        }
                        keyValueDictionary[key].Add(value);
                    }
                }
                foreach (var key in keyValueDictionary)
                {
                    Console.Write($"{key.Key}=[{string.Join(", ",key.Value)}]");
                }
                Console.WriteLine();

                keyValueDictionary.Clear();

                input = Console.ReadLine();
            }
        }
    }
}
