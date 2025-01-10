/* Combination is a class that I will use as the return type of my 
checkCombination() method. It will return an object of Combination type which has bool 
possible (true if combination is possible, else false) and a list<int> indexOfRemoveCards that 
will store the index of all the cards that should be removed if possible is true */

using System.Collections.Generic;

namespace CardElevenGame
{
    public class Combination
    {
        public bool Possible { get; set; } // return true if the combiantion is correct
        public List<int> IndexOfRemovedCards { get; set; } // store the index of all removable cards

        public Combination()
        {
            IndexOfRemovedCards = new List<int>();
        }
    }
}

