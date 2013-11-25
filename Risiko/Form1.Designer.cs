namespace Risiko
{
    partial class Form1
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
            this.pnlMap = new System.Windows.Forms.Panel();
            this.menuSMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDrawMap
            // 
            this.btnDrawMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDrawMap.Location = new System.Drawing.Point(12, 570);
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
            this.lblMessage.Location = new System.Drawing.Point(441, 575);
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
            this.autoLanderkennungAktivierenToolStripMenuItem});
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // autoLanderkennungAktivierenToolStripMenuItem
            // 
            this.autoLanderkennungAktivierenToolStripMenuItem.Name = "autoLanderkennungAktivierenToolStripMenuItem";
            this.autoLanderkennungAktivierenToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.autoLanderkennungAktivierenToolStripMenuItem.Text = "Auto Landerkennung aktivieren...";
            this.autoLanderkennungAktivierenToolStripMenuItem.Click += new System.EventHandler(this.autoLanderkennungAktivierenToolStripMenuItem_Click);
            // 
            // pnlMap
            // 
            this.pnlMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(198)))));
            this.pnlMap.Location = new System.Drawing.Point(12, 24);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(872, 540);
            this.pnlMap.TabIndex = 5;
            this.pnlMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMap_MouseMove);
            this.pnlMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMap_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 605);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnDrawMap);
            this.Controls.Add(this.menuSMain);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuSMain;
            this.Name = "Form1";
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
    }
}

