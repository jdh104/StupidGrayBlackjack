// Class Master: Madelyn

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidBlackjackSln.Code;

namespace StupidBlackjackSln
{
    public partial class Client_WaitingForConnection : Form
    {
        private int id;

        public Client_WaitingForConnection(int id)
        {
            SetID(id);
            InitializeComponent();
        }

        private int GetID()
        {
            return id;
        }

        private void SetID(int id)
        {
            this.id = id;
        }

        private void BtnLeaveGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// On load, start the timer and check for server updates.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_WaitingForConnection_Load(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            timer1.Tick += (s, ev) => {
                TimeSpan elapsed_span = DateTime.Now - startTime;
                DateTime elapsed_time = DateTime.Today.Add(elapsed_span);
                lbl_time.Text = elapsed_time.ToString("mm:ss");

                String update = Program.GetConnector().CheckForUpdate();

                if (update != null)
                {
                    lbl_ConnectorUpdate.Text = ParseUpdate(update);
                    lbl_ConnectorUpdate.Show();
                }

            };
            timer1.Interval = 500;
            timer1.Start();
        }

        /// <summary>
        /// On form close, leave game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_WaitingForConnection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.GetConnector().LeaveGameByID(id);
        }


        /// <summary>
        /// Get updates from the server and decide what to do.
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        private String ParseUpdate(String u)
        {
            String[] args = u.Split(' ');
            String update = args[0];
            if (update.Equals(StupidServer.UPDATE_GAME_CONNECTION_BROKEN))
                return "Host left game. Please leave and join another game.";
            else if (update.Equals(StupidServer.UPDATE_PLAYER_JOINED))
                return "Another player has joined!";
            else if (update.Equals(StupidServer.UPDATE_GAME_HAS_STARTED))
            {
                new FrmNewGame(id, args[1]).Show();
                this.Close();
                return "";
            }
            else
                return "";
        }

    }
}
