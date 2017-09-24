namespace _09StudentsEnrolledIn2014Or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StudentsEnrolled
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
                    var studentNumber = s.Split().First();
                    var studentEnrolled = Regex.Match(studentNumber, @"(14$)|(15$)");
                    if (studentEnrolled.Success)
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
                .ForEach(s => Console.WriteLine(string.Join(" ", s.Split().Skip(1))));
        }
    }
}
