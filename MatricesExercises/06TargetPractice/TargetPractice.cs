namespace _06TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TargetPractice
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions
                .RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSize[0];
            var cols = matrixSize[1];

            var snake = Console.ReadLine();

            var shotParameters = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions
                .RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var shotRow = shotParameters[0];
            var shotCol = shotParameters[1];
            var radius = shotParameters[2];

            var matrix = new char[rows][];

            var count = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];
                if (row % 2 == 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                        matrix[row][col] = snake[count];
                        count++;
                    }
                }
                if (row % 2 != 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (count == snake.Length)
                        {
                            count = 0;
                        } 
                        matrix[row][col] = snake[count];
                        count++;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if ((row >= shotRow - radius + 1) && (row <= shotRow + radius - 1) && (col >= shotCol - radius + 1) && (col <= shotCol + radius - 1))
                    {
                        matrix[row][col] = ' ';
                    }
                    if ((row == shotRow && col == shotCol + radius) || (row == shotRow && col == shotCol - radius) || (row == shotRow + radius && col == shotCol) || (row == shotRow - radius && col == shotCol))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

            var whiteSpace = true;
            do
            {
                whiteSpace = true;
                for (int row = 0; row < rows - 1; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row][col] != ' ' && matrix[row + 1][col] == ' ')
                        {
                            matrix[row + 1][col] = matrix[row][col];
                            matrix[row][col] = ' ';
                            whiteSpace = false;
                        }
                    }
                }
            } while (whiteSpace != true);

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("",item));
            }
        }
    }
}
