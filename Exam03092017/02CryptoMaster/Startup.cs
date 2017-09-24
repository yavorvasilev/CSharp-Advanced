namespace _02CryptoMaster
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var count = 0;
            var maxCount = 0;

            var sequenceOfNumber = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var maxStep = sequenceOfNumber.Length;

            for (int step = 0; step < maxStep; step++)
            {
                for (int i = 0; i < sequenceOfNumber.Length; i++)
                {
                    var index = i;

                    var startElement = sequenceOfNumber[index];
                    var maxElement = sequenceOfNumber[index];
                    count = 1;
                    while (true)
                    {
                        index += step;
                        if (index >= sequenceOfNumber.Length)
                        {
                            index = (index % sequenceOfNumber.Length);
                        }

                        var nextElement = sequenceOfNumber[index];
                        if (nextElement > maxElement)
                        {
                            count++;
                            maxElement = nextElement;
                        }
                        else
                        {
                            if (count >= maxCount)
                            {
                                maxCount = count;
                            }
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(maxCount);
        }
    }
}
