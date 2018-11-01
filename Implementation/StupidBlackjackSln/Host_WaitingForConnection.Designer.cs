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
            this.lblNumPlayers = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHostStartGame = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnHostStartGame);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 378);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel1.Size = new System.Drawing.Size(889, 49);
            this.panel1.TabIndex = 7;
            // 
            // btnHostStartGame
            // 
            this.btnHostStartGame.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHostStartGame.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHostStartGame.Location = new System.Drawing.Point(713, 0);
            this.btnHostStartGame.Name = "btnHostStartGame";
            this.btnHostStartGame.Size = new System.Drawing.Size(166, 39);
            this.btnHostStartGame.TabIndex = 7;
            this.btnHostStartGame.Text = "Start game";
            this.btnHostStartGame.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(10, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Leave game";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Host_WaitingForConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.greenfelt;
            this.ClientSize = new System.Drawing.Size(889, 427);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNumPlayers);
            this.Name = "Host_WaitingForConnection";
            this.Text = "waitingForConnectionDialog";
            this.Load += new System.EventHandler(this.Host_WaitingForConnection_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumPlayers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHostStartGame;
    }
}