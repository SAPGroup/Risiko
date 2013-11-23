using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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
        // aus source
        private int Factor = 0;

        //GameField
        GameField Game = new GameField();
        
        //Landerkennung
        private Boolean autoLanderkennung = false;
        
        //Speichert temporär die alte Farbe des ausgewählten Landes
        private Color tempSelCountry = Color.White;

        //Flag die festlegt ob Karte neu gezeichnet werden soll, obwohl keine Änderung im Factor vorhanden ist
        private bool DrawFlag = false;

        
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      


        // Lädt alle wichtigen Elemente
        private void Form1_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            // für ländergrenze
            stift = new Pen(Color.Black, 2);
            //zum "löschen" der Anzeige
            rubber = new SolidBrush(pnlMap.BackColor);

            //Nicht benötigt
            //Für sonstiges, eigentliche Länder werden mit Ländereigenen Farbe gemalt
            objectbrush = new SolidBrush(Color.Blue);     
        }




        /// <summary>
        /// Ereignis des Buttons "Zeichne Karte"
        /// Prüft ob die Quelldatei vorhanden ist, ansonsten direkter Abbruch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawMap_Click(object sender, EventArgs e)
        {
            // TODO: Abfrage ob Quelldatei vorhanden ist
            DrawMap();   
        }

        /// <summary>
        /// zeichnet die Karte (Game)
        /// Lädt außerdem die Daten der Karte aus der SourceDB
        /// </summary>
        private void DrawMap()
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
        }


        /// <summary>
        /// Draw Map without Load, Lädt die Daten nicht erneut aus der Datenbank
        /// womit diese Funktion schneller ist, außerdem ist das Laden
        /// nur anfangs notwendig und würde zu Geschwindigkeitsproblemen führen
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
        /// "Löscht" die Karte, bisher nicht benötigt
        /// </summary>
        private void RubberMap()
        {
            z_asBitmap = new Bitmap(pnlMap.Width, pnlMap.Height);
            z = Graphics.FromImage(z_asBitmap);

            z.FillRectangle(rubber, 0,0,pnlMap.Width,pnlMap.Height);

            pnlMap.BackgroundImage = z_asBitmap;
        }



        // NEU Jonas
        /// <summary>
        /// Prüft ob ein in der Graphics z gezeichnetes Polygon mit einem Mausklick getroffen wurde
        /// </summary>
        public int checkClickOnPolygon(Point clickedPosition)
        {

            //Farbe von geklicktem Pixel, sowie von der Randfarbe des Landes werden gesetzt
            Color colorOfClickedPixel = z_asBitmap.GetPixel(clickedPosition.X, clickedPosition.Y);
            Color colorOfBorder = Color.Black;

            //Länder, die überprüft werden sollen, werden in Array checkCountries[] geladen
            Country[] checkCountries = Game.countries;


            //Rückgabewert = clickedCountryIndex
            //Rückgabewert = -1  --> kein Treffer
            //Rückgabewert > 0   --> Treffer auf Countries[cklickedCountryIndex]
            int clickedCountryIndex = -1;
            int xMin = 0, xMax = 0, yMin = 0, yMax = 0;

            CheckFactor();


            //For Schleife, die für jedes Polygon(=Land) einmal durchlaufen wird --> jedes mal wird überprüft ob der Click ein Land getroffen hat
            for (int i = 0; i < checkCountries.Length; i++)
            {

                //Setzt die Minimalen und Maximalen Koordinatenpunkte auf die Werte des ersten Eckpunkts des Polygons
                xMin = checkCountries[i].corners[0].X * Factor;
                xMax = checkCountries[i].corners[0].X * Factor;
                yMin = checkCountries[i].corners[0].Y * Factor;
                yMax = checkCountries[i].corners[0].Y * Factor;

                //Die Eckpunkte des Vierecks,das um das Polygon gelegt wird, werden bestimmt und in xMin, xMax, yMin, yMax geschrieben
                for (int j = 1; j < checkCountries[i].corners.Length; j++)
                {
                    if (checkCountries[i].corners[j].X * Factor > xMax) { xMax = checkCountries[i].corners[j].X * Factor; }
                    if (checkCountries[i].corners[j].X * Factor < xMin) { xMin = checkCountries[i].corners[j].X * Factor; }
                    if (checkCountries[i].corners[j].Y * Factor > yMax) { yMax = checkCountries[i].corners[j].Y * Factor; }
                    if (checkCountries[i].corners[j].Y * Factor < yMin) { yMin = checkCountries[i].corners[j].Y * Factor; }
                }

               
               
                //Treffer auf ein Land wenn
                // -der Mausklicks innerhalb der äußersten Eckpunkte liegt und
                //  die Farbe des getroffenen Pixels
                //      - entweder der Landesfarbe 
                //      - oder der Farbe des Randes von dem jeweiligen Land entspricht
                if (((clickedPosition.X <= xMax && clickedPosition.X >= xMin) &&
                         (clickedPosition.Y <= yMax && clickedPosition.Y >= yMin))
                        &&
                        (((colorOfClickedPixel.A ==checkCountries[i].colorOfCountry.A) &&
                          (colorOfClickedPixel.R == checkCountries[i].colorOfCountry.R) &&
                          (colorOfClickedPixel.B == checkCountries[i].colorOfCountry.B) &&
                          (colorOfClickedPixel.G == checkCountries[i].colorOfCountry.G))
                         ||
                         (((colorOfClickedPixel.A == colorOfBorder.A) &&
                           (colorOfClickedPixel.R == colorOfBorder.R) &&
                           (colorOfClickedPixel.B == colorOfBorder.B) &&
                           (colorOfClickedPixel.G == colorOfBorder.G))))
                    )
                {
                    //Bei einem Treffer wird der Rückgabewert auf den getroffenen Index gesetzt
                    clickedCountryIndex = i;

                }

            }

            return clickedCountryIndex;

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
                    MessageBox.Show("Öffnen: " + s);
                }
            else
            {
                MessageBox.Show("Abbruch. Es wurde keine Datei geöffnet.");
            }
        }





        private void pnlMap_MouseUp(object sender, MouseEventArgs e)
        {
            //clickedPosition = aktuelle Position der Maus in der PictureBox
            Point clickedPosition = new Point(e.X, e.Y);

            int temp = checkClickOnPolygon(clickedPosition);

            if (temp == -1)
            {
                //kein Treffer
            }
            else
            {
                //Treffer auf Game.Countries[temp]
                tempSelCountry = Game.countries[temp].colorOfCountry;
                Game.countries[temp].colorOfCountry = Color.Yellow;
                DrawFlag = true;
                DrawMapWoLoad();
                String ausgabe = (Game.countries[temp].name);
                MessageBox.Show(ausgabe);
            }
        }

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

        private void pnlMap_MouseMove(object sender, MouseEventArgs e)
        {
            Point clickedPosition = new Point(e.X, e.Y);
            int temp;

            if (autoLanderkennung == true)
            {
                temp = checkClickOnPolygon(clickedPosition);

                if (temp != -1)
                {
                    //Land farblich hervorheben und Karte neu zeichnen
                }
              
            }
           
        }

    }
}
