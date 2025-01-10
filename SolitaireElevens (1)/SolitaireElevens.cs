/* This class derived from CardGame class. I am overriding the checkCombination() and LegalSelection() methods 
 * according to the rule of the real world Solitaire Elevens card game.*/

using System;

namespace CardElevenGame
{
    public class SolitaireElevens : CardGame
    {
        public SolitaireElevens(int numOfBoardCards) : base(numOfBoardCards) { }

        // Override the CheckCombination method
        // Override the CheckCombination method to accept indices of cards to check
        public override Combination CheckCombination(List<int> selectedIndices)
        {
            Combination combination = new Combination();

            // Logic to check for the combination based on selected indices
            if(selectedIndices.Count == 2)
{
                int rank1 = (int)boardCards[selectedIndices[0]].Rank + 1;
                int rank2 = (int)boardCards[selectedIndices[1]].Rank + 1;
                //Console.WriteLine($"Ranks: {rank1} + {rank2} = {rank1 + rank2}"); // Add this line for debugging
                if (rank1 + rank2 == 11)
                {
                    combination.Possible = true;
                    combination.IndexOfRemovedCards = selectedIndices;
                    return combination;
                }
            }
            else if (selectedIndices.Count == 3)
            {
                // Check if the selected cards are King, Queen, and Jack
                bool kingFound = false;
                bool queenFound = false;
                bool jackFound = false;

                foreach (int index in selectedIndices)
                {
                    switch (boardCards[index].Rank)
                    {
                        case Rank.King:
                            kingFound = true;
                            break;
                        case Rank.Queen:
                            queenFound = true;
                            break;
                        case Rank.Jack:
                            jackFound = true;
                            break;
                    }
                }

                // Check if all three cards are found
                if (kingFound && queenFound && jackFound)
                {
                    combination.Possible = true;
                    combination.IndexOfRemovedCards = selectedIndices;
                    return combination;
                }
            }

            // If none of the combinations are met, set Possible to false
            combination.Possible = false;
            combination.IndexOfRemovedCards = new List<int>();
            return combination;
        }

        // Override the LegalSelection method
        public override bool LegalSelection()
        {
            // Iterate through the board cards and check for combinations
            for (int i = 0; i < boardCards.Count; i++)
            {
                for (int j = i + 1; j < boardCards.Count; j++)
                {
                    // Check if the sum of ranks of two cards is equal to 11
                    if ((int)boardCards[i].Rank + (int)boardCards[j].Rank + 2 == 11)
                    {
                        return true; // Found a valid combination
                    }
                }
            }

            // Check if there are King, Queen, and Jack on the board
            bool kingFound = false;
            bool queenFound = false;
            bool jackFound = false;

            foreach (var card in boardCards)
            {
                switch (card.Rank)
                {
                    case Rank.King:
                        kingFound = true;
                        break;
                    case Rank.Queen:
                        queenFound = true;
                        break;
                    case Rank.Jack:
                        jackFound = true;
                        break;
                }
            }

            // Check if all three cards are found
            if (kingFound && queenFound && jackFound)
            {
                return true; // Found a valid combination
            }

            // No valid combination found
            return false;
        }
    }
}



