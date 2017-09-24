namespace _10SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            var numberOfOperations = int.Parse(Console.ReadLine());
            var textEditor = new Stack<string>();
            textEditor.Push(string.Empty);

            for (int i = 0; i < numberOfOperations; i++)
            {
                var operation = Console.ReadLine().Split();
                var command = operation[0];

                switch (command)
                {
                    
                    case "1":
                        var text = operation[1];
                        var currentText = textEditor.Peek();
                        text = currentText + text;
                        textEditor.Push(text);
                        break;

                    case "2":
                        var count = int.Parse(operation[1]);
                        var erasesText = textEditor.Peek();
                        erasesText = erasesText.Remove(erasesText.Length - count);
                        textEditor.Push(erasesText);
                        break;

                    case "3":
                        var index = int.Parse(operation[1]);
                        var printText = textEditor.Peek();
                        Console.WriteLine(printText[index - 1]);
                        break;

                    case "4":
                        textEditor.Pop();
                        break;
                }
            }
        }
    }
}
