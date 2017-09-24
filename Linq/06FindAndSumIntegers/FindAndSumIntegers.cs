namespace _06FindAndSumIntegers
{
    using System;
    using System.Linq;

    public class FindAndSumIntegers
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var sum = input
                .Split()
                .Select(w => 
                {
                    long value;
                    bool success = long.TryParse(w, out value);
                    return new { value, success };
                })
                .Where(n => n.success)
                .Select(n => n.value)
                .ToList()
                .Sum();

            if (sum != 0)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No match");
            }
            
        }
    }
}
