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
            this.pBoxBackground = new System.Windows.Forms.PictureBox();
            this.btnDrawMap = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.menuSMain = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kartenDateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBackground)).BeginInit();
            this.menuSMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBoxBackground
            // 
            this.pBoxBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBoxBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(198)))));
            this.pBoxBackground.Location = new System.Drawing.Point(12, 27);
            this.pBoxBackground.Name = "pBoxBackground";
            this.pBoxBackground.Size = new System.Drawing.Size(867, 574);
            this.pBoxBackground.TabIndex = 0;
            this.pBoxBackground.TabStop = false;
            this.pBoxBackground.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pBoxBackground.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxBackground_MouseUp);
            this.pBoxBackground.Resize += new System.EventHandler(this.ResizeForm);
            // 
            // btnDrawMap
            // 
            this.btnDrawMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDrawMap.Location = new System.Drawing.Point(12, 604);
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
            this.lblMessage.Location = new System.Drawing.Point(437, 609);
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
            this.kartenDateiToolStripMenuItem});
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
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 655);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnDrawMap);
            this.Controls.Add(this.pBoxBackground);
            this.Controls.Add(this.menuSMain);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuSMain;
            this.Name = "Form1";
            this.Text = "Risiko";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.ResizeForm);
            this.Resize += new System.EventHandler(this.ResizeForm);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBackground)).EndInit();
            this.menuSMain.ResumeLayout(false);
            this.menuSMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxBackground;
        private System.Windows.Forms.Button btnDrawMap;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.MenuStrip menuSMain;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kartenDateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
    }
}

