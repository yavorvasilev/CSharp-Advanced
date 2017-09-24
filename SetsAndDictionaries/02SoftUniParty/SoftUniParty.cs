namespace _02SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniParty
    {
        public static void Main()
        {
            var listOfGuests = new SortedSet<string>();

            var guest = Console.ReadLine();

            while (guest != "PARTY")
            {
                listOfGuests.Add(guest);
                guest = Console.ReadLine();
            }

            var comingGuest = Console.ReadLine();

            while (comingGuest != "END")
            {
                if (listOfGuests.Contains(comingGuest))
                {
                    listOfGuests.Remove(comingGuest);
                }
                comingGuest = Console.ReadLine();
            }

            Console.WriteLine(listOfGuests.Count);
            foreach (var invitation in listOfGuests)
            {
                Console.WriteLine(invitation);
            }
        }
    }
}
