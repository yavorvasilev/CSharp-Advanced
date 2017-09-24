namespace _04ConvertFromBaseNToBase10
{
    using System;
    using System.Text;
    using System.Numerics;

    public class Base10ToBaseN
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var baseN = BigInteger.Parse(input[0]);

            var baseTen = BigInteger.Parse(input[1]);

            var listOfNumbers = new StringBuilder();

            while (baseTen / baseN > 0)
            {
                var number = baseTen % baseN;

                listOfNumbers.Append(number);

                baseTen = baseTen / baseN;

                if (baseTen / baseN < 1)
                {
                    listOfNumbers.Append(baseTen);
                }
            }

            for (int i = listOfNumbers.Length - 1; i >= 0; i--)
            {
                Console.Write(listOfNumbers[i]);
            }
            Console.WriteLine();
        }
    }
}
