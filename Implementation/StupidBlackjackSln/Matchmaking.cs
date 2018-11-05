// Classmaster: Madelyn

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
        delegate void myDelegate();

        public Matchmaking()
        {
            InitializeComponent();

            // Set default game name to Game_<key>
            int id = Program.GetConnector().GetKey();
            newGameName.Text = "Game_" + id.ToString();

        }

        private void AutoRefreshLstBox()
        {
            while (true)
            {
                Thread.Sleep(5000);

                // listbox, is it ok to do something that isn't thread safe?
                if (this.lstBoxGames.InvokeRequired)
                {
                    // delegate constructs invokable object
                    myDelegate d = new myDelegate(RefreshGameList);
                    lstBoxGames.Parent.Invoke(d);
                }
                else
                {
                    // what function actually does
                    this.RefreshGameList();
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshGameList();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.CloseStupidConnector();
        }

        /// <summary>
        /// Check new game name for restricted characters (spaces, semi colons, colons, newline)
        /// </summary>
        /// <returns></returns>
        private bool CheckNewGameInput()
        {
            String checkString = newGameName.Text;

            if (checkString.Contains(" "))
                return false;
            else if (checkString.Contains(";"))
                return false;
            else if (checkString.Contains(":"))
                return false;
            else if (checkString.Contains("\t"))
                return false;
            else if (checkString.Contains("\n"))
                return false;
            else
                return true;
        }

        private void lstBoxGames_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            radioBtnExistingGame.Select();
        }

        private void Matchmaking_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CloseStupidConnector();
        }

        /// <summary>
        /// When matchmaking dialog is opened, run this
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matchmaking_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(AutoRefreshLstBox);
            t.Start();

            this.RefreshGameList();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            int id;
            int key;

            if (radioBtnNewGame.Checked)
            {
                if (!CheckNewGameInput())
                {
                    labelError.Text = "Error: Check your game name for restricted characters (space, semi colons, colons, newline)";
                    labelError.Show();
                }

                else
                {
                    id = Program.GetConnector().HostNewGame(newGameName.Text);

                    if (id == 0)
                    {
                        labelError.Text = "Error: Game name already taken";
                        labelError.Show();
                    }
                    else
                    {
                        new Host_WaitingForConnection(id).ShowDialog();
                    }
                }
            }

            if (radioBtnExistingGame.Checked)
            {
                try
                {
                    String game = lstBoxGames.SelectedItem.ToString();
                    id = Int32.Parse(game.Split(':')[0]);
                    key = Program.GetConnector().GetKey();

                    Program.GetConnector().JoinGameByID(id, key);
                    new Client_WaitingForConnection(id).ShowDialog();
                }
                catch
                {
                    // possible TODO
                }

            }
        }

        private void RadioBtnExistingGame_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RefreshGameList()
        {
            String[] games = Program.GetConnector().FetchListOfGames();


            // If there are no games, do not allow user to select anything in ListBox
            // Add "(none)" so user knows there are no games being hosted, if it's not already there
            if (games == null)
            {
                lstBoxGames.SelectionMode = SelectionMode.None;

                if (lstBoxGames.Items.Count == 0)
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



    }
}
