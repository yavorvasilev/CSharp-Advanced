namespace _02LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            using (var reader = new StreamReader("Lines.txt"))
            {
                using (var writer = new StreamWriter("LinesNumbers.txt"))
                {
                    string line = reader.ReadLine();
                    var countLine = 1;
                    while (line != null)
                    {
                        writer.WriteLine(countLine.ToString() + line);
                        countLine++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
