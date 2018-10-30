using StupidBlackjackSln.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidBlackjackSln;


namespace StupidBlackjackSln
{
    public partial class frmTitle : Form
    {

        public frmTitle()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnRulebook_Click(object sender, EventArgs e)
        {
            FrmRulebook rulebook = new FrmRulebook();
            rulebook.Show();
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                Program.StartNewConnector();
            }
            catch (Exception ex)
            {
                new FrmNewGame().Show();
                this.Hide();
                return;
            }
            new Matchmaking().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmServer().Show();
            this.Hide();
            Program.StartNewServer();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            new Options().ShowDialog();
        }

        private void achievments_button_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
