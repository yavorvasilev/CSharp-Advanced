namespace _07ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidTime
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"[01][0-9]:[0-5][0-9]:[0-5][0-9] (A|P)M");

            while (input != "END")
            {
                var match = regex.Match(input);
                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}
