namespace _11PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            var plantsNumber = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var daysPlantsDie = new int[plantsNumber];
            var previusPlants = new Stack<int>();

            previusPlants.Push(0);

            for (int i = 1; i < plantsNumber; i++)
            {
                var lastDay = 0;

                while (previusPlants.Count > 0 && plants[previusPlants.Peek()] >= plants[i])
                {
                    lastDay = Math.Max(lastDay, daysPlantsDie[previusPlants.Pop()]);
                    daysPlantsDie[i] = lastDay + 1; // Fast !!!
                }

                //if (previusPlants.Count > 0)
                //{
                //    daysPlantsDie[i] = lastDay + 1;
                //}
                previusPlants.Push(i);
            }
            Console.WriteLine(daysPlantsDie.Max());
        }
    }
}
