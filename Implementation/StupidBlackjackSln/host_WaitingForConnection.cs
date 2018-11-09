// Class Master: Madelyn

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidBlackjackSln.Code;

namespace StupidBlackjackSln
{
    public partial class Host_WaitingForConnection : Form
    {
        private int id;

        public Host_WaitingForConnection(int id)
        {
            InitializeComponent();
            this.id = id;
        }


        private void BtnLeaveGame_Click(object sender, EventArgs e)
        {
            Program.GetConnector().RemoveHostedGame(id);
            this.Close();
        }

        private void Host_WaitingForConnection_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        
        /// <summary>
        /// Load the Host's waiting for connection dialog. Start timer. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Host_WaitingForConnection_Load(object sender, EventArgs e)
        {
            // Set up timer to show time from time starting game to present
            DateTime startTime = DateTime.Now;
            timer1.Tick += (s, ev) => {
                TimeSpan elapsed_span = DateTime.Now - startTime;
                DateTime elapsed_time = DateTime.Today.Add(elapsed_span);
                lbl_time.Text = elapsed_time.ToString("mm:ss");

                // Check for any update from server
                String update = Program.GetConnector().CheckForUpdate();
                
                if (update != null)
                {
                    lbl_ConnectorUpdate.Text = ParseUpdate(update);
                    lbl_ConnectorUpdate.Show();
                    ParseUpdate(update);
                    UpdatePlayers();
                }

                // Update number of players in game
                
            };
            timer1.Interval = 750;
            timer1.Start();
            
        }

        /// <summary>
        /// Parse input string for update type and return meaningful update message
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        private String ParseUpdate(String update)
        {
            if (update.Equals(StupidServer.UPDATE_GAME_CONNECTION_BROKEN))
                return "Host left game. Please leave and join another game.";
            else if (update.Equals(StupidServer.UPDATE_PLAYER_JOINED))
                return "A player joined!";
            else
                return "";
        }


        /// <summary>
        /// Update number of players on screen.
        /// </summary>
        private void UpdatePlayers()
        {
            int? numPlayers = Program.GetConnector().GetGamePopulationByID(id);
            String gameName = Program.GetConnector().GetGameNameByID(id);

            if (numPlayers == 0)
                lblNumPlayers.Text = "Oops, something went wrong. Leave game and try again.";
            else if (numPlayers == 1)
                lblNumPlayers.Text = "No players have joined your game (" + gameName + ")";
            else if (numPlayers == 2)
                lblNumPlayers.Text = "1 player has joined your game  (" + gameName + ")";
            else
                lblNumPlayers.Text = (numPlayers - 1).ToString() + " players have joined your game (" + gameName + ")";
            
            lblNumPlayers.Show();
        }

        /// <summary>
        /// Provide functionality to "Start Game" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHostStartGame_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            String[] response = Program.GetConnector().StartHostedGame(id);

            new FrmNewGame(id, Convert.ToInt32(response[1])).Show();
            this.Close();
        }
    }
}
