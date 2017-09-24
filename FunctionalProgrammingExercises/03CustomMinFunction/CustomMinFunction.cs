namespace _03CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            Func<int[], int> findMinFunc = n => n.Min();

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(findMinFunc(input));
        }
    }
}
