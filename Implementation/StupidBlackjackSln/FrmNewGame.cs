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
        private BlackjackPlayer player1;
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
            int? nPlayers = Program.GetConnector().GetGamePopulationByID(id);
            LoadPlayers(nPlayers);

            //TODO get player order by id, key?
            // get 2d array of keys to order
            // parse for own key and store
            // new array "other players" ? thoughts?

            // TODO (contingent on above)
            //lblYouArePlayer.Text = "You are player " + Program.GetConnector().GetPlayerOrder()[] something;
            //lblYouArePlayer.Show();

            this.id = id;
        }

        /// <summary>
        /// Exit game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // TODO - something like this
            //if (this.id != 0)
            //  Program.GetConnector().RemoveHostedGame(id);

            this.Close();
        }


        /// <summary>
        /// Hit (get another card to try to reach 21)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHit_Click_1(object sender, EventArgs e)
        {
            player1.giveCard(deck.dealCard());
            showHand();
            if (player1.getBusted() == true)
            {
                btnHit.Enabled = false;   //Disable Hit Button
                BlackjackPlayer.isTurn2 = false;
            }
        }


        /// <summary>
        /// Stand (don't want to add any more cards to hand)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStand_Click_1(object sender, EventArgs e)
        {
            BlackjackPlayer.isTurn2 = false;
            ticks = 0;    //ends turn and sets time to 0
            lblTimer.Text = ticks.ToString();
            timer1.Stop();
            btnHit.Enabled = false;   //Disable Hit Button
        }


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
            deck = new Deck(FindBitmap);
            player1 = new BlackjackPlayer();

            player1.giveHand(new List<Card>() { deck.dealCard(), deck.dealCard() });
            showHand();
        }


        /// <summary>
        /// Load Player Profiles in Players Panel
        /// </summary>
        /// <param name="nPlayers">Number of players in game</param>
        private void LoadPlayers(int? nPlayers)
        {
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
        /// Refresh infomation in Player Panel
        /// </summary>
        private void RefreshPlayerInfo()
        {
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
            for (int i = 0; i < player1.Hand.Count(); i++)
            {
                picPlayerCards[i].BackgroundImage = player1.Hand[i].Bitmap;
            }
            lblPlayerScore.Text = player1.Score.ToString();
        }

        /// <summary>
        /// Timer functionality. How it ticks, show it somewhere, when clock hits 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks--;    //Time ticks down each second
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




    }
}
