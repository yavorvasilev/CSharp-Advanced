namespace _07SumBigNumbers
{
    using System;
    using System.Collections.Generic;

    public class SumBigNumbers
    {
        public static void Main()
        {
            var firstNumber = Console.ReadLine().TrimStart('0').ToCharArray();

            var secondNumber = Console.ReadLine().TrimStart('0').ToCharArray();

            var bigestNumber = new char[Math.Max(firstNumber.Length, secondNumber.Length)];

            var smalestNumber = new char[Math.Min(firstNumber.Length, secondNumber.Length)];

            if (firstNumber.Length >= secondNumber.Length)
            {
                bigestNumber = firstNumber;
                smalestNumber = secondNumber;
            }
            else
            {
                bigestNumber = secondNumber;
                smalestNumber = firstNumber;
            }

            var result = new List<int>();

            var diff = bigestNumber.Length - smalestNumber.Length;

            var sum = 0;

            var rem = 0;

            for (int i = smalestNumber.Length - 1; i >= 0; i--)
            {
                sum = int.Parse(smalestNumber[i].ToString()) + int.Parse(bigestNumber[i + diff].ToString()) + rem;

                rem = 0;

                if (sum > 9)
                {
                    result.Add(sum % 10);

                    rem = sum / 10;
                }
                else
                {
                    result.Add(sum);
                }
            }

            if (bigestNumber.Length > smalestNumber.Length)
            {
                for (int i = diff - 1; i >= 0; i--)
                {
                    sum = int.Parse(bigestNumber[i].ToString()) + rem;

                    rem = 0;

                    if (sum > 9)
                    {
                        result.Add(sum % 10);

                        rem = sum / 10;
                    }
                    else
                    {
                        result.Add(sum);
                    }
                }

                if (rem != 0)
                {
                    result.Add(rem);
                }
            }
            else
            {
                if (rem != 0)
                {
                    result.Add(rem);
                }
            }

            result.Reverse();

            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
