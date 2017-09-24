namespace _01ActionPrint
{
    using System;

    public class ActionPrint
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split();

            Action<string[]> printer = n => Console.WriteLine(string.Join("\n", n));

            printer(input);
        }
    }
}
