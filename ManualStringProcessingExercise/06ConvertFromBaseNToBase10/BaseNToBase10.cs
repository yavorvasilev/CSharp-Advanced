namespace _06ConvertFromBaseNToBase10
{
    using System;
    using System.Numerics;

    public class BaseNToBase10
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var n = int.Parse(input[0]);

            var baseN = BigInteger.Parse(input[1]);

            var numberAsString = baseN.ToString();

            BigInteger sum = 0;

            for (int power = 0; power < numberAsString.Length; power++)
            {
                var num = int.Parse(numberAsString[numberAsString.Length - 1 - power].ToString());

                sum += num * BigInteger.Pow(n, power);
            }

            Console.WriteLine(sum);
        }
    }
}
