namespace _05Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        public static void Main()
        {
            var phonebook = new Dictionary<string, string>();
            var input = Console.ReadLine();

            while (input != "search")
            {
                var contact = input.Split('-').ToArray();
                var name = contact[0];
                var number = contact[1];

                phonebook[name] = number;

                input = Console.ReadLine();
            }

            var searchedName = Console.ReadLine();

            while (searchedName != "stop")
            {
                if (phonebook.ContainsKey(searchedName))
                {
                    Console.WriteLine($"{searchedName} -> {phonebook[searchedName]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchedName} does not exist.");
                }

                searchedName = Console.ReadLine();
            }
        }
    }
}
