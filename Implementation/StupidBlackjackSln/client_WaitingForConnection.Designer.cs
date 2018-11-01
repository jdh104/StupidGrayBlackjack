namespace StupidBlackjackSln
{
    partial class Client_WaitingForConnection
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
            this.btnLeaveGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumPlayers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLeaveGame
            // 
            this.btnLeaveGame.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLeaveGame.Location = new System.Drawing.Point(13, 259);
            this.btnLeaveGame.Name = "btnLeaveGame";
            this.btnLeaveGame.Size = new System.Drawing.Size(166, 36);
            this.btnLeaveGame.TabIndex = 0;
            this.btnLeaveGame.Text = "Leave game";
            this.btnLeaveGame.UseVisualStyleBackColor = false;
            this.btnLeaveGame.Click += new System.EventHandler(this.btnLeaveGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(80, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Waiting for the host to start game...";
            // 
            // lblNumPlayers
            // 
            this.lblNumPlayers.AutoSize = true;
            this.lblNumPlayers.BackColor = System.Drawing.Color.Transparent;
            this.lblNumPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPlayers.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNumPlayers.Location = new System.Drawing.Point(156, 140);
            this.lblNumPlayers.Name = "lblNumPlayers";
            this.lblNumPlayers.Size = new System.Drawing.Size(479, 39);
            this.lblNumPlayers.TabIndex = 2;
            this.lblNumPlayers.Text = "__ players have joined the game";
            this.lblNumPlayers.Visible = false;
            // 
            // client_WaitingForConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.greenfelt;
            this.ClientSize = new System.Drawing.Size(793, 320);
            this.Controls.Add(this.lblNumPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLeaveGame);
            this.Name = "client_WaitingForConnection";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLeaveGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumPlayers;
    }
}