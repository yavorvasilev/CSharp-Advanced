namespace _04FindEvensOrOdds
{
    using System;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            var rangeOfNumbers = Console.ReadLine().Split();
            var oddOrEven = Console.ReadLine();

            var lowerBound = int.Parse(rangeOfNumbers[0]);
            var upperBound = int.Parse(rangeOfNumbers[1]);

            Predicate<int> isEven = delegate (int a) { return a % 2 == 0; };
            Predicate<int> isOdd = delegate (int a) { return a % 2 != 0; };

            if (oddOrEven == "even")
            {
                for (int i = lowerBound; i <= upperBound; i++)
                {
                    var number = i;

                    if (isEven(number))
                    {
                        Console.Write("{0} ", number);
                    }
                }
            }
            else if (oddOrEven == "odd")
            {
                for (int i = lowerBound; i <= upperBound; i++)
                {
                    var number = i;

                    if (isOdd(number))
                    {
                        Console.Write("{0} ", number);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
