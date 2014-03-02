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
        /// Zufallsgenerator, hier konstruiert, da sonst Zufallszahl
        /// eventuell die gleiche ist, da zu schnell hintereinander 
        /// konstruiert werden würde
        /// </summary>
        Random rnd = new Random();


        /// <summary>
        /// Pfad der Quelldatei!!
        /// syntax: con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
        /// "Data Source=C:\\Temp\\Risiko_Weltkarte.accdb";
        /// 
        /// TODO: Durch Datei öfnnen verändern (neues Spiel -> Quelldatei auswählen usw)
        /// </summary>
        private string DataSourceString = System.Environment.CurrentDirectory + "\\Risiko_Weltkarte2.accdb";

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
        /// alle Spieler
        /// </summary>
        private Player[] Players;

        /// <summary>
        /// Index des Spielers deraktuell am Zug ist, bei 0 beginnend
        /// </summary>
        private Player ActualPlayer = null;

        /// <summary>
        /// Aktueller Status, 0 Setzen der Spieler am Anfang des Spiels
        /// 1 setzen vor jeder Runde der Spieler
        /// 2 angreifen, 3 ziehen
        /// </summary>
        private int GameState = -1;


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
        /// Set- und Get- Methoden für den Spieler
        /// der ander Reihe ist
        /// </summary>
        public Player actualPlayer
        {
            get { return ActualPlayer; }
            set { ActualPlayer = value; }
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

        /// <summary>
        /// Set und Get des SpielStatuses, Begrenzung da andere
        /// Werte keinen Sinn ergeben
        /// </summary>
        public int gameState
        {
            get { return GameState; }
            set
            {
                if (value >= 0 & value <= 3)
                    GameState = value;
            }
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
            ActualPlayer = null;
        }

        /// <summary>
        /// Konstruktor mit Anfangsdaten
        /// </summary>
        /// <param name="CountriesIn"></param>
        /// <param name="LengthIn"></param>
        /// <param name="WidthIn"></param>
        public GameField(int CountriesIn, int LengthIn, int WidthIn, Player ActualPlayerIn)
        {
            NumberOfCountries = CountriesIn;
            Height = LengthIn;
            Width = WidthIn;
            ActualPlayer = ActualPlayerIn;
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
        public void SetAllValues(int CountriesIn, int LengthIn, int WidthIn, Player ActualPlayerIn)
        {
            NumberOfCountries = CountriesIn;
            Height = LengthIn;
            Width = WidthIn;
            ActualPlayer = ActualPlayerIn;
        }

        /// <summary>
        /// Setzt nur die Spielereigenschaften
        /// </summary>
        /// <param name="TurnOfPlayerIn"></param>
        /// <param name="NumberOfPlayersIn"></param>
        public void SetPlayersOnly(Player ActualPlayerIn, Player[] PlayersIn)
        {
            ActualPlayer = ActualPlayerIn;
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
        public Country GiveCountry(int Index)
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
        /// Verteilt die Länder an die Spieler, zufallsgeneriert
        /// TODO: Option Länder selbst auswählen, abwechselnd Einheit in verfügbares Land setzen
        /// </summary>
        public void SpreadCountriesToPlayers()
        {
            Random rnd = new Random();
            // Speichert temporär die Anzahl der Länder die der Spieler
            // bereits besitzt
            int[] CounterOfCountries = new int[players.Length];

            // Die Anzahl der Länder die jeder Spieler mindestens bekommt
            int CountriesEachPlayer = countries.Length/players.Length;

            // Anzahl der "mindest" länder setzen
            for (int i = 0; i < players.Length; ++i)
                CounterOfCountries[i] = CountriesEachPlayer;

            // Die Anzahl der Länder die "zu viel" sind, die also
            // Spielern zusätzlich zugeteilt werden
            // TODO: "Echte" Spieler vlt bevorzugen (nicht KI)
            int CountriesLeft = countries.Length - (CountriesEachPlayer*players.Length);

            // Zufallsvariable
            int tempRnd;

            // Gibt zufällig manchen Spielern mehr Länder (die die zu viel waren)
            while (CountriesLeft > 0)
            {
                tempRnd = (int) rnd.NextDouble() * players.Length;
                if (CounterOfCountries[tempRnd] == CountriesEachPlayer)
                {
                    CounterOfCountries[tempRnd]++;
                    CountriesLeft--;
                }
            }

            // Gibt den Spielern die Länder
            for (int i = 0;i < countries.Length;i++)
            {
                tempRnd = (int) (rnd.NextDouble() * players.Length);
                if (CounterOfCountries[tempRnd] > 0)
                {
                    // Country- Besitzer festlegen
                    countries[i].owner = Players[tempRnd];
                    // Anzahl der Länder für neuen Besitzer die noch zu vergeben sind verringern
                    CounterOfCountries[tempRnd]--;
                    // 1 Einheit in Land setzen
                    countries[i].unitsStationed = 1;
                    // 1 Einheit bei Spieler abziehen
                    Players[tempRnd].unitsPT--;
                }
                else
                    --i;
                // damit land sicher vergeben wird
            }

            // Farbe des Spielers in Land übernehmen
            for (int i = 0;i < countries.Length;++i)
            {
                countries[i].colorOfCountry = countries[i].owner.playerColor;
            }

            // Besitz der Länder in ownedCountries der Spieler speichern, (2seitige Beziehung) TODO: unnötig?
            for (int i = 0; i < countries.Length; ++i)
            {
                players[GetPlayerIndex(countries[i].owner.name)].AddOwnedCountry(countries[i]);
            }
        }





        /// <summary>
        /// Laden aus neuer accdb, Arrays, da bessere Speicher und Modifikationsmöglichkeiten
        /// sonst ist beim kreieren eigener Karten nur begrenzte Anzahl an Eckpunkten möglich
        /// außerdem ist die Anzahl der Nachbarländer begrenzt
        /// </summary>
        public void LoadCountriesFromDBSource()
        {
            // Source einbinden
            //DataSourceString = System.Environment.CurrentDirectory + "\\Risiko_Weltkarte1.accdb";
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



        /// <summary>
        /// Methode die beim Attackieren eines Landes aufgerufen wird
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Defender"></param>
        /// <param name="NumberOfAttackers"></param>
        /// <param name="NumberOfDefenders"></param>
        public void AttackCountry(ref Country Attacker,ref Country Defender,ref int NumberOfAttackers, int NumberOfDefenders)
        {
            // TODO: Different Difficulties, nur beim würfeln benötigt
            // NumberOfDefenders wird auf -1 gesetzt wenn Land übernommen wurde
            int[] AttackerNbr = new int[NumberOfAttackers];
            for (int i = 0;NumberOfAttackers > i;++i)
            {
                AttackerNbr[i] = ThrowDices(0);
            }
            AttackerNbr = SortArray(AttackerNbr);

            int[] DefenderNbr = new int[NumberOfDefenders];
            for (int i = 0;i < NumberOfDefenders;++i)
            {
                DefenderNbr[i] = ThrowDices(0);
            }
            DefenderNbr = SortArray(DefenderNbr);


            int AttackerLoss = 0, DefenderLoss = 0;

            // Normalfall: mehr oder gleich viel Angreifer als Verteidiger
            if (NumberOfAttackers >= NumberOfDefenders)
            {
                for (int i = 0;i < NumberOfDefenders;++i)
                {
                    if (AttackerNbr[i] > DefenderNbr[i])
                        DefenderLoss++;
                    else
                        AttackerLoss++;
                }
            }
            // Sonderfall
            else
            {
                for (int i = 0; i < NumberOfAttackers; ++i)
                {
                    if (AttackerNbr[i] > DefenderNbr[i])
                        DefenderLoss++;
                    else
                        AttackerLoss++;
                }
            }

            Attacker.unitsStationed -= AttackerLoss;
            NumberOfAttackers -= AttackerLoss;
            Defender.unitsStationed -= DefenderLoss;
            //NumberOfDefenders -= DefenderLoss;

            //nochmal angreifen, letzter mann wird von Main geregelt
            if(NumberOfAttackers > 0 && NumberOfDefenders > 0)
                AttackCountry(ref Attacker,ref Defender,ref NumberOfAttackers, NumberOfDefenders);
            if (NumberOfDefenders == 0)
            {
                NumberOfDefenders = -1;
                Defender.owner = Attacker.owner;
                Defender.unitsStationed = NumberOfAttackers;
                Attacker.unitsStationed -= NumberOfAttackers;
                Defender.colorOfCountry = Attacker.colorOfCountry;
            }

        }




        /// <summary>
        /// Würfelt und gibt Augenzahl zurück
        /// </summary>
        /// <returns></returns>
        private int ThrowDices(int Difficulty)
        {
            // TODO: Different Difficulties
            if (Difficulty == 0)
            {
                int Number = (int)(rnd.NextDouble() * 5) + 1;
                return Number;
            }
            return 0;
        }


        /// <summary>
        /// Sortiert Array, höchste zuletzt
        /// </summary>
        /// <param name="Array"></param>
        /// <returns></returns>
        private int[] SortArray(int[] Array)
        {
            int[] a = Array;
            int x, i, j;
            for (i = a.Length - 2;i > 0;i--)
            {
                for (j = 0;j <= i;j++)
                {
                    if (a[j + 1] > a[j])
                    {
                        x = a[j]; 
                        a[j] = a[j + 1];
                        a[j + 1] = x;
                    }
                }   
            }

            return a;
        }


        /// <summary>
        /// Liefert Index aus Players[] des Spielers mit NameIn zurück
        /// </summary>
        /// <param name="NameIn"></param>
        /// <returns></returns>
        private int GetPlayerIndex(string NameIn)
        {
            for (int i = 0;i < Players.Length;++i)
            {
                if (Players[i].name == NameIn)
                    return i;
            }
            // error
            return -1;
        }


        /// <summary>
        /// Gibt Index eines Landes in OwnedCountries eines Spielers aus
        /// </summary>
        /// <param name="CountryNameIn"></param>
        /// <param name="PlayerIn"></param>
        /// <returns></returns>
        public int GetIndexOfCountryInOwnedCountries(string CountryNameIn, Player PlayerIn)
        {
            for (int i = 0;i < PlayerIn.ownedCountries.Length;++i)
            {
                if (PlayerIn.ownedCountries[i].name == CountryNameIn)
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// Gibt zurück ob Länder mit Index1 und 2 Nachbarländer sind
        /// </summary>
        /// <param name="IndexCountry1"></param>
        /// <param name="IndexCountry2"></param>
        /// <returns></returns>
        public bool CountriesAreNeighbours(int IndexCountry1, int IndexCountry2)
        {
            string Country2Name = countries[IndexCountry2].name;
            for (int i = 0;i < Countries[IndexCountry1].neighbouringCountries.Length;++i)
            {
                if (Countries[IndexCountry1].neighbouringCountries[i] == Country2Name)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Liefert Index eines landes zurück
        /// </summary>
        /// <param name="CountryNameIn"></param>
        /// <returns></returns>
        public int GetCountryIndex(string CountryNameIn)
        {
            for (int i = 0;i < countries.Length;++i)
            {
                if (countries[i].name == CountryNameIn)
                    return i;
            }
            return -1;
        }


        // ToAdd Methoden, (Überladungen)
        /// <summary>
        /// Fügt ToAdd an letzter Stelle des Arrays ArrayIn ein
        /// </summary>
        /// <param name="ArrayIn"></param>
        /// <param name="ToAdd"></param>
        public string[] AddToArray(string[] ArrayIn, string ToAdd)
        {
            string[] OutBuff = new string[ArrayIn.Length+1];
            for (int i = 0;i < ArrayIn.Length;++i)
                OutBuff[i] = ArrayIn[i];
            OutBuff[ArrayIn.Length] = ToAdd;
            return OutBuff;
        }
        public int[] AddToArray(int[] ArrayIn, int ToAdd)
        {
            int[] OutBuff = new int[ArrayIn.Length + 1];
            for (int i = 0; i < ArrayIn.Length; ++i)
                OutBuff[i] = ArrayIn[i];
            OutBuff[ArrayIn.Length] = ToAdd;
            return OutBuff;
        } 
    }
}
