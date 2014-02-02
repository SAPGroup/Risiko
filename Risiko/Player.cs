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
        private Country[] OwnedCountries;

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

        /// <summary>
        /// Speichert die Anzahl der Männer die der Spieler bei Angriff pro
        /// Würfelrunde stellt
        /// 1 oder 2
        /// </summary>
        private int NumberOfDefenders;


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
        public Player(string NameIn, Country[] OwnedCountriesIn)
        {
            Name = NameIn;
            OwnedCountries = OwnedCountriesIn;
        }

        /// <summary>
        /// Konstruktor mit Name und besetzten Ländern und PlayerTyp
        /// </summary>
        /// <param name="NameIn"></param>
        /// <param name="OwnedCountriesIn"></param>
        public Player(string NameIn, Country[] OwnedCountriesIn, bool IsAIPlayer)
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
        public Country[] ownedCountries
        {
            get { return OwnedCountries; }
            set { OwnedCountries = value; }
        }

        /// <summary>
        /// Set- und Get- Methode der Einehiten pro Runde, 
        /// minimal 3 Männer pro Runde
        /// </summary>
        public int unitsPT
        {
            get { return UnitsPT; }
            set
            {
                if(value >=3)
                    UnitsPT = value;
            }
        }

        /// <summary>
        /// Set und Get der SpielerFarbe
        /// </summary>
        public Color playerColor
        {
            get { return PlayerColor; }
            set { PlayerColor = value; }
        }

        /// <summary>
        /// Set und Get der Anzahl der Verteidiger
        /// </summary>
        public int numberOfDefenders
        {
            get { return NumberOfDefenders; }
            set
            {
                if (value == 1 | value == 2)
                    NumberOfDefenders = value;
            }
        }



        public void SetAllValues(string NameIn, Country[] OwnedCountriesIn, int[] UnitsInCountriesIn)
        {
            Name = NameIn;
            OwnedCountries = OwnedCountriesIn;
            UnitsInCountries = UnitsInCountriesIn;
        }

        /// <summary>
        /// Fügt ein Land dem StringArray der besitzenden Länder hinzu
        /// </summary>
        /// <param name="CountryName"></param>
        public void AddOwnedCountry(Country CountryIn)
        {
            if (ownedCountries != null)
            {
                Country[] newOwnedCountries = new Country[ownedCountries.Length + 1];
                for (int i = 0;i < ownedCountries.Length;++i)
                {
                    newOwnedCountries[i] = ownedCountries[i];
                }
                newOwnedCountries[ownedCountries.Length] = CountryIn;

                ownedCountries = newOwnedCountries;
            }
            else
            {
                ownedCountries = new Country[1];
                ownedCountries[0] = CountryIn;
            }
        }



        public int GetCountryIndex(string CountryName)
        {

            return 0;
        }
    }
}
