using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_A01_2223
{
    public class Card
    {
        // Base for the Card class.
        // Below are two encapsulated values: value and suit.
        // Value: numbers 1 - 13
        private int value;
        // Suit: numbers 1 - 4
        private Suits suit;
        // Name: user friendly name, public.
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

        public Suits Suit
        {
            get {
                return Suit; // Returns the suit of the card.
            }
            set {
                Suit = suit; // Sets the suit of the card.
            }
        }

        // Encapsulated user friendly names for use later
        private static List<string> cardNames = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        public static int numCardNames = cardNames.Count; // This is public though! This value is very important for utilising the pack.

        public Card(int value, int suit)
        {
            if (value < 0 || value > numCardNames) // Validation to prevent cards with invalid values (the Suits class has its own validation).
            {
                throw new ArgumentException("Attempted to initialise a card with an invalid value."); // Invalid card? Get lost!
            }

            // Not invalid? Fantastic. Set the values.
            this.value = value;
            Suits s = new Suits(suit);
            this.suit = s;

            // Now for a user friendly name.
            this.name = getCardName(value, s);
        }

        private string getCardName(int v, Suits s) // Encapsulated setCardName function, was not part of the base code.
        {
            // Gives the card a user friendly name based on the value and suit.
            string friendlyCardName = "";
            try
            {
                friendlyCardName = cardNames[v - 1];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Warning! Specified Card value {v} has no name."); // This.. shouldn't happen. But just in case someone does an oopsie...
                friendlyCardName = "Undefined";
            }
            string friendlySuitName = s.name;
            string friendlyName = $"{friendlyCardName} of {friendlySuitName}"; // Combine the value name and suit together for a full user friendly name.
            return friendlyName;

        }
    }
}