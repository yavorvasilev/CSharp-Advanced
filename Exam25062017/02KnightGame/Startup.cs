namespace _02KnightGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var sizeOfTheBoard = int.Parse(Console.ReadLine());

            var board = new int[sizeOfTheBoard][];

            CreateBoard(sizeOfTheBoard, board);

            ReadKnightPosition(board, sizeOfTheBoard);

            var removedKnight = 0;

            while (true)
            {
                var knightWihtMoreAttacks = CheckTheKnightWithMoreAttacks(board, sizeOfTheBoard);
                var countAttack = knightWihtMoreAttacks[0];
                var rowOfKnight = knightWihtMoreAttacks[1];
                var colOfKnight = knightWihtMoreAttacks[2];

                if (countAttack > 0)
                {
                    board[rowOfKnight][colOfKnight] = 0;
                    removedKnight++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedKnight);
        }

        private static List<int> CheckTheKnightWithMoreAttacks(int[][] board, int sizeOfTheBoard)
        {
            var maxPossibleAttack = 0;
            var maxRow = 0;
            var maxCol = 0;

            for (int row = 0; row < sizeOfTheBoard; row++)
            {
                for (int col = 0; col < sizeOfTheBoard; col++)
                {
                    if (board[row][col] == 1)
                    {
                        var numberOfAttack = GetNumberOfAttack(board, row, col, sizeOfTheBoard);

                        if (numberOfAttack > maxPossibleAttack)
                        {
                            maxPossibleAttack = numberOfAttack;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
            }
            var result = new List<int>();
            result.Add(maxPossibleAttack);
            result.Add(maxRow);
            result.Add(maxCol);

            return result;
        }

        private static int GetNumberOfAttack(int[][] board, int row, int col, int sizeOfTheBoard)
        {
            var countOfKnights = 0;

            if (row + 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard && board[row + 1][col + 2] == 1)
            {
                countOfKnights++;
            }
            if (row + 1 < sizeOfTheBoard && col - 2 >= 0 && board[row + 1][col - 2] == 1)
            {
                countOfKnights++;
            }
            if (row - 1 >= 0 && col + 2 < sizeOfTheBoard && board[row - 1][col + 2] == 1)
            {
                countOfKnights++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && board[row - 1][col - 2] == 1)
            {
                countOfKnights++;
            }
            if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2][col - 1] == 1)
            {
                countOfKnights++;
            }
            if (row + 2 < sizeOfTheBoard && col - 1 >= 0 && board[row + 2][col - 1] == 1)
            {
                countOfKnights++;
            }
            if (row - 2 >= 0 && col + 1 < sizeOfTheBoard && board[row - 2][col + 1] == 1)
            {
                countOfKnights++;
            }
            if (row + 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard && board[row + 2][col + 1] == 1)
            {
                countOfKnights++;
            }

            return countOfKnights;
        }

        private static void ReadKnightPosition(int[][] board, int sizeOfTheBoard)
        {
            for (int row = 0; row < sizeOfTheBoard; row++)
            {
                var rowString = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowString.Length; col++)
                {
                    if (rowString[col] == 'K')
                    {
                        board[row][col] = 1;
                    }
                }
            }
        }

        private static void CreateBoard(int sizeOfTheBoard, int[][] board)
        {
            for (int row = 0; row < sizeOfTheBoard; row++)
            {
                board[row] = new int [sizeOfTheBoard];

                for (int col = 0; col < sizeOfTheBoard; col++)
                {
                    board[row][col] = 0;
                }
            }
        }
    }
}
