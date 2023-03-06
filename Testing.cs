using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing // This testing class was not in the base code, but is being used to make sure all features are working properly.
    {
        public static void Test()
        {
            // Create a new pack
            Pack testingPack = new Pack();

            Console.WriteLine("Successfully initialised a new pack. Press ENTER to see the cards.");
            Console.ReadLine();

            // Now, let's display all of the cards in this pack, in order.
            foreach (Card card in testingPack.pack)
            {
                Console.WriteLine(card.name);
            }

            Console.WriteLine("Press ENTER test the first shuffle (Fisher-Yates Shuffle).");
            Console.ReadLine();

            // Performs a shuffle using the first shuffle option.
            Console.WriteLine("Testing shuffle 1.");
            if (testingPack.shuffleCardPack(1))
            {
                Console.WriteLine("Fisher-Yates Shuffle completed successfully.");
            }
            else
            {
                Console.WriteLine("Shuffle 1 was declared invalid. Something is wrong.");
            }

            Console.WriteLine("Press ENTER to see the new card order.");
            Console.ReadLine();

            // Now, let's see the new card order.
            Console.WriteLine("The new card order is as follows:");
            foreach (Card card in testingPack.pack)
            {
                Console.WriteLine(card.name);
            }

            Console.WriteLine("Press ENTER to deal one card.");
            Console.ReadLine();

            // Let's test the deal function! This should deal one card.
            Console.WriteLine("Dealing one card.");
            Console.WriteLine("Successfully dealt {0}", testingPack.deal().name);


            Console.WriteLine("Press ENTER to deal ten cards.");
            Console.ReadLine();

            // Now to deal ten cards. They should all be different.
            Console.WriteLine("Dealing ten cards.");
            foreach (Card card in testingPack.dealCard(10))
            {
                Console.WriteLine("Successfully dealt {0}", card.name);
            }

            // Now to shuffle again, using the second shuffle option!
            Console.WriteLine("Press ENTER test the second shuffle (Riffle Shuffle).");
            Console.ReadLine();

            Console.WriteLine("Testing shuffle 2.");
            if (testingPack.shuffleCardPack(2))
            {
                Console.WriteLine("Riffle Shuffle completed successfully.");
            }
            else
            {
                Console.WriteLine("Shuffle 2 was declared invalid. Something is wrong.");
            }

            Console.WriteLine("Press ENTER to see the new card order.");
            Console.ReadLine();


            // Now, let's see the new order!
            Console.WriteLine("The new card order is as follows:");
            foreach (Card card in testingPack.pack)
            {
                Console.WriteLine(card.name);
            }

            Console.WriteLine("Press ENTER to deal one card.");
            Console.ReadLine();

            // Time to deal one card again.
            Console.WriteLine("Dealing one card.");
            Console.WriteLine("Successfully dealt {0}", testingPack.deal().name);


            Console.WriteLine("Press ENTER to deal ten cards.");
            Console.ReadLine();

            // Now, time to deal ten! As last time, they should all be different.
            Console.WriteLine("Dealing ten cards.");
            foreach (Card card in testingPack.dealCard(10))
            {
                Console.WriteLine("Successfully dealt {0}", card.name);
            }

            // Third and final shuffle option. This shouldn't change the cards at all.
            Console.WriteLine("Press ENTER test the third shuffle (No-Shuffle).");
            Console.ReadLine();

            if (testingPack.shuffleCardPack(3))
            {
                Console.WriteLine("No-Shuffle completed successfully.");
            }
            else
            {
                Console.WriteLine("Shuffle 3 was declared invalid. Something is wrong.");
            }

            // Moment of truth: Are they all the same?
            Console.WriteLine("Press ENTER to see the card order, which should be the same.");
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
            Console.WriteLine("Successfully dealt {0}", testingPack.deal().name);

            // We'll deal ten cards here, to ensure this still works.
            Console.WriteLine("Press ENTER to deal ten cards.");
            Console.ReadLine();

            Console.WriteLine("Dealing ten cards.");
            foreach (Card card in testingPack.dealCard(10))
            {
                Console.WriteLine("Successfully dealt {0}", card.name);
            }

            // Now, let's try doing an invalid shuffle method. The function should return false.
            Console.WriteLine("Press ENTER test an invalid shuffle. The line below after you press ENTER should say 'False'.");
            Console.ReadLine();

            Console.WriteLine(testingPack.shuffleCardPack(4));

            // Excellent! If we made it here with no issues, the program is fully functional.
            Console.WriteLine("Testing complete!");

        }
    }
}
