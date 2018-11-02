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

        private void BtnLeaveGame_Click(object sender, EventArgs e)
        {
            Program.CloseStupidConnector();
            this.Close();
        }

        private int GetID()
        {
            return id;
        }

        private void SetID(int id)
        {
            this.id = id;
        }

    }
}
