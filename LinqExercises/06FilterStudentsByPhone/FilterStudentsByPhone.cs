namespace _06FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class FilterStudentsByPhone
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
                    var number = s.Split().Last();
                    var validNumber = Regex.Match(number, @"(^02)|(^\+3592)");
                    if (validNumber.Success)
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
