namespace _05AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var command = Console.ReadLine();

            Action<int[]> printNumbers = numbers => Console.WriteLine(string.Join(" ", numbers));
            Func<int[], int[]> addFunc = numbers => numbers.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiplayFunc = numbers => numbers.Select(n => n * 2).ToArray();
            Func<int[], int[]> substractFunc = numbers => numbers.Select(n => n - 1).ToArray();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        inputNumbers = addFunc(inputNumbers);
                        break;

                    case "multiply":
                        inputNumbers = multiplayFunc(inputNumbers);
                        break;

                    case "subtract":
                        inputNumbers = substractFunc(inputNumbers);
                        break;

                    case "print":
                        printNumbers(inputNumbers);
                        break;
                }

                command = Console.ReadLine();
            }

        }
    }
}
