using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        public List<Card> pack;

        public Pack()
        {
            // Initialises the card pack
            pack = new List<Card>();
        }

        public bool shuffleCardPack(int typeOfShuffle)
        {
            // Shuffles the pack based on the type of shuffle
            return false; // Stub, just putting this here so the program can actually run
        }
        public Card deal()
        {
            // Deals one card
            Pack p = new Pack();
            var random = new Random();
            int randomCardIndex = random.Next(p.pack.Count);
            return p.pack[randomCardIndex];

        }
        public List<Card> dealCard(int amount)
        {
            // Deals the number of cards specified by 'amount'
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
