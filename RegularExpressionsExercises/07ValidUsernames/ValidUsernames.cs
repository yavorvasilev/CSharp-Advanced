namespace _07ValidUsernames
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            var userNames = Console.ReadLine()
                .Split(new char[] { '/', ' ', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(u => Regex.IsMatch(u, @"\b[a-zA-Z][a-zA-Z0-9_]{2,24}\b"))
                .ToArray();

            //Console.WriteLine(string.Join(" ",userNames));
            var maxSum = 0;
            var bestFirstSumUsername = "";
            var bestSecondSumUsername = "";
            for (int i = 0; i < userNames.Length - 1; i++)
            {
                var firstUsername = userNames[i];
                var secondUsername = userNames[i + 1];
                var currentSum = firstUsername.Length + secondUsername.Length;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    bestFirstSumUsername = firstUsername;
                    bestSecondSumUsername = secondUsername;
                }
            }

            Console.WriteLine(bestFirstSumUsername);
            Console.WriteLine(bestSecondSumUsername);
        }
    }
}
