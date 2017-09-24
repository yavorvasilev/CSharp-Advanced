namespace _09StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            var fibNumber = long.Parse(Console.ReadLine());
            var fibStack = new Stack<long>();

            fibStack.Push(0);
            fibStack.Push(1);

           // fibStack.Reverse();

            for (long i = 1; i < fibNumber; i++)
            {
                var f1 = fibStack.Pop();
                var f2 = fibStack.Pop();
                var f = f1 + f2;
                fibStack.Push(f1);
                fibStack.Push(f);
            }

            Console.WriteLine(fibStack.Peek());

        }
    }
}
