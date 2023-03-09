using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    public class Suits // This Suit class was not in the base code, it has been added for the cards.
    {
        // Encapsulated user friendly names for use later
        private static List<string> suitNames = new List<string> { "Hearts", "Diamonds", "Clubs", "Spades" };
        public static int numSuits = suitNames.Count; // This is public though! This value is very important for utilising the pack.

        public int id;
        public string name;

        public Suits(int ID)
        {
            if (ID < 1 || ID > numSuits)
            {
                throw new ArgumentException("Attempted to initialise an invalid suit."); // Invalid suit? Get lost!
            }
            this.id = ID;
            try
            {
                this.name = suitNames[ID - 1]; // Set it to the name associated with that ID.
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Warning! Specified Suit ID {id} has no name."); // This.. shouldn't happen. But just in case someone does an oopsie...
                this.name = "Undefined";
            }
        }
    }
}