namespace _01ReverseString
{
    using System;
    using System.Text;

    public class ReverseString
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var reversedString = new StringBuilder();

            for (int i = input.Length -1; i >= 0; i--)
            {
                reversedString.Append(input[i]);
            }

            Console.WriteLine(reversedString.ToString());
        }
    }
}
