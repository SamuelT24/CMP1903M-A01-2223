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
                if (pack.Count < 2)
                {
                    Console.WriteLine("Cannot do a Fisher-Yates Shuffle with less than 2 cards.");
                    return false;
                }
                var random = new Random();
                for (int i = pack.Count; i > 1; i--)
                {
                    int swapWith = random.Next(i - 1); // Random index between 0 and the current index
                    if (swapWith != i-1) // If the chosen index is the same as the current index, do nothing.
                    {
                        // Store both values, then swap them in the list.
                        Card firstIndexItem = pack[swapWith];
                        Card lastIndexItem = pack[i-1];

                        pack[swapWith] = lastIndexItem;
                        pack[i-1] = firstIndexItem;
                    }
                }
            }
            else if (typeOfShuffle == 2)
            { // Riffle Shuffle - it's recommended to do this one multiple times or do a Fisher-Yates Shuffle instead.
                // This seems awkward - but we must be prepared for any number of cards, since cards can be added and removed.
                if (pack.Count < 2)
                {
                    Console.WriteLine("Cannot do a Riffle Shuffle with less than 2 cards.");
                    return false;
                }
                int halfIndex = pack.Count / 2;
                // Split the pack into two halves.
                List<Card> firstHalf = pack.GetRange(0, halfIndex);
                List<Card> secondHalf = pack.GetRange(halfIndex, pack.Count - halfIndex);

                for (int i = 0; i < halfIndex; i+=2)
                {
                    // Add a card from each half back to the pack, one after the other.
                    pack[i] = firstHalf[i];
                    pack[i+1] = secondHalf[i];
                }
            }
            else
            {
                if (typeOfShuffle == 3)
                {
                    return false; // No shuffle happened, but it's valid, return false to say the deck is unchanged.
                }
                else
                {
                    throw new ArgumentException("Invalid shuffle was specified."); // Invalid shuffle! Raise an exception.
                }
            }
            return true;
        }
        public Card deal()
        {
            // Deals one card.
            if (pack.Count < 1)
            {
                throw new Exception("Cannot deal card from an empty pack.");
            }
            return pack[0]; // Pick the card at the top of the pack.

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
            List<Card> chosenCards = new List<Card>();
            for (int i = 0; i < amount; i++) // Keep drawing a card until the requested amount has been met.
            {
                chosenCards.Add(pack[i]);
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
            catch (Exception)
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
