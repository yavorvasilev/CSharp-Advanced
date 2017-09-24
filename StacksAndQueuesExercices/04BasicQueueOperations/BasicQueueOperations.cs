namespace _04BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            var input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var countOfPushInStack = input[0];
            var countOfPopFromStack = input[1];
            var number = input[2];

            var inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < countOfPushInStack; i++)
            {
                queue.Enqueue(inputNumbers[i]);
            }

            for (int i = 0; i < countOfPopFromStack; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(number))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
