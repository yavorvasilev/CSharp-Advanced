namespace _03MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            var numberOfQueries = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var stackOfMaxNumbers = new Stack<int>();
            var maxValue = int.MinValue;

            for (int i = 0; i < numberOfQueries; i++)
            {
                var operation = Console.ReadLine();

                if (operation[0] == '1')
                {
                    var number = operation
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();

                    stack.Push(number[1]);

                    if (maxValue < number[1])
                    {
                        maxValue = number[1];
                        stackOfMaxNumbers.Push(maxValue);
                    }
                }
                else if(operation[0] == '2')
                {
                    if (stack.Pop() == maxValue)
                    {
                        stackOfMaxNumbers.Pop();
                        if (stackOfMaxNumbers.Count() != 0)
                        {
                            maxValue = stackOfMaxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                    
                }
                else if (operation[0] == '3')
                {
                    Console.WriteLine(maxValue);
                }
            }
            //Console.WriteLine();
        }
    }
}
