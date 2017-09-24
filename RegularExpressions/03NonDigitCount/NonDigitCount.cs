namespace _03NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    public class NonDigitCount
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"\D");

            var match = regex.Matches(input);

            Console.WriteLine($"Non-digits: {match.Count}");
        }
    }
}
