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
        }
        public String GetName()
        {
            return name;
        }

        public bool MakeMove(int id)
        {
            this.calcScore();
            if (Score <= 16)
            {
                Card c = FrmNewGame.deck.dealCard();
                this.giveCard(c);
                Program.GetConnector().NotifyDealerDraw(c, id);
                return true;
            }
            else
            {
                Program.GetConnector().NotifyDealerStand(id);
                return false;
            }
        }
        public void MakeTurn(int id)
        {
            while (MakeMove(id));
        }

    }

}
