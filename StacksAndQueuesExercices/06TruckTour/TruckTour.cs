namespace _06TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class TruckTour
    {
        public static void Main()
        {
            long nStations = long.Parse(Console.ReadLine());
            long fuelInTank = 0;
            var stations = new Queue<string>();

            for (long i = 0; i < nStations; i++)
            {
                var station = Console.ReadLine();

                stations.Enqueue(station);

            }

            for (long i = 0; i < nStations; i++, fuelInTank = 0)
            {
                foreach (var station in stations)
                {
                    var fuelAndDistace = station
                        .Trim()
                        .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToArray();

                    long fuel = fuelAndDistace[0] + fuelInTank;
                    long distance = fuelAndDistace[1];

                    fuelInTank = fuel - distance;

                    if (fuelInTank < 0)
                    {
                        break;
                    }
                }
                if (fuelInTank >= 0)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    var station = stations.Dequeue();
                    stations.Enqueue(station);
                }
            }
            
        }
    }
}
