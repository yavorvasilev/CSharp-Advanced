namespace _03CubicMessages
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CubicMessages
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            

            while (input != "Over!")
            {
                var messageLenght = int.Parse(Console.ReadLine());

                var tokens = Regex.Match(input, $@"^(\d+)([a-zA-Z]{{{messageLenght}}})([^a-zA-Z]*$)");

                if (tokens.Success)
                {
                    var verificationCodeFirst = tokens.Groups[1].Value.ToArray();
                    var text = tokens.Groups[2].Value;
                    var verificationCodeSecond = tokens.Groups[3].Value.Where(ch => Char.IsDigit(ch)).ToArray();
                    var allVerificationCode = verificationCodeFirst.Concat(verificationCodeSecond).ToArray();

                    var message = new StringBuilder();

                    for (int i = 0; i < allVerificationCode.Length; i++)
                    {
                        var digit = (int)Char.GetNumericValue(allVerificationCode[i]);

                        if (digit < messageLenght)
                        {
                            message.Append(text[digit]);
                        }
                        else
                        {
                            message.Append(" ");
                        }
                    }

                    Console.WriteLine($"{text} == {message}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
