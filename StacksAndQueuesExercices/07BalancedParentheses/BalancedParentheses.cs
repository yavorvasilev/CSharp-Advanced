namespace _07BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var parenthesesLine = Console.ReadLine();

            var openedParentheses = new Stack<char>();
            var openingCases = new char[] {'{', '[', '('};

            for (int i = 0; i < parenthesesLine.Length; i++)
            {
                if (openingCases.Contains(parenthesesLine[i]))
                {
                    openedParentheses.Push(parenthesesLine[i]);
                }
                else
                {
                    if (openedParentheses.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    switch (parenthesesLine[i])
                    {
                        case '}':
                            if (openedParentheses.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case ']':
                            if (openedParentheses.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case ')':
                            if (openedParentheses.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
