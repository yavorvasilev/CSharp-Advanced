namespace _01OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            using (var reader = new StreamReader("oddNumbersFile.txt"))
            {
                int lineNumber = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine("{0}", line);
                    }
                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
