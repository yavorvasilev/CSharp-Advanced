namespace _02DiagonalDifference
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new int[matrixSize][];

            var leftDiagonalSum = 0;
            var rightDiagonalSum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions
                    .RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                leftDiagonalSum += matrix[row][row];
                rightDiagonalSum += matrix[row][matrix.Length - 1 - row];
            }
            Console.WriteLine(Math.Abs(leftDiagonalSum - rightDiagonalSum));
        }
    }
}
