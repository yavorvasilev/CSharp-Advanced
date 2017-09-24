﻿namespace _03GroupNumbers
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var zero = numbers.Where(n => Math.Abs(n) % 3 == 0);
            var one = numbers.Where(n => Math.Abs(n) % 3 == 1);
            var two = numbers.Where(n => Math.Abs(n) % 3 == 2);

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));

        }
    }
}
