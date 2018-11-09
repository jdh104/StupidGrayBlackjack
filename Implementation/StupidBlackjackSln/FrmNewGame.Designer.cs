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
            this.pnlPlayerX = new System.Windows.Forms.Panel();
            this.pnlCtrPlayerX = new System.Windows.Forms.SplitContainer();
            this.pnlPlayerXcards = new System.Windows.Forms.Panel();
            this.lblPlayerXstatus = new System.Windows.Forms.Label();
            this.lblPlayerXscore = new System.Windows.Forms.Label();
            this.lblPlayerXname = new System.Windows.Forms.Label();
            this.picPlayerX = new System.Windows.Forms.PictureBox();
            this.pnlPlayerY = new System.Windows.Forms.Panel();
            this.pnlCtrPlayerY = new System.Windows.Forms.SplitContainer();
            this.pnlPlayerYcards = new System.Windows.Forms.Panel();
            this.lblPlayerYstatus = new System.Windows.Forms.Label();
            this.lblPlayerYscore = new System.Windows.Forms.Label();
            this.lblPlayerYname = new System.Windows.Forms.Label();
            this.picPlayerY = new System.Windows.Forms.PictureBox();
            this.pnlPlayerZ = new System.Windows.Forms.Panel();
            this.pnlCtrPlayerZ = new System.Windows.Forms.SplitContainer();
            this.pnlPlayerZcards = new System.Windows.Forms.Panel();
            this.lblPlayerZstatus = new System.Windows.Forms.Label();
            this.lblPlayerZscore = new System.Windows.Forms.Label();
            this.lblPlayerZname = new System.Windows.Forms.Label();
            this.picPlayerZ = new System.Windows.Forms.PictureBox();
            this.pnlTableHolder = new System.Windows.Forms.Panel();
            this.tablePnlGamePlay = new System.Windows.Forms.TableLayoutPanel();
            this.flowPnlCards = new System.Windows.Forms.FlowLayoutPanel();
            this.picPlayerCard1 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard2 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard3 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard4 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard5 = new System.Windows.Forms.PictureBox();
            this.pnlGameFunctions = new System.Windows.Forms.Panel();
            this.pnlScoreTimer = new System.Windows.Forms.Panel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnHit = new System.Windows.Forms.Button();
            this.lblYouArePlayer = new System.Windows.Forms.Label();
            this.pnlDealer = new System.Windows.Forms.Panel();
            this.lblDealerCards = new System.Windows.Forms.Label();
            this.lblDealerScore = new System.Windows.Forms.Label();
            this.lblDealer = new System.Windows.Forms.Label();
            this.lblPlayerXcards = new System.Windows.Forms.Label();
            this.lblPlayerYcards = new System.Windows.Forms.Label();
            this.lblPlayerZcards = new System.Windows.Forms.Label();
            this.pnlTopBtns.SuspendLayout();
            this.flowPnlPlayers.SuspendLayout();
            this.pnlPlayerX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrPlayerX)).BeginInit();
            this.pnlCtrPlayerX.Panel1.SuspendLayout();
            this.pnlCtrPlayerX.Panel2.SuspendLayout();
            this.pnlCtrPlayerX.SuspendLayout();
            this.pnlPlayerXcards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerX)).BeginInit();
            this.pnlPlayerY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrPlayerY)).BeginInit();
            this.pnlCtrPlayerY.Panel1.SuspendLayout();
            this.pnlCtrPlayerY.Panel2.SuspendLayout();
            this.pnlCtrPlayerY.SuspendLayout();
            this.pnlPlayerYcards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerY)).BeginInit();
            this.pnlPlayerZ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrPlayerZ)).BeginInit();
            this.pnlCtrPlayerZ.Panel1.SuspendLayout();
            this.pnlCtrPlayerZ.Panel2.SuspendLayout();
            this.pnlCtrPlayerZ.SuspendLayout();
            this.pnlPlayerZcards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerZ)).BeginInit();
            this.pnlTableHolder.SuspendLayout();
            this.tablePnlGamePlay.SuspendLayout();
            this.flowPnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard5)).BeginInit();
            this.pnlGameFunctions.SuspendLayout();
            this.pnlScoreTimer.SuspendLayout();
            this.pnlDealer.SuspendLayout();
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
            this.pnlTopBtns.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTopBtns.Name = "pnlTopBtns";
            this.pnlTopBtns.Size = new System.Drawing.Size(2464, 112);
            this.pnlTopBtns.TabIndex = 11;
            // 
            // btnExitGame
            // 
            this.btnExitGame.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExitGame.Location = new System.Drawing.Point(0, 0);
            this.btnExitGame.Margin = new System.Windows.Forms.Padding(6);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new System.Drawing.Size(150, 112);
            this.btnExitGame.TabIndex = 9;
            this.btnExitGame.Text = "Exit Table";
            this.btnExitGame.UseVisualStyleBackColor = true;
            this.btnExitGame.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // flowPnlPlayers
            // 
            this.flowPnlPlayers.BackColor = System.Drawing.Color.Transparent;
            this.flowPnlPlayers.Controls.Add(this.pnlPlayerX);
            this.flowPnlPlayers.Controls.Add(this.pnlPlayerY);
            this.flowPnlPlayers.Controls.Add(this.pnlPlayerZ);
            this.flowPnlPlayers.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowPnlPlayers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPnlPlayers.Location = new System.Drawing.Point(1764, 112);
            this.flowPnlPlayers.Margin = new System.Windows.Forms.Padding(8);
            this.flowPnlPlayers.Name = "flowPnlPlayers";
            this.flowPnlPlayers.Size = new System.Drawing.Size(700, 1311);
            this.flowPnlPlayers.TabIndex = 12;
            this.flowPnlPlayers.Visible = false;
            // 
            // pnlPlayerX
            // 
            this.pnlPlayerX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPlayerX.Controls.Add(this.pnlCtrPlayerX);
            this.pnlPlayerX.Location = new System.Drawing.Point(4, 4);
            this.pnlPlayerX.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlayerX.Name = "pnlPlayerX";
            this.pnlPlayerX.Padding = new System.Windows.Forms.Padding(4);
            this.pnlPlayerX.Size = new System.Drawing.Size(600, 300);
            this.pnlPlayerX.TabIndex = 0;
            this.pnlPlayerX.Visible = false;
            // 
            // pnlCtrPlayerX
            // 
            this.pnlCtrPlayerX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCtrPlayerX.Location = new System.Drawing.Point(4, 4);
            this.pnlCtrPlayerX.Margin = new System.Windows.Forms.Padding(8);
            this.pnlCtrPlayerX.MinimumSize = new System.Drawing.Size(150, 100);
            this.pnlCtrPlayerX.Name = "pnlCtrPlayerX";
            // 
            // pnlCtrPlayerX.Panel1
            // 
            this.pnlCtrPlayerX.Panel1.Controls.Add(this.pnlPlayerXcards);
            this.pnlCtrPlayerX.Panel1.Controls.Add(this.lblPlayerXstatus);
            this.pnlCtrPlayerX.Panel1.Controls.Add(this.lblPlayerXscore);
            this.pnlCtrPlayerX.Panel1.Controls.Add(this.lblPlayerXname);
            this.pnlCtrPlayerX.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlCtrPlayerX.Panel1MinSize = 200;
            // 
            // pnlCtrPlayerX.Panel2
            // 
            this.pnlCtrPlayerX.Panel2.AutoScroll = true;
            this.pnlCtrPlayerX.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.pnlCtrPlayerX.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCtrPlayerX.Panel2.Controls.Add(this.picPlayerX);
            this.pnlCtrPlayerX.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlCtrPlayerX.Panel2MinSize = 100;
            this.pnlCtrPlayerX.Size = new System.Drawing.Size(592, 292);
            this.pnlCtrPlayerX.SplitterDistance = 350;
            this.pnlCtrPlayerX.SplitterWidth = 8;
            this.pnlCtrPlayerX.TabIndex = 0;
            // 
            // pnlPlayerXcards
            // 
            this.pnlPlayerXcards.Controls.Add(this.lblPlayerXcards);
            this.pnlPlayerXcards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayerXcards.Location = new System.Drawing.Point(0, 33);
            this.pnlPlayerXcards.Margin = new System.Windows.Forms.Padding(8);
            this.pnlPlayerXcards.Name = "pnlPlayerXcards";
            this.pnlPlayerXcards.Size = new System.Drawing.Size(263, 230);
            this.pnlPlayerXcards.TabIndex = 3;
            // 
            // lblPlayerXstatus
            // 
            this.lblPlayerXstatus.AutoSize = true;
            this.lblPlayerXstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPlayerXstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerXstatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerXstatus.Location = new System.Drawing.Point(0, 263);
            this.lblPlayerXstatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPlayerXstatus.Name = "lblPlayerXstatus";
            this.lblPlayerXstatus.Size = new System.Drawing.Size(75, 29);
            this.lblPlayerXstatus.TabIndex = 2;
            this.lblPlayerXstatus.Text = "status";
            // 
            // lblPlayerXscore
            // 
            this.lblPlayerXscore.AutoSize = true;
            this.lblPlayerXscore.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPlayerXscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerXscore.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerXscore.Location = new System.Drawing.Point(263, 33);
            this.lblPlayerXscore.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPlayerXscore.Name = "lblPlayerXscore";
            this.lblPlayerXscore.Size = new System.Drawing.Size(87, 33);
            this.lblPlayerXscore.TabIndex = 1;
            this.lblPlayerXscore.Text = "score";
            // 
            // lblPlayerXname
            // 
            this.lblPlayerXname.AutoSize = true;
            this.lblPlayerXname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlayerXname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerXname.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerXname.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerXname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerXname.Name = "lblPlayerXname";
            this.lblPlayerXname.Size = new System.Drawing.Size(117, 33);
            this.lblPlayerXname.TabIndex = 0;
            this.lblPlayerXname.Text = "PlayerX";
            // 
            // picPlayerX
            // 
            this.picPlayerX.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.user1;
            this.picPlayerX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayerX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayerX.Location = new System.Drawing.Point(0, 0);
            this.picPlayerX.Margin = new System.Windows.Forms.Padding(8);
            this.picPlayerX.MinimumSize = new System.Drawing.Size(175, 100);
            this.picPlayerX.Name = "picPlayerX";
            this.picPlayerX.Size = new System.Drawing.Size(234, 292);
            this.picPlayerX.TabIndex = 0;
            this.picPlayerX.TabStop = false;
            // 
            // pnlPlayerY
            // 
            this.pnlPlayerY.Controls.Add(this.pnlCtrPlayerY);
            this.pnlPlayerY.Location = new System.Drawing.Point(4, 312);
            this.pnlPlayerY.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlayerY.Name = "pnlPlayerY";
            this.pnlPlayerY.Padding = new System.Windows.Forms.Padding(4);
            this.pnlPlayerY.Size = new System.Drawing.Size(600, 300);
            this.pnlPlayerY.TabIndex = 3;
            this.pnlPlayerY.Visible = false;
            // 
            // pnlCtrPlayerY
            // 
            this.pnlCtrPlayerY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCtrPlayerY.Location = new System.Drawing.Point(4, 4);
            this.pnlCtrPlayerY.Margin = new System.Windows.Forms.Padding(8);
            this.pnlCtrPlayerY.MinimumSize = new System.Drawing.Size(150, 100);
            this.pnlCtrPlayerY.Name = "pnlCtrPlayerY";
            // 
            // pnlCtrPlayerY.Panel1
            // 
            this.pnlCtrPlayerY.Panel1.Controls.Add(this.pnlPlayerYcards);
            this.pnlCtrPlayerY.Panel1.Controls.Add(this.lblPlayerYstatus);
            this.pnlCtrPlayerY.Panel1.Controls.Add(this.lblPlayerYscore);
            this.pnlCtrPlayerY.Panel1.Controls.Add(this.lblPlayerYname);
            this.pnlCtrPlayerY.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlCtrPlayerY.Panel1MinSize = 100;
            // 
            // pnlCtrPlayerY.Panel2
            // 
            this.pnlCtrPlayerY.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.pnlCtrPlayerY.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCtrPlayerY.Panel2.Controls.Add(this.picPlayerY);
            this.pnlCtrPlayerY.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlCtrPlayerY.Panel2MinSize = 100;
            this.pnlCtrPlayerY.Size = new System.Drawing.Size(592, 292);
            this.pnlCtrPlayerY.SplitterDistance = 350;
            this.pnlCtrPlayerY.SplitterWidth = 8;
            this.pnlCtrPlayerY.TabIndex = 2;
            // 
            // pnlPlayerYcards
            // 
            this.pnlPlayerYcards.Controls.Add(this.lblPlayerYcards);
            this.pnlPlayerYcards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayerYcards.Location = new System.Drawing.Point(0, 33);
            this.pnlPlayerYcards.Margin = new System.Windows.Forms.Padding(8);
            this.pnlPlayerYcards.Name = "pnlPlayerYcards";
            this.pnlPlayerYcards.Size = new System.Drawing.Size(263, 230);
            this.pnlPlayerYcards.TabIndex = 3;
            // 
            // lblPlayerYstatus
            // 
            this.lblPlayerYstatus.AutoSize = true;
            this.lblPlayerYstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPlayerYstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerYstatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerYstatus.Location = new System.Drawing.Point(0, 263);
            this.lblPlayerYstatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPlayerYstatus.Name = "lblPlayerYstatus";
            this.lblPlayerYstatus.Size = new System.Drawing.Size(75, 29);
            this.lblPlayerYstatus.TabIndex = 2;
            this.lblPlayerYstatus.Text = "status";
            // 
            // lblPlayerYscore
            // 
            this.lblPlayerYscore.AutoSize = true;
            this.lblPlayerYscore.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPlayerYscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerYscore.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerYscore.Location = new System.Drawing.Point(263, 33);
            this.lblPlayerYscore.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPlayerYscore.Name = "lblPlayerYscore";
            this.lblPlayerYscore.Size = new System.Drawing.Size(87, 33);
            this.lblPlayerYscore.TabIndex = 1;
            this.lblPlayerYscore.Text = "score";
            // 
            // lblPlayerYname
            // 
            this.lblPlayerYname.AutoSize = true;
            this.lblPlayerYname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlayerYname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerYname.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerYname.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerYname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerYname.Name = "lblPlayerYname";
            this.lblPlayerYname.Size = new System.Drawing.Size(118, 33);
            this.lblPlayerYname.TabIndex = 0;
            this.lblPlayerYname.Text = "PlayerY";
            // 
            // picPlayerY
            // 
            this.picPlayerY.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.user1;
            this.picPlayerY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayerY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayerY.Location = new System.Drawing.Point(0, 0);
            this.picPlayerY.Margin = new System.Windows.Forms.Padding(8);
            this.picPlayerY.MinimumSize = new System.Drawing.Size(175, 100);
            this.picPlayerY.Name = "picPlayerY";
            this.picPlayerY.Size = new System.Drawing.Size(234, 292);
            this.picPlayerY.TabIndex = 0;
            this.picPlayerY.TabStop = false;
            // 
            // pnlPlayerZ
            // 
            this.pnlPlayerZ.Controls.Add(this.pnlCtrPlayerZ);
            this.pnlPlayerZ.Location = new System.Drawing.Point(4, 620);
            this.pnlPlayerZ.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlayerZ.Name = "pnlPlayerZ";
            this.pnlPlayerZ.Size = new System.Drawing.Size(600, 300);
            this.pnlPlayerZ.TabIndex = 4;
            this.pnlPlayerZ.Visible = false;
            // 
            // pnlCtrPlayerZ
            // 
            this.pnlCtrPlayerZ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCtrPlayerZ.Location = new System.Drawing.Point(0, 0);
            this.pnlCtrPlayerZ.Margin = new System.Windows.Forms.Padding(8);
            this.pnlCtrPlayerZ.MinimumSize = new System.Drawing.Size(200, 150);
            this.pnlCtrPlayerZ.Name = "pnlCtrPlayerZ";
            // 
            // pnlCtrPlayerZ.Panel1
            // 
            this.pnlCtrPlayerZ.Panel1.Controls.Add(this.pnlPlayerZcards);
            this.pnlCtrPlayerZ.Panel1.Controls.Add(this.lblPlayerZstatus);
            this.pnlCtrPlayerZ.Panel1.Controls.Add(this.lblPlayerZscore);
            this.pnlCtrPlayerZ.Panel1.Controls.Add(this.lblPlayerZname);
            this.pnlCtrPlayerZ.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlCtrPlayerZ.Panel1MinSize = 100;
            // 
            // pnlCtrPlayerZ.Panel2
            // 
            this.pnlCtrPlayerZ.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.pnlCtrPlayerZ.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCtrPlayerZ.Panel2.Controls.Add(this.picPlayerZ);
            this.pnlCtrPlayerZ.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlCtrPlayerZ.Panel2MinSize = 75;
            this.pnlCtrPlayerZ.Size = new System.Drawing.Size(592, 292);
            this.pnlCtrPlayerZ.SplitterDistance = 350;
            this.pnlCtrPlayerZ.SplitterWidth = 8;
            this.pnlCtrPlayerZ.TabIndex = 3;
            // 
            // pnlPlayerZcards
            // 
            this.pnlPlayerZcards.Controls.Add(this.lblPlayerZcards);
            this.pnlPlayerZcards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayerZcards.Location = new System.Drawing.Point(0, 33);
            this.pnlPlayerZcards.Margin = new System.Windows.Forms.Padding(8);
            this.pnlPlayerZcards.Name = "pnlPlayerZcards";
            this.pnlPlayerZcards.Size = new System.Drawing.Size(263, 230);
            this.pnlPlayerZcards.TabIndex = 3;
            // 
            // lblPlayerZstatus
            // 
            this.lblPlayerZstatus.AutoSize = true;
            this.lblPlayerZstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPlayerZstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerZstatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerZstatus.Location = new System.Drawing.Point(0, 263);
            this.lblPlayerZstatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPlayerZstatus.Name = "lblPlayerZstatus";
            this.lblPlayerZstatus.Size = new System.Drawing.Size(75, 29);
            this.lblPlayerZstatus.TabIndex = 2;
            this.lblPlayerZstatus.Text = "status";
            // 
            // lblPlayerZscore
            // 
            this.lblPlayerZscore.AutoSize = true;
            this.lblPlayerZscore.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPlayerZscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerZscore.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerZscore.Location = new System.Drawing.Point(263, 33);
            this.lblPlayerZscore.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPlayerZscore.Name = "lblPlayerZscore";
            this.lblPlayerZscore.Size = new System.Drawing.Size(87, 33);
            this.lblPlayerZscore.TabIndex = 1;
            this.lblPlayerZscore.Text = "score";
            // 
            // lblPlayerZname
            // 
            this.lblPlayerZname.AutoSize = true;
            this.lblPlayerZname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlayerZname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerZname.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerZname.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerZname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerZname.Name = "lblPlayerZname";
            this.lblPlayerZname.Size = new System.Drawing.Size(116, 33);
            this.lblPlayerZname.TabIndex = 0;
            this.lblPlayerZname.Text = "PlayerZ";
            // 
            // picPlayerZ
            // 
            this.picPlayerZ.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.user1;
            this.picPlayerZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayerZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayerZ.Location = new System.Drawing.Point(0, 0);
            this.picPlayerZ.Margin = new System.Windows.Forms.Padding(4);
            this.picPlayerZ.MinimumSize = new System.Drawing.Size(175, 100);
            this.picPlayerZ.Name = "picPlayerZ";
            this.picPlayerZ.Size = new System.Drawing.Size(234, 292);
            this.picPlayerZ.TabIndex = 0;
            this.picPlayerZ.TabStop = false;
            // 
            // pnlTableHolder
            // 
            this.pnlTableHolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlTableHolder.Controls.Add(this.tablePnlGamePlay);
            this.pnlTableHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableHolder.ForeColor = System.Drawing.Color.Black;
            this.pnlTableHolder.Location = new System.Drawing.Point(0, 112);
            this.pnlTableHolder.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTableHolder.Name = "pnlTableHolder";
            this.pnlTableHolder.Size = new System.Drawing.Size(1764, 1311);
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
            this.tablePnlGamePlay.Controls.Add(this.lblYouArePlayer, 0, 3);
            this.tablePnlGamePlay.Controls.Add(this.pnlDealer, 0, 0);
            this.tablePnlGamePlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePnlGamePlay.Location = new System.Drawing.Point(0, 0);
            this.tablePnlGamePlay.Margin = new System.Windows.Forms.Padding(4);
            this.tablePnlGamePlay.Name = "tablePnlGamePlay";
            this.tablePnlGamePlay.RowCount = 4;
            this.tablePnlGamePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.59582F));
            this.tablePnlGamePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.40418F));
            this.tablePnlGamePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 798F));
            this.tablePnlGamePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tablePnlGamePlay.Size = new System.Drawing.Size(1764, 1311);
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
            this.flowPnlCards.Location = new System.Drawing.Point(4, 445);
            this.flowPnlCards.Margin = new System.Windows.Forms.Padding(4);
            this.flowPnlCards.Name = "flowPnlCards";
            this.flowPnlCards.Size = new System.Drawing.Size(1756, 790);
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
            this.picPlayerCard5.Location = new System.Drawing.Point(908, 12);
            this.picPlayerCard5.Margin = new System.Windows.Forms.Padding(12);
            this.picPlayerCard5.Name = "picPlayerCard5";
            this.picPlayerCard5.Size = new System.Drawing.Size(212, 277);
            this.picPlayerCard5.TabIndex = 5;
            this.picPlayerCard5.TabStop = false;
            // 
            // pnlGameFunctions
            // 
            this.pnlGameFunctions.AutoSize = true;
            this.pnlGameFunctions.Controls.Add(this.pnlScoreTimer);
            this.pnlGameFunctions.Controls.Add(this.btnStand);
            this.pnlGameFunctions.Controls.Add(this.btnHit);
            this.pnlGameFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGameFunctions.Location = new System.Drawing.Point(4, 302);
            this.pnlGameFunctions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGameFunctions.Name = "pnlGameFunctions";
            this.pnlGameFunctions.Size = new System.Drawing.Size(1756, 135);
            this.pnlGameFunctions.TabIndex = 2;
            // 
            // pnlScoreTimer
            // 
            this.pnlScoreTimer.Controls.Add(this.lblTimer);
            this.pnlScoreTimer.Controls.Add(this.lblPlayerScore);
            this.pnlScoreTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScoreTimer.Location = new System.Drawing.Point(96, 0);
            this.pnlScoreTimer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlScoreTimer.Name = "pnlScoreTimer";
            this.pnlScoreTimer.Size = new System.Drawing.Size(1512, 135);
            this.pnlScoreTimer.TabIndex = 15;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(1512, 0);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
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
            this.btnStand.Location = new System.Drawing.Point(1608, 0);
            this.btnStand.Margin = new System.Windows.Forms.Padding(12);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(148, 135);
            this.btnStand.TabIndex = 7;
            this.btnStand.Text = "Stand";
            this.btnStand.UseCompatibleTextRendering = true;
            this.btnStand.UseVisualStyleBackColor = false;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // btnHit
            // 
            this.btnHit.AutoSize = true;
            this.btnHit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHit.Location = new System.Drawing.Point(0, 0);
            this.btnHit.Margin = new System.Windows.Forms.Padding(6);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(96, 135);
            this.btnHit.TabIndex = 6;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = false;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // lblYouArePlayer
            // 
            this.lblYouArePlayer.AutoSize = true;
            this.lblYouArePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYouArePlayer.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblYouArePlayer.Location = new System.Drawing.Point(4, 1239);
            this.lblYouArePlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYouArePlayer.Name = "lblYouArePlayer";
            this.lblYouArePlayer.Size = new System.Drawing.Size(252, 37);
            this.lblYouArePlayer.TabIndex = 5;
            this.lblYouArePlayer.Text = "You are player _";
            this.lblYouArePlayer.Visible = false;
            // 
            // pnlDealer
            // 
            this.pnlDealer.AutoSize = true;
            this.pnlDealer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlDealer.Controls.Add(this.lblDealerCards);
            this.pnlDealer.Controls.Add(this.lblDealerScore);
            this.pnlDealer.Controls.Add(this.lblDealer);
            this.pnlDealer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDealer.Location = new System.Drawing.Point(8, 8);
            this.pnlDealer.Margin = new System.Windows.Forms.Padding(8);
            this.pnlDealer.Name = "pnlDealer";
            this.pnlDealer.Size = new System.Drawing.Size(1748, 282);
            this.pnlDealer.TabIndex = 4;
            // 
            // lblDealerCards
            // 
            this.lblDealerCards.AutoSize = true;
            this.lblDealerCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDealerCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblDealerCards.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDealerCards.Location = new System.Drawing.Point(0, 73);
            this.lblDealerCards.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDealerCards.Name = "lblDealerCards";
            this.lblDealerCards.Size = new System.Drawing.Size(0, 46);
            this.lblDealerCards.TabIndex = 2;
            // 
            // lblDealerScore
            // 
            this.lblDealerScore.AutoSize = true;
            this.lblDealerScore.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDealerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerScore.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDealerScore.Location = new System.Drawing.Point(0, 73);
            this.lblDealerScore.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDealerScore.Name = "lblDealerScore";
            this.lblDealerScore.Size = new System.Drawing.Size(0, 37);
            this.lblDealerScore.TabIndex = 1;
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lblDealer.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDealer.Location = new System.Drawing.Point(0, 0);
            this.lblDealer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(221, 73);
            this.lblDealer.TabIndex = 0;
            this.lblDealer.Text = "Dealer";
            // 
            // lblPlayerXcards
            // 
            this.lblPlayerXcards.AutoSize = true;
            this.lblPlayerXcards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayerXcards.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerXcards.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerXcards.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerXcards.Name = "lblPlayerXcards";
            this.lblPlayerXcards.Size = new System.Drawing.Size(0, 37);
            this.lblPlayerXcards.TabIndex = 0;
            // 
            // lblPlayerYcards
            // 
            this.lblPlayerYcards.AutoSize = true;
            this.lblPlayerYcards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayerYcards.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerYcards.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerYcards.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerYcards.Name = "lblPlayerYcards";
            this.lblPlayerYcards.Size = new System.Drawing.Size(0, 37);
            this.lblPlayerYcards.TabIndex = 0;
            // 
            // lblPlayerZcards
            // 
            this.lblPlayerZcards.AutoSize = true;
            this.lblPlayerZcards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayerZcards.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerZcards.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerZcards.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerZcards.Name = "lblPlayerZcards";
            this.lblPlayerZcards.Size = new System.Drawing.Size(0, 37);
            this.lblPlayerZcards.TabIndex = 0;
            // 
            // FrmNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.greenfelt;
            this.ClientSize = new System.Drawing.Size(2464, 1423);
            this.Controls.Add(this.pnlTableHolder);
            this.Controls.Add(this.flowPnlPlayers);
            this.Controls.Add(this.pnlTopBtns);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmNewGame";
            this.Text = "Stupid Gray Blackjack";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNewGame_FormClosed);
            this.Load += new System.EventHandler(this.FrmNewGame_Load);
            this.pnlTopBtns.ResumeLayout(false);
            this.flowPnlPlayers.ResumeLayout(false);
            this.pnlPlayerX.ResumeLayout(false);
            this.pnlCtrPlayerX.Panel1.ResumeLayout(false);
            this.pnlCtrPlayerX.Panel1.PerformLayout();
            this.pnlCtrPlayerX.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrPlayerX)).EndInit();
            this.pnlCtrPlayerX.ResumeLayout(false);
            this.pnlPlayerXcards.ResumeLayout(false);
            this.pnlPlayerXcards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerX)).EndInit();
            this.pnlPlayerY.ResumeLayout(false);
            this.pnlCtrPlayerY.Panel1.ResumeLayout(false);
            this.pnlCtrPlayerY.Panel1.PerformLayout();
            this.pnlCtrPlayerY.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrPlayerY)).EndInit();
            this.pnlCtrPlayerY.ResumeLayout(false);
            this.pnlPlayerYcards.ResumeLayout(false);
            this.pnlPlayerYcards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerY)).EndInit();
            this.pnlPlayerZ.ResumeLayout(false);
            this.pnlCtrPlayerZ.Panel1.ResumeLayout(false);
            this.pnlCtrPlayerZ.Panel1.PerformLayout();
            this.pnlCtrPlayerZ.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrPlayerZ)).EndInit();
            this.pnlCtrPlayerZ.ResumeLayout(false);
            this.pnlPlayerZcards.ResumeLayout(false);
            this.pnlPlayerZcards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerZ)).EndInit();
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
            this.pnlScoreTimer.ResumeLayout(false);
            this.pnlScoreTimer.PerformLayout();
            this.pnlDealer.ResumeLayout(false);
            this.pnlDealer.PerformLayout();
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
        private System.Windows.Forms.Panel pnlScoreTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.PictureBox picPlayerCard3;
        private System.Windows.Forms.Panel pnlPlayerX;
        private System.Windows.Forms.SplitContainer pnlCtrPlayerX;
        private System.Windows.Forms.Panel pnlPlayerXcards;
        private System.Windows.Forms.Label lblPlayerXstatus;
        private System.Windows.Forms.Label lblPlayerXscore;
        private System.Windows.Forms.Label lblPlayerXname;
        private System.Windows.Forms.PictureBox picPlayerX;
        private System.Windows.Forms.Panel pnlPlayerY;
        private System.Windows.Forms.SplitContainer pnlCtrPlayerY;
        private System.Windows.Forms.Panel pnlPlayerYcards;
        private System.Windows.Forms.Label lblPlayerYstatus;
        private System.Windows.Forms.Label lblPlayerYscore;
        private System.Windows.Forms.Label lblPlayerYname;
        private System.Windows.Forms.PictureBox picPlayerY;
        private System.Windows.Forms.Panel pnlPlayerZ;
        private System.Windows.Forms.SplitContainer pnlCtrPlayerZ;
        private System.Windows.Forms.Panel pnlPlayerZcards;
        private System.Windows.Forms.Label lblPlayerZstatus;
        private System.Windows.Forms.Label lblPlayerZscore;
        private System.Windows.Forms.Label lblPlayerZname;
        private System.Windows.Forms.PictureBox picPlayerZ;
        private System.Windows.Forms.Label lblYouArePlayer;
        private System.Windows.Forms.Label lblDealerCards;
        private System.Windows.Forms.Label lblDealerScore;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.Label lblPlayerXcards;
        private System.Windows.Forms.Label lblPlayerYcards;
        private System.Windows.Forms.Label lblPlayerZcards;
    }
}