namespace StupidBlackjackSln
{
    partial class FrmNewGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlTopBtns = new System.Windows.Forms.Panel();
            this.btnExitGame = new System.Windows.Forms.Button();
            this.flowPnlPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTableHolder = new System.Windows.Forms.Panel();
            this.tablePnlGamePlay = new System.Windows.Forms.TableLayoutPanel();
            this.flowPnlCards = new System.Windows.Forms.FlowLayoutPanel();
            this.picPlayerCard1 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard2 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard3 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard4 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard5 = new System.Windows.Forms.PictureBox();
            this.pnlGameFunctions = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnHit = new System.Windows.Forms.Button();
            this.pnlDealer = new System.Windows.Forms.Panel();
            this.pnlTopBtns.SuspendLayout();
            this.pnlTableHolder.SuspendLayout();
            this.tablePnlGamePlay.SuspendLayout();
            this.flowPnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard5)).BeginInit();
            this.pnlGameFunctions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlTopBtns
            // 
            this.pnlTopBtns.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopBtns.Controls.Add(this.btnExitGame);
            this.pnlTopBtns.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBtns.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBtns.Name = "pnlTopBtns";
            this.pnlTopBtns.Size = new System.Drawing.Size(1809, 58);
            this.pnlTopBtns.TabIndex = 11;
            // 
            // btnExitGame
            // 
            this.btnExitGame.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExitGame.Location = new System.Drawing.Point(0, 0);
            this.btnExitGame.Margin = new System.Windows.Forms.Padding(6);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new System.Drawing.Size(150, 58);
            this.btnExitGame.TabIndex = 9;
            this.btnExitGame.Text = "Exit Table";
            this.btnExitGame.UseVisualStyleBackColor = true;
            this.btnExitGame.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // flowPnlPlayers
            // 
            this.flowPnlPlayers.BackColor = System.Drawing.Color.Transparent;
            this.flowPnlPlayers.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowPnlPlayers.Location = new System.Drawing.Point(1582, 58);
            this.flowPnlPlayers.Name = "flowPnlPlayers";
            this.flowPnlPlayers.Size = new System.Drawing.Size(227, 915);
            this.flowPnlPlayers.TabIndex = 12;
            // 
            // pnlTableHolder
            // 
            this.pnlTableHolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlTableHolder.Controls.Add(this.tablePnlGamePlay);
            this.pnlTableHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableHolder.ForeColor = System.Drawing.Color.Black;
            this.pnlTableHolder.Location = new System.Drawing.Point(0, 58);
            this.pnlTableHolder.Name = "pnlTableHolder";
            this.pnlTableHolder.Size = new System.Drawing.Size(1582, 915);
            this.pnlTableHolder.TabIndex = 13;
            // 
            // tablePnlGamePlay
            // 
            this.tablePnlGamePlay.AutoSize = true;
            this.tablePnlGamePlay.BackColor = System.Drawing.Color.Transparent;
            this.tablePnlGamePlay.ColumnCount = 1;
            this.tablePnlGamePlay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePnlGamePlay.Controls.Add(this.flowPnlCards, 0, 2);
            this.tablePnlGamePlay.Controls.Add(this.pnlGameFunctions, 0, 1);
            this.tablePnlGamePlay.Controls.Add(this.pnlDealer, 0, 0);
            this.tablePnlGamePlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePnlGamePlay.Location = new System.Drawing.Point(0, 0);
            this.tablePnlGamePlay.Name = "tablePnlGamePlay";
            this.tablePnlGamePlay.RowCount = 4;
            this.tablePnlGamePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.59582F));
            this.tablePnlGamePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.40418F));
            this.tablePnlGamePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 591F));
            this.tablePnlGamePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tablePnlGamePlay.Size = new System.Drawing.Size(1582, 915);
            this.tablePnlGamePlay.TabIndex = 11;
            // 
            // flowPnlCards
            // 
            this.flowPnlCards.AutoSize = true;
            this.flowPnlCards.Controls.Add(this.picPlayerCard1);
            this.flowPnlCards.Controls.Add(this.picPlayerCard2);
            this.flowPnlCards.Controls.Add(this.picPlayerCard3);
            this.flowPnlCards.Controls.Add(this.picPlayerCard4);
            this.flowPnlCards.Controls.Add(this.picPlayerCard5);
            this.flowPnlCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPnlCards.Location = new System.Drawing.Point(3, 290);
            this.flowPnlCards.Name = "flowPnlCards";
            this.flowPnlCards.Size = new System.Drawing.Size(1576, 585);
            this.flowPnlCards.TabIndex = 3;
            // 
            // picPlayerCard1
            // 
            this.picPlayerCard1.BackColor = System.Drawing.Color.Transparent;
            this.picPlayerCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayerCard1.Location = new System.Drawing.Point(6, 6);
            this.picPlayerCard1.Margin = new System.Windows.Forms.Padding(6);
            this.picPlayerCard1.Name = "picPlayerCard1";
            this.picPlayerCard1.Size = new System.Drawing.Size(212, 277);
            this.picPlayerCard1.TabIndex = 1;
            this.picPlayerCard1.TabStop = false;
            // 
            // picPlayerCard2
            // 
            this.picPlayerCard2.BackColor = System.Drawing.Color.Transparent;
            this.picPlayerCard2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayerCard2.Location = new System.Drawing.Point(230, 6);
            this.picPlayerCard2.Margin = new System.Windows.Forms.Padding(6);
            this.picPlayerCard2.Name = "picPlayerCard2";
            this.picPlayerCard2.Size = new System.Drawing.Size(212, 277);
            this.picPlayerCard2.TabIndex = 2;
            this.picPlayerCard2.TabStop = false;
            // 
            // picPlayerCard3
            // 
            this.picPlayerCard3.BackColor = System.Drawing.Color.Transparent;
            this.picPlayerCard3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayerCard3.Location = new System.Drawing.Point(454, 6);
            this.picPlayerCard3.Margin = new System.Windows.Forms.Padding(6);
            this.picPlayerCard3.Name = "picPlayerCard3";
            this.picPlayerCard3.Size = new System.Drawing.Size(212, 277);
            this.picPlayerCard3.TabIndex = 6;
            this.picPlayerCard3.TabStop = false;
            // 
            // picPlayerCard4
            // 
            this.picPlayerCard4.BackColor = System.Drawing.Color.Transparent;
            this.picPlayerCard4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayerCard4.Location = new System.Drawing.Point(678, 6);
            this.picPlayerCard4.Margin = new System.Windows.Forms.Padding(6);
            this.picPlayerCard4.Name = "picPlayerCard4";
            this.picPlayerCard4.Size = new System.Drawing.Size(212, 277);
            this.picPlayerCard4.TabIndex = 4;
            this.picPlayerCard4.TabStop = false;
            // 
            // picPlayerCard5
            // 
            this.picPlayerCard5.BackColor = System.Drawing.Color.Transparent;
            this.picPlayerCard5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayerCard5.Location = new System.Drawing.Point(902, 6);
            this.picPlayerCard5.Margin = new System.Windows.Forms.Padding(6);
            this.picPlayerCard5.Name = "picPlayerCard5";
            this.picPlayerCard5.Size = new System.Drawing.Size(212, 277);
            this.picPlayerCard5.TabIndex = 5;
            this.picPlayerCard5.TabStop = false;
            // 
            // pnlGameFunctions
            // 
            this.pnlGameFunctions.AutoSize = true;
            this.pnlGameFunctions.Controls.Add(this.panel1);
            this.pnlGameFunctions.Controls.Add(this.btnStand);
            this.pnlGameFunctions.Controls.Add(this.btnHit);
            this.pnlGameFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGameFunctions.Location = new System.Drawing.Point(3, 197);
            this.pnlGameFunctions.Name = "pnlGameFunctions";
            this.pnlGameFunctions.Size = new System.Drawing.Size(1576, 87);
            this.pnlGameFunctions.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTimer);
            this.panel1.Controls.Add(this.lblPlayerScore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(60, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1410, 87);
            this.panel1.TabIndex = 15;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(1410, 0);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 73);
            this.lblTimer.TabIndex = 11;
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerScore.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerScore.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerScore.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(205, 73);
            this.lblPlayerScore.TabIndex = 10;
            this.lblPlayerScore.Text = "Score";
            this.lblPlayerScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStand
            // 
            this.btnStand.AutoSize = true;
            this.btnStand.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStand.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStand.Location = new System.Drawing.Point(1470, 0);
            this.btnStand.Margin = new System.Windows.Forms.Padding(6);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(106, 87);
            this.btnStand.TabIndex = 7;
            this.btnStand.Text = "Stand";
            this.btnStand.UseCompatibleTextRendering = true;
            this.btnStand.UseVisualStyleBackColor = false;
            // 
            // btnHit
            // 
            this.btnHit.AutoSize = true;
            this.btnHit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHit.Location = new System.Drawing.Point(0, 0);
            this.btnHit.Margin = new System.Windows.Forms.Padding(6);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(60, 87);
            this.btnHit.TabIndex = 6;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = false;
            // 
            // pnlDealer
            // 
            this.pnlDealer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDealer.AutoSize = true;
            this.pnlDealer.Location = new System.Drawing.Point(3, 191);
            this.pnlDealer.Name = "pnlDealer";
            this.pnlDealer.Size = new System.Drawing.Size(0, 0);
            this.pnlDealer.TabIndex = 4;
            // 
            // FrmNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.greenfelt;
            this.ClientSize = new System.Drawing.Size(1809, 973);
            this.Controls.Add(this.pnlTableHolder);
            this.Controls.Add(this.flowPnlPlayers);
            this.Controls.Add(this.pnlTopBtns);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmNewGame";
            this.Text = "Stupid Gray Blackjack";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNewGame_FormClosed);
            this.Load += new System.EventHandler(this.FrmNewGame_Load);
            this.pnlTopBtns.ResumeLayout(false);
            this.pnlTableHolder.ResumeLayout(false);
            this.pnlTableHolder.PerformLayout();
            this.tablePnlGamePlay.ResumeLayout(false);
            this.tablePnlGamePlay.PerformLayout();
            this.flowPnlCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard5)).EndInit();
            this.pnlGameFunctions.ResumeLayout(false);
            this.pnlGameFunctions.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlTopBtns;
        private System.Windows.Forms.Button btnExitGame;
        private System.Windows.Forms.FlowLayoutPanel flowPnlPlayers;
        private System.Windows.Forms.Panel pnlTableHolder;
        private System.Windows.Forms.TableLayoutPanel tablePnlGamePlay;
        private System.Windows.Forms.FlowLayoutPanel flowPnlCards;
        private System.Windows.Forms.PictureBox picPlayerCard1;
        private System.Windows.Forms.PictureBox picPlayerCard2;
        private System.Windows.Forms.PictureBox picPlayerCard4;
        private System.Windows.Forms.PictureBox picPlayerCard5;
        private System.Windows.Forms.Panel pnlGameFunctions;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Panel pnlDealer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.PictureBox picPlayerCard3;
    }
}