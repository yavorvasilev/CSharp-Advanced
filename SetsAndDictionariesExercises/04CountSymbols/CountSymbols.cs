namespace _04CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];

                if (symbols.ContainsKey(symbol))
                {
                    symbols[symbol] += 1;
                }
                else
                {
                    symbols[symbol] = 1;
                }
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
