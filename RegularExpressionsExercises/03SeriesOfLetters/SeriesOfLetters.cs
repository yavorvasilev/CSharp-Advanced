namespace _03SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class SeriesOfLetters
    {
        public static void Main()
        {
            //var letter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //var input = Console.ReadLine();

            //for (int i = 0; i < letter.Length; i++)
            //{
            //    var regex = new Regex(@letter[i] + "+");
            //    var matches = regex.Matches(input);

            //    if (matches.Count > 0 )
            //    {
            //        foreach (var match in matches)
            //        {
            //            var matchString = match.ToString();
            //            input = input.Replace(matchString, letter[i].ToString());
            //        }
            //    }
            //}
            //Console.WriteLine(input);

            var input = Console.ReadLine();

            var output = Regex.Replace(input, "([A-Za-z])\\1+", "$1");

            Console.WriteLine(output);
        }
    }
}
