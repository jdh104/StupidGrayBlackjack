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
        private BlackjackPlayer host_player;
        private int nPlayers;
        private BlackjackPlayer[] players;
        private PictureBox[] picPlayerCards;
        private int ticks = 15;  //15 seconds for a player's turn
        private int id = 0;


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

            host_player = new BlackjackPlayer("host_player");

            deck = new Deck(FindBitmap);

            host_player.giveHand(new List<Card>() { deck.dealCard(), deck.dealCard() });
            showHand();
        }

        /// <summary>
        /// For an online game
        /// </summary>
        /// <param name="id">Game ID</param>
        public FrmNewGame(int id)
        {
            InitializeComponent();
            timer1.Start();
            picPlayerCards = new PictureBox[5];
            for (int i = 0; i < 5; i++)
            {
                picPlayerCards[i] = Controls.Find("picPlayerCard" + (i + 1).ToString(), true)[0] as PictureBox;
            }

            if (Program.GetConnector().GetGamePopulationByID(id) != null)
            {
                nPlayers = System.Convert.ToInt32(Program.GetConnector().GetGamePopulationByID(id));
            }
                
            LoadPlayers();

            // Update information in panel with info from server
            UpdateInfoFromServer();

            this.id = id;
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
            host_player.giveCard(deck.dealCard());
            showHand();
            //Program.GetConnector().NotifyCardDrawn(deck.getRecentCard(), id); //Notify server what was drawn
            if (host_player.getBusted() == true)                        //currently returns null TODO - needs to test
            {
                btnHit.Enabled = false;   //Disable Hit Button
                ticks = 0;    //ends turn and sets time to 0
                timer1.Stop();
                lblTimer.Text = ticks.ToString();
                BlackjackPlayer.isTurn2 = false;
            }
        }


        /// <summary>
        /// Stand (don't want to add any more cards to hand)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStand_Click(object sender, EventArgs e)
        {
            BlackjackPlayer.isTurn2 = false;
            ticks = 0;    //ends turn and sets time to 0
            lblTimer.Text = ticks.ToString();
            timer1.Stop();
            btnHit.Enabled = false;   //Disable Hit Button
            //Program.GetConnector().NotifyStand(id); //Notify Server this player has stands
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
            players = new BlackjackPlayer[nPlayers-1];
            players[0] = new BlackjackPlayer("host_player");
            for (int i = 1; i < nPlayers; i++)
            {
                players[i] = new BlackjackPlayer("player" + (i + 1).ToString());
            }

            if (nPlayers >= 2)
            {
                // lblPlayerXname.Text = "Player" + Program.GetConnector().GetPlayerOrder()[]something like this.toString();
                pnlPlayerX.Show();
            }
            if (nPlayers >= 3)
            {
                // lblPlayerXname.Text = "Player" + Program.GetConnector().GetPlayerOrder()[]something like this.toString();
                pnlPlayerY.Show();
            }
            if (nPlayers == 4)
            {
                // lblPlayerXname.Text = "Player" + Program.GetConnector().GetPlayerOrder()[]something like this.toString();
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

            if (update[0].Equals(StupidServer.UPDATE_GAME_CONNECTION_BROKEN))
            {
                Program.CloseStupidConnector();
                this.Close();
            }

            else if (update[0].Equals(StupidServer.UPDATE_DEALER_DRAW)) { }
            else if (update[0].Equals(StupidServer.UPDATE_DEALER_TURN)) { }
            else if (update[0].Equals(StupidServer.UPDATE_PLAYER_CONNECTION_BROKEN))
            {
                // TODO
            }
            else if (update[0].Equals(StupidServer.UPDATE_PLAYER_JOINED)) { }
            else if (update[0].Equals(StupidServer.UPDATE_PLAYER_DRAW)) { }
            else if (update[0].Equals(StupidServer.UPDATE_PLAYER_STAND)) { }
            else if (update[0].Equals(StupidServer.UPDATE_YOUR_TURN)) { }
            else if (update[0].Equals(StupidServer.NOTIFY_CARD_DRAW)) { }
            else if (update[0].Equals(StupidServer.NOTIFY_STAND)) { }

        }

        /// <summary>
        /// Refresh infomation in Player Panel
        /// </summary>
        private void RefreshPlayerInfo()
        {
            // This player info
            //lblYouArePlayer.Text = "You are player " + Program.GetConnector().GetPlayerOrder()[] something;
            //lblYouArePlayer.Show();

            // Other player info
            // Up to 4 players in game, thus up to 3 players in players panel
            // players in players panel are identified by PlayerX, PlayerY, and PlayerZ
            // lblPlayer_score
            // lblPlayer_cards
            // lblPlayer_status
        }

        /// <summary>
        /// Display cards in hand
        /// </summary>
        private void showHand()
        {
            for (int i = 0; i < host_player.Hand.Count(); i++)
            {
                picPlayerCards[i].BackgroundImage = host_player.Hand[i].Bitmap;
            }
            lblPlayerScore.Text = host_player.Score.ToString();
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

            if (ticks <= 0)
            {
                //We could switch turns here and keep going with the clock
                BlackjackPlayer.isTurn2 = false;
                btnHit.Enabled = false;   //Disable Hit Button
                RefreshPlayerInfo();    // Refresh info on rhs panel
                timer1.Stop();
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
