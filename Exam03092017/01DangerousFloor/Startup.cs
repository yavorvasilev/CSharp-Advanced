namespace _01DangerousFloor
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
            var board = new char[8][];

            FillingTheBoard(board);

            string moves;
            while ((moves = Console.ReadLine()) != "END")
            {
                var movesTokens = moves.ToLower().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                var figure = movesTokens[0][0];
                var startPosition = movesTokens[0].Skip(1).ToArray();
                var endPosition = movesTokens[1].ToCharArray();

                var startPositionRow = (int)Char.GetNumericValue(startPosition[0]);
                var startPositionCol = (int)Char.GetNumericValue(startPosition[1]);

                var endPositionRow = (int)Char.GetNumericValue(endPosition[0]);
                var endPositionCol = (int)Char.GetNumericValue(endPosition[1]);

                if (CheckStartPositionHaveFigure(figure, startPositionRow, startPositionCol, board)) //ok!
                {
                    if (CheckFigureForInvalidMove(figure, startPositionRow, startPositionCol, endPositionRow, endPositionCol))
                    {
                        if (CheckingForOutOfBoard(endPositionRow, endPositionCol))
                        {
                            board[endPositionRow][endPositionCol] = figure;
                            board[startPositionRow][startPositionCol] = 'x';
                        }
                        else
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                }
            }
        }

        private static bool CheckingForOutOfBoard(int endPositionRow, int endPositionCol)
        {
            if (endPositionRow < 8 && endPositionRow >= 0 && endPositionCol < 8 && endPositionCol >= 0)
            {
                return true;
            }
            return false;
        }

        private static bool CheckFigureForInvalidMove(char figure, int startPositionRow, int startPositionCol, int endPositionRow, int endPositionCol)
        {

            switch (figure)
            {
                case 'k':
                    return CheckKingMove(startPositionRow, startPositionCol, endPositionRow, endPositionCol);

                case 'r':
                    return ChekingRookMove(startPositionRow, startPositionCol, endPositionRow, endPositionCol);

                case 'b':
                     return ChekingBishopMove(startPositionRow, startPositionCol, endPositionRow, endPositionCol);

                case 'q':
                    return ChekingQueenMove(startPositionRow, startPositionCol, endPositionRow, endPositionCol);

                case 'p':
                    return ChekingPawnMove(startPositionRow, startPositionCol, endPositionRow, endPositionCol);
            }
            return false;
        }

        private static bool ChekingPawnMove(int startPositionRow, int startPositionCol, int endPositionRow, int endPositionCol)
        {
            if (startPositionRow - endPositionRow == 1 && startPositionCol == endPositionCol)
            {
                return true;
            }
            return false;
        }

        private static bool ChekingQueenMove(int startPositionRow, int startPositionCol, int endPositionRow, int endPositionCol)
        {
            if (startPositionRow != endPositionRow && startPositionCol != endPositionCol)
            {
                return true;
            }
            if (startPositionRow == endPositionRow && startPositionCol != endPositionCol)
            {
                return true;
            }
            if (startPositionRow != endPositionRow && startPositionCol == endPositionCol)
            {
                return true;
            }
            return false;
        }

        private static bool ChekingBishopMove(int startPositionRow, int startPositionCol, int endPositionRow, int endPositionCol)
        {
            if (startPositionRow != endPositionRow && startPositionCol != endPositionCol)
            {
                return true;
            }
            return false;
        }

        private static bool ChekingRookMove(int startPositionRow, int startPositionCol, int endPositionRow, int endPositionCol)
        {
            if (startPositionRow == endPositionRow && startPositionCol != endPositionCol)
            {
                return true;
            }
            if (startPositionRow != endPositionRow && startPositionCol == endPositionCol)
            {
                return true;
            }
            return false;
        }

        private static bool CheckKingMove(int startPositionRow, int startPositionCol, int endPositionRow, int endPositionCol)
        {
            if (Math.Abs(startPositionRow - endPositionRow) == 1 && Math.Abs(startPositionCol - endPositionCol) == 1)
            {
                return true;
            }
            if (Math.Abs(startPositionRow - endPositionRow) == 1 && startPositionCol== endPositionCol)
            {
                return true;
            }
            if (startPositionRow == endPositionRow && Math.Abs(startPositionCol - endPositionCol) == 1)
            {
                return true;
            }
            return false;
        }

        private static bool CheckStartPositionHaveFigure(char figure, int startPositionRow, int startPositionCol, char[][] board)
        {
            if (board[startPositionRow][startPositionCol] == figure)
            {
                return true;
            }
            return false;
            
        }

        private static void FillingTheBoard(char[][] board)
        {
            for (int row = 0; row < 8; row++)
            {
                var line = Console.ReadLine().ToLower().Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                board[row] = new char[8];
                for (int col = 0; col < line.Length; col++)
                {
                    board[row][col] = line[col];
                }
            }
        }
    }
}
