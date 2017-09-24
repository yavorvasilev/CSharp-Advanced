namespace _01ArrangeIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArrangeIntegers
    {
        public static void Main()
        {
            var digitWord = new Dictionary<char, string>()
            {
                { '0', "zero"},
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" }
            };

            var allDigitWord = new Dictionary<string, List<string>>();
            var input = Console.ReadLine()
                .Split(new[] { ", " },StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var number in input)
            {
                if (number.Length > 1)
                {
                    for (int i = 0; i < number.Length; i++)
                    {
                        if (i == number.Length - 1)
                        {
                            var ch = number[i];
                            sb.Append(digitWord[ch]);
                        }
                        else
                        {
                            var ch = number[i];
                            sb.Append(digitWord[ch] + "-");
                        }
                    }
                    var word = string.Join("", sb);
                    if (!allDigitWord.ContainsKey(word))
                    {
                        allDigitWord[word] = new List<string>();
                    }
                    allDigitWord[word].Add(number);
                    sb.Clear();
                }
                else
                {
                    var word = digitWord[Char.Parse(number)];
                    if (!allDigitWord.ContainsKey(word))
                    {
                        allDigitWord[word] = new List<string>();
                    }
                    allDigitWord[word].Add(number);
                }
            }
            Console.WriteLine();
            var orderedNumber = new List<string>();
            foreach (var digitInWord in allDigitWord.OrderBy(x => x.Key))
            {
                foreach (var number in digitInWord.Value)
                {
                    orderedNumber.Add(number);
                }
            }

            Console.WriteLine(string.Join(", ", orderedNumber));
           
      
        }
    }
}
