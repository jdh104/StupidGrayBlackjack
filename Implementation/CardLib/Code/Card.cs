using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    /// <summary>
    /// Card class.
    /// </summary>
    public class Card
    {
        // "value:suit"
        public const char DELIM = ':';
        private string id;

        private static String[] possibleRanks = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "jack", "queen", "king", "ace" };
        private static String[] possibleSuits = new String[] { "hearts", "spades", "diamonds", "clubs" };

        public Bitmap Bitmap
        {
            get;
            set;
        }

        public Card(string id, Bitmap bitmap)
        {
            this.id = id;
            Bitmap = bitmap;
        }

        public String GetValue()
        {
            return id.Split(DELIM)[0];
        }

        public String GetSuit()
        {
            return id.Split(DELIM)[1];
        }

        public static Card Parse(String rep)
        {
            String[] args = rep.Split(':');
            try
            {
                if (!possibleRanks.Contains(args[0]) || !possibleSuits.Contains(args[1]))
                {
                    throw new Exception("Parse failed");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Deck.GenerateCard(args[0] + DELIM + args[1]);
        }

        public String ToString()
        {
            return id;
        }
    }
}
