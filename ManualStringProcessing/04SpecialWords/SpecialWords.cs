namespace _04SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SpecialWords
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine()
                .Split(new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' '});
            var text = Console.ReadLine() 
                .Split(new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' });

            var dictionaryOFSpecialWords = new Dictionary<string, int>();

            foreach (var specialWord in specialWords)
            {
                dictionaryOFSpecialWords[specialWord] = 0;
                foreach (var word in text)
                {
                    if (specialWord == word)
                    {
                        dictionaryOFSpecialWords[specialWord]++;
                    }
                }
            }

            foreach (var specialWord in dictionaryOFSpecialWords)
            {
                Console.WriteLine($"{specialWord.Key} - {specialWord.Value}");
            }
        }
    }
}
