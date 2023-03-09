using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    class Testing // This testing class was not in the base code, but is being used to make sure all features are working properly.
    {

        public static Pack testingPack = new Pack();

        public static void Test()
        {
            // Create a new pack

            Console.WriteLine("Successfully initialised a new pack. Press ENTER to see the cards.");
            Console.ReadLine();

            // Now, let's display all of the cards in this pack, in order.
            foreach (Card card in testingPack.pack)
            {
                Console.WriteLine(card.name);
            }

            List<string> shuffles = new List<string> { "Fisher-Yates Shuffle", "Riffle Shuffle", "No-Shuffle" }; // No-Shuffle should always be last if new ones are added.

            for (int i = 1; i <= shuffles.Count; i++) // Test each shuffle.
            {
                Console.WriteLine($"Press ENTER to test Shuffle {i} ({shuffles[i-1]}).");
                Console.ReadLine();

                Console.WriteLine($"Testing shuffle {i}.");
                if (testingPack.shuffleCardPack(i))
                {
                    if (i == shuffles.Count)
                    {
                        Console.WriteLine($"{shuffles[i-1]} should not return true!"); // This shouldn't happen, unless the information above was not followed.
                    }
                    else
                    {
                        Console.WriteLine($"{shuffles[i - 1]} completed successfully.");
                    }
                    drawFromShuffledPack();
                }
                else
                {
                    if (i == shuffles.Count)
                    {
                        Console.WriteLine($"{shuffles[i - 1]} successfully returned false."); // No shuffle happens, so it should return false.
                    }
                    else
                    {
                        Console.WriteLine($"Shuffle {i} was declared invalid. Something is wrong.");
                    }
                }
            }

            // Now, let's try doing an invalid shuffle method. The function should throw an ArgumentException.
            Console.WriteLine("Press ENTER test an invalid shuffle. This should throw an ArgumentException.");
            Console.ReadLine();

            try
            {
                testingPack.shuffleCardPack(shuffles.Count + 1);
                Console.WriteLine("The invalid shuffle did not raise an exception...");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The invalid shuffle threw an ArgumentException successfully.");
            }
            // Excellent! If we made it here with no issues, the program is fully functional.
            Console.WriteLine("Testing complete!");

        }
        private static bool drawFromShuffledPack()
        {
            // Now to see the new (or the same if it was a no-shuffle) card order.
            Console.WriteLine("Press ENTER to see the current card order.");
            Console.ReadLine();

            Console.WriteLine("The card order is as follows:");
            foreach (Card card in testingPack.pack)
            {
                Console.WriteLine(card.name);
            }

            // We'll deal one card here, to ensure this still works.
            Console.WriteLine("Press ENTER to deal one card.");
            Console.ReadLine();

            Console.WriteLine("Dealing one card.");
            Card cardToRemove = testingPack.deal();
            Console.WriteLine($"Successfully dealt {cardToRemove.name}");

            // Now let's try removing a card.
            Console.WriteLine("Press ENTER to remove this card from the pack.");
            Console.ReadLine();

            bool successfulRemoval = testingPack.removeCard(cardToRemove);
            if (successfulRemoval)
            {
                Console.WriteLine("Successfully removed the card from the pack.");
            }
            else
            {
                Console.WriteLine("Failed to remove the card from the pack.");
            }

            // If we successfully removed it, is the card actually gone?
            if (successfulRemoval)
            {
                Console.WriteLine($"Press ENTER to see the card order, the {cardToRemove.name} card should be missing!");
                Console.ReadLine();

                Console.WriteLine("The card order is as follows:");
                foreach (Card card in testingPack.pack)
                {
                    Console.WriteLine(card.name);
                }
            }

            // We'll deal ten cards here, to ensure this still works.
            Console.WriteLine("Press ENTER to deal ten cards.");
            Console.ReadLine();

            Console.WriteLine("Dealing ten cards.");
            foreach (Card card in testingPack.dealCard(10))
            {
                Console.WriteLine($"Successfully dealt {card.name}");
            }

            // Now let's try adding the card back, provided we successfully removed it earlier.
            bool successfulAddition = false;
            if (successfulRemoval)
            {
                Console.WriteLine("Press ENTER to add the card from earlier back to the pack.");
                Console.ReadLine();

                successfulAddition = testingPack.addCard(cardToRemove);
                if (successfulAddition)
                {
                    Console.WriteLine("Successfully added the card back to the pack.");
                }
                else
                {
                    Console.WriteLine("Failed to add the card back to the pack.");
                }
            }

            // If we successfully added it back, is the card actually there?
            if (successfulAddition)
            {
                Console.WriteLine($"Press ENTER to see the card order, the {cardToRemove.name} card should be back in the pack!");
                Console.ReadLine();

                Console.WriteLine("The card order is as follows:");
                foreach (Card card in testingPack.pack)
                {
                    Console.WriteLine(card.name);
                }
            }
            return true;
        }
    }
}
