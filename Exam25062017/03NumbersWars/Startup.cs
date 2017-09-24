namespace _03NumbersWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {

        public static void Main()
        {
            int turns = 0;

            Queue<KeyValuePair<char, int>> firstDeck = GetDeck();

            Queue<KeyValuePair<char, int>> secondDeck = GetDeck();

            var tooManyTurns = false;


            while (firstDeck.Count != 0 && secondDeck.Count != 0)
            {
                if (turns >= 1000000)
                {
                    tooManyTurns = true;
                    break;
                }

                Battle(firstDeck, secondDeck);
                turns++;
            }

            if (tooManyTurns)
            {
                if (firstDeck.Count > secondDeck.Count)
                {
                    Console.WriteLine($"First player wins after {turns} turns");
                }
                else if(firstDeck.Count < secondDeck.Count)
                {
                    Console.WriteLine($"Second player wins after {turns} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {turns} turns");
                }
            }
            else
            {
                if (firstDeck.Count > 0)
                {
                    Console.WriteLine($"First player wins after {turns} turns");
                }
                else if (secondDeck.Count > 0)
                {
                    Console.WriteLine($"Second player wins after {turns} turns");
                }
            }
        }

        private static void Battle(Queue<KeyValuePair<char, int>> firstDeck, Queue<KeyValuePair<char, int>> secondDeck)
        {
            var winnerHand = new List<KeyValuePair<char, int>>();
            var firstPlayerCard = firstDeck.Dequeue();
            var secondPlayerCard = secondDeck.Dequeue();

            int firstPlayerCardNumber = firstPlayerCard.Value;

            int secondPlayerCardNumber = secondPlayerCard.Value;

            winnerHand.Add(firstPlayerCard);
            winnerHand.Add(secondPlayerCard);

            if (firstPlayerCardNumber > secondPlayerCardNumber)
            {
                AddingWinnerHandToDeck(winnerHand, firstDeck);
            }
            else if (firstPlayerCardNumber < secondPlayerCardNumber)
            {
                AddingWinnerHandToDeck(winnerHand, secondDeck);
            }
            else
            {
                War(winnerHand, firstDeck, secondDeck);
            }


        }

        private static void War(List<KeyValuePair<char, int>> winnerHand, Queue<KeyValuePair<char, int>> firstDeck, Queue<KeyValuePair<char, int>> secondDeck)
        {
            var isWinner = false;

            while (!isWinner)
            {
                List<KeyValuePair<char, int>> firstPlayerWarHand = GedCardsForWar(firstDeck);

                winnerHand.AddRange(firstPlayerWarHand);

                List<KeyValuePair<char, int>> secondPlayerWarHand = GedCardsForWar(secondDeck);

                winnerHand.AddRange(secondPlayerWarHand);

                var sumOfCardFirstPlayer = firstPlayerWarHand.Sum(c => (int)c.Key);

                var sumOfCardSecondPlayer = secondPlayerWarHand.Sum(c => (int)c.Key);

                if (sumOfCardFirstPlayer > sumOfCardSecondPlayer)
                {
                    AddingWinnerHandToDeck(winnerHand, firstDeck);
                    isWinner = true;
                }
                else if (sumOfCardFirstPlayer < sumOfCardSecondPlayer)
                {
                    AddingWinnerHandToDeck(winnerHand, secondDeck);
                    isWinner = true;
                }
                else
                {
                    if (firstDeck.Count == 0 || secondDeck.Count == 0)
                    {
                        isWinner = true;
                    }
                }
            }
        }

        private static List<KeyValuePair<char, int>> GedCardsForWar(Queue<KeyValuePair<char, int>> deck)
        {
            var warHand = new List<KeyValuePair<char, int>>(); // Possible buck if there is no card in deck;

            for (int i = 0; i < 3; i++)
            {
                if (deck.Count == 0)
                {
                    break;
                }
                warHand.Add(deck.Dequeue());
            }

            return warHand;
        }

        private static void AddingWinnerHandToDeck(List<KeyValuePair<char, int>> winnerHand, Queue<KeyValuePair<char, int>> deck)
        {
            foreach (var card in winnerHand.OrderByDescending(x => x.Value).ThenByDescending(l => l.Key))
            {
                deck.Enqueue(card);
            }
        }

        //private static int GetNumberOfCard(string firstPlayerCard)
        //{
            
        //    string stringNumber = null;

        //    var number = firstPlayerCard.Take(firstPlayerCard.Length - 1);

        //    foreach (var item in number)
        //    {
        //        stringNumber += item;
        //    }

        //    return int.Parse(stringNumber);
        //}

        private static Queue<KeyValuePair<char, int>> GetDeck()
        {
            var cards = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var deck = new Queue<KeyValuePair<char, int>>();

            foreach (var card in cards)
            {
                var value = int.Parse(card.Substring(0, card.Length - 1));

                var letter = card[card.Length - 1];

                deck.Enqueue(new KeyValuePair<char, int>(letter, value));
            }

            return deck;
        }
    }
}
