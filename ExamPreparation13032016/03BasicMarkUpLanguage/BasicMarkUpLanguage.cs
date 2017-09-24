namespace _03BasicMarkUpLanguage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class BasicMarkUpLanguage
    {
        public static void Main(string[] args)
        {
            var inversePattern = @"<\s*inverse\s*content\s*=\s*\""([^""]{0,50})\""\s*\/\s*>";
            var reveresePattern = @"<\s*reverse\s*content\s*=\s*\""([^""]{0,50})\""\s*\/\s*>";
            var repeatPattern = @"<\s*repeat\s*value\s*=\s*""\s*([0-9]|10)\s*""\s*content\s*=\s*\""([^""]{0,50})\""\s*\/\s*>";

            var newContents = new List<string>();
            var input = Console.ReadLine();
            while (input != "<stop/>")
            {
                if (Regex.IsMatch(input,inversePattern))
                {
                    var token = Regex.Match(input, inversePattern);
                    var content = token.Groups[1].Value;
                    var sb = new StringBuilder();
                    for (int i = 0; i < content.Length; i++)
                    {
                        var ch = content[i];
                        if (char.IsLower(ch))
                        {
                            sb.Append(char.ToUpper(ch));
                        }
                        else if (char.IsUpper(ch))
                        {
                            sb.Append(char.ToLower(ch));
                        }
                        else
                        {
                            sb.Append(ch);
                        }
                    }
                    newContents.Add(sb.ToString());
                }
                if (Regex.IsMatch(input,reveresePattern))
                {
                    var token = Regex.Match(input, reveresePattern);
                    var content = token.Groups[1].Value.Reverse().ToArray();
                    var newContent = new string(content);
                    newContents.Add(newContent.ToString());
                }
                if (Regex.IsMatch(input, repeatPattern))
                {
                    var tokens = Regex.Match(input, repeatPattern);
                    var n = int.Parse(tokens.Groups[1].Value);
                    var content = tokens.Groups[2].Value;
                    for (int i = 0; i < n; i++)
                    {
                        newContents.Add(content);
                    }
                }

                input = Console.ReadLine();
            }

            var count = 1;
            foreach (var content in newContents)
            {
                Console.WriteLine($"{count}. {content}");
                count++;
            }
            
        }
    }
}
