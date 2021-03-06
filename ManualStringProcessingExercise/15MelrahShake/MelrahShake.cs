﻿namespace _15MelrahShake
{
    using System;

    public class MelrahShake
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                var firstIndex = text.IndexOf(pattern);
                var lastIndex = text.LastIndexOf(pattern);

                if (firstIndex == -1 || firstIndex == lastIndex)
                {
                    break;
                }

                text = text.Remove(lastIndex, pattern.Length);
                text = text.Remove(firstIndex, pattern.Length);
                Console.WriteLine("Shaked it.");

                if (pattern.Length <= 1)
                {
                    break;
                }
                pattern = pattern.Remove(pattern.Length / 2, 1);

            }

            Console.WriteLine("No shake." + Environment.NewLine + text);
        }
    }
}
