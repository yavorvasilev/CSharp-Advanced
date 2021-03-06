﻿namespace _04AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var students = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < number; i++)
            {
                var student = Console.ReadLine();
                var results = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => double.Parse(n, CultureInfo.InvariantCulture))
                    .ToList();

                students.Add(student, results);
            }

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} is graduated with {item.Value.Average()}");
            }
        }
    }
}
