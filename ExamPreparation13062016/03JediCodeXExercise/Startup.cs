namespace _03JediCodeXExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            var listOfNames = new List<string>();
            var listOfMessages = new List<string>();

            var inputNumber = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < inputNumber; i++)
            {
                sb.Append(Console.ReadLine().Trim());
            }

            var namePattern = Console.ReadLine();

            var messagePattern = Console.ReadLine();

            var names = Regex.Matches(sb.ToString(), $@"{namePattern}([a-zA-Z]{{{namePattern.Length}}})(?![a-zA-Z])");
            var messages = Regex.Matches(sb.ToString(), $@"{messagePattern}([a-zA-Z0-9]{{{messagePattern.Length}}})(?![a-zA-Z0-9])");

            foreach (Match message in messages)
            {
                listOfMessages.Add(message.Groups[1].Value.Trim());
            }

            foreach (Match name in names)
            {
                listOfNames.Add(name.Groups[1].Value.Trim());
            }

            var indexesOfMessages = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int indexOfName = 0;

            for (int i = 0; i < indexesOfMessages.Count; i++)
            {
                if (indexesOfMessages[i] - 1 < listOfMessages.Count)
                {
                    Console.WriteLine($"{listOfNames[indexOfName]} - {listOfMessages[indexesOfMessages[i] - 1]}");
                    indexOfName++;
                }
                if (indexOfName >= listOfNames.Count)
                {
                    break;
                }
            }
        }
    }
}
