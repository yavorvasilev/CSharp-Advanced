namespace _07BoundedNumbers
{
    using System;
    using System.Linq;

    public class BoundedNumbers
    {
        public static void Main()
        {
            var bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => bounds.Min() <= n && n <= bounds.Max())
                .ToList();

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
