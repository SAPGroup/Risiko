using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Risiko
{
    public partial class Form1 : Form
    {
        // zum Zeichnen
        private Bitmap z_asBitmap;                                              //Bilddatei der Graphic z
        private Graphics z;
        private Pen stift;                                                      // für die Objekte
        private SolidBrush rubber, objectbrush;                                 // löschen (farbe des Backgrounds), für ausgefüllte Objekte 

        // der Faktor der Darstellung, wird in DrawMap verändert bzw aktualisiert
        // wird indirekt aus Source und Aktuelle Höhe und Breite der Karte berechnet
        private int Factor = 0;

        //GameField
        private GameField Game = new GameField();
        
        //Landerkennung
        private bool autoLanderkennung = true;
        
        //Speichert temporär die alte Farbe des ausgewählten Landes
        //um sie später wieder zurück zu setzen
        private Color tempSelCountry = Color.White;

        // false, wenn die Karte noch nicht gezeichnet wurde (würde sonst zu Fehlern in CheckClickOnPolygon führen)
        private bool DrawnMap = false;

        //Bei Klick wichtig!
        //Flag die festlegt ob Karte neu gezeichnet werden soll, obwohl keine Änderung im Factor vorhanden ist
        //noch benötigt?? - ja -> DrawMapWoLoad
        private bool DrawFlag = false;
        // temporärer Index des zuletzt angklickten Landes
        private int tempIndex = -1;

        
        public Form1()
        {
            InitializeComponent();
        }


        // Lädt alle wichtigen Elemente
        private void Form1_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            autoLanderkennungAktivierenToolStripMenuItem.Text = "Auto Landerkennung deaktivieren...";

            // für ländergrenze
            stift = new Pen(Color.Black, 2);
            //zum "löschen" der Anzeige
            rubber = new SolidBrush(pnlMap.BackColor);

            //bisher Nicht benötigt
            //Für sonstiges, eigentliche Länder werden mit Ländereigenen Farbe gemalt
            objectbrush = new SolidBrush(Color.Blue);     
        }


        /// <summary>
        /// Set- und Get- von Game, für Form2
        /// </summary>
        /// <returns></returns>
        public GameField GetGame()
        {
            return Game;
        }
        public void SetGame(GameField GameIn)
        {
            Game = GameIn;
        }


        /// <summary>
        /// Ereignis des Buttons "Zeichne Karte"
        /// Prüft ob die Quelldatei vorhanden ist, ansonsten direkter Abbruch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawMap_Click(object sender, EventArgs e)
        {
            // TODO: Abfrage ob Quelldatei vorhanden ist (vlt schon bei Load Fehlermeldung)
            if(DrawnMap)
                DrawMapWoLoad();
            else
                DrawAndLoadMap();   
        }

        /// <summary>
        /// zeichnet die Karte (Game)
        /// Lädt außerdem die Daten der Karte aus der SourceDB
        /// </summary>
        private void DrawAndLoadMap()
        {
            Game.LoadCountriesFromDBSource();
            z_asBitmap = new Bitmap(pnlMap.Width, pnlMap.Height);              
            z = Graphics.FromImage(z_asBitmap);

            CheckFactor();

            for (int i = 0; i < Game.numberOfCountries; ++i)
            {
                Point[] tempPoints = Game.GiveCountryToDraw(i).corners;
                Point[] realPoints = new Point[Game.GiveCountryToDraw(i).corners.Length];

                for (int j = 0; j < realPoints.Length; ++j)
                {
                    realPoints[j].X = (tempPoints[j].X * Factor);
                    realPoints[j].Y = (tempPoints[j].Y * Factor);
                }

                SolidBrush tempObjectbrush = new SolidBrush(Game.GiveCountryToDraw(i).colorOfCountry);
                z.FillPolygon(tempObjectbrush, realPoints);
                z.DrawPolygon(stift, realPoints);
            }

            //pnlMap bekommt Bilddatei zugewiesen
            pnlMap.BackgroundImage = z_asBitmap;
            DrawnMap = true;
        }

        /// <summary>
        /// Draw Map without Load, Lädt die Daten nicht erneut aus der Datenbank
        /// womit diese Funktion schneller ist, außerdem ist das Laden
        /// nur anfangs notwendig und würde zu Geschwindigkeitseinbußen führen
        /// </summary>
        private void DrawMapWoLoad()
        {
            int tempOldFactor = Factor;
            CheckFactor();
            if (tempOldFactor != Factor | DrawFlag == true)
            {
                z_asBitmap = new Bitmap(pnlMap.Width, pnlMap.Height);
                z = Graphics.FromImage(z_asBitmap);

                for (int i = 0; i < Game.numberOfCountries; ++i)
                {
                    Point[] tempPoints = Game.GiveCountryToDraw(i).corners;
                    Point[] realPoints = new Point[Game.GiveCountryToDraw(i).corners.Length];

                    for (int j = 0; j < realPoints.Length; ++j)
                    {
                        realPoints[j].X = (tempPoints[j].X * Factor);
                        realPoints[j].Y = (tempPoints[j].Y * Factor);
                    }

                    SolidBrush tempObjectbrush = new SolidBrush(Game.GiveCountryToDraw(i).colorOfCountry);
                    z.FillPolygon(tempObjectbrush, realPoints);
                    z.DrawPolygon(stift, realPoints);
                }

                //pnlMap bekommt Bilddatei zugewiesen
                pnlMap.BackgroundImage = z_asBitmap;
                DrawFlag = false;
            }
            
        }

        /// <summary>
        /// Setzt den Faktor der Darstellung der Karte
        /// </summary>
        private void CheckFactor()
        {
            int temp1 = pnlMap.Width / Game.width;
            int temp2 = pnlMap.Height / Game.height;
            if (temp1 > temp2)
                Factor = temp2;
            else
                Factor = temp1;
        }

        /// <summary>
        /// ResizeMethode der Form1, zeichnet Map erneut und bestimmt Factor neu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeForm(object sender, EventArgs e)
        {
            if (Game.numberOfCountries != 0)
            {
                DrawMapWoLoad();
            }
        }

        /// <summary>
        /// Leer!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //kein Inhalt, wird durch die einzelnen MouseUp-events der einzelnen Bedienelemente abgedeckt
            //kann nicht gelöscht werden
        }

        /// <summary>
        /// zeichnet auf pnl mithilfe der Standard GDI+
        /// allerdings nur ein Land, womit zu viel zeichnen vermieden wird
        /// -> kein Flackern
        /// </summary>
        /// <param name="IndexIn"></param>
        private void DrawCountry(int IndexIn)
        {
            Graphics temp;
            temp = pnlMap.CreateGraphics();

            Point[] tempPoints = Game.GiveCountryToDraw(IndexIn).corners;
            Point[] realPoints = new Point[Game.GiveCountryToDraw(IndexIn).corners.Length];

            for (int i = 0; i < realPoints.Length; ++i)
            {
                realPoints[i].X = (tempPoints[i].X * Factor);
                realPoints[i].Y = (tempPoints[i].Y * Factor);
            }

            SolidBrush tempObjectbrush = new SolidBrush(Game.GiveCountryToDraw(IndexIn).colorOfCountry);
            temp.FillPolygon(tempObjectbrush, realPoints);
            temp.DrawPolygon(stift, realPoints);
        }




        // Maussteuerung
        /// <summary>
        ///  MouseUP (ende eines Klicks)- Methode des Pnl der Map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlMap_MouseUp(object sender, MouseEventArgs e)
        {
            //clickedPosition = aktuelle Position der Maus in der PictureBox
            Point clickedPosition = new Point(e.X, e.Y);

            //int temp = checkClickOnPolygon(clickedPosition);
            int temp = CheckClickInPolygon(clickedPosition);

            if (temp != -1)
            {
                if (Game.turnOfPlayer != -1 & Game.gameState == 0 & Game.players[Game.turnOfPlayer].unitsPT > 0)
                {
                    Game.countries[temp].owner = Game.turnOfPlayer;
                    Game.players[Game.turnOfPlayer].unitsPT--;
                    Game.countries[temp].unitsStationed++;
                    // für pBar
                    progBMenLeft.Value = Game.players[Game.turnOfPlayer].unitsPT;
                    DrawMiddleCircle(temp);
                } 
                // Temp und momentan störend
                //MessageBox.Show(Game.countries[temp].name);
            }

        }

        /// <summary>
        /// MouseMove (Bewegung der Maus über Bedienelemnt)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlMap_MouseMove(object sender, MouseEventArgs e)
        {
            // hier könnte man DrawnMap (bool (Map bereits gezeichnet)) auch abfragen, jedoch unnötig
            // da bereits in CheckClickOnPolygon
            if (autoLanderkennung)
            {
                Point clickedPosition = new Point(e.X, e.Y);
                //int temp = checkClickOnPolygon(clickedPosition);
                int temp = CheckClickInPolygon(clickedPosition);

                //if(temp != -1)
                //  tempOldIndex = temp;

                if (temp == -1 & tempIndex != -1)//& tempOldIndex != tempIndex)
                {
                    //kein Treffer

                    // auskommentiert da Abfrage zu oft (auch in einem Land) auftritt
                    // wieso liefert CheckClickOnPolygon direkt in einem Land -1? 

                    Game.countries[tempIndex].colorOfCountry = tempSelCountry;

                    DrawCountry(tempIndex);
                    // da sonst Kreis in der Mitte verschwindet
                    DrawMiddleCircle(tempIndex);
                    tempIndex = -1;
                    DrawFlag = true;
                }
                else if (temp != -1 & temp != tempIndex)
                {
                    //bei Treffer                
                    if (tempIndex != -1)
                    {
                        Game.countries[tempIndex].colorOfCountry = tempSelCountry;
                        DrawCountry(tempIndex);
                        // da sonst der Kreis in der Mitte verschwindet
                        DrawMiddleCircle(tempIndex);
                    }

                    tempSelCountry = Game.countries[temp].colorOfCountry;
                    Game.countries[temp].colorOfCountry = Color.Yellow;

                    tempIndex = temp;
                    DrawFlag = true;

                    DrawCountry(temp);
                    // da sonst Kreis in der Mitte verschwindet
                    DrawMiddleCircle(temp);
                }
            }

        }



        // Funktionen des Menübandes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kartenDateiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = false;
            ofd.InitialDirectory = "C:\\";
            ofd.Filter = "Texte (*.txt)|*.txt;";
            ofd.Title = "Datei zum Öffnen auswählen";
            if(ofd.ShowDialog() == DialogResult.OK)
                foreach (string s in ofd.FileNames)
                {
                    //später bei mehreren Source-Dateien
                    //Game.dataSourceString = s;
                    MessageBox.Show("Öffnen: " + s);
                }
            else
            {
                MessageBox.Show("Abbruch. Es wurde keine Datei geöffnet.");
            }
        }


        /// <summary>
        /// Option Auto-Landerkennung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoLanderkennungAktivierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tempItem = autoLanderkennungAktivierenToolStripMenuItem;
            if (autoLanderkennung == false)
            {
                tempItem.Text = "Auto Landerkennung deaktivieren...";
                autoLanderkennung = true;
            }
            else
            {
                tempItem.Text = "Auto Landerkennung aktivieren...";
                autoLanderkennung = false;
            }

        }
        

        /// <summary>
        /// Neues Spiel Button im Menüband
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuesSpieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gibt der Form2 "alles" als Parameter mit
            // für veränderungen usw.
            Form2 newGame = new Form2(this);
            // Lädt Form2, in der Spieler eingegeben werden
            newGame.ShowDialog();

            // Auslesen und vergeben der Länder
            Game.LoadCountriesFromDBSource();
            Game.SpreadCountriesToPlayers();

            // eigentlich temp, später vlt mehr anzeigen+
            // gibt Spieler der aktuell am Zug ist aus
            lblMessage.Text = Convert.ToString(Game.players[Game.turnOfPlayer].name);
            // vlt temp
            progBMenLeft.Maximum = Game.players[Game.turnOfPlayer].unitsPT;
            progBMenLeft.Value = Game.players[Game.turnOfPlayer].unitsPT;
        }
      






        // Sonstiges
        /// <summary>
        /// Liefert den Index des Landes zurück
        /// über dem die Maus ist oder auf das geklickt wurde
        /// -1 -> kein Land
        /// ansonsten Index des Landes
        /// </summary>
        /// <param name="ClickedPosition"></param>
        /// <returns></returns>
        public int CheckClickInPolygon(Point ClickedPosition)
        {
            if (DrawnMap == true)
            {
                //Länder, die überprüft werden sollen, werden in Array checkCountries[] geladen
                Country[] checkCountries = Game.countries;

                for (int i = 0; i < checkCountries.Length; ++i)
                {
                    Point[] tempPoints = Game.GiveCountryToDraw(i).corners;
                    Point[] realPoints = new Point[Game.GiveCountryToDraw(i).corners.Length];

                    for (int j = 0; j < realPoints.Length; ++j)
                    {
                        realPoints[j].X = (tempPoints[j].X * Factor);
                        realPoints[j].Y = (tempPoints[j].Y * Factor);
                    }

                    if (PointInPolygon(ClickedPosition, realPoints))
                        return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Checkt ob Punkt P ind Polygon Polygon
        /// true = innherhalb des Polygons
        /// false = außerhalb
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Polygon"></param>
        /// <returns></returns>
        public bool PointInPolygon(Point P, Point[] Polygon)
        {
            Point P1, P2;

            bool Inside = false;

            if (Polygon.Length < 3)
                return Inside;

            Point oldPoint = new Point(Polygon[Polygon.Length-1].X, Polygon[Polygon.Length-1].Y);

            for (int i = 0;i < Polygon.Length;++i)
            {
                Point newPoint = new Point(Polygon[i].X, Polygon[i].Y);

                if (newPoint.X > oldPoint.X)
                {
                    P1 = oldPoint;
                    P2 = newPoint;
                }
                else
                {
                    P1 = newPoint;
                    P2 = oldPoint;
                }

                if ((newPoint.X < P.X) == (P.X <= oldPoint.X) &&
                    ((long) P.Y - (long) P1.Y)*(long) (P2.X - P1.X) < ((long) P2.Y - (long) P1.Y)*(long) (P.X - P1.X))
                    Inside = !Inside;
                oldPoint = newPoint;
            }
            return Inside;
        }

        /// <summary>
        /// Button "Zug Beenden"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            if (Game.countries != null)
            {
                // Für Testzwecke
                for (int i = 0; i < Game.countries.Length; ++i)
                    DrawMiddleCircle(i);
                DrawNeighbours();

                // später wahrscheinlich benötigt
                if (Game.players != null)
                {
                    Game.turnOfPlayer++;
                    if (Game.turnOfPlayer >= Game.players.Length)
                        Game.turnOfPlayer = 0;
                    lblMessage.Text = Convert.ToString(Game.players[Game.turnOfPlayer].name);
                }       
            }     
        }



        /// <summary>
        /// Liefert die echten Bildpunkte des Landes zurück, nicht die des "kleinen"
        /// Koordinatenfeldes, die in Corners gespeichert ist
        /// </summary>
        /// <param name="Corners"></param>
        /// <returns></returns>
        public Point[] GetRealPointsFromCorners(Point[] Corners)
        {
            Point[] realPoints = new Point[Corners.Length];

            for (int i = 0; i < realPoints.Length; ++i)
            {
                realPoints[i].X = (Corners[i].X * Factor);
                realPoints[i].Y = (Corners[i].Y * Factor);
            }
            return realPoints;
        }

        /// <summary>
        /// Kreis in der Mitte eine Landes (CountryIn)
        /// wird gezeichnet, mit der Anzahl der Einheiten
        /// </summary>
        /// <param name="Country"></param>
        public void DrawMiddleCircle(int Country)
        {
            Point[] realPoints = GetRealPointsFromCorners(Game.countries[Country].corners);
            Point Middle = GetMiddleOfPolygon(realPoints);
            
            //graphics initialisieren
            Graphics temp = pnlMap.CreateGraphics();

            //MittelKreis in Schwarz zeichnen
            SolidBrush tempObjectbrush = new SolidBrush(Color.Black);
            temp.FillEllipse(tempObjectbrush,Middle.X-10, Middle.Y-10, 20,20);

            //zum schreiben
            Font f = new Font("Arial", 10);
            tempObjectbrush = new SolidBrush(Color.White);

            // -5 magic, TODO: Verbessern, passt nicht immer (nicht immer in der Mitte -> zweistellig usw.)
            temp.DrawString(Convert.ToString(Game.countries[Country].unitsStationed), f, tempObjectbrush, Middle.X - 5, Middle.Y - 5);
        }

        /// <summary>
        /// Liefert Mittel-Punkt eines Polygons zurück
        /// In Form1, da in Game.Countries.Corners nur die Eckpunkte des "kleinen",
        /// internen Polygons gespeichert sind
        /// </summary>
        /// <param name="realPoints"></param>
        /// <returns></returns>
        public Point GetMiddleOfPolygon(Point[] Points)
        {
            double Area = 0.0;
            double MiddleX = 0.0;
            double MiddleY = 0.0;

            for (int i = 0, j = Points.Length - 1; i < Points.Length; j = i++)
            {
                float temp = Points[i].X * Points[j].Y - Points[j].X * Points[i].Y;
                Area += temp;
                MiddleX += (Points[i].X + Points[j].X) * temp;
                MiddleY += (Points[i].Y + Points[j].Y) * temp;
            }

            Area *= 3;
            return new Point((int)(MiddleX / Area), (int)(MiddleY / Area));
        }

        /// <summary>
        /// Liefert Mittel-Punkt eines Polygons zurück
        /// In Form1, da in Game.Countries.Corners nur die Eckpunkte des "kleinen",
        /// internen Polygons gespeichert sind
        /// 
        /// Rechnet die Punkte aus den Ländern automatisch mit Faktor um
        /// somit kein umrechnen in aufrufender Methode mehr nötig
        /// </summary>
        /// <param name="realPoints"></param>
        /// <returns></returns>
        public Point GetRealMiddleOfPolygon(Point[] Points)
        {
            double Area = 0.0;
            double MiddleX = 0.0;
            double MiddleY = 0.0;

            Point[] realPoints = GetRealPointsFromCorners(Points);


            for (int i = 0, j = realPoints.Length - 1; i < realPoints.Length; j = i++)
            {
                float temp = realPoints[i].X * realPoints[j].Y - realPoints[j].X * realPoints[i].Y;
                Area += temp;
                MiddleX += (realPoints[i].X + realPoints[j].X) * temp;
                MiddleY += (realPoints[i].Y + realPoints[j].Y) * temp;
            }

            Area *= 3;
            return new Point((int)(MiddleX / Area), (int)(MiddleY / Area));
        }
        

        /// <summary>
        /// TEMP:
        /// Zeichnet Nachbarländer (zeichnet das Netzwerk an Nachbarländern) 
        /// um zu überprüfen ob die Nachbarläner richtig ausgelesen wurden
        /// </summary>
        public void DrawNeighbours()
        {
            Graphics temp = pnlMap.CreateGraphics();
            
            for (int i = 0;i < Game.numberOfCountries;++i)
            {
                string[] Neighbours = Game.countries[i].neighbouringCountries;
                for (int j = 0;j < Neighbours.Length;++j)
                {
                    string tempName = Neighbours[j];
                    int tempK = 0;
                    for (int k = 0; k < Game.numberOfCountries; ++k)
                        if (Game.countries[k].name == tempName)
                            tempK = k;
                    temp.DrawLine(stift, GetRealMiddleOfPolygon(Game.countries[tempK].corners).X, 
                        GetRealMiddleOfPolygon(Game.countries[tempK].corners).Y, GetRealMiddleOfPolygon(Game.countries[i].corners).X, 
                        GetRealMiddleOfPolygon(Game.countries[i].corners).Y);
                }        
            }
        }




        // OLD, wird vermutlich nicht benötigt werden
        /// <summary>
        /// "Löscht" die Karte, bisher nicht benötigt
        /// </summary>
        private void RubberMap()
        {
            z_asBitmap = new Bitmap(pnlMap.Width, pnlMap.Height);
            z = Graphics.FromImage(z_asBitmap);

            z.FillRectangle(rubber, 0, 0, pnlMap.Width, pnlMap.Height);

            pnlMap.BackgroundImage = z_asBitmap;
        }
    }
}
