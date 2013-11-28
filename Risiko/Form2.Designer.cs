namespace Risiko
{
    partial class Form2
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
            this.dGVNewGame = new System.Windows.Forms.DataGridView();
            this.btnBeginNewGame = new System.Windows.Forms.Button();
            this.btnAbbort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVNewGame)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVNewGame
            // 
            this.dGVNewGame.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVNewGame.Location = new System.Drawing.Point(12, 12);
            this.dGVNewGame.Name = "dGVNewGame";
            this.dGVNewGame.Size = new System.Drawing.Size(415, 376);
            this.dGVNewGame.TabIndex = 0;
            // 
            // btnBeginNewGame
            // 
            this.btnBeginNewGame.Location = new System.Drawing.Point(300, 394);
            this.btnBeginNewGame.Name = "btnBeginNewGame";
            this.btnBeginNewGame.Size = new System.Drawing.Size(127, 23);
            this.btnBeginNewGame.TabIndex = 1;
            this.btnBeginNewGame.Text = "Neues Spiel beginnen";
            this.btnBeginNewGame.UseVisualStyleBackColor = true;
            // 
            // btnAbbort
            // 
            this.btnAbbort.Location = new System.Drawing.Point(12, 394);
            this.btnAbbort.Name = "btnAbbort";
            this.btnAbbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbbort.TabIndex = 2;
            this.btnAbbort.Text = "Abbrechen";
            this.btnAbbort.UseVisualStyleBackColor = true;
            this.btnAbbort.Click += new System.EventHandler(this.btnAbbort_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 423);
            this.Controls.Add(this.btnAbbort);
            this.Controls.Add(this.btnBeginNewGame);
            this.Controls.Add(this.dGVNewGame);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVNewGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVNewGame;
        private System.Windows.Forms.Button btnBeginNewGame;
        private System.Windows.Forms.Button btnAbbort;
    }
}