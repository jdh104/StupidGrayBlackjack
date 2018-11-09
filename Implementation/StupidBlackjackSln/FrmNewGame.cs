// Class Master: Jeremy Thomas

using StupidBlackjackSln.Code;
using StupidBlackjackSln.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StupidBlackjackSln
{
    public partial class FrmNewGame : Form
    {
        public static Deck deck;
        private bool isOnline;
        private int turnCount = 0;
        ///private BlackjackPlayer host_player;
        private int nPlayers;
        private BlackjackPlayer[] players;
        private List<int> otherPlayers;
        private PictureBox[] picPlayerCards;
        private int ticks = 60;  //15 seconds for a player's turn
        private int id = 0;
        private int myindex;
        private Dealer dealer;
        private bool isMyTurn = false;


        /// <summary>
        /// For a local game
        /// </summary>
        public FrmNewGame()
        {
            InitializeComponent();
            timer1.Start(); // Do we need a timer for a local game? -mnm
            picPlayerCards = new PictureBox[5];
            for (int i = 0; i < 5; i++)
            {
                picPlayerCards[i] = Controls.Find("picPlayerCard" + (i + 1).ToString(), true)[0] as PictureBox;
            }

            deck = new Deck(FindBitmap);

            showHand();
            isOnline = false;
        }

        /// <summary>
        /// For an online game
        /// </summary>
        /// <param name="id">Game ID</param>
        public FrmNewGame(int id, int myIndex)
        {
            InitializeComponent();
            deck = new Deck(FindBitmap);
            dealer = new Dealer("Bob");
            dealer.giveHand(new List<Card>());

            picPlayerCards = new PictureBox[5];
            for (int i = 0; i < 5; i++)
            {
                picPlayerCards[i] = Controls.Find("picPlayerCard" + (i + 1).ToString(), true)[0] as PictureBox;
            }
            
            while (Program.GetConnector().HasResponse())
            {
                ParseUpdate(Program.GetConnector().CheckForUpdate());
            }

            int? pop = Program.GetConnector().GetGamePopulationByID(id);
            if (pop != null)
            {
                nPlayers = (int)pop;
            }
                
            LoadPlayers();

            // This player info
            lblYouArePlayer.Text = "You are player " + myIndex.ToString();
            lblYouArePlayer.Show();

            this.id = id;
            this.myindex = myIndex;
            this.isOnline = true;

            btnHit.Enabled = false;
            btnStand.Enabled = false;

            ParseUpdate(Program.GetConnector().NotifyInitializationComplete(id));
            timer1.Start();
        }

        /// <summary>
        /// Exit game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Hit (get another card to try to reach 21)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHit_Click(object sender, EventArgs e)
        {
            Card c = deck.dealCard();
            players[myindex].giveCard(c);
            this.ParseUpdate(Program.GetConnector().NotifyCardDrawn(c, id));
            showHand();
            if (players[myindex].getBusted() == true)                        //currently returns null TODO - needs to test
            {
                btnStand_Click(sender, e);
            }
        }


        /// <summary>
        /// Stand (don't want to add any more cards to hand)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStand_Click(object sender, EventArgs e)
        {
            isMyTurn = false;
            this.ParseUpdate(Program.GetConnector().NotifyStand(id));
            ticks = 60;    //ends turn and sets time to 0
            lblTimer.Text = ticks.ToString();
            //timer1.Stop();
            btnHit.Enabled = false;
            btnStand.Enabled = false;//Disable Hit Button
            this.RefreshPlayerInfo();
        }                                             //Currently returns null TODO - test this

        /// <summary>
        /// Find image corresponding to card
        /// </summary>
        /// <param name="value">Value of card A,2-9,J,Q,K</param>
        /// <param name="suit">Suit of card heart, club, diamond, spade</param>
        /// <returns></returns>
        private Bitmap FindBitmap(string value, string suit)
        {
            string textName = "";
            int valueAsNum;
            if (int.TryParse(value, out valueAsNum))
            {
                textName += "_";
            }

            textName += value;
            textName += "_of_";
            textName += suit;

            return (Bitmap)Resources.ResourceManager.GetObject(textName);
        }

        /// <summary>
        /// Exit window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmNewGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dealer dealer = new Dealer("dealer");
        }


        /// <summary>
        /// On game load, get a deck, make a player, give player hand, and show player his/her hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmNewGame_Load(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// Load Player Profiles in Players Panel
        /// </summary>
        private void LoadPlayers()
        {
            players = new BlackjackPlayer[nPlayers];
            otherPlayers = new List<int>();

            for (int i = 0; i < nPlayers; i++)
            {
                players[i] = new BlackjackPlayer("player" + (i).ToString() );
                otherPlayers.Add(i);
                players[i].giveHand(new List<Card>());
            }

            otherPlayers.RemoveAt(myindex);


            if (nPlayers >= 2)
            {
                lblPlayerXname.Text = "Player" + otherPlayers[0].ToString();
                pnlPlayerX.Show();
            }
            if (nPlayers >= 3)
            {
                lblPlayerYname.Text = "Player" + otherPlayers[1].ToString();
                pnlPlayerY.Show();
            }
            if (nPlayers == 4)
            {
                lblPlayerZname.Text = "Player" + otherPlayers[2].ToString();
                pnlPlayerZ.Show();
            }

            flowPnlPlayers.Show();
        }

        /// <summary>
        /// Parse input string for update type and return meaningful update message
        /// </summary>
        /// <param name="update">Update from server</param>
        private void ParseUpdate(String update)
        {
            String[] update_array = update.Split(' ');
            ParseUpdate(update_array);
        }

        private void ParseUpdate(String[] update_array)
        {
            if (update_array[0].Equals(StupidServer.UPDATE_GAME_CONNECTION_BROKEN))
            {
                Program.CloseStupidConnector();
                this.Close();
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_DEALER_DRAW))
            {
                Card cardToDraw = Card.Parse(update_array[1]);
                dealer.giveCard(cardToDraw);
                deck.RemoveCard(cardToDraw);
                lblDealerCards.Text += cardToDraw.GetUnicode() + "  ";
                lblDealerScore.Text = dealer.Score.ToString();
                //lblDealerCards.Enabled = true;
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_DEALER_SETUP))
            {
                Card card1 = deck.dealCard();
                Card card2 = deck.dealCard();
               /// dealer.giveCard(card1);
               /// dealer.giveCard(card2);
                ParseUpdate(Program.GetConnector().NotifyDealerDraw(card1, this.id));
                ParseUpdate(Program.GetConnector().NotifyDealerDraw(card2, this.id));
                ParseUpdate(Program.GetConnector().NotifyDealerSetupFinished(this.id));
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_DEALER_STAND))
            {
                turnCount++; //Keeps track of the number of times this method has been called
                int array_size = nPlayers + 1;
                int[] scoresToCompare = new int[array_size];
                for (int i=0; i<array_size-1; i++)
                {
                    scoresToCompare[i] = players[i].Score;
                }
                scoresToCompare[myindex] = 0;
                scoresToCompare[array_size-1] = dealer.Score;

                if (players[myindex].Score > 21)
                {
                    System.Windows.Forms.MessageBox.Show("You busted, loser!", "Hey Player" + myindex.ToString());
                }
                else if (players[myindex].Score > dealer.Score || dealer.Score > 21)
                {
                        System.Windows.Forms.MessageBox.Show("You won!", "Hey Player" + myindex.ToString());
                        AchievementMonitor.GetInstance().AddWin();
                        if (isOnline)
                        {
                            AchievementMonitor.GetInstance().AddOnlineWinAchievement();
                        }
                        if (turnCount == 1)
                        {
                            AchievementMonitor.GetInstance().AddInstantWinAchievement();
                        }
                }
                else if (players[myindex].Score == dealer.Score)
                {
                    System.Windows.Forms.MessageBox.Show("You tied!", "Hey Player" + myindex.ToString());
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You took the L!", "Hey Player" + myindex.ToString());
                }
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_DEALER_TURN))
            {
                dealer.MakeTurn(id);
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_PLAYER_CONNECTION_BROKEN))
            {
                int playerindex = Int32.Parse(update_array[1]);
                players[playerindex].SetStatus("Left game");
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_PLAYER_JOINED))
            {
                // ignore, game already started
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_PLAYER_DRAW))
            {
                int playerindex = Int32.Parse(update_array[1]);
                if (myindex != playerindex)
                {
                    Card cardToDraw = Card.Parse(update_array[2]);
                    players[playerindex].giveCard(cardToDraw);
                    deck.RemoveCard(cardToDraw);
                    players[playerindex].SetStatus("Drew: " + cardToDraw.ToString());
                }
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_PLAYER_STAND))
            {
                int playerindex = Int32.Parse(update_array[1]);
                players[playerindex].SetStatus("Stood");
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_YOUR_SETUP))
            {
                Card card1 = deck.dealCard();
                Card card2 = deck.dealCard();
                players[myindex].giveCard(card1);
                players[myindex].giveCard(card2);
                this.ParseUpdate(Program.GetConnector().NotifyCardDrawn(card1, this.id));
                this.ParseUpdate(Program.GetConnector().NotifyCardDrawn(card2, this.id));
                this.ParseUpdate(Program.GetConnector().NotifySetupFinished(this.id));
            }
            else if (update_array[0].Equals(StupidServer.UPDATE_YOUR_TURN))
            {
                isMyTurn = true;
                System.Windows.Forms.MessageBox.Show("It's your turn!", "Hey Player" + myindex.ToString());
                btnHit.Enabled = true;
                btnStand.Enabled = true;
            }
            else
            {
                // unrecognized update, probably leftover RESPONSE_SUCCESS
            }
        }

        /// <summary>
        /// Refresh infomation in Player Panel
        /// </summary>
        private void RefreshPlayerInfo()
        {
            if (nPlayers >= 2)
            {
                lblPlayerXscore.Text = players[otherPlayers[0]].GetScore().ToString();
                lblPlayerXstatus.Text = players[otherPlayers[0]].GetStatus();
                lblPlayerXcards.Text = players[otherPlayers[0]].GetUnicodeHand();
            }
            if (nPlayers >= 3)
            {
                lblPlayerYscore.Text = players[otherPlayers[1]].GetScore().ToString();
                lblPlayerYstatus.Text = players[otherPlayers[1]].GetStatus();
                lblPlayerYcards.Text = players[otherPlayers[1]].GetUnicodeHand();
            }
            if (nPlayers == 4)
            {
                lblPlayerZscore.Text = players[otherPlayers[2]].GetScore().ToString();
                lblPlayerZstatus.Text = players[otherPlayers[2]].GetStatus();
                lblPlayerZcards.Text = players[otherPlayers[2]].GetUnicodeHand();
            }

            showHand();

        }

        /// <summary>
        /// Display cards in hand
        /// </summary>
        private void showHand()
        {
            for (int i = 0; i < players[myindex].Hand.Count(); i++)
            {
                picPlayerCards[i].BackgroundImage = players[myindex].Hand[i].Bitmap;
            }
            lblPlayerScore.Text = players[myindex].Score.ToString();
        }

        /// <summary>
        /// Timer functionality. How it ticks, show it somewhere, when clock hits 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks--;    //Time ticks down each second
            UpdateInfoFromServer();
            lblTimer.Text = ticks.ToString();
            this.Text = "Stupid Gray Blackjack";

            if (ticks <= 0 && isMyTurn)
            {
                //We could switch turns here and keep going with the clock
                btnStand_Click(sender, e);
                //this.ParseUpdate(Program.GetConnector().NotifyStand(this.id));
                //btnHit.Enabled = false;   //Disable Hit Button
                //btnStand.Enabled = false;
                //RefreshPlayerInfo();    // Refresh info on rhs panel
                //timer1.Stop();
            }
        }

        /// <summary>
        /// Updates the information in the panel from server update
        /// </summary>
        private void UpdateInfoFromServer()
        {
            String update = Program.GetConnector().CheckForUpdate();

            if (update != null)
            {
                ParseUpdate(update);
                RefreshPlayerInfo();
            }
        }
    }
}
