namespace _05CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class CalculateSequence
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var numbers = new Queue<long>();

            numbers.Enqueue(n);

            for (int i = 0; i < 50; i++)
            {

                foreach (var number in numbers)
                {
                    var s = numbers.Peek();
                    Console.Write(s + " ");

                    numbers.Enqueue(s + 1);
                    numbers.Enqueue(2 * s + 1);
                    numbers.Enqueue(s + 2);

                    numbers.Dequeue();

                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
