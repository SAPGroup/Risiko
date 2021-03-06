﻿namespace Risiko
{
    partial class RisikoMain
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
            this.btnDrawMap = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.menuSMain = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kartenDateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuesSpieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoLanderkennungAktivierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verteidigerBeiAngriffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.progBMenLeft = new System.Windows.Forms.ProgressBar();
            this.btnTestBtn = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.menuSMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDrawMap
            // 
            this.btnDrawMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDrawMap.Location = new System.Drawing.Point(12, 582);
            this.btnDrawMap.Name = "btnDrawMap";
            this.btnDrawMap.Size = new System.Drawing.Size(140, 23);
            this.btnDrawMap.TabIndex = 1;
            this.btnDrawMap.Text = "Zeichne Karte";
            this.btnDrawMap.UseVisualStyleBackColor = true;
            this.btnDrawMap.Click += new System.EventHandler(this.btnDrawMap_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(441, 587);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(30, 13);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "(leer)";
            // 
            // menuSMain
            // 
            this.menuSMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.ansichtToolStripMenuItem});
            this.menuSMain.Location = new System.Drawing.Point(0, 0);
            this.menuSMain.Name = "menuSMain";
            this.menuSMain.Size = new System.Drawing.Size(896, 24);
            this.menuSMain.TabIndex = 4;
            this.menuSMain.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kartenDateiToolStripMenuItem,
            this.neuesSpieToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // kartenDateiToolStripMenuItem
            // 
            this.kartenDateiToolStripMenuItem.Name = "kartenDateiToolStripMenuItem";
            this.kartenDateiToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.kartenDateiToolStripMenuItem.Text = "Datei öffnen...";
            this.kartenDateiToolStripMenuItem.Click += new System.EventHandler(this.kartenDateiToolStripMenuItem_Click);
            // 
            // neuesSpieToolStripMenuItem
            // 
            this.neuesSpieToolStripMenuItem.Name = "neuesSpieToolStripMenuItem";
            this.neuesSpieToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.neuesSpieToolStripMenuItem.Text = "Neues Spiel";
            this.neuesSpieToolStripMenuItem.Click += new System.EventHandler(this.neuesSpieToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoLanderkennungAktivierenToolStripMenuItem,
            this.verteidigerBeiAngriffToolStripMenuItem});
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.ansichtToolStripMenuItem.Text = "Einstellungen";
            this.ansichtToolStripMenuItem.Click += new System.EventHandler(this.ansichtToolStripMenuItem_Click);
            // 
            // autoLanderkennungAktivierenToolStripMenuItem
            // 
            this.autoLanderkennungAktivierenToolStripMenuItem.Name = "autoLanderkennungAktivierenToolStripMenuItem";
            this.autoLanderkennungAktivierenToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.autoLanderkennungAktivierenToolStripMenuItem.Text = "Auto Landerkennung aktivieren...";
            this.autoLanderkennungAktivierenToolStripMenuItem.Click += new System.EventHandler(this.autoLanderkennungAktivierenToolStripMenuItem_Click);
            // 
            // verteidigerBeiAngriffToolStripMenuItem
            // 
            this.verteidigerBeiAngriffToolStripMenuItem.Name = "verteidigerBeiAngriffToolStripMenuItem";
            this.verteidigerBeiAngriffToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.verteidigerBeiAngriffToolStripMenuItem.Text = "1 Verteidiger bei Angriff";
            this.verteidigerBeiAngriffToolStripMenuItem.Click += new System.EventHandler(this.verteidigerBeiAngriffToolStripMenuItem_Click);
            // 
            // pnlMap
            // 
            this.pnlMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(198)))));
            this.pnlMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlMap.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlMap.Location = new System.Drawing.Point(12, 24);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(872, 542);
            this.pnlMap.TabIndex = 5;
            this.pnlMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMap_Paint);
            this.pnlMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMap_MouseMove);
            this.pnlMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMap_MouseUp);
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndTurn.Location = new System.Drawing.Point(778, 582);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(106, 23);
            this.btnEndTurn.TabIndex = 6;
            this.btnEndTurn.Text = "Zug beenden";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // progBMenLeft
            // 
            this.progBMenLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progBMenLeft.Location = new System.Drawing.Point(323, 566);
            this.progBMenLeft.Name = "progBMenLeft";
            this.progBMenLeft.Size = new System.Drawing.Size(268, 12);
            this.progBMenLeft.TabIndex = 0;
            // 
            // btnTestBtn
            // 
            this.btnTestBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestBtn.Location = new System.Drawing.Point(697, 582);
            this.btnTestBtn.Name = "btnTestBtn";
            this.btnTestBtn.Size = new System.Drawing.Size(75, 23);
            this.btnTestBtn.TabIndex = 7;
            this.btnTestBtn.Text = "Test";
            this.btnTestBtn.UseVisualStyleBackColor = true;
            this.btnTestBtn.Click += new System.EventHandler(this.btnTestBtn_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(616, 582);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(75, 23);
            this.btnTest2.TabIndex = 8;
            this.btnTest2.Text = "Test2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // RisikoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 617);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.btnTestBtn);
            this.Controls.Add(this.progBMenLeft);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnDrawMap);
            this.Controls.Add(this.menuSMain);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuSMain;
            this.Name = "RisikoMain";
            this.Text = "Risiko";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.ResizeForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.ResizeForm);
            this.menuSMain.ResumeLayout(false);
            this.menuSMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDrawMap;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.MenuStrip menuSMain;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kartenDateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.ToolStripMenuItem autoLanderkennungAktivierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuesSpieToolStripMenuItem;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.ProgressBar progBMenLeft;
        private System.Windows.Forms.Button btnTestBtn;
        private System.Windows.Forms.ToolStripMenuItem verteidigerBeiAngriffToolStripMenuItem;
        private System.Windows.Forms.Button btnTest2;
    }
}

