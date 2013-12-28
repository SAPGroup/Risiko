using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risiko
{
    public class Player
    {
        /// <summary>
        /// Array aller besetzten Länder
        /// </summary>
        private string[] OwnedCountries;

        /// <summary>
        /// Name des Spielers
        /// </summary>
        private string Name;

        /// <summary>
        /// Die Anzahl der Männer in den besetzten Länder (Index passend zu OwnedCountries)
        /// </summary>
        private int[] UnitsInCountries;

        /// <summary>
        /// Die Anzahl der Männer die der Spieler am Anfang des Zuges setzten kann
        /// wird berechnet, nicht gesetzt
        /// </summary>
        private int UnitsPT;

        /// <summary>
        /// Legt fest ob Computergegner oder "richtiger" Spieler
        /// </summary>
        private bool AIPlayer;

        /// <summary>
        /// Farbe des Spielers
        /// </summary>
        private Color PlayerColor; 


        // Konstruktoren
        /// <summary>
        /// Basiskonstruktor
        /// </summary>
        public Player()
        {
            Name = "";
            UnitsPT = 0;
        }

        /// <summary>
        /// Konstruktor mit Name und besetzten Ländern
        /// </summary>
        /// <param name="NameIn"></param>
        /// <param name="OwnedCountriesIn"></param>
        public Player(string NameIn, string[] OwnedCountriesIn)
        {
            Name = NameIn;
            OwnedCountries = OwnedCountriesIn;
        }

        /// <summary>
        /// Konstruktor mit Name und besetzten Ländern und PlayerTyp
        /// </summary>
        /// <param name="NameIn"></param>
        /// <param name="OwnedCountriesIn"></param>
        public Player(string NameIn, string[] OwnedCountriesIn, bool IsAIPlayer)
        {
            Name = NameIn;
            OwnedCountries = OwnedCountriesIn;
            AIPlayer = IsAIPlayer;
        }

        public Player(string NameIn, bool IsAIPlayer, Color PlayerColorIn)
        {
            Name = NameIn;
            AIPlayer = IsAIPlayer;
            PlayerColor = PlayerColorIn;
        }

        // Set- und Get- Methoden
        /// <summary>
        /// Set und Get des Namens des Spielers
        /// </summary>
        public string name
        {
            get { return Name; }
            set
            {
                if (value != "")
                    Name = value;
            }
        }

        /// <summary>
        /// Set- und Get- Methode der Einheiten der besetzten Ländern
        /// </summary>
        public int[] unitsInCountry
        {
            get { return UnitsInCountries; }
            set { UnitsInCountries = value; }
        }

        /// <summary>
        /// Set- und Get- Methode der besetzten Ländern
        /// </summary>
        public string[] ownedCountries
        {
            get { return OwnedCountries; }
            set { OwnedCountries = value; }
        }

        /// <summary>
        /// Set- und Get- Methode der Einehiten pro Runde
        /// </summary>
        public int unitsPT
        {
            get { return UnitsPT; }
            set { UnitsPT = value; }
        }

        /// <summary>
        /// Set und Get der SpielerFarbe
        /// </summary>
        public Color playerColor
        {
            get { return PlayerColor; }
            set { PlayerColor = value; }
        }


        public void SetAllValues(string NameIn, string[] OwnedCountriesIn, int[] UnitsInCountriesIn)
        {
            Name = NameIn;
            OwnedCountries = OwnedCountriesIn;
            UnitsInCountries = UnitsInCountriesIn;
        }

        /// <summary>
        /// Fügt ein Land dem StringArray der besitzenden Länder hinzu
        /// </summary>
        /// <param name="CountryName"></param>
        public void AddOwnedCountry(string CountryName)
        {
            if (ownedCountries != null)
            {
                string[] tempCountries = new string[ownedCountries.Length + 1];
                for (int i = 0; i < ownedCountries.Length; ++i)
                {
                    tempCountries[i] = ownedCountries[i];
                }
                tempCountries[ownedCountries.Length + 1] = CountryName;
                ownedCountries = tempCountries;
            } 
        }
    }
}
