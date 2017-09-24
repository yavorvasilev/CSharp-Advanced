namespace _03FormattingNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FormattingNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var a = int.Parse(input[0]);
            var b = double.Parse(input[1]);
            var c = double.Parse(input[2]);

            Console.WriteLine($"{a:X}");
            Console.WriteLine($"{a:x2}");
        }
    }
}
