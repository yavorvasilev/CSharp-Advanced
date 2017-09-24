namespace _05ExtractTags
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractTags
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"<.+?>");

            while (input != "END")
            {
                var matches = regex.Matches(input);

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
                input = Console.ReadLine();
            }
           
        }
    }
}
