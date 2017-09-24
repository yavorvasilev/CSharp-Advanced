namespace _05MinEvenNumber
{
    using System;
    using System.Linq;

    public class MinEvenNumber
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("{0:f2}",Console.ReadLine()
               .Split()
               .Select(double.Parse)
               .Where(n => n % 2 == 0)
               .Min());
            }
            catch (Exception)
            {
                Console.WriteLine("No match");
            }
        }
    }
}
