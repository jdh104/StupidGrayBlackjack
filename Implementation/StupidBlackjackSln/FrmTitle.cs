using StupidBlackjackSln.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidBlackjackSln;

namespace StupidBlackjackSln {
  public partial class frmTitle : Form {
    public frmTitle() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
    }

    private void btnRulebook_Click(object sender, EventArgs e) {
      FrmRulebook rulebook = new FrmRulebook();
      rulebook.Show();
    }

    private void btnExitGame_Click(object sender, EventArgs e) {
      DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
      if (result == DialogResult.Yes)
        Application.Exit();
    }

    private void btnNewGame_Click(object sender, EventArgs e) {
      FrmNewGame frmNewGame = new FrmNewGame();
      frmNewGame.Show();
      this.Hide();
    }

		private void button2_Click(object sender, EventArgs e)
		{
			FrmServer f = new FrmServer();
			f.Show();
			this.Hide();
			Program.StartNewServer();
		}
	}
}
