namespace _01SecondNature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SecondNature
    {
        public static void Main()
        {
            var inputDust = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var inputWaterBucket = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var dustWeiss = new Queue<int>(inputDust);
            var waterBucket = new Stack<int>(inputWaterBucket);
            var secondNature = new Queue<int>();

            while ((dustWeiss.Count != 0) && (waterBucket.Count != 0))
            {
                var reminderWater = 0;
                var reminderDust = 0;

                var dust = dustWeiss.Dequeue();
                var bucket = waterBucket.Pop();

                if (bucket > dust)
                {
                    reminderWater = bucket - dust;
                    if (waterBucket.Count == 0)
                    {
                        waterBucket.Push(reminderWater);
                    }
                    else
                    {
                        reminderWater += waterBucket.Pop();
                        waterBucket.Push(reminderWater);
                    }
                    //nextBucket = 0;

                }
                else if (dust > bucket)
                {
                    reminderDust = dust - bucket;
                    bucket = 0;

                    while ((bucket < reminderDust) && waterBucket.Count != 0)
                    {
                        bucket = waterBucket.Pop();
                        if (bucket - reminderDust > 0)
                        {
                            reminderWater = bucket - reminderDust;
                            reminderDust = 0;
                            if (waterBucket.Count == 0)
                            {
                                waterBucket.Push(reminderWater);
                            }
                            else
                            {
                                reminderWater += waterBucket.Pop();
                                waterBucket.Push(reminderWater);
                            }
                            break;
                        }
                        else if (bucket - reminderDust < 0)
                        {
                            reminderDust = reminderDust - bucket;
                            bucket = 0;
                        }
                        else if (bucket - reminderDust == 0)
                        {
                            secondNature.Enqueue(reminderDust);
                            bucket = 0;
                            reminderDust = 0;
                        }
                    }
                    if (reminderDust > 0)
                    {
                        dustWeiss.Enqueue(reminderDust);
                        for (int i = 1; i < dustWeiss.Count; i++)
                        {
                            var reminder = dustWeiss.Dequeue();
                            dustWeiss.Enqueue(reminder);
                        }
                    }
                }
                else if(dust == bucket)
                {
                    secondNature.Enqueue(dust);
                }
            }

            if (waterBucket.Count > 0)
            {
                Console.WriteLine($"{string.Join(" ",waterBucket)}");
            }
            if (dustWeiss.Count > 0)
            {
                Console.WriteLine($"{string.Join(" ", dustWeiss)}");
            }
            if (secondNature.Count > 0)
            {
                Console.WriteLine($"{string.Join(" ", secondNature)}");
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
