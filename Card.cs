using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Card
    {
        // Base for the Card class.
        // Below are two encapsulated values: value and suit.
        // Value: numbers 1 - 13
        private int value;
        // Suit: numbers 1 - 4
        private int suit;
        // Name: user friendly name, public, TESTING/DEBUGGING PURPOSES ONLY
        public string name;
        // Validation is in place to prevent invalid cards.

        public int Value
        {
            get { 
                return Value; // Returns the number of the card.
            }
            set {
                Value = value; // Sets the number of the card.
            }
        }

        public int Suit
        {
            get {
                return Suit; // Returns the suit of the card.
            }
            set {
                Suit = suit; // Sets the suit of the card.
            }
        }

        public Card(int value, int suit)
        {
            if (value > 0 ^ value < 14 ^ suit > 0 ^ suit < 5) // Validation to prevent invalid cards.
            {
                throw new ArgumentException("Attempted to initialise an invalid card."); // Invalid card? Get lost!
            }

            // Not invalid? Fantastic. Set the values.
            this.value = value;
            this.suit = suit;

            // Now for a user friendly name, mostly for testing and debugging purposes.
            List<string> cardNames = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            List<string> suitNames = new List<string> { "Hearts", "Diamonds", "Clubs", "Spades" };
            string friendlyCardName = cardNames[value - 1];
            string friendlySuitName = suitNames[suit - 1];


            this.name = friendlyCardName + " of " + friendlySuitName; // Doing this value in the same format and value and suit but as a string just threw a StackOverflow exception.
            // It's just for debugging anyway, so it's not important.
        }
    }
}