namespace _04ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"\d+");

            var matches = regex.Matches(input);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
