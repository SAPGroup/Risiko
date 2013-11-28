using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risiko
{
    class Country
    {

        /// <summary>
        /// Eckpunkte des Landes
        /// </summary>
        private Point[] Corners;

        /// <summary>
        /// Name des Landes
        /// </summary>
        private string Name;

        /// <summary>
        /// Farbe des Landes
        /// </summary>
        private Color ColorOfCountry;

        /// <summary>
        /// Besitzender Spieler, -1 kein spieler
        /// </summary>
        private int Owner;

        /// <summary>
        /// Anzahl der Einheiten im Land
        /// </summary>
        private int UnitsStationed;

        /// <summary>
        /// Array in dem die Nachbarländer gespeichert sind
        /// </summary>
        private string[] NeighbouringCountries;

        /// <summary>
        /// Speichert den Kontinent, zu dem das Land gehört
        /// 0-x , Kontinente, -1 unbelegt (noch nicht initialisiert)
        /// </summary>
        private int Continent;


        //
        // Konstruktoren
        /// <summary>
        /// Basiskonstruktor, Corners werden nicht gesetzt, Name = leer
        /// </summary>
        public Country()
        {
            Name = "";
            ColorOfCountry = Color.Black;
            UnitsStationed = 0;
            Owner = -1;
        }

        /// <summary>
        /// veränderterKonstruktor
        /// </summary>
        /// <param name="NameIn"></param>
        /// <param name="CornersIn"></param>
        public Country(string NameIn, Point[] CornersIn, Color ColorIn)
        {
            Corners = CornersIn;
            Name = NameIn;
            ColorOfCountry = ColorIn;
        }

        /// <summary>
        /// veränderterKonstruktor
        /// </summary>
        /// <param name="NameIn"></param>
        /// <param name="CornersIn"></param>
        public Country(string NameIn, Point[] CornersIn, Color ColorIn, string[]  NeighbouringCountriesIn, int ContinentIn)
        {
            Corners = CornersIn;
            Name = NameIn;
            ColorOfCountry = ColorIn;
            NeighbouringCountries = NeighbouringCountriesIn;
            Continent = ContinentIn;
        }

        /// <summary>
        /// veränderterKonstruktor
        /// </summary>
        /// <param name="NameIn"></param>
        /// <param name="CornersIn"></param>
        public Country(string NameIn, Point[] CornersIn, Color ColorIn, string[] NeighbouringCountriesIn)
        {
            Corners = CornersIn;
            Name = NameIn;
            ColorOfCountry = ColorIn;
            NeighbouringCountries = NeighbouringCountriesIn;
        }


        //
        //Set für alle Variablen
        /// <summary>
        /// Setzt die Eigenschaften eines Objekts
        /// </summary>
        /// <param name="CornersIn"></param>
        /// <param name="NameIn"></param>
        public void SetValues(Point[] CornersIn, string NameIn, Color ColorIn, int OwnerIn, int UnitsStationedIn)
        {
            Corners = CornersIn;
            Name = NameIn;
            ColorOfCountry = ColorIn;
            UnitsStationed = UnitsStationedIn;
            Owner = OwnerIn;
        }

        //
        // Set- und Get-Methoden
        /// <summary>
        /// Set- und Get- Methoden für Name
        /// </summary>
        public string name
        {
            get { return Name; }
            private set { Name = value; }
        }

        /// <summary>
        /// Set und Get der Ecken des Vielecks
        /// </summary>
        public Point[] corners
        {
            get { return Corners; }
            private set { Corners = value; }
        }

        /// <summary>
        /// Set und Get der Farbe des Landes
        /// </summary>
        public Color colorOfCountry
        {
            get { return ColorOfCountry; }
            set { ColorOfCountry = value; }
        }

        /// <summary>
        /// Set und Get des Besitzers
        /// </summary>
        public int owner
        {
            get { return Owner; }
            set
            {
                if(value >= 0)
                    Owner = value; 
            }
        }

        /// <summary>
        /// Set und Get der Stationierten Einheiten
        /// </summary>
        public int unitsStationed
        {
            get { return UnitsStationed; }
            set
            {
                if (value >= 0)
                    UnitsStationed = value;
            }
        }

        /// <summary>
        /// Set und Get der benachbarten Länder
        /// </summary>
        public string[] neighbouringCountries
        {
            get { return NeighbouringCountries; }
            set { NeighbouringCountries = value; }
        }

        /// <summary>
        /// Set- und Get- des Kontinent, zu dem das Land gehört
        /// </summary>
        public int continent
        {
            get { return Continent; }
            set { Continent = value; }
        }
    }
}
