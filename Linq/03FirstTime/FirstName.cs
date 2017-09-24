namespace _03FirstTime
{
    using System;
    using System.Linq;

    public class FirstName
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split();
            var letters = Console.ReadLine()
                .Split()
                .OrderBy(w => w);

            foreach (var letter in letters)
            {
                var result = names
                    .Where(w => w.ToLower()
                    .StartsWith(letter.ToLower()))
                    .FirstOrDefault();

                if (result != null)
                {
                    Console.WriteLine(result);
                    return;
                }
            }
            Console.WriteLine("No match");
        }
    }
}
