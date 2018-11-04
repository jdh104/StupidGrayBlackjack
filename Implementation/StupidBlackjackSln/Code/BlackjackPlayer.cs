using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    class BlackjackPlayer : Player
    {
        private bool hasBusted = false;     //true if they go over 21
        private bool hasWon = false;       // true if they win

        public bool getBusted()
        {
            return hasBusted;
        }

        public bool getWon()
        {
            return hasWon;
        }

        protected override void calcScore()
        {
            this.Score = 0;
            int numAces = 0;
            foreach (Card card in Hand)
            {
                int value;
                string cardValue = card.getValue();
                // 2 - 10
                if (int.TryParse(cardValue, out value))
                {
                    Score += value;
                }
                // jack, queen, king
                else if (!cardValue.ToLower().Equals("ace"))
                {
                    Score += 10;
                }
                // ace
                else
                {
                    numAces++;
                    Score += 11;
                }
            }

            if (this.Score > 21)
            {
                while (numAces > 0)
                {
                    Score -= 10;
                    if (this.Score > 21)
                    {
                        numAces--;
                        continue;
                    }
                    break;
                }
            }
        }
    }
}
