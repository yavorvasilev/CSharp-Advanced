namespace _13SrabskoUnleashed
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class SrabskoUnleashed
    {
        public static void Main()
        {
            var venues = new Dictionary<string, Dictionary<string, int>>();
            
            var line = Console.ReadLine();

            while (line != "End")
            {
                var venueTokens = line.Split(new[] { " @" }, StringSplitOptions.RemoveEmptyEntries);

                if (!(venueTokens.Length > 1))
                {
                    line = Console.ReadLine();
                    continue;
                }
                var singer = venueTokens[0];

                var venuAndTickets = venueTokens[1].Split();

                var ticketPrice = 0;
                var ticketCount = 0;
                try
                {
                    ticketPrice = int.Parse(venuAndTickets[venuAndTickets.Length - 2]);
                    ticketCount = int.Parse(venuAndTickets[venuAndTickets.Length - 1]);
                }
                catch (Exception)
                {
                    line = Console.ReadLine();
                    continue;
                }

                var venue = new StringBuilder();
                for (int i = 0; i < venuAndTickets.Length - 2; i++)
                {
                    venue.Append(venuAndTickets[i]);
                    venue.Append(" ");
                }

                if (venues.ContainsKey(venue.ToString()))
                {
                    if (venues[venue.ToString()].ContainsKey(singer))
                    {
                        venues[venue.ToString()][singer] += ticketPrice * ticketCount;
                    }
                    else
                    {
                        venues[venue.ToString()].Add(singer, ticketPrice * ticketCount);
                    }
                }
                else
                {
                    venues[venue.ToString()] = new Dictionary<string, int>() { { singer, ticketPrice * ticketCount } };
                }
                line = Console.ReadLine();
            }

            foreach (var venue in venues)
            {
                Console.WriteLine(venue.Key);

                foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
