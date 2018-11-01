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
            this.button1 = new System.Windows.Forms.Button();
            this.btnHostStartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumPlayers
            // 
            this.lblNumPlayers.AutoSize = true;
            this.lblNumPlayers.BackColor = System.Drawing.Color.Transparent;
            this.lblNumPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPlayers.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNumPlayers.Location = new System.Drawing.Point(106, 105);
            this.lblNumPlayers.Name = "lblNumPlayers";
            this.lblNumPlayers.Size = new System.Drawing.Size(596, 48);
            this.lblNumPlayers.TabIndex = 3;
            this.lblNumPlayers.Text = "__ players have joined the game";
            this.lblNumPlayers.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(42, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Leave game";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BtnLeaveGame_Click);
            // 
            // btnHostStartGame
            // 
            this.btnHostStartGame.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHostStartGame.Location = new System.Drawing.Point(591, 264);
            this.btnHostStartGame.Name = "btnHostStartGame";
            this.btnHostStartGame.Size = new System.Drawing.Size(166, 36);
            this.btnHostStartGame.TabIndex = 5;
            this.btnHostStartGame.Text = "Start game";
            this.btnHostStartGame.UseVisualStyleBackColor = false;
            // 
            // Host_WaitingForConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.greenfelt;
            this.ClientSize = new System.Drawing.Size(804, 327);
            this.Controls.Add(this.btnHostStartGame);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblNumPlayers);
            this.Name = "Host_WaitingForConnection";
            this.Text = "waitingForConnectionDialog";
            this.Load += new System.EventHandler(this.Host_WaitingForConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumPlayers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHostStartGame;
    }
}