namespace _01JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JediMeditation
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var mQueue = new Queue<string>();
            var kQueue = new Queue<string>();
            var pQueue = new Queue<string>();
            var stQueue = new Queue<string>();
            var sb = new StringBuilder();
            bool isThereYoda = false;

            for (int i = 0; i < n; i++)
            {
                var jediSequence = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (jediSequence.Any(x => x[0] == 'y'))
                {
                    isThereYoda = true;
                }

                foreach (var jedi in jediSequence)
                {
                    switch (jedi[0])
                    {
                        case 'm':
                            mQueue.Enqueue(jedi);
                            break;
                        case 'k':
                            kQueue.Enqueue(jedi);
                            break;
                        case 'p':
                            pQueue.Enqueue(jedi);
                            break;
                        case 's':
                            stQueue.Enqueue(jedi);
                            break;
                        case 't':
                            stQueue.Enqueue(jedi);
                            break;
                    }
                }
            }

            if (isThereYoda)
            {
                sb.Append($"{string.Join(" ", mQueue)} ");
                sb.Append($"{string.Join(" ", kQueue)} ");
                sb.Append($"{string.Join(" ", stQueue)} ");
                sb.Append($"{string.Join(" ", pQueue)} ");
            }
            else
            {
                sb.Append($"{string.Join(" ", stQueue)} ");
                sb.Append($"{string.Join(" ", mQueue)} ");
                sb.Append($"{string.Join(" ", kQueue)} ");
                sb.Append($"{string.Join(" ", pQueue)} ");
            }
            Console.WriteLine(sb);
        }
    }
}
