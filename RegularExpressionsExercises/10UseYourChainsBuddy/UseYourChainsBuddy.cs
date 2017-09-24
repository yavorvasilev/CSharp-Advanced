namespace _10UseYourChainsBuddy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"<p>(.*?)</p>");
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var whiteSpaces = @"[^a-z0-9]+";
                var reminder = match.Groups[1].Value;
                var replaced = Regex.Replace(reminder, whiteSpaces, " ");

                //var sb = new StringBuilder();

                foreach (var character in replaced)
                {
                    if (character >= 'a' && character <= 'm')
                    {
                        Console.Write(((char)(character + 13)));
                    }
                    else if(character >= 'n' && character <= 'z')
                    {
                        Console.Write(((char)(character - 13)));
                    }
                    else
                    {
                        Console.Write(((char)(character)));
                    }
                }

                //var result = Regex.Replace(sb.ToString(), "\\s+", " ");
                //Console.WriteLine(result);
            }
        }
    }
}
