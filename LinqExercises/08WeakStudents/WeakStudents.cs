namespace _08WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WeakStudents
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
                    var weakStudent = Regex.Matches(s, @"((\s2)|(\s3))");
                    if (weakStudent.Count >= 2)
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
                .ForEach(s => Console.WriteLine(string.Join(" ", s.Split().Take(2))));
        }
    }
}
