namespace _01StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroup
    {
        public static void Main()
        {
            var names = new HashSet<string>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                var nameAndGroup = input.Split();
                var group = nameAndGroup[2];
                var name = nameAndGroup[0] + " " + nameAndGroup[1];

                if (group == "2")
                {
                    names.Add(name);
                }

                input = Console.ReadLine();
            }

            names
                .OrderBy(n => n)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
