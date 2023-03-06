using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack // The pack class. Contains 52 cards once initialised.
    {
        public List<Card> pack;

        public Pack()
        {
            // Initialises the card pack.
            pack = new List<Card>();
            for (int v = 1; v < 14; v++) // For each value (start at 1, don't exceed 13).
            {
                for (int s = 1; s < 5; s++) // For each suit, per value (start at 1, don't exceed 4).
                {
                    pack.Add(new Card(v, s)); // Add a new card for each value and suit. There should be 52 total. No jokers!
                }
            }
        }

        public bool shuffleCardPack(int typeOfShuffle)
        {
            // Shuffles the pack based on the type of shuffle.
            if (typeOfShuffle == 1)
            { // Fisher-Yates Shuffle
                Console.WriteLine("Not implemented.");
            }
            else if (typeOfShuffle == 2)
            { // Riffle Shuffle
                Console.WriteLine("Not implemented.");
            }
            else
            {
                if (typeOfShuffle == 3)
                {
                    return true; // No-Shuffle, do nothing, just confirm it's valid.
                }
                else
                {
                    return false; // Invalid shuffle!
                }
            }
            return true;
            // Stub, just putting this here so the program can actually run. This is all that's left to finish.
        }
        public Card deal()
        {
            // Deals one card.
            Pack p = new Pack();
            var random = new Random();
            int randomCardIndex = random.Next(p.pack.Count);
            return p.pack[randomCardIndex];

        }
        public List<Card> dealCard(int amount)
        {
            // Deals the number of cards specified by 'amount'.
            Pack p = new Pack();
            var random = new Random();
            List<Card> chosenCards = new List<Card>();
            List<int> previousIndexes = new List<int>();
            for (int i = 0; i < amount; i++)
            {
                bool invalidCardIndex = true;
                int randomCardIndex = random.Next(p.pack.Count);
                while (invalidCardIndex)
                {
                    if (previousIndexes.Contains(randomCardIndex))
                    {
                        randomCardIndex = random.Next(p.pack.Count);
                    }
                    else
                    {
                        invalidCardIndex = false;
                    }
                }
                previousIndexes.Add(randomCardIndex);
                chosenCards.Add(p.pack[randomCardIndex]);
            }

            return chosenCards;
        }
    }
}
