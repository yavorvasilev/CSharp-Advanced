namespace _02ParkingSystem
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var dimensionsOfParking = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = dimensionsOfParking.First();
            var cols = dimensionsOfParking.Last();

            var parking = new int[rows][];

            CreateParking(parking, rows, cols);

            string coordinateOfParkingPosition;
            while ((coordinateOfParkingPosition = Console.ReadLine()) != "stop")
            {
                var coordinateTokens = coordinateOfParkingPosition
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                var entryRow = coordinateTokens[0];
                var rowOfParkingPlace = coordinateTokens[1];
                var colOfParkingPlace = coordinateTokens[2];

                int shortestDistance = FindShortestDistanceToParkingPlace(parking, entryRow, rowOfParkingPlace, colOfParkingPlace);

                if (shortestDistance != -1)
                {
                    Console.WriteLine(shortestDistance);
                }
                else
                {
                    Console.WriteLine($"Row {rowOfParkingPlace} full");
                }
            }
        }

        private static int FindShortestDistanceToParkingPlace(int[][] parking, int entryRow, int rowOfParkingPlace, int colOfParkingPlace)
        {
            var count = 0;

            count = Math.Abs(rowOfParkingPlace - entryRow) + 1;
            if (parking[rowOfParkingPlace][colOfParkingPlace] == 0)
            {
                count += colOfParkingPlace;
                parking[rowOfParkingPlace][colOfParkingPlace] = 1;
            }
            else if (parking[rowOfParkingPlace][colOfParkingPlace] == 1)
            {
                var a = parking[rowOfParkingPlace];
                var index = FindSpot(parking[rowOfParkingPlace], colOfParkingPlace);
                if (index != -1)
                {
                    count += index;
                    parking[rowOfParkingPlace][index] = 1;
                }
                else
                {
                    count = index;
                }
                   
            }

            return count;
        }

        private static int FindSpot(int[] parkingRow, int colOfParkingPlace)
        {
            var col1 = 0;
            var col2 = 0;
            bool havePlace = false;

            for (int col = colOfParkingPlace; col > 0 ; col--)
            {
                if (parkingRow[col] == 0)
                {
                    col1 = col;
                    havePlace = true;
                    break;
                }
            }

            for (int col = colOfParkingPlace; col < parkingRow.Length; col++)
            {
                if (parkingRow[col] == 0)
                {
                    col2 = col;
                    havePlace = true;
                    break;
                }
            }

            if (!havePlace)
            {
                return -1;
            }

            if (Math.Abs(col1 - colOfParkingPlace) > Math.Abs(col2 - colOfParkingPlace))
            {
                return col2;
            }
            else if (Math.Abs(col1 - colOfParkingPlace) < Math.Abs(col2 - colOfParkingPlace))
            {
                return col1;
            }
            else
            {
                return col1;
            }
            
        }

        private static void CreateParking(int[][] parking, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                parking[row] = new int[cols];
            }
        }
    }
}
