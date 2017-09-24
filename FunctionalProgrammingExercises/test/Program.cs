namespace _10PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        private static List<string> partyParticipants;
        public static void Main()
        {
            Func<string, string, List<string>, List<string>> criteriaStartsWith = (command, criteria, names) => {
                var listOfnames = new List<string>();
                if (command == "Remove")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (!names[i].StartsWith(criteria))
                        {
                            listOfnames.Add(names[i]);
                        }
                    }
                    return listOfnames;
                }
                else
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].StartsWith(criteria))
                        {
                            listOfnames.Add(names[i]);
                            listOfnames.Add(names[i]);
                        }
                        else
                        {
                            listOfnames.Add(names[i]);
                        }
                        
                    }

                    return listOfnames;
                }
            };
            Func<string, string, List<string>, List<string>> criteriaEndsWith = (command, criteria, names) => {
                var listOfnames = new List<string>();
                if (command == "Remove")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (!names[i].EndsWith(criteria))
                        {
                            listOfnames.Add(names[i]);
                        }
                    }
                    return listOfnames;
                }
                else
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].EndsWith(criteria))
                        {
                            listOfnames.Add(names[i]);
                            listOfnames.Add(names[i]);
                        }
                        else
                        {
                            listOfnames.Add(names[i]);
                        }
                    }

                    return listOfnames;
                }
            };
            Func<string, int, List<string>, List<string>> criteriaLenght = (command, criteria, names) => {
                var listOfnames = new List<string>();
                if (command == "Remove")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].Length != criteria)
                        {
                            listOfnames.Add(names[i]);
                        }
                    }
                    return listOfnames;
                }
                else
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].Length == criteria)
                        {
                            listOfnames.Add(names[i]);
                            listOfnames.Add(names[i]);
                        }
                        else
                        {
                            listOfnames.Add(names[i]);
                        }
                    }

                    return listOfnames;
                }
            };

            partyParticipants = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var commandAndCriterias = Console.ReadLine();

            while (commandAndCriterias != "Party!")
            {
                var tokens = commandAndCriterias.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var criteria = tokens[1];
                var param = tokens[2];

                if (criteria == "StartsWith")
                {
                    partyParticipants = criteriaStartsWith(command, param, partyParticipants);
                }
                else if (criteria == "Length")
                {
                    partyParticipants = criteriaLenght(command, int.Parse(param), partyParticipants);
                }
                else
                {
                    partyParticipants = criteriaEndsWith(command, param, partyParticipants);
                }


                commandAndCriterias = Console.ReadLine();
            }

            if (partyParticipants.Count != 0)
            {
                Console.WriteLine(string.Join(", ", partyParticipants) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
