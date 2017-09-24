namespace _11Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Palindromes
    {
        public static void Main()
        {
            var text = Console.ReadLine().Split(new char[] { '.', '!', '?', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var listOfPalindromes = new List<string>();

            foreach (var word in text)
            {
                var palindromes = word.ToCharArray();
                var revereseWord = palindromes.Reverse().ToArray();

                if (palindromes.SequenceEqual(revereseWord))
                {
                    listOfPalindromes.Add(word);
                }

            }
            Console.Write("[");
            Console.Write(string.Join(", ", listOfPalindromes.Distinct().OrderBy(x => x)));
            Console.WriteLine("]");
        }
    }
}
