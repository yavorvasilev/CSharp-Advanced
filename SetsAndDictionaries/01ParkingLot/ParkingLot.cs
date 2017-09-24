namespace _01ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        public static void Main()
        {
            var carNumbers = new SortedSet<string>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var carNumber = input
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var inOrOut = carNumber[0];
                var number = carNumber[1];

                if (inOrOut == "IN")
                {
                    carNumbers.Add(number);
                }
                else
                {
                    carNumbers.Remove(number);
                }
                input = Console.ReadLine();
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
