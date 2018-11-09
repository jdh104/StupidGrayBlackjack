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
        /*
        public var CardtoUnicode(String value, String suit)
        {
            char u_val;
            char u_suit;

            if (value.Length == 1)
                u_val = value.ToCharArray()[0];     
            else if (value.Equals("jack"))
                u_val = 'B';
            else if (value.Equals("queen"))
                u_val = 'D';
            else if (value.Equals("king"))
                u_val = 'E';
            else if (value.Equals("ace"))
                u_val = '1';

            if (suit.Equals("spades"))
                u_suit = 'A';
            else if (suit.Equals("hearts"))
                u_suit = 'B';
            else if (suit.Equals("diamonds"))
                u_suit = 'C';
            else if (suit.Equals("clubs"))
                u_suit = 'D';

            //var unicode = 1f0 + u_suit + u_val;
            return '';
        } */
    }
}
