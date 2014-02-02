namespace Risiko
{
    partial class RisikoAttackCountry
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
            this.lblDescAttackerName = new System.Windows.Forms.Label();
            this.lblDescDefenderName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.numUDAttacker = new System.Windows.Forms.NumericUpDown();
            this.btnAttack = new System.Windows.Forms.Button();
            this.pnlNumberOfDefenders = new System.Windows.Forms.Panel();
            this.rB2Def = new System.Windows.Forms.RadioButton();
            this.rB1Def = new System.Windows.Forms.RadioButton();
            this.lblDescNumberDefenders = new System.Windows.Forms.Label();
            this.tBAttackerName = new System.Windows.Forms.TextBox();
            this.tBDefenderName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUDAttacker)).BeginInit();
            this.pnlNumberOfDefenders.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescAttackerName
            // 
            this.lblDescAttackerName.AutoSize = true;
            this.lblDescAttackerName.Location = new System.Drawing.Point(20, 12);
            this.lblDescAttackerName.Name = "lblDescAttackerName";
            this.lblDescAttackerName.Size = new System.Drawing.Size(52, 13);
            this.lblDescAttackerName.TabIndex = 0;
            this.lblDescAttackerName.Text = "Angreifer:";
            // 
            // lblDescDefenderName
            // 
            this.lblDescDefenderName.AutoSize = true;
            this.lblDescDefenderName.Location = new System.Drawing.Point(12, 39);
            this.lblDescDefenderName.Name = "lblDescDefenderName";
            this.lblDescDefenderName.Size = new System.Drawing.Size(60, 13);
            this.lblDescDefenderName.TabIndex = 1;
            this.lblDescDefenderName.Text = "Verteidiger:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 98);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // numUDAttacker
            // 
            this.numUDAttacker.Location = new System.Drawing.Point(336, 6);
            this.numUDAttacker.Name = "numUDAttacker";
            this.numUDAttacker.Size = new System.Drawing.Size(120, 20);
            this.numUDAttacker.TabIndex = 3;
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(384, 98);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 5;
            this.btnAttack.Text = "Angreifen";
            this.btnAttack.UseVisualStyleBackColor = true;
            // 
            // pnlNumberOfDefenders
            // 
            this.pnlNumberOfDefenders.Controls.Add(this.rB2Def);
            this.pnlNumberOfDefenders.Controls.Add(this.rB1Def);
            this.pnlNumberOfDefenders.Location = new System.Drawing.Point(251, 67);
            this.pnlNumberOfDefenders.Name = "pnlNumberOfDefenders";
            this.pnlNumberOfDefenders.Size = new System.Drawing.Size(208, 25);
            this.pnlNumberOfDefenders.TabIndex = 6;
            // 
            // rB2Def
            // 
            this.rB2Def.AutoSize = true;
            this.rB2Def.Location = new System.Drawing.Point(120, 3);
            this.rB2Def.Name = "rB2Def";
            this.rB2Def.Size = new System.Drawing.Size(84, 17);
            this.rB2Def.TabIndex = 1;
            this.rB2Def.TabStop = true;
            this.rB2Def.Text = "2 Verteidiger";
            this.rB2Def.UseVisualStyleBackColor = true;
            // 
            // rB1Def
            // 
            this.rB1Def.AutoSize = true;
            this.rB1Def.Location = new System.Drawing.Point(3, 5);
            this.rB1Def.Name = "rB1Def";
            this.rB1Def.Size = new System.Drawing.Size(84, 17);
            this.rB1Def.TabIndex = 0;
            this.rB1Def.TabStop = true;
            this.rB1Def.Text = "1 Verteidiger";
            this.rB1Def.UseVisualStyleBackColor = true;
            // 
            // lblDescNumberDefenders
            // 
            this.lblDescNumberDefenders.AutoSize = true;
            this.lblDescNumberDefenders.Location = new System.Drawing.Point(9, 72);
            this.lblDescNumberDefenders.Name = "lblDescNumberDefenders";
            this.lblDescNumberDefenders.Size = new System.Drawing.Size(110, 13);
            this.lblDescNumberDefenders.TabIndex = 7;
            this.lblDescNumberDefenders.Text = "Anzahl der Verteidiger";
            // 
            // tBAttackerName
            // 
            this.tBAttackerName.Location = new System.Drawing.Point(78, 9);
            this.tBAttackerName.Name = "tBAttackerName";
            this.tBAttackerName.Size = new System.Drawing.Size(115, 20);
            this.tBAttackerName.TabIndex = 8;
            // 
            // tBDefenderName
            // 
            this.tBDefenderName.Location = new System.Drawing.Point(78, 36);
            this.tBDefenderName.Name = "tBDefenderName";
            this.tBDefenderName.Size = new System.Drawing.Size(100, 20);
            this.tBDefenderName.TabIndex = 9;
            // 
            // RisikoAttackCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 128);
            this.Controls.Add(this.tBDefenderName);
            this.Controls.Add(this.tBAttackerName);
            this.Controls.Add(this.lblDescNumberDefenders);
            this.Controls.Add(this.pnlNumberOfDefenders);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.numUDAttacker);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDescDefenderName);
            this.Controls.Add(this.lblDescAttackerName);
            this.Name = "RisikoAttackCountry";
            this.Text = "RisikoAttackCountry";
            this.Load += new System.EventHandler(this.RisikoAttackCountry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDAttacker)).EndInit();
            this.pnlNumberOfDefenders.ResumeLayout(false);
            this.pnlNumberOfDefenders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescAttackerName;
        private System.Windows.Forms.Label lblDescDefenderName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.NumericUpDown numUDAttacker;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Panel pnlNumberOfDefenders;
        private System.Windows.Forms.RadioButton rB2Def;
        private System.Windows.Forms.RadioButton rB1Def;
        private System.Windows.Forms.Label lblDescNumberDefenders;
        private System.Windows.Forms.TextBox tBAttackerName;
        private System.Windows.Forms.TextBox tBDefenderName;
    }
}