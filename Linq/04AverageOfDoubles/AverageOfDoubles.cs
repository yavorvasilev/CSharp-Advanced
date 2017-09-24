namespace _04AverageOfDoubles
{
    using System;
    using System.Linq;

    public class AverageOfDoubles
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine();

            Console.WriteLine("{0:F2}", inputNumbers
                .Split()
                .Select(double.Parse)
                .Average());
        }
    }
}
