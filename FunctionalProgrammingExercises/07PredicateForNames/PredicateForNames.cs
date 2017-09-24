namespace _07PredicateForNames
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            var numberOfLetters = int.Parse(Console.ReadLine());
            var inputNames = Console.ReadLine().Split();

            Action<string[]> printNames = names => names.Where(n => n.Length <= numberOfLetters)
            .ToList()
            .ForEach(n => Console.WriteLine(n));

            printNames(inputNames);
        }
    }
}
