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

            if (Game.countries[DefenderIndex].owner.numberOfDefenders == 1)
            {
                rB1Def.Checked = true;
                rB1Def.Checked = false;
            }
            else if (Game.countries[DefenderIndex].owner.numberOfDefenders == 2)
            {
                rB2Def.Checked = true;
                rB1Def.Checked = false;
            }

            rB1Def.Enabled = false;
            rB2Def.Enabled = false;
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

        private void rB1Def_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
