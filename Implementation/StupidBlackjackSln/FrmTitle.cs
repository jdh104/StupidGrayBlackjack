using StupidBlackjackSln.Code;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            AchievementMonitor achievements = AchievementMonitor.GetInstance();
            List<Achievement> achievementList = achievements.GetAchievements();
            
            for (int i = 0; i < achievementList.Count; i++)
            {
                //Create new icon
                PictureBox icon = new PictureBox();

                //Set icon properties
                icon.Tag = i;
                icon.Image = achievementList[i].GetIcon();
                icon.Width = 38;
                icon.Height = 34;
                icon.SizeMode = PictureBoxSizeMode.StretchImage;

                //Set tooltip
                icon.MouseHover += (s, exp) =>
                {
                    int index = (int) icon.Tag;
                    MakeToolTip(icon, achievementList[index].GetName() +
                        "\n\r" + achievementList[index].GetDescription() +
                        "\n\r Date Earned: " + achievementList[index].GetReadableTime());
                };

                flowPnlAchievements.Controls.Add(icon);
            }
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
        /// Create tooltips for achievements
        /// Inegrated from https://stackoverflow.com/questions/1339524/c-how-do-i-add-a-tooltip-to-a-control
        /// </summary>
        private void MakeToolTip(PictureBox i, String message)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip tt = new ToolTip();

            // Set up the delays for the ToolTip.
            tt.AutoPopDelay = 0;
            tt.InitialDelay = 500;
            tt.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            tt.ShowAlways = true;

            // Set up the ToolTip text for the Achievement
            tt.SetToolTip(i, message);
        }
        
    }
}
