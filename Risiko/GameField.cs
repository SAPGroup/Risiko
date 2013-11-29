using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace Risiko
{
    public class GameField
    {

        /// <summary>
        /// Reader, zum Lesen aus der Datenbank
        /// </summary>
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader reader;
        
        /// <summary>
        /// Pfad der Quelldatei!!
        /// syntax: con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
        /// "Data Source=C:\\Temp\\Risiko_Weltkarte.accdb";
        /// 
        /// TODO: Durch Datei öfnnen verändern (neues Spiel -> Quelldatei auswählen usw)
        /// </summary>
        private string DataSourceString = System.Environment.CurrentDirectory + "\\Risiko_Weltkarte1.accdb";

        /// <summary>
        /// Daten von Gamefield, Anzahl der Läbder, Höhe und Breite
        /// </summary>
        private int NumberOfCountries, Height, Width;

        /// <summary>
        /// beschränkt den Zugriff auf die Angabe der Anzahl der Länder
        /// wenn Anzahl aus Source geladen -> kein Zugriff mehr
        /// </summary>
        private bool NumberOfCountriesAccesible = true;

        /// <summary>
        /// Länder des Spielfelds
        /// </summary>
        private Country[] Countries;


        /// <summary>
        /// Anzahl der Spieler
        /// </summary>
        private int NumberOfPlayers;

        /// <summary>
        /// alle Spieler
        /// </summary>
        private Player[] Players;

        /// <summary>
        /// Index des Spielers deraktuell am Zug ist, bei 0 beginnend
        /// </summary>
        private int TurnOfPlayer = -1;


        //
        // Set- und Get-Methoden
        /// <summary>
        /// Set- und Get-Methode von NumberOfCountries (Anzahl der Länder)
        /// </summary>
        public int numberOfCountries
        {
            get { return NumberOfCountries; }
            set
            {
                if (NumberOfCountriesAccesible == true)
                    NumberOfCountries = value;
            }
        }

        /// <summary>
        /// Set- und Get- Methoden für Height
        /// </summary>
        public int height
        {
            get { return Height; }
            set { Height = value; }
        }

        /// <summary>
        /// Set- und Get- Methoden für Width
        /// </summary>
        public int width
        {
            get { return Width; }
            set { Width = value; }
        }

        /// <summary>
        /// Set- und Get- Methoden für die Anzahl der Spieler
        /// </summary>
        public int numberOfPlayers
        {
            get { return NumberOfCountries; }
            set
            {
                if (value >= 0)
                    NumberOfCountries = value;
            }
        }

        /// <summary>
        /// Set- und Get- Methoden für den Spieler
        /// der ander Reihe ist
        /// </summary>
        public int turnOfPlayer
        {
            get { return TurnOfPlayer; }
            set
            {
                if (value >= 0)
                    TurnOfPlayer = value;
            }
        }

        /// <summary>
        /// Get Methode der Countries (alle Länder des Spielfelds)
        /// </summary>
        public Country[] countries
        {
            get { return Countries; }
        }

        /// <summary>
        /// Get- und Set-Methode des Quellpfades (Source) (DB- mit der Karte)
        /// </summary>
        public string dataSourceString
        {
            get { return DataSourceString; }
            set { DataSourceString = value; }
        }

        /// <summary>
        /// Get- und Set-Methode der Spieler
        /// </summary>
        public Player[] players
        {
            get { return Players; }
            set { Players = value; }
        }


        //
        // Konstruktoren
        /// <summary>
        /// Konstruktor, "leer"
        /// </summary>
        public GameField()
        {
            NumberOfCountries = 0;
            Height = 0;
            Width = 0;
            NumberOfPlayers = 0;
            TurnOfPlayer = 0;
        }

        /// <summary>
        /// Konstruktor mit Anfangsdaten
        /// </summary>
        /// <param name="CountriesIn"></param>
        /// <param name="LengthIn"></param>
        /// <param name="WidthIn"></param>
        public GameField(int CountriesIn, int LengthIn, int WidthIn, int TurnOfPlayerIn, int NumberOfPlayersIn)
        {
            NumberOfCountries = CountriesIn;
            Height = LengthIn;
            Width = WidthIn;
            TurnOfPlayer = TurnOfPlayerIn;
            NumberOfPlayers = NumberOfPlayersIn;
        }

        //

        // Set für die Variablen (ohne Player, mit, nur Player)
        /// <summary>
        /// Festlegen der Werte der Karte, (ohne Player)
        /// </summary>
        /// <param name="CountriesIn"></param>
        /// <param name="LengthIn"></param>
        /// <param name="WidthIn"></param>
        public void SetMapOnlyValues(int CountriesIn, int LengthIn, int WidthIn)
        {
            NumberOfCountries = CountriesIn;
            Height = LengthIn;
            Width = WidthIn;
        }
        
        /// <summary>
        /// Festlegen der Werte der Karte und der Spieler 
        /// </summary>
        /// <param name="CountriesIn"></param>
        /// <param name="LengthIn"></param>
        /// <param name="WidthIn"></param>
        /// <param name="TurnOfPlayerIn"></param>
        /// <param name="NumberOfPlayersIn"></param>
        public void SetAllValues(int CountriesIn, int LengthIn, int WidthIn, int TurnOfPlayerIn, int NumberOfPlayersIn)
        {
            NumberOfCountries = CountriesIn;
            Height = LengthIn;
            Width = WidthIn;
            TurnOfPlayer = TurnOfPlayerIn;
            NumberOfPlayers = NumberOfPlayersIn;
        }

        /// <summary>
        /// Setzt nur die Spielereigenschaften
        /// </summary>
        /// <param name="TurnOfPlayerIn"></param>
        /// <param name="NumberOfPlayersIn"></param>
        public void SetPlayersOnly(int TurnOfPlayerIn, int NumberOfPlayersIn, Player[] PlayersIn)
        {
            TurnOfPlayer = TurnOfPlayerIn;
            NumberOfPlayers = NumberOfPlayersIn;
            Players = PlayersIn;
        }


        
        //
        // Sonstiges
        //
        /// <summary>
        /// Liefert Land mit entsprechendem Index zurück
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Country GiveCountryToDraw(int Index)
        {
            return Countries[Index];
        }

        /// <summary>
        /// wandelt tempString in Farbe um
        /// Muss leider alles vorgegeben werden (die möglichen farben, da sonst nur weiß zurückgegeben wird)
        /// </summary>
        /// <param name="tempColor"></param>
        /// <returns></returns>
        public Color GetColorFromString(string tempColor)
        {
            tempColor = tempColor.Trim('\t', ' ','\'');
            if (tempColor == "blue")
                return Color.Blue;
            else if (tempColor == "green")
                return Color.Green;
            else if (tempColor == "yellow")
                return Color.Yellow;
            else if (tempColor == "red")
                return Color.Red;
            else if (tempColor == "white")
                return Color.White;
            else if (tempColor == "black")
                return Color.Black;
            else if (tempColor == "violet")
                return Color.Violet;
            else if (tempColor == "orange")
                return Color.Orange;
            else 
                return Color.White;
        }





        /// <summary>
        /// Laden aus neuer accdb, Arrays, da bessere Speicher und Modifikationsmöglichkeiten
        /// sonst ist beim kreieren eigener Karten nur begrenzte Anzahl an Eckpunkten möglich
        /// außerdem ist die Anzahl der Nachbarländer begrenzt
        /// </summary>
        public void LoadCountriesFromDBSource()
        {
            // Source einbinden
            DataSourceString = System.Environment.CurrentDirectory + "\\Risiko_Weltkarte1.accdb";
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=" + DataSourceString;

            // Anzahl der Länder auslesen
            GetNumberOfCountriesDB();

            cmd.Connection = con;
            // Aus table Weltkarte (alles)
            cmd.CommandText = "select * from Worldmap;";

            // Länder erzeugen
            Countries = new Country[NumberOfCountries];

            try
            {
                //öffnen
                con.Open();
                reader = cmd.ExecuteReader();

                // Fortlaufender Zähler, zählt welche Country aktuell erzeugt werden muss
                int counter = 0;

                // temp Werte, die später dem Konstruktor der Country zugeführt werden
                Color tempColorOfCountry;
                string tempName;
                Point[] tempPoints;
                // Max X und Y Werte, um Höhe und Breite der internen "kleinen" Karte herauszufinden
                int tempMaxX = 0;
                int tempMaxY = 0;

                while (reader.Read())
                {
                    // Name
                    tempName = Convert.ToString(reader["Name"]);

                    // Color (Farbe)
                    tempColorOfCountry = GetColorFromString(Convert.ToString(reader["Color"]));

                    // Corners (Ecken)
                    string tempCorners = Convert.ToString(reader["Corners"]);
                    string[] Corners = tempCorners.Split(';');
                    tempPoints = new Point[Corners.Length/2];
                    for (int i = 0;i < Corners.Length/2;++i)
                    {
                        tempPoints[i].X = Convert.ToInt32(Corners[i*2]);
                        tempPoints[i].Y = Convert.ToInt32(Corners[i*2 + 1]);
                        if (Convert.ToInt32(Corners[i*2]) > tempMaxX)
                            tempMaxX = Convert.ToInt32(Corners[i*2]);
                        if (Convert.ToInt32(Corners[i*2 + 1]) > tempMaxY)
                            tempMaxY = Convert.ToInt32(Corners[i*2 + 1]);
                    }

                    // Konstruktor der Country
                    Countries[counter] = new Country(tempName, tempPoints, tempColorOfCountry);
                    counter++;
                }
                Width = tempMaxX;
                Height = tempMaxY;
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                // temp String, falls Fehlermeldung
                string temp = ex.Message;
            }


            // Laden der NachbarLänder, Countries muss schon festlegen, da daraus Namen
            // der Länder gelesen werden
            cmd.CommandText = "select * from Worldmap;";
            try
            {
                //öffnen
                con.Open();
                reader = cmd.ExecuteReader();

                // Fortlaufender Zähler, zählt welche Country aktuell erzeugt werden muss
                int counter = 0;

                while (reader.Read())
                {
                    
                    string tempNeighbours = Convert.ToString(reader["Neighbours"]);
                    string[] Neighbours = tempNeighbours.Split(';');
                    string[] tempNeighbouringCountries = new string[Neighbours.Length];
                    for (int i = 0;i < Neighbours.Length;++i)
                    {
                        int tempCountryID = Convert.ToInt32(Neighbours[i]);
                        tempNeighbouringCountries[i] = Countries[tempCountryID-1].name;
                    }

                    Countries[counter].neighbouringCountries = tempNeighbouringCountries;
                    counter++;
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                // temp String, falls Fehlermeldung
                string temp = ex.Message;
                MessageBox.Show(temp);
            }

        }

        /// <summary>
        /// Liest die Anzahl der Länder aus der DB
        /// um ArrayLänge festzulegen
        /// </summary>
        private void GetNumberOfCountriesDB()
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from Worldmap;";
            try
            {
                //öffnen
                con.Open();
                reader = cmd.ExecuteReader();
                // Anzahl der Länder
                int tempNumberOfCountries = 0;
                while (reader.Read())
                {
                    ++tempNumberOfCountries;
                }
                NumberOfCountries = tempNumberOfCountries;
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                string temp = ex.Message;
            }
        }








        // OLD
        ///// <summary>
        ///// Laden aus DB
        ///// </summary>
        //public void LoadCountriesFromDBSource()
        //{
        //    // Source einbinden
        //    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
        //                           "Data Source=" + DataSourceString;

        //    // Anzahl der Länder auslesen
        //    GetNumberOfCountriesDB();

        //    // Darin wird jeweils die Anzahl der Punkte gespeichert, um 0|0 Punkte zu vermeiden
        //    int[] tempCounterPointsArray = new int[numberOfCountries];
        //    int[] tempCounterNeighboursArray = new int[numberOfCountries];

        //    GetNumberPointsArrayDB(ref tempCounterPointsArray);
        //    GetNumberOfNeighboursArrayDB(ref tempCounterNeighboursArray);


        //    cmd.Connection = con;
        //    // Aus table Weltkarte (alles)
        //    cmd.CommandText = "select * from Weltkarte;";

        //    // Länder erzeugen
        //    Countries = new Country[NumberOfCountries];

        //    try
        //    {
        //        //öffnen
        //        con.Open();
        //        reader = cmd.ExecuteReader();

        //        // Fortlaufender Zähler, zählt welche Country aktuell erzeugt werden muss
        //        int counter = 0;

        //        // temp Werte, die später dem Konstruktor der Country zugeführt werden
        //        Color tempColorOfCountry;
        //        string tempName;
        //        Point[] tempPoints;

        //        while (reader.Read())
        //        {
        //            // erzeugt entsprechend viele Punkte
        //            tempPoints = new Point[tempCounterPointsArray[counter]];
        //            // liest Farbe des Landes aus
        //            tempColorOfCountry = GetColorFromString(Convert.ToString(reader["color"]));
        //            // liest den Namen des Landes aus
        //            tempName = Convert.ToString(reader["Land"]);

        //            // Liest alle vorhandenen Punkte des Landes aus
        //            for (int i = 1; i < 15; ++i)
        //            {
        //                if (Convert.ToInt32(reader["x" + i]) != -1)
        //                    tempPoints[i - 1].X = Convert.ToInt32(reader["x" + i]);
        //                if (Convert.ToInt32(reader["y" + i]) != -1)
        //                    tempPoints[i - 1].Y = Convert.ToInt32(reader["y" + i]);
        //            }

        //            // Konstruktor der Country
        //            Countries[counter] = new Country(tempName, tempPoints, tempColorOfCountry);
        //            counter++;
        //        }
        //        reader.Close();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // temp String, falls Fehlermeldung
        //        string temp = ex.Message;
        //    }


        //    // Laden der NachbarLänder (aus anderer Table)
        //    cmd.CommandText = "select * from Neighbours;";
        //    try
        //    {
        //        //öffnen
        //        con.Open();
        //        reader = cmd.ExecuteReader();

        //        // Fortlaufender Zähler, zählt welche Country aktuell erzeugt werden muss
        //        int counter = 0;

        //        while (reader.Read())
        //        {
        //            string[] tempNeighbouringCountriesNames = new string[tempCounterNeighboursArray[counter]];
        //            for (int i = 1; (i - 1) < tempCounterNeighboursArray[counter]; ++i)
        //            {
        //                int tempIDCountry = Convert.ToInt32(reader["Neighbour" + i]);
        //                tempNeighbouringCountriesNames[i - 1] = Countries[tempIDCountry - 1].name;
        //            }

        //            // Konstruktor der Country
        //            Countries[counter].neighbouringCountries = tempNeighbouringCountriesNames;
        //            counter++;
        //        }
        //        reader.Close();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // temp String, falls Fehlermeldung
        //        string temp = ex.Message;
        //        MessageBox.Show(temp);
        //    }

        //}

        ///// <summary>
        ///// Liest die Anzahl der Länder, die Höhe und Breite der Karte
        ///// aus der Source-DB aus
        ///// </summary>
        //private void GetNumberOfCountriesDB()
        //{
        //    cmd.Connection = con;
        //    cmd.CommandText = "select * from Weltkarte;";
        //    try
        //    {
        //        //öffnen
        //        con.Open();
        //        reader = cmd.ExecuteReader();

        //        int tempMaxX = 0;
        //        int tempMaxY = 0;

        //        int tempNumberOfCountries = 0;
        //        while (reader.Read())
        //        {
        //            for (int i = 1; i < 15; ++i)
        //            {
        //                if (reader["x" + i] != null & Convert.ToInt32(reader["x" + i]) > tempMaxX)
        //                    tempMaxX = Convert.ToInt32(reader["x" + i]);
        //                if (reader["y" + i] != null & Convert.ToInt32(reader["y" + i]) > tempMaxY)
        //                    tempMaxY = Convert.ToInt32(reader["y" + i]);
        //            }
        //            ++tempNumberOfCountries;
        //        }
        //        height = tempMaxY;
        //        width = tempMaxX;
        //        NumberOfCountries = tempNumberOfCountries;
        //        reader.Close();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        string temp = ex.Message;
        //    }
        //}

        ///// <summary>
        ///// Speichert die Anzahl der Nachbarländer in ParameterArray
        ///// </summary>
        ///// <param name="tempCounterOfNeighbours"></param>
        //private void GetNumberOfNeighboursArrayDB(ref int[] tempCounterOfNeighbours)
        //{
        //    cmd.Connection = con;
        //    cmd.CommandText = "select * from Neighbours;";
        //    try
        //    {
        //        //öffnen
        //        con.Open();
        //        reader = cmd.ExecuteReader();

        //        int Counter = 0;

        //        while (reader.Read())
        //        {
        //            int tempNeighbourCounter = 0;
        //            for (int i = 1; i < 11; ++i)
        //            {
        //                if (reader["Neighbour" + i] != null & Convert.ToInt32(reader["Neighbour" + i]) >= 1)
        //                    tempNeighbourCounter++;
        //            }
        //            tempCounterOfNeighbours[Counter] = tempNeighbourCounter;
        //            ++Counter;
        //        }

        //        reader.Close();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        string temp = ex.Message;
        //    }
        //}

        ///// <summary>
        ///// Speicher in dem Eingabe-Array die Anzahl der Punkte des
        ///// jeweiligen Index, Country[x] -> temmCounterPointsArray[x] 
        ///// </summary>
        ///// <param name="tempCounterPointsArray">zuvor leerer Array</param>
        //private void GetNumberPointsArrayDB(ref int[] tempCounterPointsArray)
        //{
        //    cmd.Connection = con;
        //    cmd.CommandText = "select * from Weltkarte;";
        //    try
        //    {
        //        //öffnen
        //        con.Open();
        //        reader = cmd.ExecuteReader();
        //        int Counter = 0;
        //        while (reader.Read())
        //        {
        //            int tempNumberOfPoints = 0;
        //            for (int i = 1; i < 15; ++i)
        //            {
        //                if (Convert.ToInt32(reader["x" + i]) != -1 & Convert.ToInt32(reader["y" + i]) != -1)
        //                    tempNumberOfPoints++;
        //            }
        //            tempCounterPointsArray[Counter] = tempNumberOfPoints;
        //            Counter++;
        //        }
        //        reader.Close();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        string temp = ex.Message;
        //    }
        //}
    }
}
