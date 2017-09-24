namespace _02MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"\+359( |-)\d\1\d{3}\1\d{4}$");

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
