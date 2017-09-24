namespace _05ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"([a-zA-Z0-9_\.\-]+)@([a-zA-Z0-9_\-]+)((\.([a-zA-Z0-9_]){2,})+)");

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var matchString = match.ToString();

                if (!(matchString.StartsWith("-") || matchString.StartsWith(".") || matchString.StartsWith("_")))
                {
                    Console.Write(match);
                    Console.WriteLine();
                }

            }
        }
    }
}
