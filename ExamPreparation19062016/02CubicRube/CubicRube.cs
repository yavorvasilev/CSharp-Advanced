namespace _02CubicRube
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CubicRube
    {
        public static void Main()
        {
            var dimensionOfCube = long.Parse(Console.ReadLine());

            var cubicRube = new long[dimensionOfCube , dimensionOfCube , dimensionOfCube];
            var sumOfcells = dimensionOfCube * dimensionOfCube * dimensionOfCube;
            var countOfValues = 0l;
            var sumOfValues = 0l;

            for (int a = 0; a < cubicRube.GetLength(0); a++)
            {
                for (int b = 0; b < cubicRube.GetLength(1); b++)
                {
                    for (int c = 0; c < cubicRube.GetLength(2); c++)
                    {
                        cubicRube[a , b , c] = 0;
                    }
                }
            }

            var pointAndValue = Console.ReadLine();

            while (pointAndValue != "Analyze")
            {
                var tokens = pointAndValue.Trim().Split().Select(long.Parse).ToList();
                var a = tokens[0];
                var b = tokens[1];
                var c = tokens[2];
                var value = tokens[3];

                if (value != 0)
                {
                    if ((a >= 0 && a < dimensionOfCube) && (b >= 0 && b < dimensionOfCube) && (c >= 0 && c < dimensionOfCube))
                    {
                        cubicRube[a, b, c] += value;
                        sumOfValues += value;
                        countOfValues++;
                    }
                }

                pointAndValue = Console.ReadLine();
            }

           

            //for (int a = 0; a < cubicRube.GetLength(0); a++)
            //{
            //    for (int b = 0; b < cubicRube.GetLength(1); b++)
            //    {
            //        for (int c = 0; c < cubicRube.GetLength(2); c++)
            //        {
            //            if (cubicRube[a, b, c] != 0)
            //            {
            //                sumOfValues += cubicRube[a, b, c];
            //            }
            //        }
            //    }
            //}

            Console.WriteLine(sumOfValues);
            Console.WriteLine(sumOfcells - countOfValues);

        }
    }
}
