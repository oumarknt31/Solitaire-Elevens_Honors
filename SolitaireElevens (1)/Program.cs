// Oumar Kante
// CSC 350H
// Dr Tang
// Project 1 Spring 2024 
// 13 Mar. 2024

                                                /*---------------------------------------------------------------- 
 * This program is about the implementation of the Solitaire Elevens card game in C# based on my refined design.
 *  In the main program, I am testing the different methosds I implimented within my different classes by creating 
 *  a real world Solitaire Elevens game.
-------------------------------------------------------*/

using System;

namespace CardElevenGame
{
    class Program
    {

        static void Main(string[] args)
        {
            // Initialize the game with 9 board cards
            SolitaireElevens game = new SolitaireElevens(9);
            game.DealCards();

            while (true)
            {
                // Display the current board
                Console.WriteLine("\nCurrent Deck: " + game.updateDeck() + " cards" + "\nCurrent board:");
                game.PrintBoard();

                // Check if there are no more valid combinations
                if (!game.LegalSelection())
                {
                    Console.WriteLine("\n\nSorry; No more valid combinations. You lose!");
                    break;
                }

                Console.Write("\n\nEnter indices of 2 or 3 cards (separated by spaces): ");
                string input = Console.ReadLine();
                string[] indicesStr = input.Split(' ');

                List<int> selectedIndices = new List<int>();
                foreach (var indexStr in indicesStr)
                {
                    if (int.TryParse(indexStr, out int index))
                    {
                        selectedIndices.Add(index - 1); // Convert to 0-based index
                    }
                }
                /*
                foreach (int index in selectedIndices)
                {
                    Console.WriteLine(index +" ");
                }*/
                

                // Check if the combination is legal
                if (game.CheckCombination(selectedIndices).Possible)
                {
                    // Remove the selected cards
                    game.RemoveCards(selectedIndices);
                }
                else
                {
                    Console.WriteLine("\nInvalid selection. Try another combination.");
                }

                // Check if the player has won
                if (game.CheckWin())
                {
                    Console.WriteLine("\n\nCongratulations! You've won!");
                    break;
                }
                
            }
        }

    }
}
    
