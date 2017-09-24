namespace _06ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            Func<int[], List<int>> reverseNumbers = numbers => numbers.Reverse().ToList();


            var inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var divisibleNumber = int.Parse(Console.ReadLine());

            var reversedList = reverseNumbers(inputNumbers);

            Predicate<int> isDivisible = delegate (int a) { return a % divisibleNumber == 0; };

            for (int i = reversedList.Count - 1; i >= 0; i--)
            {
                if (isDivisible(reversedList[i]))
                {
                    reversedList.Remove(reversedList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", reversedList));

        }
    }
}
