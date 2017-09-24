namespace _01UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main()
        {
            var numberOfNames = int.Parse(Console.ReadLine());
            var setOfNames = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                var name = Console.ReadLine();

                setOfNames.Add(name);
            }

            foreach (var name in setOfNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
