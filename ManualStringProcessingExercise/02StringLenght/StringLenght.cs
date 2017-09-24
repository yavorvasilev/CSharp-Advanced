namespace _02StringLenght
{
    using System;

    public class StringLenght
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();

            if (inputString.Length >= 20)
            {
                Console.WriteLine(inputString.Substring(0, 20));
            }
            else
            {
                Console.WriteLine(inputString.PadRight(20,'*'));
            }
        }
    }
}
