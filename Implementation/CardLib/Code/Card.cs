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

        public string getValue()
        {
            return id.Split(DELIM)[0];
        }
        public string getSuit()
        {
            return id.Split(DELIM)[1];
        }
    }
}
