namespace _08CustomComparator
{
    using System;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(inputNumbers, (x, y) => {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                if (x > y)
                {
                    return 1;
                }
                if (y > x)
                {
                    return -1;
                }
                return 0;
            });

            Console.WriteLine(string.Join(" ", inputNumbers));
        }
    }
}
