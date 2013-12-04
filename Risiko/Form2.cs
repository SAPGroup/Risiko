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
        // Wird nachher an Form1 zurückgegeben, mit geänderten Player-Werten
        GameField tempGame;
        // Array der die alten Werte speichert, falls änderung
        // Bisherige Fehler bei Bennung der KI (Nummer) -> vlt einfach Farbe zum Namen hinzufügen
        // TODO: private bool[] KI;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 aufrufer)
        {
            fh = aufrufer;
            tempGame = aufrufer.GetGame();
            InitializeComponent();
        }

        // Tabelle um neues Spiel zu erstellen, Player, Name, Farbe usw.
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }


        // Neues-Spiel erstellen abbrechen
        private void btnAbbort_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBeginNewGame_Click(object sender, EventArgs e)
        {
            Player[] PlayersStart = new Player[dGVNewGame.Rows.Count-1];
            for (int i = 0;i < (dGVNewGame.Rows.Count - 1);++i)
            {
                string tempName = Convert.ToString(dGVNewGame.Rows[i].Cells[0].Value);
                Color tempColor = GetColorFromString(Convert.ToString(dGVNewGame.Rows[i].Cells[1].Value));
                bool tempAI = Convert.ToBoolean(dGVNewGame.Rows[i].Cells[2].Value);
                // Werte der einzelnen Spieler werden gespeichert
                PlayersStart[i] = new Player(tempName, tempAI, tempColor);
                PlayersStart[i].unitsPT = 20;
            }
            // Werte werden in GameField übernommen
            tempGame.players = PlayersStart;
            tempGame.turnOfPlayer = 0;
            tempGame.gameState = 0;
            // GameField in Form1 wird mit lokalem verändertem GameField überschrieben
            fh.SetGame(tempGame);
            Close();
        }

        private void dGVNewGame_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int tempCounter = 1;
            for (int i = 0;i < (dGVNewGame.Rows.Count - 1);++i)
            {
                if (Convert.ToBoolean(dGVNewGame.Rows[i].Cells[2].Value))
                {
                    dGVNewGame.Rows[i].Cells[0].Value = "KI" + tempCounter;
                    tempCounter++;
                }
            }

        }

        /// <summary>
        /// Wandelt Deutschen String (aus Anzeige des Auswahlfelder) in Farbe um
        /// </summary>
        /// <param name="tempColor"></param>
        /// <returns></returns>
        public Color GetColorFromString(string tempColor)
        {
            tempColor = tempColor.Trim('\t', ' ', '\'');
            if (tempColor == "Blau")
                return Color.Blue;
            else if (tempColor == "Grün")
                return Color.Green;
            else if (tempColor == "Gelb")
                return Color.Yellow;
            else if (tempColor == "Rot")
                return Color.Red;
            else if (tempColor == "Weiß")
                return Color.White;
            else if (tempColor == "Schwarz")
                return Color.Black;
            else if (tempColor == "Violett")
                return Color.Violet;
            else if (tempColor == "Orange")
                return Color.Orange;
            else
                return Color.White;
        }


    }
}
