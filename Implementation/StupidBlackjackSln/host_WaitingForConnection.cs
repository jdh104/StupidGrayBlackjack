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
    public partial class Host_WaitingForConnection : Form
    {
        private int id;
        private int id1;

        public Host_WaitingForConnection(int id)
        {
            InitializeComponent();
            SetID(id);
        }

        private void BtnLeaveGame_Click(object sender, EventArgs e)
        {
            Program.CloseStupidConnector();
            this.Close();
        }

        private int GetID()
        {
            return id;
        }

        private void Host_WaitingForConnection_Load(object sender, EventArgs e)
        {
            //int numPlayers = Program.GetConnector();
            String gameName = "";

            if (numPlayers == 0)
            {
                lblNumPlayers.Text = "Oops, something went wrong. Leave game and try again.";
            }
            else if (numPlayers == 1)
            {
                lblNumPlayers.Text = "No players have joined your game (" + gameName + ")";
            }
            else
            {
                lblNumPlayers.Text = numPlayers.ToString + " players have joined your game (" + gameName + ")";
            }
            lblNumPlayers.Show(); 
        }

        private void SetID(int id)
        {
            this.id = id;
        }

    }
}
