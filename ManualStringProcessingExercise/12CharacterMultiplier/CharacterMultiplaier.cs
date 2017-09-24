namespace _12CharacterMultiplier
{
    using System;

    public class CharacterMultiplaier
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var str1 = input[0];

            var str2 = input[1];

            Console.WriteLine(GetMultiplyStrings(str1, str2));
        }

        public static int GetMultiplyStrings(string str1, string str2)
        {
            var min = Math.Min(str1.Length, str2.Length);

            var multiplySum = 0;

            for (int i = 0; i < min; i++)
            {
                multiplySum += (int)str1[i] * (int)str2[i];
            }

            if (str1.Length > str2.Length)
            {
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    multiplySum += (int)str1[i];
                }
            }
            else if (str2.Length > str1.Length)
            {
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    multiplySum += (int)str2[i];
                }
            }

            return multiplySum;
        }

    }
}
