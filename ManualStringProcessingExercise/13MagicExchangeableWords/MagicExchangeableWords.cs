namespace _13MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;

    public class MagicExchangeableWords
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var str1 = input[0];

            var str2 = input[1];


            if (IsExchangeableWords(str1, str2))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        public static bool IsExchangeableWords(string str1, string str2)
        {
            var alphabeticalDictionary = new Dictionary<char, char>();

            var isExchanble = true;

            var min = Math.Min(str1.Length, str2.Length);

            for (int i = 0; i < min; i++)
            {
                if (!alphabeticalDictionary.ContainsKey(str1[i]))
                {
                    if (!alphabeticalDictionary.ContainsValue(str2[i]))
                    {
                        alphabeticalDictionary[str1[i]] = str2[i];
                    }
                    else
                    {
                        isExchanble = false;
                    }
                }
                else if (!alphabeticalDictionary.ContainsValue(str2[i]))
                {
                    isExchanble = false;
                }
            }

            if (str1.Length > str2.Length && isExchanble == true)
            {
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    if (!alphabeticalDictionary.ContainsKey(str1[i]) && !alphabeticalDictionary.ContainsValue(str1[i]))
                    {
                        isExchanble = false;
                        break;
                    }
                }
            }

            if (str2.Length > str1.Length && isExchanble == true)
            {
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    if (!alphabeticalDictionary.ContainsKey(str2[i]) && !alphabeticalDictionary.ContainsValue(str2[i]))
                    {
                        isExchanble = false;
                        break;
                    }
                }
            }

            return isExchanble;
        }
    }
}
