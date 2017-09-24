namespace _06SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;
    using System.Text;

    public class SentenceExtractor
    {
        public static void Main()
        {
            var keyWord = Console.ReadLine();
            var sentences = Console.ReadLine();

            var regex = new Regex($@"([a-zA-Z0-9 ]+\b{keyWord}\b\s*.*?[?!.])");
            var matches = regex.Matches(sentences);

            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
