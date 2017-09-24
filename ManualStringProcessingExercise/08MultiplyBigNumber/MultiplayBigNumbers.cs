namespace _08MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;

    public class MultiplayBigNumbers
    {
        public static void Main()
        {
            var firstNumber = Console.ReadLine();

            var secondNumber = Console.ReadLine();

            var bigestNumber = "";

            var smalestNumber = "";

            if (firstNumber.Length > secondNumber.Length)
            {
                bigestNumber = firstNumber;
                smalestNumber = secondNumber;
            }
            else if(secondNumber.Length > firstNumber.Length)
            {
                bigestNumber = secondNumber;
                smalestNumber = firstNumber;
            }
            else
            {
                bigestNumber = Math.Max(int.Parse(firstNumber), int.Parse(secondNumber)).ToString();
                smalestNumber = Math.Min(int.Parse(firstNumber), int.Parse(secondNumber)).ToString();
            }

            if (smalestNumber == "0")
            {
                Console.WriteLine("0");
            }
            else
            {
                var result = new List<int>();

                var sum = 0;

                var rem = 0;

                for (int i = bigestNumber.Length - 1; i >= 0; i--)
                {
                    sum = int.Parse(smalestNumber) * int.Parse(bigestNumber[i].ToString()) + rem;

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

                if (rem > 0)
                {
                    result.Add(rem);
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
}
