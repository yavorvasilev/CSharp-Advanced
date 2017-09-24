namespace _08RadioactiveMutantVampireBunnies
{
    using System;
    using System.Linq;

    public class RadioactiveBunnies
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

            var matrix = new char[rows][];

            var rowPlayer = 0;
            var colPlayer = 0;

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                var inputRow = input.ToCharArray();
                matrix[row] = inputRow;
                if (input.Contains('P'))
                {
                    rowPlayer = row;
                    colPlayer = input.IndexOf('P');
                }
            }

            var commands = Console.ReadLine();
            var deadPlayer = false;
            var winPlayer = false;

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                switch (command)
                {
                    case 'U':
                        if (rowPlayer - 1 >= 0)
                        {
                            if (matrix[rowPlayer - 1][colPlayer] == 'B')
                            {
                                deadPlayer = true;
                                matrix[rowPlayer][colPlayer] = '.';
                                rowPlayer = rowPlayer - 1;
                                matrix = movePlayer(matrix, rowPlayer, colPlayer);
                                break;
                            }
                            else
                            {
                                matrix[rowPlayer][colPlayer] = '.';
                                rowPlayer = rowPlayer - 1;
                                matrix[rowPlayer][colPlayer] = 'P';
                                matrix = movePlayer(matrix, rowPlayer, colPlayer);
                            }
                        }
                        else
                        {
                            winPlayer = true;
                            matrix[rowPlayer][colPlayer] = '.';
                            matrix = movePlayer(matrix, rowPlayer, colPlayer);
                            break;
                        }
                        break;

                    case 'D':
                        if (rowPlayer + 1 < rows)
                        {
                            if (matrix[rowPlayer + 1][colPlayer] == 'B')
                            {
                                deadPlayer = true;
                                matrix[rowPlayer][colPlayer] = '.';
                                rowPlayer = rowPlayer + 1;
                                matrix = movePlayer(matrix, rowPlayer, colPlayer);
                                break;
                            }
                            else
                            {
                                matrix[rowPlayer][colPlayer] = '.';
                                rowPlayer = rowPlayer + 1;
                                matrix[rowPlayer][colPlayer] = 'P';
                                matrix = movePlayer(matrix, rowPlayer, colPlayer);
                            }
                        }
                        else
                        {
                            winPlayer = true;
                            matrix[rowPlayer][colPlayer] = '.';
                            matrix = movePlayer(matrix, rowPlayer, colPlayer);
                            break;
                        }
                        break;

                    case 'R':
                        if (colPlayer + 1 < cols)
                        {
                            if (matrix[rowPlayer][colPlayer + 1] == 'B')
                            {
                                deadPlayer = true;
                                matrix[rowPlayer][colPlayer] = '.';
                                colPlayer = colPlayer + 1;
                                matrix = movePlayer(matrix, rowPlayer, colPlayer);
                                break;
                            }
                            else
                            {
                                matrix[rowPlayer][colPlayer] = '.';
                                colPlayer = colPlayer + 1;
                                matrix[rowPlayer][colPlayer] = 'P';
                                matrix = movePlayer(matrix, rowPlayer, colPlayer);
                            }
                        }
                        else
                        {
                            winPlayer = true;
                            matrix[rowPlayer][colPlayer] = '.';
                            matrix = movePlayer(matrix, rowPlayer, colPlayer);
                            break;
                        }
                        break;

                    case 'L':
                        if (colPlayer - 1 >= 0)
                        {
                            if (matrix[rowPlayer][colPlayer - 1] == 'B')
                            {
                                deadPlayer = true;
                                matrix[rowPlayer][colPlayer] = '.';
                                colPlayer = colPlayer - 1;
                                matrix = movePlayer(matrix, rowPlayer, colPlayer);
                                break;
                            }
                            else
                            {
                                matrix[rowPlayer][colPlayer] = '.';
                                colPlayer = colPlayer - 1;
                                matrix[rowPlayer][colPlayer] = 'P';
                                matrix = movePlayer(matrix, rowPlayer, colPlayer);
                            }
                        }
                        else
                        {
                            winPlayer = true;
                            matrix[rowPlayer][colPlayer] = '.';
                            matrix = movePlayer(matrix, rowPlayer, colPlayer);
                            break;
                        }
                        break;
                }


                if (winPlayer)
                {
                    foreach (var item in matrix)
                    {
                        Console.WriteLine(string.Join("", item));
                    }
                    Console.WriteLine($"won: {rowPlayer} {colPlayer}");
                    break;
                }
                else if (deadPlayer)
                {
                    foreach (var item in matrix)
                    {
                        Console.WriteLine(string.Join("", item));
                    }
                    Console.WriteLine($"dead: {rowPlayer} {colPlayer}");
                    break;
                }
                else
                {
                    foreach (var item in matrix)
                    {
                        if (item.Contains('P'))
                        {
                            deadPlayer = false;
                            break;
                        }
                        else
                        {
                            deadPlayer = true;
                        }
                    }
                    if (deadPlayer)
                    {
                        foreach (var item in matrix)
                        {
                            Console.WriteLine(string.Join("", item));
                        }
                        Console.WriteLine($"dead: {rowPlayer} {colPlayer}");
                        break;
                    }
                }
            }
        }

        private static char[][] movePlayer(char[][] matrix, int rowPlayer, int colPlayer)
        {
            var copyMatrix = matrix.Select(a => a.ToArray()).ToArray();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    
                    if (matrix[row][col] == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            copyMatrix[row - 1][col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            copyMatrix[row][col - 1] = 'B';
                        }
                        if (row + 1 < matrix.Length)
                        {
                            copyMatrix[row + 1][col] = 'B';
                        }
                        if (col + 1 < matrix[row].Length)
                        {
                            copyMatrix[row][col + 1] = 'B';
                        }
                    }
                }
            }
            return copyMatrix;

        }
    }
}
