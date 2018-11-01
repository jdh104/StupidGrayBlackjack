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
        public Client_WaitingForConnection()
        {
            InitializeComponent();
        }

        private void btnLeaveGame_Click(object sender, EventArgs e)
        {
            Program.CloseStupidConnector();
            this.Close();
        }
    }
}
