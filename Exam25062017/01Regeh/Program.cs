using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();
            var pattern = @"\[[^\s\[\]]+<(\d+REGEH\d+)>[^\s\[\]]+\]";
            var listOfIndexes = new List<int>();

            if (Regex.IsMatch(inputLine, pattern))
            {
                var tokens = Regex.Matches(inputLine, pattern);
                foreach (Match regex in tokens)
                {
                    var match = regex.Groups[1].Value;
                    var numbers = match.Split(new[] { "REGEH" },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    var resulIndexes = listOfIndexes.Concat(numbers);
                    listOfIndexes = resulIndexes.ToList();
                }
            }
            var sumIndex = 0;
            foreach (var index in listOfIndexes)
            {
                sumIndex += index;
                if (sumIndex >= inputLine.Length)
                {
                    //while (sumIndex >= inputLine.Length)
                    //{
                    //    sumIndex = sumIndex / inputLine.Length + 1;
                    //}
                    sumIndex = (sumIndex % inputLine.Length) - 1;
                    if (sumIndex == -1)
                    {
                        sumIndex = inputLine.Length - 1;
                    }
                    Console.Write(inputLine[sumIndex]);
                }
                else
                {
                    Console.Write(inputLine[sumIndex]);
                }
            }
        }
    }
}
