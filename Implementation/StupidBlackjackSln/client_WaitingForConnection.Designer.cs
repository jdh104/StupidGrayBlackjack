﻿namespace StupidBlackjackSln
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnLeaveGame = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumPlayers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_ConnectorUpdate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lbl_time);
            this.panel1.Controls.Add(this.BtnLeaveGame);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 319);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel1.Size = new System.Drawing.Size(793, 61);
            this.panel1.TabIndex = 3;
            // 
            // BtnLeaveGame
            // 
            this.BtnLeaveGame.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnLeaveGame.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnLeaveGame.Location = new System.Drawing.Point(10, 0);
            this.BtnLeaveGame.Margin = new System.Windows.Forms.Padding(0);
            this.BtnLeaveGame.Name = "BtnLeaveGame";
            this.BtnLeaveGame.Size = new System.Drawing.Size(166, 51);
            this.BtnLeaveGame.TabIndex = 1;
            this.BtnLeaveGame.Text = "Leave game";
            this.BtnLeaveGame.UseVisualStyleBackColor = false;
            this.BtnLeaveGame.Click += new System.EventHandler(this.BtnLeaveGame_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_ConnectorUpdate, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNumPlayers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 20, 20, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 306);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblNumPlayers
            // 
            this.lblNumPlayers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNumPlayers.AutoSize = true;
            this.lblNumPlayers.BackColor = System.Drawing.Color.Transparent;
            this.lblNumPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPlayers.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNumPlayers.Location = new System.Drawing.Point(157, 177);
            this.lblNumPlayers.Name = "lblNumPlayers";
            this.lblNumPlayers.Size = new System.Drawing.Size(479, 39);
            this.lblNumPlayers.TabIndex = 3;
            this.lblNumPlayers.Text = "__ players have joined the game";
            this.lblNumPlayers.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(787, 131);
            this.label1.TabIndex = 2;
            this.label1.Text = "Waiting for the host to start game...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_time.Location = new System.Drawing.Point(327, -1);
            this.lbl_time.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Padding = new System.Windows.Forms.Padding(10);
            this.lbl_time.Size = new System.Drawing.Size(138, 62);
            this.lbl_time.TabIndex = 11;
            this.lbl_time.Text = "label1";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ConnectorUpdate
            // 
            this.lbl_ConnectorUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_ConnectorUpdate.AutoSize = true;
            this.lbl_ConnectorUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ConnectorUpdate.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_ConnectorUpdate.Location = new System.Drawing.Point(350, 272);
            this.lbl_ConnectorUpdate.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lbl_ConnectorUpdate.Name = "lbl_ConnectorUpdate";
            this.lbl_ConnectorUpdate.Size = new System.Drawing.Size(93, 24);
            this.lbl_ConnectorUpdate.TabIndex = 9;
            this.lbl_ConnectorUpdate.Text = "Update: ";
            this.lbl_ConnectorUpdate.Visible = false;
            // 
            // Client_WaitingForConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StupidBlackjackSln.Properties.Resources.greenfelt;
            this.ClientSize = new System.Drawing.Size(793, 380);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Client_WaitingForConnection";
            this.Text = "New Online Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_WaitingForConnection_FormClosed);
            this.Load += new System.EventHandler(this.Client_WaitingForConnection_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnLeaveGame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNumPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_ConnectorUpdate;
        private System.Windows.Forms.Timer timer1;
    }
}