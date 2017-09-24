namespace _07LegoBlocks
{
    using System;
    using System.Linq;
     
    public class LegoBlocks
    {
        public static void Main()
        {
            var nRows = int.Parse(Console.ReadLine());

            var firstMatrix = new int[nRows][];
            var secondMatrix = new int[nRows][];
            var countElements = 0;
            for (int row = 0; row < nRows; row++)
            {
                var cols = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions
                    .RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                firstMatrix[row] = cols;
                countElements += cols.Length;
            }

            for (int row = 0; row < nRows; row++)
            {
                var cols = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions
                    .RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                secondMatrix[row] = cols;
                countElements += cols.Length;
            }

            var maxLenght = (firstMatrix[0].Length + secondMatrix[0].Length);
            var isFit = true;

            for (int row = 1; row < nRows; row++)
            {
                var currentLenght = firstMatrix[row].Length + secondMatrix[row].Length;
                if (currentLenght != maxLenght)
                {
                    isFit = false;
                    break;
                }
            }

            if (isFit)
            {
                var resultMatrix = new int[nRows][];

                for (int row = 0; row < nRows; row++)
                {
                    secondMatrix[row] = secondMatrix[row].Reverse().ToArray();
                }

                for (int row = 0; row < nRows; row++)
                {
                    resultMatrix[row] = firstMatrix[row].Concat(secondMatrix[row]).ToArray();
                }

                foreach (var row in resultMatrix)
                {
                    Console.WriteLine("[{0}]",string.Join(", ", row));
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {countElements}");
            }
        }
    }
}
