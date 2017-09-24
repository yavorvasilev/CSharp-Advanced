namespace _02SumNumbers
{
    using System;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Console.WriteLine(input
                .Split(new string[] {", "},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Count());

            Console.WriteLine(input
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Sum());
        }
    }
}
