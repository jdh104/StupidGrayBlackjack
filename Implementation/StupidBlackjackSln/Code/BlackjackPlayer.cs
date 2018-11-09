// Class Master: Madelyn

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
    public class BlackjackPlayer : Player
    {
        public bool hasBusted = false;     //true if they go over 21
        public bool hasWon = false;       // true if they win
        public static Boolean isTurn2;

        public String playerName;
        private String status;

        
        public BlackjackPlayer(String name)
        {
            playerName = name;
        }

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
                string cardValue = card.GetValue();
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
                while (numAces > 0)  //has 1 or more aces
                {
                    Score -= 10;
                    if (this.Score > 21)
                    {
                        numAces--;
                        continue;
                    }
                    break;
                }
                if(this.Score > 21)
                {
                    hasBusted = true;
                }
            }
        }
    }
}
