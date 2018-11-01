//Classmaster: Madelyn

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

        public Matchmaking()
        {
            InitializeComponent();

            // Set default game name to Game_<key>
            int id = Program.GetConnector().GetKey();
            newGameName.Text = "Game_" + id.ToString();

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RefreshGameList()
        {
            String[] games = Program.GetConnector().FetchListOfGames();


            // If there are no games, do not allow user to select anything in ListBox
            // Add "(none)" so user knows there are no games being hosted
            if (games == null)
            {
                lstBoxGames.SelectionMode = SelectionMode.None;
                lstBoxGames.Items.Add("(none)");
            }

            // Since there are games, add them to ListBox
            else
            {
                // User can only select one game in list
                lstBoxGames.SelectionMode = SelectionMode.One;

                // Add games that aren't already in the list
                foreach (String game in games)
                    if (!lstBoxGames.Items.Contains(game))
                        lstBoxGames.Items.Add(game);                    

                // Removes games that are no longer being hosted
                for (int i = 0; i < lstBoxGames.Items.Count; i++)
                    if (!games.Contains(lstBoxGames.Items[i]))
                        lstBoxGames.Items.RemoveAt(i);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When matchmaking dialog is opened, run this
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matchmaking_Load(object sender, EventArgs e)
        {
            this.RefreshGameList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Check new game name for restricted characters
        /// </summary>
        /// <returns></returns>
        private bool CheckNewGameInput()
        {
            // TODO
            string checkString = newGameName.Text;

            return true;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (radioBtnNewGame.Checked)
            {
                Program.GetConnector().HostNewGame(newGameName.Text);
            }

            if (radioBtnExistingGame.Checked)
            {
                // TODO
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshGameList();
        }

        private void lstBoxGames_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void radioBtnExistingGame_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
