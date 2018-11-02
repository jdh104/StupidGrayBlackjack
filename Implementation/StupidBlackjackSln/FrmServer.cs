//ClassMaster: Madelyn

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
	public partial class FrmServer : Form
	{
		public FrmServer()
		{
			InitializeComponent();
            Program.StartNewServer(this.txtBoxStatus);
		}

		private void CloseServer_Click(object sender, EventArgs e)
		{
            this.Close();
		}

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CloseStupidServer();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
