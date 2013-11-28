using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Risiko
{
    public partial class Form2 : Form
    {

        // Lädt "alles" aus Form 1;
        private Form1 fh;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 aufrufer)
        {
            fh = aufrufer;
            InitializeComponent();
        }

        // Tabelle um neues Spiel zu erstellen, Player, Name, Farbe usw.
        private void Form2_Load(object sender, EventArgs e)
        {
            dGVNewGame.Columns.Add("PlName", "Name");
            dGVNewGame.Columns.Add("PlColour", "Farbe");
        }


        // Neues-Spiel erstellen abbrechen
        private void btnAbbort_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
