/* This class is an abstract base class for all card games. Every card game has almost the same feature
 The only difference between them is the number of cards on the board, the Combination and the possible
selection. I wiil use that to my advantage by making the checkCombination a pure virtual method that would
override according to the specific game (Solitaire Elevens, Thirteens, Teens...)
*/

using System;
using System.Collections.Generic;

namespace CardElevenGame
{
    public abstract class CardGame
    {
        protected Deck deck;
        protected List<Card> boardCards = new List<Card>();
        protected int numOfBoardCards;

        public List<Card> BoardCards { get { return boardCards; } }
        public CardGame(int numOfBoardCards)
        {
            this.numOfBoardCards = numOfBoardCards;
        }

        public void DealCards()
        {
            deck = new Deck();
            deck.shuffle();
            for (int i = 0; i < numOfBoardCards; i++)
            {
                boardCards.Add(deck.TakeTopCard());
            }
        }

        // abstract method
        public abstract Combination CheckCombination(List<int> selectedIndices);
        

        public void RemoveCards(List<int> selectedIndices)
        {
            Combination combination = CheckCombination(selectedIndices);
            if (combination.Possible)
            {
                foreach (int index in combination.IndexOfRemovedCards)
                {
                    // I replace card simulstenously (Remove and Add at the same time) if the deck is not empty 
                    if (!deck.Empty)
                    boardCards[index] = deck.TakeTopCard();
                    else
                    {
                        boardCards.RemoveAt(index);
                    }
                }
            }
        }
        
        public bool CheckWin()
        {
            return deck.Empty && boardCards.Count == 0;
        }

        // abstract method 
        public abstract bool LegalSelection();
        

        public void Endgame()
        {
            if (!LegalSelection())
            {
                Console.WriteLine("End of the game");
            }
        }

        public void PrintBoard()
        {
            int i = 1;
            foreach (var card in boardCards)
            {
                Console.Write(i + "- " + card.Rank + " of " + card.Suit + " |~~| " );
                i++;
            }
        }

        public int updateDeck()
        {
            return deck.Count;
        }
    }
}
