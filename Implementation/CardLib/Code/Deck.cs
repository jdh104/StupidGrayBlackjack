using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    public class Deck
    {
        private List<Card> cards;
        private Random rand;

        public Deck(Func<string, string, Bitmap> CardToBitmap)
        {
            newDeck(CardToBitmap);
            rand = new Random();
        }

        /// <summary>
        /// Generates a new deck
        /// </summary>
        private void newDeck(Func<string, string, Bitmap> CardToBitmap)
        {
            string[] suits = new string[] { "diamonds", "clubs", "spades", "hearts" };
            string[] values = new string[13];
            for (int i = 2; i <= 10; i++)
            {
                values[i - 2] = i.ToString();
            }
            values[9] = "jack";
            values[10] = "queen";
            values[11] = "king";
            values[12] = "ace";

            cards = new List<Card>();
            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    cards.Add(new Card(value + Card.DELIM + suit, CardToBitmap.Invoke(value, suit)));
                }
            }
        }

        /// <summary>
        /// Gives a new random card from deck
        /// </summary>
        /// <returns>Random card from deck</returns>
        public Card dealCard()
        {
            int cardIndex = rand.Next(cards.Count);
            Card card = cards[cardIndex];
            cards.RemoveAt(cardIndex);
            return card;
        }
    }
}
