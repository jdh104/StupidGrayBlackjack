using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
   public class Dealer : BlackjackPlayer
    {
        private String name;
       public Dealer(String name) : base(name) //test
        {

            this.name = name;
            this.calcScore();
            if (Score <= 16)
            {
                this.giveCard(FrmNewGame.deck.dealCard());
            }
            else 
            {
                isTurn = false;
            }
        }
        public String GetName()
        {
            return name;
        }
    }

}
