namespace _08ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractQuotations
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex("('|\")(.+?)\\1");

            var matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                Console.WriteLine(item.Groups[2].Value);
            }
        }
    }
}
