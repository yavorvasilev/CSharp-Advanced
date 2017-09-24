namespace _02UpperStrings
{
    using System;
    using System.Linq;

    public class UpperStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            input
                .Split()
                .Select(n => n.ToUpper())
                .ToList()
                .ForEach(n => Console.Write("{0} ", n));
            Console.WriteLine();
        }
    }
}
