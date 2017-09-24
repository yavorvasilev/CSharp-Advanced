namespace _02SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            var sizeOfSets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var setN = new HashSet<int>();

            var setM = new HashSet<int>();

            var n = sizeOfSets[0];

            var m = sizeOfSets[1];

            for (int i = 0; i < n + m; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    setN.Add(number);
                }
                else
                {
                    setM.Add(number);
                }
            }
            setN.IntersectWith(setM);

            foreach (var number in setN)
            {
                Console.WriteLine(number);
            }
            //Console.WriteLine();
        }
    }
}
