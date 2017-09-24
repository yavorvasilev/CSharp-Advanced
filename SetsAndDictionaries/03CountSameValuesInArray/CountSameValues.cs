namespace _03CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValues
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var dictionaryOfNumbers = new SortedDictionary<double, int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                double token;
                if (inputNumbers[i].Contains(","))
                {
                    token = double.Parse(inputNumbers[i].Replace(",", "."));
                }
                else
                {
                    token = double.Parse(inputNumbers[i]);
                }
                


                if (!dictionaryOfNumbers.ContainsKey(token))
                {
                    dictionaryOfNumbers[token] = 0;
                }
                dictionaryOfNumbers[token] += 1;
            }

            foreach (var item in dictionaryOfNumbers)
            {
                if (item.Key.ToString().Contains("."))
                {
                    var remainder = item.Key.ToString().Replace(".", ",");
                    Console.WriteLine($"{item.Key} - {item.Value} times");
                }
                else
                {
                    Console.WriteLine($"{item.Key} - {item.Value} times");
                }
            }
        }
    }
}
