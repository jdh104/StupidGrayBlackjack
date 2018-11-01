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
		}

		private void CloseServer_Click(object sender, EventArgs e)
		{
            // TODO change this name, dummies. We're getting graded on this Stupid Thing ^(TM)
			frmTitle dicks = new frmTitle();
			dicks.Show();
			this.Hide();
			Program.CloseStupidServer();
		}
	}
}
