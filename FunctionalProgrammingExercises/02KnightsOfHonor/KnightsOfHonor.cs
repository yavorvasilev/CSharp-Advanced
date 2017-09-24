namespace _02KnightsOfHonor
{
    using System;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Console.Write("Sir ");
            Action<string[]> print = n =>  Console.WriteLine(string.Join("\nSir" + " ", n));

            print(input);
        }
    }
}
