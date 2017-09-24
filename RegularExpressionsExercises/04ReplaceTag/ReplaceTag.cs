namespace _04ReplaceTag
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class ReplaceTag
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "end")
            {
                var pattern = @"<a (href=.+?)>(.+)</a>";

                var result = Regex.Replace(input, pattern, w=> $"[URL {w.Groups[1]}]{w.Groups[2]}[/URL]");
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}
