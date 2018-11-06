using System;
using System.Windows.Forms;


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

        private void btnNewOnlineGame_Click(object sender, EventArgs e)
        {
            try
            {
                Program.StartNewConnector();
            }
            catch (Exception)
            {
                FrmNewGame firstGame = new FrmNewGame();
                firstGame.FormClosed += new FormClosedEventHandler(firstGame_FormClosed);
                firstGame.Show();
                this.Hide();
                return;
            }
            new Matchmaking().ShowDialog();
        }

        private void firstGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();    //unhides the title screen when the newGame Form closes
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

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            FrmNewGame firstGame = new FrmNewGame();
            firstGame.FormClosed += new FormClosedEventHandler(firstGame_FormClosed);
            firstGame.Show();
            this.Hide();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            new FrmServer().ShowDialog();
        }

        /// <summary>
        /// Inegrated from https://stackoverflow.com/questions/1339524/c-how-do-i-add-a-tooltip-to-a-control
        /// </summary>
        private void MakeToolTip(Panel p, String message)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip tt = new ToolTip();

            // Set up the delays for the ToolTip.
            tt.AutoPopDelay = 1000;
            tt.InitialDelay = 1000;
            tt.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            tt.ShowAlways = true;

            // Set up the ToolTip text for the Achievement
            tt.SetToolTip(p, message);
        }

        private void pnlWinOneGame_MouseHover(object sender, EventArgs e)
        {
            MakeToolTip(pnlWinOneGame, "Win 1 game");
        }

        private void pnlWin10Games_MouseHover(object sender, EventArgs e)
        {
            MakeToolTip(pnlWin10Games, "Win 10 games");
        }

        private void pnlWin25Games_MouseHover(object sender, EventArgs e)
        {
            MakeToolTip(pnlWin25Games, "Win 25 games");
        }

        private void pnlWin100Games_MouseHover(object sender, EventArgs e)
        {
            MakeToolTip(pnlWin100Games, "Win 100 games");
        }

        private void pnlInstantWin_MouseHover(object sender, EventArgs e)
        {
            MakeToolTip(pnlInstantWin, "Win instantly");
        }

        private void pnlWinOnlineGame_MouseHover(object sender, EventArgs e)
        {
            MakeToolTip(pnlWinOnlineGame, "Win an online game");
        }

        private void pnlWinWithBlackJack_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
