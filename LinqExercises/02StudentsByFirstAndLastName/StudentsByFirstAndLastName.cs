namespace _02StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByFirstAndLastName
    {
        public static void Main()
        {
            var names = new HashSet<string>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                names.Add(input);

                input = Console.ReadLine();
            }
            names
                .Select(n =>
                {
                    var tokens = n.Split();
                    var firstname = tokens[0];
                    var secondName = tokens[1];
                    if (string.Compare(firstname, secondName) < 0)
                    {
                        return n;
                    }
                    return "";
                })
                .Where(n => n != "")
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
