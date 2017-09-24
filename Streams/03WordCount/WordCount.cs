namespace _03WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WordCount
    {
        public static void Main()
        {
            var dictionaryOfWords = new Dictionary<string, int>();
            using (var readerWords = new StreamReader("words.txt"))
            {
                var word = readerWords.ReadLine();
                while (word != null)
                {
                    dictionaryOfWords[word] = 0;
                    word = readerWords.ReadLine();
                }
            }
            using (var readerText = new StreamReader("text.txt"))
            {
                var text = readerText.ReadLine();
                while (text != null)
                {
                    var words = text
                        .ToLower()
                        .Split(new char[] { '.', ',', '-', '\'', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    foreach (var word in words)
                    {
                        if (dictionaryOfWords.ContainsKey(word))
                        {
                            dictionaryOfWords[word] += 1;
                        }
                    }
                 
                   text = readerText.ReadLine();
                }
            }
            using (var writer = new StreamWriter("results.txt"))
            {
                foreach (var word in dictionaryOfWords.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
