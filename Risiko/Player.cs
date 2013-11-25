using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risiko
{
    class Player
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
        private int[] UnitsInCountry;

        /// <summary>
        /// Die Anzahl der Männer die der Spieler am Anfang des Zuges setzten kann
        /// </summary>
        private int UnitsPT;


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
            get { return UnitsInCountry; }
            set { UnitsInCountry = value; }
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
    }
}
