namespace _01SortEvenNumber
{
    using System;
    using System.Linq;

    public class SortEvenNumber
    {
        public static void Main()
        {
            Func<string, int> numberParser = n => int.Parse(n);



            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(numberParser)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToList()
                ));
        }

        private static int NumberParser(string arg)
        {
            return int.Parse(arg);
        }
    }
}
