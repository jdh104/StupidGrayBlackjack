namespace StupidBlackjackSln
{
    partial class Matchmaking
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
            this.lstBoxGames = new System.Windows.Forms.ListBox();
            this.radioBtnExistingGame = new System.Windows.Forms.RadioButton();
            this.radioBtnNewGame = new System.Windows.Forms.RadioButton();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.newGameName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBoxGames
            // 
            this.lstBoxGames.FormattingEnabled = true;
            this.lstBoxGames.ItemHeight = 25;
            this.lstBoxGames.Location = new System.Drawing.Point(80, 79);
            this.lstBoxGames.Margin = new System.Windows.Forms.Padding(4);
            this.lstBoxGames.Name = "lstBoxGames";
            this.lstBoxGames.Size = new System.Drawing.Size(424, 204);
            this.lstBoxGames.TabIndex = 0;
            this.lstBoxGames.SelectedIndexChanged += new System.EventHandler(this.lstBoxGames_SelectedIndexChanged);
            // 
            // radioBtnExistingGame
            // 
            this.radioBtnExistingGame.AutoSize = true;
            this.radioBtnExistingGame.Location = new System.Drawing.Point(36, 42);
            this.radioBtnExistingGame.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnExistingGame.Name = "radioBtnExistingGame";
            this.radioBtnExistingGame.Size = new System.Drawing.Size(182, 29);
            this.radioBtnExistingGame.TabIndex = 1;
            this.radioBtnExistingGame.TabStop = true;
            this.radioBtnExistingGame.Text = "Existing Game";
            this.radioBtnExistingGame.UseVisualStyleBackColor = true;
            this.radioBtnExistingGame.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioBtnNewGame
            // 
            this.radioBtnNewGame.AutoSize = true;
            this.radioBtnNewGame.Checked = true;
            this.radioBtnNewGame.Location = new System.Drawing.Point(36, 356);
            this.radioBtnNewGame.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnNewGame.Name = "radioBtnNewGame";
            this.radioBtnNewGame.Size = new System.Drawing.Size(144, 29);
            this.radioBtnNewGame.TabIndex = 2;
            this.radioBtnNewGame.TabStop = true;
            this.radioBtnNewGame.Text = "New game";
            this.radioBtnNewGame.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(512, 444);
            this.Ok.Margin = new System.Windows.Forms.Padding(4);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(100, 46);
            this.Ok.TabIndex = 3;
            this.Ok.Text = "Okay";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(352, 444);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(116, 46);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // newGameName
            // 
            this.newGameName.Location = new System.Drawing.Point(160, 385);
            this.newGameName.Margin = new System.Windows.Forms.Padding(4);
            this.newGameName.Name = "newGameName";
            this.newGameName.Size = new System.Drawing.Size(214, 31);
            this.newGameName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 390);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 288);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 52);
            this.button1.TabIndex = 7;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Matchmaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 563);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newGameName);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.radioBtnNewGame);
            this.Controls.Add(this.radioBtnExistingGame);
            this.Controls.Add(this.lstBoxGames);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Matchmaking";
            this.Text = "Matchmaking";
            this.Load += new System.EventHandler(this.Matchmaking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxGames;
        private System.Windows.Forms.RadioButton radioBtnExistingGame;
        private System.Windows.Forms.RadioButton radioBtnNewGame;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox newGameName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}