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

        private String playerName;
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

        public List<Card> GetHand()
        {
            return Hand;
        }

        public String GetUnicodeHand()
        {
            Hand = GetHand();
            String unicodeHand = "";
            foreach (Card c in Hand) {
                unicodeHand += c.GetUnicode();
            }

            return unicodeHand;
        }

        public String GetStatus()
        {
            return status;
        }

        public int GetScore()
        {
            return Score;
        }

        public void SetStatus(String status)
        {
            this.status = status;
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

            //Check for blackjack condition
            if (this.Score == 21)
            {
                if (Hand.Count == 2)
                {
                    if ((Hand[0].GetValue() == "jack") && ((Hand[0].GetSuit() == "spades") || (Hand[0].GetSuit() == ("clubs"))))
                    {
                        AchievementMonitor.GetInstance().AddBlackjackAchievement();
                    }

                    else if ((Hand[1].GetValue() == "jack") && ((Hand[0].GetSuit() == "spades") || (Hand[1].GetSuit() == ("clubs"))))
                    {
                        AchievementMonitor.GetInstance().AddBlackjackAchievement();
                    }
                }
            }
        }
    }
}
