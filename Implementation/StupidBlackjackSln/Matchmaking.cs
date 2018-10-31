using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace StupidBlackjackSln
{
    public partial class Matchmaking : Form
    {

        private Thread RefreshThread;
        private GroupBox radioBtns;

        public Matchmaking()
        {
            InitializeComponent();
            GroupRadioButtons();

            // Set default game name to Game_<key>
            int id = Program.GetConnector().GetKey();
            newGameName.Text = "Game_" + id.ToString();

            RefreshThread = new Thread(RefreshLoop);
        }

        public void GroupRadioButtons()
        {
            this.radioBtns = new System.Windows.Forms.GroupBox();

            this.radioBtns.Controls.Add(this.radioBtnExistingGame);
            this.radioBtns.Controls.Add(this.radioBtnNewGame);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RefreshLoop()
        {
            while (true)
            {
                Thread.Sleep(3000);
                this.RefreshGameList();
            }
        }

        private void RefreshGameList()
        {
            String[] games = Program.GetConnector().FetchListOfGames();
            foreach (String game in games)
            {
                if (!lstBoxGames.Items.Contains(game))
                {
                    lstBoxGames.Items.Add(game);
                }
            }
            for (int i = 0; i < lstBoxGames.Items.Count; i++)
            {
                if (!games.Contains(lstBoxGames.Items[i]))
                {
                    lstBoxGames.Items.RemoveAt(i);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGameList();
        }

        private void Matchmaking_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] games = Program.GetConnector().FetchListOfGames();

            if (games == null)
            {
                lstBoxGames.SelectionMode = SelectionMode.None;
                lstBoxGames.Items.Add("(none)");
            }
            else
            {
                lstBoxGames.SelectionMode = SelectionMode.One;
                foreach (String game in games)
                    lstBoxGames.Items.Add(game);
            }

        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (radioBtnNewGame.Checked)
            {
                Program.GetConnector().HostNewGame(newGameName.Text);
            }

            if (radioBtnExistingGame.Checked)
            {

            } 
        }
    }
}
