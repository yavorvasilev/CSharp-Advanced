namespace _02NaturesProphet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NaturesProphet
    {
        public static void Main()
        {
            var matriceDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matriceDimensions[0];
            var cols = matriceDimensions[1];

            var garden = FillMatrice(rows, cols);

            var coordinateOfFlower = Console.ReadLine();

            while (coordinateOfFlower != "Bloom Bloom Plow")
            {
                var tokens = coordinateOfFlower.Split().Select(int.Parse).ToArray();
                var rowFlower = tokens[0];
                var colFlower = tokens[1];

                BloomFlowers(rowFlower, colFlower, garden);


                coordinateOfFlower = Console.ReadLine();
            }

            PrintGarden(garden);
            Console.WriteLine();
        }

        private static void PrintGarden(int[][] garden)
        {
            foreach (var item in garden)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        private static void BloomFlowers(int rowFlower, int colFlower, int[][] garden)
        {
            for (int i = 0; i < garden.Length; i++)
            {
                garden[rowFlower][i] += 1;
                garden[i][colFlower] += 1;
            }
            garden[rowFlower][colFlower] -= 1;
        }

        private static int[][] FillMatrice(int rows, int cols)
        {
            var matrice = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrice[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrice[row][col] = 0;
                }
            }

            return matrice;
        }
    }
}
