namespace _03StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByAge
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var students = new HashSet<string>();

            while (input != "END")
            {
                students.Add(input);
                input = Console.ReadLine();
            }

            students
                .Select(s =>
                {
                    var tokens = s.Split();
                    var age = int.Parse(tokens[2]);
                    if (18 <= age && age <= 24)
                    {
                        return s;
                    }
                    else
                    {
                        return "";
                    }
                })
                .Where(s => s != "")
                .ToList()
                .ForEach(s => Console.WriteLine(s));
        }
    }
}
