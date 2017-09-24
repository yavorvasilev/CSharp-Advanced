namespace _02JediGalaxy
{
    using System;
    using System.Linq;

    public class JediGalaxy
    {
        private static long stars;
        public static void Main()
        {
            var dimensionOfGalaxy = Console.ReadLine();
            int[][] galaxy = CreateGalaxy(dimensionOfGalaxy);

            var input = Console.ReadLine();
            while (input != "Let the Force be with you")
            {
                var ivosRowAndCol = input;
                input = Console.ReadLine();
                var evilRowAndCol = input;
                EvilDestroyStars(evilRowAndCol, galaxy);
                CollectStars(ivosRowAndCol, galaxy);

                input = Console.ReadLine();
            }
            Console.WriteLine(stars);
        }

        private static void CollectStars(string ivosRowAndCol, int[][] galaxy)
        {
            var tokens = ivosRowAndCol.Split().Select(int.Parse).ToArray();
            var ivoRow = tokens[0];
            var ivoCol = tokens[1];

            for (int row = ivoRow, col = ivoCol; row >= 0 && col < galaxy[0].Length; row--, col++)
            {
                if (row < galaxy.Length && col >= 0)
                {
                    stars += galaxy[row][col];
                }
            }

        }

        private static void EvilDestroyStars(string evilRowAndCol, int[][] galaxy)
        {
            var tokens = evilRowAndCol.Split().Select(int.Parse).ToArray();
            var evilRow = tokens[0];
            var evilCol = tokens[1];

            for (int row = evilRow, col = evilCol; row >= 0 && col >= 0; row--, col--)
            {
                if (row < galaxy.Length && col < galaxy[0].Length)
                {
                    galaxy[row][col] = 0;
                }
            }
        }

        private static int[][] CreateGalaxy(string dimensionOfGalaxy)
        {
            var tokens = dimensionOfGalaxy.Split().Select(int.Parse).ToArray();
            var rows = tokens[0];
            var cols = tokens[1];
            var galaxy = new int[rows][];
            var count = 0;

            for (int row = 0; row < galaxy.Length; row++)
            {
                galaxy[row] = new int[cols];
                for (int col = 0; col < galaxy[row].Length; col++)
                {
                    galaxy[row][col] = count;
                    count++;
                }
            }
            return galaxy;
        }
    }
}
