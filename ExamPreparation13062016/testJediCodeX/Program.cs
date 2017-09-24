using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.JediGalaxy
{
    class JediGalaxy
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var input = Console.ReadLine();

            var matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                for (int col = 0; col < matrixSize[1]; col++)
                {
                    matrix[row, col] = row * matrixSize[0] + col;
                }
            }

            var stars = 0L;

            while (input != "Let the Force be with you")
            {
                var goodPoints = input.Split(' ').Select(int.Parse).ToArray();
                var badPoints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var row = badPoints[0];
                var col = badPoints[1];

                while (row >= 0 || col >= 0)
                {
                    if (row < matrixSize[0] && row >= 0 && col >= 0 && col < matrixSize[1])
                    {
                        matrix[row, col] = 0;
                    }

                    row--;
                    col--;
                }

                row = goodPoints[0];
                col = goodPoints[1];

                while (row >= 0 || col < goodPoints[1])
                {
                    if (row >= 0 && row < matrixSize[0] && col < matrixSize[1] && col >= 0)
                    {
                        stars += matrix[row, col];
                    }

                    row--;
                    col++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(stars);
        }
    }
}