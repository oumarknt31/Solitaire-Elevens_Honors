using System;
namespace CardElevenGame
{
    public class Deck
    {
        List<Card> cards = new List<Card>();
        private Random random = new Random();


        public Deck()
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }


        public bool Empty { get { return cards.Count == 0; } }

        public Card TakeTopCard()
        {
            
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            

            
        }

        public void Cut(int location)
        {
            /*int count = 0;
            while (count < location)
            {
                cards.RemoveAt(count);
                count++;
            }*/

            if (cards.Count == 2)
            {
                Console.WriteLine("The deck has to have at least 2 cards");
            }
            else
            {
                List<Card> tempCards = new List<Card>();

                for (int i = location + 1; i < cards.Count; i++)
                {
                    tempCards.Add(cards[i]);
                }

                for (int i = 0; i <= location; i++)
                {
                    tempCards.Add(cards[i]);
                }

                cards = tempCards;
            }
        }

        public void print()
        {

            foreach (Card card in cards)
            {
                Console.Write(card.Rank + " " + card.Suit + " || ");

            }
        }

        public void shuffle()
        {
            //Random random = new Random(); // Initialize a Random instance

            /* My shuffle() method consists to sawp the index of the first element in my list 
             * with the random number generated between 0 and 52
             * Then the next swap will be between 1 and 52, then 2 and 52, ensuring that all the
             * cards will be shuffled at least once and the position won't be the same as the previous order
             */

            for (int i = 0; i < cards.Count; i++)
            {
                int randomIndex = random.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }

        }

        public int Count { get { return cards.Count; } }

        public Card At(int location)
        {
            if (location < cards.Count)
            {
                return cards[location];
            }
            else
            { return null; }
        }
    }
}

