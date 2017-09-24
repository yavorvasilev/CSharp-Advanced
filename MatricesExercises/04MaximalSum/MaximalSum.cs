namespace _04MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            var rowAndCol = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var row = rowAndCol[0];
            var col = rowAndCol[1];

            var maxSum = int.MinValue;
            var currentSum = 0;

            var matrix = new int[row][];

            for (int r = 0; r < matrix.Length; r++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[r] = input;
            }

            var maxRol = 0;
            var maxCol = 0;

            for (int r = 0; r < matrix.Length - 2; r++)
            {
                for (int c = 0; c < matrix[r].Length - 2; c++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        currentSum += matrix[r + i][c] + matrix[r + i][c + 1] + matrix[r + i][c + 2];
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRol = r;
                        maxCol = c;
                    }
                    currentSum = 0;
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Console.Write($"{matrix[maxRol + r][maxCol + c]} ");
                }
                Console.WriteLine();
            }
           
        }
    }
}
