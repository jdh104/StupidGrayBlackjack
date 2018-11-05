// Master: Madelyn

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

        private void Client_WaitingForConnection_Load(object sender, EventArgs e)
        {

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
    }
}
