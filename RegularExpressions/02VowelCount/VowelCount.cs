namespace _02VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class VowelCount
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"[aeiouyAEIOUY]");

            var match = regex.Matches(input);

            Console.WriteLine($"Vowels: {match.Count}");    
        }
    }
}
