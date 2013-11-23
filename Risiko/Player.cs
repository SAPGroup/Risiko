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

        /// <summary>
        /// Basiskonstruktor
        /// </summary>
        public Player()
        {
            Name = "";
            UnitsPT = 0;
        }

        public Player(string NameIn, string[] OwnedCountriesIn)
        {
            
        }
    }
}
