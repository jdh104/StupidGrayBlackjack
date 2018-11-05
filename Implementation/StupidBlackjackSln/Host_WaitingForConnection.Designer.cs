namespace StupidBlackjackSln
{
    partial class Host_WaitingForConnection
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
            this.lblNumPlayers = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_time = new System.Windows.Forms.Label();
            this.BtnLeaveGame = new System.Windows.Forms.Button();
            this.BtnHostStartGame = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_ConnectorUpdate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumPlayers
            // 
            this.lblNumPlayers.BackColor = System.Drawing.Color.Transparent;
            this.lblNumPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPlayers.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNumPlayers.Location = new System.Drawing.Point(0, 0);
            this.lblNumPlayers.Name = "lblNumPlayers";
            this.lblNumPlayers.Size = new System.Drawing.Size(889, 427);
            this.lblNumPlayers.TabIndex = 3;
            this.lblNumPlayers.Text = "__ players have joined the game";
            this.lblNumPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNumPlayers.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lbl_time);
            this.panel1.Controls.Add(this.BtnLeaveGame);
            this.panel1.Controls.Add(this.BtnHostStartGame);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel1.Size = new System.Drawing.Size(889, 53);
            this.panel1.TabIndex = 7;
            // 
            // lbl_time
            // 
            this.lbl_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_time.AutoSize = true;
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_time.Location = new System.Drawing.Point(375, -5);
            this.lbl_time.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Padding = new System.Windows.Forms.Padding(10);
            this.lbl_time.Size = new System.Drawing.Size(132, 62);
            this.lbl_time.TabIndex = 10;
            this.lbl_time.Text = "Timer";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnLeaveGame
            // 
            this.BtnLeaveGame.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnLeaveGame.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnLeaveGame.Location = new System.Drawing.Point(10, 0);
            this.BtnLeaveGame.Name = "BtnLeaveGame";
            this.BtnLeaveGame.Size = new System.Drawing.Size(166, 43);
            this.BtnLeaveGame.TabIndex = 8;
            this.BtnLeaveGame.Text = "Leave game";
            this.BtnLeaveGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLeaveGame.UseVisualStyleBackColor = false;
            this.BtnLeaveGame.Click += new System.EventHandler(this.BtnLeaveGame_Click);
            // 
            // BtnHostStartGame
            // 
            this.BtnHostStartGame.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnHostStartGame.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnHostStartGame.Location = new System.Drawing.Point(713, 0);
            this.BtnHostStartGame.Name = "BtnHostStartGame";
            this.BtnHostStartGame.Size = new System.Drawing.Size(166, 43);
            this.BtnHostStartGame.TabIndex = 7;
            this.BtnHostStartGame.Text = "Start game";
            this.BtnHostStartGame.UseVisualStyleBackColor = false;
            this.BtnHostStartGame.Click += new System.EventHandler(this.BtnHostStartGame_Click);
            // 
            // lbl_ConnectorUpdate
            // 
            this.lbl_ConnectorUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ConnectorUpdate.AutoSize = true;
            this.lbl_ConnectorUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ConnectorUpdate.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_ConnectorUpdate.Location = new System.Drawing.Point(408, 18);
            this.lbl_ConnectorUpdate.Name = "lbl_ConnectorUpdate";
            this.lbl_ConnectorUpdate.Size = new System.Drawing.Size(93, 25);
            this.lbl_ConnectorUpdate.TabIndex = 8;
            this.lbl_ConnectorUpdate.Text = "Update: ";
            this.lbl_ConnectorUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ConnectorUpdate.Visible = false;
            // 
            // Host_WaitingForConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.greenfelt;
            this.ClientSize = new System.Drawing.Size(889, 427);
            this.Controls.Add(this.lbl_ConnectorUpdate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNumPlayers);
            this.Name = "Host_WaitingForConnection";
            this.Text = "New Online Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Host_WaitingForConnection_FormClosed);
            this.Load += new System.EventHandler(this.Host_WaitingForConnection_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumPlayers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnLeaveGame;
        private System.Windows.Forms.Button BtnHostStartGame;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_ConnectorUpdate;
    }
}