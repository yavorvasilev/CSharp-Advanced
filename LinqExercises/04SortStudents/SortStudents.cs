namespace _04SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
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
                .OrderBy(s => s.Split().Last())
                .ThenByDescending(s => s.Split().First())
                .ToList()
                .ForEach(s => Console.WriteLine(s));
        }
    }
}
