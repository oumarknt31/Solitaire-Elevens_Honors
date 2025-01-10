using System;
namespace CardElevenGame
{
    public class Card
    {
        Suit suit;
        Rank rank;
        bool faceUp;

        public Suit Suit { get { return suit; } }
        public Rank Rank { get { return rank; } }
        public bool FaceUp { get { return faceUp; } }

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
            this.faceUp = false;
        }

        public void FlipOver()
        {
            faceUp = !faceUp;
        }
    }
}

