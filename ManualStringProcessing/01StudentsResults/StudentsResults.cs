namespace _01StudentsResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StudentsResults
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");

            for (int i = 0; i < number; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var firstNum = double.Parse(tokens[1]);
                var secondNum = double.Parse(tokens[2]);
                var thirdNum = double.Parse(tokens[3]);
                var average = (firstNum + secondNum + thirdNum) / 3;

                Console.WriteLine("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", name, firstNum, secondNum, thirdNum, average);
            }
        }
    }
}
