namespace testJediCodeX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var encodedText = new StringBuilder();
            var jediNames = new List<string>();
            var messages = new List<string>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                encodedText.Append(Console.ReadLine().Trim());
            }

            var namePrefix = Console.ReadLine();
            var nameLenght = namePrefix.Length;
            var messagePrefix = Console.ReadLine();
            var messageLenght = messagePrefix.Length;


            var jediTokens = Regex.Matches(encodedText.ToString(), $@"{namePrefix}([a-zA-Z]{{{nameLenght}}})(?![a-zA-Z])");
            var messageTokens = Regex.Matches(encodedText.ToString(), $@"{messagePrefix}([a-zA-Z0-9]{{{messageLenght}}})(?![a-zA-Z0-9])");

            if (jediTokens.Count > 0)
            {
                foreach (Match name in jediTokens)
                {
                    var jediName = name.Groups[1].Value;
                    jediNames.Add(jediName);
                }
            }
            if (messageTokens.Count > 0)
            {
                foreach (Match message in messageTokens)
                {
                    var jediMessage = message.Groups[1].Value;
                    messages.Add(jediMessage);
                }
            }

            var indexes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var jediIndex = 0;

            for (int i = 0; i < indexes.Length; i++)
            {
                var index = indexes[i] - 1;
                if (index <= messages.Count - 1)
                {
                    Console.WriteLine($"{jediNames[jediIndex]} - {messages[index]}");
                    jediIndex++;
                }
                if (jediIndex >= jediNames.Count)
                {
                    break;
                }
            }
        }
    }
}