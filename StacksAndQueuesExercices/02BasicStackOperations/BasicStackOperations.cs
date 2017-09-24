namespace _02BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var countOfPushInStack = input[0];
            var countOfPopFromStack = input[1];
            var number = input[2];

            var inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < countOfPushInStack; i++)
            {
                stack.Push(inputNumbers[i]);
            }

            for (int i = 0; i < countOfPopFromStack; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(number))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(stack.Peek());
                }
                
            }
        }
    }
}
