namespace _04JediDreamsExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            var methodDeclarationPattern = @"static\s*.*\s([A-Z][a-zA-Z]+)\s*\(.*\)";
            var methodInvokePattern = @"([A-Z][a-zA-Z]+)\s*\(";
            string currentMethodDeclaration = "";
            var methods = new Dictionary<string, List<string>>();
            var isHaveMethodDeclaration = false;

            for (int line = 0; line < numberOfLines; line++)
            {
                var inputLine = Console.ReadLine();
                if (CheckLineForMethodDeclaration(inputLine, methodDeclarationPattern))
                {
                    currentMethodDeclaration = Regex.Match(inputLine, methodDeclarationPattern).Groups[1].Value;
                    methods.Add(currentMethodDeclaration, new List<string>());
                    isHaveMethodDeclaration = true;
                    continue;
                }
                if (isHaveMethodDeclaration)
                {
                    if (CheckLineForMethodInvokePattern(inputLine, methodInvokePattern))
                    {
                        var methodsInvked = Regex.Matches(inputLine, methodInvokePattern);

                        foreach (Match method in methodsInvked)
                        {
                            methods[currentMethodDeclaration].Add(method.Groups[1].Value);
                        }
                    }
                }
            }

            foreach (var method in methods.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
            {
                if (method.Value.Count > 0)
                {
                    Console.WriteLine($"{method.Key} -> {method.Value.Count} -> {string.Join(", ", method.Value.OrderBy(n => n))}");
                }
                else
                {
                    Console.WriteLine($"{method.Key} -> None");
                }
            }
        }

        private static bool CheckLineForMethodInvokePattern(string line, string methodInvokePattern)
        {
            var methodsInvoked = Regex.Matches(line, methodInvokePattern);

            if (methodsInvoked.Count != 0)
            {
                return true;
            }
            return false;
        }

        private static bool CheckLineForMethodDeclaration(string line, string methodDeclarationPattern)
        {
            var methodDeclaration = Regex.Matches(line, methodDeclarationPattern);

            if (methodDeclaration.Count != 0)
            {
                return true;
            }
            return false;
        }
    }
}
