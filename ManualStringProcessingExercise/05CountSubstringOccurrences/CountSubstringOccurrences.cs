namespace _05CountSubstringOccurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();

            var pattern = Console.ReadLine().ToLower();

            var index = 0;

            var count = 0;

            while (true)
            {
                var found = text.IndexOf(pattern, index);

                if (found >= 0)
                {
                    count++;
                    index = found + 1;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(count);
        }
    }
}
