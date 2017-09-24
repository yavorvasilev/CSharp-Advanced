namespace _06ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"^[\w-]{3,16}$");

            if (input == "END")
            {
                Console.WriteLine("(no output)");
            }
            else
            {
                while (input != "END")
                {
                    var matches = regex.Matches(input);

                    if (matches.Count == 0)
                    {
                        Console.WriteLine("invalid");
                    }
                    else
                    {
                        Console.WriteLine("valid");
                    }
                    input = Console.ReadLine();
                }
            }
        }
    }
}
