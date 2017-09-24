namespace _05FilterStudentsByEmailDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByEmailDomain
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
                    var email = tokens.Last();
                    if (email.Contains("@gmail.com"))
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
                .ForEach(s => 
                {
                    var tokens = s.Split().Take(2);
                    Console.WriteLine(string.Join(" ", tokens));
                });
        }
    }
}
