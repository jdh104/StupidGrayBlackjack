using StupidBlackjackSln.Code;
using System;
using System.Windows.Forms;

namespace StupidBlackjackSln
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            this.txtBoxIP.Text = StupidServer.DEFAULT_DOMAIN;
            this.txtBoxPort.Text = StupidServer.DEFAULT_PORT.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StupidConnector.SetIP(txtBoxIP.Text);
            StupidConnector.SetPort(Int32.Parse(txtBoxPort.Text));
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
