namespace _07ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ExcellentStudents
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var students = new HashSet<string>();

            while (input != "END")
            {
                var number = input.Split().Last();
                var firstDigit = number.ToCharArray().Take(2);
                students.Add(input);
                input = Console.ReadLine();
            }

            students
                .Select(s =>
                {
                    var markExcellent = Regex.Match(s, @"(\s6)");
                    if (markExcellent.Success)
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
