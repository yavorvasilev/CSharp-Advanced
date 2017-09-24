namespace _01TakeTwo
{
    using System;
    using System.Linq;

    public class TakeTwo
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            input
                .Split()
                .Select(int.Parse)
                .Distinct()
                .Where(n => n >= 10 && n <= 20)
                .Take(2)
                .ToList()
                .ForEach(n => Console.Write("{0} ",n));
        }
    }
}
