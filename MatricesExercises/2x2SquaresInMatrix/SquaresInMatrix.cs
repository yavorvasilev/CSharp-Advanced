namespace _2x2SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SqaresInMatrix
    {
        public static void Main()
        {
            var rowAndCol = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var row = rowAndCol[0];
            var col = rowAndCol[1];

            var numberOfMatrix = 0;

            var matrix = new char[row][];

            for (int r = 0; r < matrix.Length; r++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[r] = input;
            }

            for (int r = 0; r < matrix.Length - 1; r++)
            {
                for (int c = 0; c < matrix[r].Length - 1; c++)
                {
                    if (matrix[r][c] == matrix[r][c + 1] && matrix[r][c] == matrix[r + 1][c + 1] && matrix[r][c] == matrix[r + 1][c])
                    {
                        numberOfMatrix++;
                    }
                }
            }
            Console.WriteLine(numberOfMatrix);
        }
    }
}
