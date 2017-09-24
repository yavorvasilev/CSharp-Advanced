namespace _01MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"(([A-Z])\w+) (([A-Z])\w+)");

            while (input != "end")
            {
                var match = regex.Match(input);
                if (match.Success)
                {
                    Console.WriteLine(input);
                }
                input = Console.ReadLine();
            }
        }
    }
}
