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
    public partial class RisikoAttackCountry : Form
    {
        // Daten aus RisikoMain holen
        private RisikoMain Main;
        // Extra Game auslesen
        private GameField Game;
        // Index des AngreiferLandes
        private int AttackerIndex;
        // Index des VerteidigerLandes
        private int DefenderIndex;


        public RisikoAttackCountry()
        {
            InitializeComponent();
        }

        public RisikoAttackCountry(RisikoMain Caller, int tempClickedIndex, int temp)
        {
            // Informationen abspeichern
            Main = Caller;
            Game = Caller.GetGame();
            AttackerIndex = tempClickedIndex;
            DefenderIndex = temp;

            InitializeComponent();

            // Namen der Länder übernehmen
            tBAttackerName.Text = Game.countries[AttackerIndex].name;
            tBDefenderName.Text = Game.countries[DefenderIndex].name;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Um veränderte Game Datei zurück zu liefern
            Main.SetGame(Game);
            Close();
        }

        private void RisikoAttackCountry_Load(object sender, EventArgs e)
        {

        }
    }
}
