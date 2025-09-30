using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3
{
    public partial class RysownicaLab : Form
    {
        const ushort PromieńPunktu = 2;
        Graphics Rysownica;
        Pen Pióro;
        SolidBrush Pędzel;
        Point Punkt = Point.Empty;
        private int amountImage = 1;
        private int PoziomRekurencji;
        private Color KolorWypełnienia = Color.Red;
        
        public RysownicaLab()
        {
            InitializeComponent();


            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);

            Rysownica = Graphics.FromImage(pbRysownica.Image);

            Pióro = new Pen(Color.Red, 1.7F);
            Pióro.DashStyle = DashStyle.Dash;
            Pióro.StartCap = LineCap.Round;
            Pióro.EndCap = LineCap.Round;

            Pędzel = new SolidBrush(Color.Blue);
        }
        private void RysownicaLab_FormClosing(object sender, FormClosingEventArgs e)
        {

            KokpitProjektuNr3 FormularzKokpity = new KokpitProjektuNr3();
            FormularzKokpity.Show();
            this.Hide();
        }
        private void pbRysownica_MouseDown(object sender, MouseEventArgs e)
        {

            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
                Punkt = e.Location;
        }

        private void pbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            int LewyGórnyNarożnikX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int LewyGórnyNarożnikY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int Szerokość = Math.Abs(Punkt.X- e.Location.X);
            int Wysokość = Math.Abs(Punkt.Y-e.Location.Y);
            
            if (e.Button == MouseButtons.Left)
            {
                if (rdbPunkt.Checked)



                    Rysownica.FillEllipse(Pędzel, Punkt.X - PromieńPunktu,
                                                  Punkt.Y - PromieńPunktu,
                                                  2 * PromieńPunktu,
                                                  2 * PromieńPunktu);


                if (rdbLinia.Checked)
                    Rysownica.DrawLine(Pióro, Punkt.X, Punkt.Y, e.Location.X, e.Location.Y);

                if (rdbLiniaKreślonaMyszkę.Checked)
                    Rysownica.DrawLine(Pióro, Punkt.X, Punkt.Y, e.Location.X, e.Location.Y);
                if (rdbWielokąt.Checked) 
                {
                    ushort StopieńWielokąta;
                    int PromieńWielokąta;
                    numUD_LiczbaKątów.Enabled = false;
                    StopieńWielokąta = (ushort)numUD_LiczbaKątów.Value;
                    double KątMiędzyWierzchołkamiWielokąta = 360.0 / StopieńWielokąta;
                    double KątPołożeniaPierwszegoWierzchołkaWielokąta = 0.0;
                    PromieńWielokąta = Szerokość;
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąta];
                    for (int i = 0; i < StopieńWielokąta; i++) 
                    { 
                        WierzchołkiWielokąta[i].X = LewyGórnyNarożnikX +
                        (int)(PromieńWielokąta * Math.Cos(Math.PI*(KątPołożeniaPierwszegoWierzchołkaWielokąta +
                        i* KątMiędzyWierzchołkamiWielokąta) / 180));
                    WierzchołkiWielokąta[i].Y = LewyGórnyNarożnikY - 
                        (int)(PromieńWielokąta * Math.Sin(Math.PI*(KątPołożeniaPierwszegoWierzchołkaWielokąta + 
                        i * KątMiędzyWierzchołkamiWielokąta) / 180));
                    }
                    Rysownica.DrawPolygon(Pióro, WierzchołkiWielokąta);
                }
                if (rdbWielokątWypełnoiny.Checked)
                {
                    ushort StopieńWielokąta;
                    int PromieńWielokąta;
                    numUD_LiczbaKątów.Enabled = false;
                    StopieńWielokąta = (ushort)numUD_LiczbaKątów.Value;
                    double KątMiędzyWierzchołkamiWielokąta = 360.0 / StopieńWielokąta;
                    double KątPołożeniaPierwszegoWierzchołkaWielokąta = 0.0;
                    PromieńWielokąta = Szerokość;
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąta];
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        WierzchołkiWielokąta[i].X = LewyGórnyNarożnikX +
                        (int)(PromieńWielokąta * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkaWielokąta +
                        i * KątMiędzyWierzchołkamiWielokąta) / 180));
                        WierzchołkiWielokąta[i].Y = LewyGórnyNarożnikY -
                            (int)(PromieńWielokąta * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkaWielokąta +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));
                    }
                    Rysownica.FillPolygon(Pędzel, WierzchołkiWielokąta);
                }
                if (rdbTrójkątSierpińskiego.Checked)
                {
                    ushort poziomRekurencji = (ushort)numUD_PoziomRekurencji.Value;
                    Point WierzchołeGórny = new Point(LewyGórnyNarożnikX + Szerokość / 2, LewyGórnyNarożnikY);
                    Point WierzchołeLewy = new Point(LewyGórnyNarożnikX, LewyGórnyNarożnikY + Wysokość);
                    Point WierzchołePrawy = new Point(LewyGórnyNarożnikX + Szerokość, LewyGórnyNarożnikY + Wysokość);
                    WykreślTrójkątSierpińskiego(Rysownica, poziomRekurencji, bttnKolorWypełnienia.BackColor, WierzchołeGórny, WierzchołeLewy, WierzchołePrawy);



                }
            }
            pbRysownica.Refresh();
        }

        private void pbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();

            if (e.Button == MouseButtons.Left)
            {
                if (rdbLiniaKreślonaMyszkę.Checked)
                {
                    Rysownica.DrawLine(Pióro, Punkt.X, Punkt.Y, e.Location.X, e.Location.Y);
                    Punkt =e.Location;

                }

            }

            pbRysownica.Refresh();

        }
        
         private void rdbTrójkątSierpińskiego_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTrójkątSierpińskiego.Checked)
            {
                numUD_PoziomRekurencji.Value = 3;
                bttnKolorWypełnienia.BackColor = Color.Yellow;
                lblPoziomRekurencji.Visible = true;
                numUD_PoziomRekurencji.Visible = true;
                bttnKolorWypełnienia.Visible = true;
                numUD_PoziomRekurencji.Enabled = true;
                bttnKolorWypełnienia.Enabled = true;
            }

            else
            {
                lblPoziomRekurencji.Visible = false;
                numUD_PoziomRekurencji.Visible = false;
                bttnKolorWypełnienia.Visible = false;
            }
        }
        void WykreślTrójkątSierpińskiego(Graphics Rysownica, 
            int poziomRekurencji, Color KolorWypiełnienia, 
            Point WierzchołeGórny, Point WierzchołeLewy, Point WierzchołePrawy)
        {
            if (poziomRekurencji == 0)
            {
                Point[] WierzchołkiTrójkąta = { WierzchołeGórny, WierzchołeLewy, WierzchołePrawy };
                using (SolidBrush Pędzel = new SolidBrush(KolorWypiełnienia))
                {
                    Rysownica.FillPolygon(Pędzel, WierzchołkiTrójkąta);
                }
            }

            else
            {
                Point PunktSrodkowyLewejKrawędzi = new Point((WierzchołeGórny.X + WierzchołeLewy.X) / 2, (WierzchołeGórny.Y + WierzchołeLewy.Y) / 2);
                Point PunktSrodkowyPrawejKrawędzi = new Point((WierzchołeGórny.X + WierzchołePrawy.X) / 2, (WierzchołeGórny.Y + WierzchołePrawy.Y) / 2);
                Point PunktSrodkowyDolneKrawędzi = new Point((WierzchołeLewy.X + WierzchołePrawy.X) / 2, (WierzchołeLewy.Y + WierzchołePrawy.Y) / 2);

                WykreślTrójkątSierpińskiego(Rysownica, poziomRekurencji - 1, KolorWypiełnienia, WierzchołeGórny, PunktSrodkowyLewejKrawędzi, PunktSrodkowyPrawejKrawędzi);
                WykreślTrójkątSierpińskiego(Rysownica, poziomRekurencji - 1, KolorWypiełnienia, PunktSrodkowyLewejKrawędzi, WierzchołeLewy, PunktSrodkowyDolneKrawędzi);
                WykreślTrójkątSierpińskiego(Rysownica, poziomRekurencji - 1, KolorWypiełnienia, PunktSrodkowyPrawejKrawędzi, PunktSrodkowyDolneKrawędzi, WierzchołePrawy);
            }
        }
        private void kolorTłaRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
                 DialogResult result = colorDialog1.ShowDialog(); 
                if (result == DialogResult.OK)
                {
                   Color color = colorDialog1.Color; pbRysownica.BackColor = color;
                }
        }

        private void kolorLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog(); 
            if (result == DialogResult.OK)
            {
                Color color = colorDialog1.Color; Pióro.Color = color;
            }
        }

        private void kolorWypełnieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color color = colorDialog1.Color; Pędzel.Color = color;
            }
            
        }

        private void bttnKolorWypełnienia_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorów = new ColorDialog();
            PaletaKolorów.Color = bttnKolorWypełnienia.BackColor;
            if (PaletaKolorów.ShowDialog() == DialogResult.OK)
            {
                bttnKolorWypełnienia.BackColor = PaletaKolorów.Color;
            }

            PaletaKolorów.Dispose();

        }

        private void zapiszBitMapęWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog INZapisPliku = new SaveFileDialog();
            INZapisPliku.Filter = "Image Files|*.jpg;*.jpeg;*.png|Allfiles(*.*.)|*.*";
            INZapisPliku.FilterIndex = 1;
            INZapisPliku.RestoreDirectory = true;
            INZapisPliku.InitialDirectory = "D:\\";
            INZapisPliku.Title = "Zapisz BitMapę";

            if (INZapisPliku.ShowDialog() == DialogResult.OK)
            {
                int INSzerokośćTła = Convert.ToInt32(pbRysownica.Width);
                int INWysokośćTła = Convert.ToInt32(pbRysownica.Height);

                using (Bitmap INBitmap = new Bitmap(INSzerokośćTła, INWysokośćTła))
                {
                    pbRysownica.DrawToBitmap(INBitmap, new Rectangle(0, 0, INSzerokośćTła, INWysokośćTła));
                    INBitmap.Save(INZapisPliku.FileName, ImageFormat.Jpeg);
                }
            }
        }

        private void odczytajBitMapęZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();
            this.openFileDialog1.Filter =
            "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
            "All files (*.*)|*.*";

            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Photos";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {

                        Image.GetThumbnailImageAbort myCallback =
                                new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        Bitmap myBitmap = new Bitmap(file);
                        Image myThumbnail = myBitmap.GetThumbnailImage(pbRysownica.Width, pbRysownica.Height,
                            myCallback, IntPtr.Zero);
                        pbRysownica.Image = myThumbnail;



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        private void exitZFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void restartProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RysownicaLab INForm2 = new RysownicaLab();
            INForm2.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pióro.Width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Pióro.Width = 5;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Pióro.Width = 10;
        }

        private void ciaglyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.Solid;
        }

        private void kropkowanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.Dot;
        }

        private void kreskowanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.Dash;
        }

        private void kreskowanyKropkowanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.DashDot;
        }

        private void kreskowanyKropkowanyKropkowanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.DashDotDot;
        }

        private void roundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.StartCap = LineCap.Round;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.StartCap = LineCap.Triangle;
        }

        private void squareAnchorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.StartCap = LineCap.SquareAnchor;
        }

        private void roundAnchorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.StartCap = LineCap.RoundAnchor;
        }

        private void diamondAnchorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.StartCap = LineCap.DiamondAnchor;
        }

        private void arrowAnchorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.StartCap = LineCap.ArrowAnchor;
        }

        private void roundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pióro.EndCap = LineCap.Round;
        }

        private void triangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pióro.EndCap = LineCap.Triangle;
        }

        private void squareAnchorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pióro.EndCap = LineCap.SquareAnchor;
        }

        private void roundAnchorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pióro.EndCap = LineCap.RoundAnchor;
        }

        private void diamondAnchorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pióro.EndCap = LineCap.DiamondAnchor;
        }

        private void arrowAnchorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pióro.EndCap = LineCap.ArrowAnchor;
        }

        private void krójCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog INKrójCzcionki = new FontDialog();
            INKrójCzcionki.Font = this.Font;
            if (INKrójCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = INKrójCzcionki.Font;
            }

            INKrójCzcionki.Dispose();
        }

        private void rozmiarCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog INRozmiarCzcionki = new FontDialog();
            INRozmiarCzcionki.Font = this.Font;
            if (INRozmiarCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = INRozmiarCzcionki.Font;
            }

            INRozmiarCzcionki.Dispose();
        }

        private void kolorCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog INKolorCzcionki = new ColorDialog();
            INKolorCzcionki.Color = this.ForeColor;
            if (INKolorCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = INKolorCzcionki.Color;
            }

            INKolorCzcionki.Dispose();
        }
    }
}
    

        

