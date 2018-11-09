using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBlackjackSln.Code
{
   public class Dealer : BlackjackPlayer 
    {
       public Dealer()
        {
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

    }

}
