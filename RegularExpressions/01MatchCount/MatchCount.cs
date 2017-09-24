namespace _01MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchCount
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();
            var input = Console.ReadLine();

            var regex = new Regex(pattern);
            var match = regex.Matches(input);

            Console.WriteLine(match.Count);
        }
    }
}
