namespace _03PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class PeriodicTable
    {
        public static void Main()
        {
            var numberOfElements = int.Parse(Console.ReadLine());
            var setOfElements = new SortedSet<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                var elements = Console.ReadLine().Split();

                //setOfElements.UnionWith(elements);
                for (int j = 0; j < elements.Length; j++)
                {
                    setOfElements.Add(elements[j]);
                }
            }

            foreach (var element in setOfElements)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }
}
