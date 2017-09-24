namespace _11SemanticHtml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class SemanticHtml
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            while (line != "END")
            {
                var openingMatch = Regex.Match(line, $"<(div)([^>]+)(?:id|class)\\s*=\\s*\"(.*?)\"(.*?)>");

                var closingMatch = Regex.Match(line, $"<\\/div>\\s*<!--\\s*(.*?)\\s*-->");
                if (openingMatch.Success)
                {
                    line = Regex.Replace(line, 
                        $"<(div)([^>]+)(?:id|class)\\s*=\\s*\"(.*?)\"(.*?)>",
                        @"$3 $2 $4")
                        .Trim();

                    line = "<" + Regex.Replace(line, @"\s+", " ") + ">";

                }
                else if (closingMatch.Success)
                {
                    line = "</" + closingMatch.Groups[1] + ">";
                }
                Console.WriteLine(line);
                line = Console.ReadLine();
            }
        }
    }
}
