namespace _04AddVat
{
    using System;
    using System.Linq;

    public class AddVat
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n *= 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}
