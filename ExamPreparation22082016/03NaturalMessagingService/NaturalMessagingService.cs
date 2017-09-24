namespace _03NaturalMessagingService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NaturalMessagingService
    {
        public static void Main()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var input = Console.ReadLine();
            var wordInMessage = new StringBuilder();
            var message = new List<string>();
            var currentPosition = -1;
            var position = -1;

            while (input != "---NMS SEND---")
            {
                var token = input.ToLower();

                for (int i = 0; i < input.Length; i++)
                {
                    currentPosition = alphabet.IndexOf(token[i]);

                    if (currentPosition >= position)
                    {
                        position = currentPosition;
                        currentPosition = -1;

                        wordInMessage.Append(input[i]);
                    }
                    else
                    {
                        message.Add(wordInMessage.ToString());
                        position = currentPosition;
                        currentPosition = -1;
                        wordInMessage.Clear();
                        wordInMessage.Append(input[i]);
                    }
                }
            
                input = Console.ReadLine();
            }
            if (wordInMessage.Length != 0)
            {
                message.Add(wordInMessage.ToString());
            }

            var separator = Console.ReadLine();
            Console.WriteLine(string.Join(separator, message));

        }
    }
}
