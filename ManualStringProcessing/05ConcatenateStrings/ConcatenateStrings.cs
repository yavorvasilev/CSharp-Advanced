
namespace _05ConcatenateStrings
{
    using System;
    using System.Text;

    public class ConcatenateStrings
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var sb = new StringBuilder(1000);

            for (int i = 0; i < count; i++)
            {
                sb.Append(Console.ReadLine()).Append(" ");
            }

            Console.WriteLine(sb);
        }
    }
}
