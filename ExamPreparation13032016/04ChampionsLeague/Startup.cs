namespace _04ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        private static readonly IDictionary<string, int> teamsAndVictories = new Dictionary<string, int>();
        private static readonly IDictionary<string, HashSet<string>> teamsAndOpponents = new Dictionary<string, HashSet<string>>();

        public static void Main()
        {
            var pattern = @"\b([a-zA-Z\s?]+)\s|\s([a-zA-Z\s?]+)\s|\s([0-9]|10):([0-9]|10)\s|\s([0-9]|10):([0-9]|10)";

            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                var regex = new Regex(pattern);

                var matches = regex.Matches(input);

                if (matches.Count == 4)
                {
                    var firstTeam = matches[0].ToString().Trim();

                    var secondTeam = matches[1].ToString().Trim();

                    var firstScores = matches[2].ToString().Trim();

                    var secondScores = matches[3].ToString().Trim();

                    RegistrationTeam(firstTeam, secondTeam);

                    int winner = GetWinner(firstScores, secondScores);

                    if (winner == 1)
                    {
                        teamsAndVictories[firstTeam]++;
                    }
                    else
                    {
                        teamsAndVictories[secondTeam]++;
                    }
                }
            }
            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var team in teamsAndVictories.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- Wins: {team.Value}");
                Console.WriteLine($"- Opponents: {string.Join(", ",teamsAndOpponents[team.Key].OrderBy(x => x))}");
            }
        }

        private static int GetWinner(string firstScores, string secondScores)
        {
            var firstScoresFromFirstMatch = int.Parse(firstScores.Split(':').First());

            var secondScoresFromFirstMatch = int.Parse(firstScores.Split(':').Last());

            var firstScoresFromSecondMatch = int.Parse(secondScores.Split(':').First());

            var secondScoresFromSecondMatch = int.Parse(secondScores.Split(':').Last());

            var totalScoresFirstTeam = firstScoresFromFirstMatch + secondScoresFromSecondMatch;

            var totalScoresSecondTeam = secondScoresFromFirstMatch + firstScoresFromSecondMatch;

            if (totalScoresFirstTeam > totalScoresSecondTeam)
            {
                return 1;
            }
            else if (totalScoresFirstTeam < totalScoresSecondTeam)
            {
                return -1;
            }
            else
            {
                if (secondScoresFromFirstMatch > secondScoresFromSecondMatch)
                {
                    return -1;
                }
                else if (secondScoresFromFirstMatch < secondScoresFromSecondMatch)
                {
                    return 1;
                }
            }

            return 0;
        }

        private static void RegistrationTeam(string firstTeam, string secondTeam)
        {
            if (!teamsAndVictories.ContainsKey(firstTeam))
            {
                teamsAndVictories[firstTeam] = 0;
            }
            if (!teamsAndVictories.ContainsKey(secondTeam))
            {
                teamsAndVictories[secondTeam] = 0;
            }
            if (!teamsAndOpponents.ContainsKey(firstTeam))
            {
                teamsAndOpponents[firstTeam] = new HashSet<string>();
            }
            teamsAndOpponents[firstTeam].Add(secondTeam);
            if (!teamsAndOpponents.ContainsKey(secondTeam))
            {
                teamsAndOpponents[secondTeam] = new HashSet<string>();
            }
            teamsAndOpponents[secondTeam].Add(firstTeam);
        }
    }
}
