using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    class Pack // The pack class. Contains all of the possible cards.
    {
        public List<Card> pack;

        public Pack()
        {
            // Initialises the card pack.
            pack = new List<Card>();
            for (int v = 1; v <= Card.numCardNames; v++) // For each value (start at 1, don't exceed the maximum number of card values).
            {
                for (int s = 1; s <= Suits.numSuits; s++) // For each suit, per value (start at 1, don't exceed the maximum number of suits).
                {
                    pack.Add(new Card(v, s)); // Add a new card for each defined value and suit.
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
            var random = new Random();
            int randomCardIndex = random.Next(pack.Count);
            return pack[randomCardIndex];

        }

        // For the deal and dealCard functions, I was in two minds whether to remove the selected card(s) from the deck
        // upon being called with the functions to add/remove cards, but since the deck and functions are public, the program
        // that utilises this can do it themselves if they want to, rather than the deal functions forcing it.

        public List<Card> dealCard(int amount)
        {
            // Deals the number of cards specified by 'amount'.
            if (amount > pack.Count)
            {
                throw new ArgumentException("Attempted to deal more cards than what was in the deck."); // Can only deal what's in the deck!
            }
            var random = new Random();
            List<Card> chosenCards = new List<Card>();
            List<int> previousIndexes = new List<int>();
            for (int i = 0; i < amount; i++) // Keep drawing a random card until the requested amount has been met.
            {
                bool invalidCardIndex = true;
                int randomCardIndex = random.Next(pack.Count);
                while (invalidCardIndex) // Check to make sure we don't draw more than one of the same card, there's no duplicates in this deck!
                {
                    if (previousIndexes.Contains(randomCardIndex))
                    {
                        randomCardIndex = random.Next(pack.Count);
                    }
                    else
                    {
                        invalidCardIndex = false;
                    }
                }
                // Now to add it to the previous indexes as part of the check above, then add it to the list of chosen cards.
                previousIndexes.Add(randomCardIndex);
                chosenCards.Add(pack[randomCardIndex]);
            }

            return chosenCards;
        }

        public bool addCard(Card card)
        {
            // Adds a specified card given a value and suit, if it's valid. We don't need additional
            // validation here as the Suits and Card classes do that for us. Returns true if successful,
            // false if unsuccessful.
            try
            {
                pack.Add(card);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool removeCard(Card card)
        {
            // Removes a specified card from the pack, if found.
            return pack.Remove(card); // Returns true if successfully removed, returns false if not found.

        }
    }
}
