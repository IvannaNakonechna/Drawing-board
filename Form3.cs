using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Projekt3
{
    public partial class ProjektNr3_Nakonechna68940 : Form
    {
        
        
        Graphics graphicsProjektNr3;

        
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing;
        List<RectangleF> rectangles = new List<RectangleF>();
        List<RectangleF> ellipses = new List<RectangleF>();
        List<Point> point = new List<Point>(); 
        List<Point> point1 = new List<Point>(); 

        Color kolorLinii= Color.Black;
        Color KolorTłaRysownicy = Color.White;
        Color kolorWypełnienia = Color.Blue;
        int grubośćLinii = 1;
        Pen pen = new Pen(Color.Black);
        DashStyle dashStyle = new DashStyle();
        LineCap lineCapStart = new LineCap();
        LineCap lineCapEnd = new LineCap();
        public ProjektNr3_Nakonechna68940()
        {
            InitializeComponent();
            inpbProjekt.Image = new Bitmap(inpbProjekt.Width, inpbProjekt.Height);
            graphicsProjektNr3 = Graphics.FromImage(inpbProjekt.Image);
                        
            inpbProjekt.MouseDown += InpbProjekt_MouseDown;
            inpbProjekt.MouseUp += InpbProjekt_MouseUp;
            inpbProjekt.MouseMove += InpbProjekt_MouseMove;
           
        }

        private void ProjektNr3_FormClosing(object sender, FormClosingEventArgs e)
        {
            KokpitProjektuNr3 FormularzKokpity = new KokpitProjektuNr3();
            FormularzKokpity.Show();
            this.Hide();
        }

        private void InpbProjekt_MouseDown(object sender, MouseEventArgs e)
        {

            inlblX.Text = e.Location.X.ToString();
            inlblY.Text = e.Location.Y.ToString();

            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                isDrawing = true;
                endPoint = e.Location;
            }
        }


        private void InpbProjekt_MouseUp(object sender, MouseEventArgs e)
        {
            pen = new Pen(kolorLinii,grubośćLinii);
            pen.DashStyle = dashStyle;
            pen.StartCap = lineCapStart;
            pen.EndCap = lineCapEnd;
            inlblX.Text = e.Location.X.ToString();
            inlblY.Text = e.Location.Y.ToString();
            
            if (e.Button == MouseButtons.Left)
            {
                if (isDrawing)
                {
                    isDrawing = false;
                    if (inrdb_Prostokąt.Checked)
                    {

                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        graphicsProjektNr3.DrawRectangle(pen, x,y,width,height);

                    }
                    if (inrdb_ProstokątWypełniony.Checked)
                    {

                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        SolidBrush brush = new SolidBrush(kolorWypełnienia);
                        graphicsProjektNr3.FillRectangle(brush, x, y, width, height);
                        brush.Dispose();

                    }
                    if (inrdb_Kwadrat.Checked)
                    {

                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        width = height;
                        graphicsProjektNr3.DrawRectangle(pen, x, y, width, height);

                    }
                    if (inrdb_KwadratWypełniony.Checked)
                    {

                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        width = height;
                        SolidBrush brush = new SolidBrush(kolorWypełnienia);
                        graphicsProjektNr3.FillRectangle(brush, x, y, width, height);
                        brush.Dispose();

                    }
                    if (inrdb_Elipsa.Checked)
                    {
                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        graphicsProjektNr3.DrawEllipse(pen, x, y, width, height);
                                               
                    }
                    if (inrdb_ŁukElipsy.Checked)
                    {
                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        graphicsProjektNr3.DrawArc(pen, x, y, width, height,30,260);

                    }
                    if (inrdb_WycinekElipsy.Checked)
                    {
                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        
                        Pen blackPen = new Pen(kolorLinii, 1);
                        graphicsProjektNr3.DrawPie(blackPen,x,y,width,height,e.Location.X,e.Location.Y );
                        blackPen.Dispose();
                    }
                    if (inrdb_WypełnionyWycinekElipsy.Checked)
                    {
                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        
                        SolidBrush brush = new SolidBrush(kolorWypełnienia);
                        graphicsProjektNr3.FillPie(brush, x, y, width, height, e.Location.X, e.Location.Y);
                        brush.Dispose();
                    }
                    if (inrdb_WupełnionyObramowychWycinekElipsy.Checked)
                    {
                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        Rectangle rect = new Rectangle(x, y, width, height);
                        double startAngle = Math.Atan2(startPoint.Y - rect.Y - rect.Height / 2, startPoint.X - rect.X - rect.Width / 2);
                        double endAngle = Math.Atan2(endPoint.Y - rect.Y - rect.Height / 2, endPoint.X - rect.X - rect.Width / 2);

                        startAngle *= (180 / Math.PI);
                        endAngle *= (180 / Math.PI);

                        if (startAngle < 0)
                            startAngle += 360;
                        if (endAngle < 0)
                            endAngle += 360;
                        SolidBrush brush = new SolidBrush(kolorWypełnienia);
                         x = Math.Min(startPoint.X, endPoint.X);
                         y = Math.Min(startPoint.Y, endPoint.Y);
                         width = Math.Abs(startPoint.X - endPoint.X);
                         height = Math.Abs(startPoint.Y - endPoint.Y);
                       
                        graphicsProjektNr3.DrawRectangle(pen, x, y, width, height);
                        graphicsProjektNr3.FillPie(brush, rect, (float)startAngle, (float)(endAngle - startAngle));
                        brush.Dispose();

                    }
                    if (inrdb_ElipsaWypełniona.Checked)
                    {
                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        SolidBrush brush = new SolidBrush(kolorWypełnienia);
                        graphicsProjektNr3.FillEllipse(brush, x, y, width, height);
                        brush.Dispose();
                    }
                    if (inrdb_Okrąg.Checked)
                    {
                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        width = height;
                        graphicsProjektNr3.DrawEllipse(pen, x, y, width, height);

                    }
                    if (inrdb_Koło.Checked)
                    {
                        int x = Math.Min(startPoint.X, endPoint.X);
                        int y = Math.Min(startPoint.Y, endPoint.Y);
                        int width = Math.Abs(startPoint.X - endPoint.X);
                        int height = Math.Abs(startPoint.Y - endPoint.Y);
                        width = height;
                        SolidBrush brush = new SolidBrush(kolorWypełnienia);
                        graphicsProjektNr3.FillEllipse(brush, x, y, width, height);
                        brush.Dispose();

                    }
                    if (inrdb_KrzywaBeziera.Checked)
                    {

                        if (point.Count < 4)
                        {
                            int x = 0;
                            int y = 0;
                            if (point.Count < 1)
                            {
                                x = startPoint.X;
                                y = startPoint.Y;
                                point.Add(new Point(x, y));
                            }
                            else
                            {

                                x = endPoint.X;
                                y = endPoint.Y;
                                point.Add(new Point(x, y));

                                Point[] arr_point = new Point[point.Count];
                                int i = 0;
                                foreach (Point p in point)
                                {
                                    arr_point[i] = p;
                                    i++;
                                }

                                graphicsProjektNr3.DrawBeziers(pen, arr_point);

                            }
                            SolidBrush brush = new SolidBrush(Color.Red);

                            foreach (Point p in point)
                            {
                                graphicsProjektNr3.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);

                                Font smallFont = new Font(Font.FontFamily, 7);
                                graphicsProjektNr3.DrawString($"P{point.IndexOf(p) + 1}", smallFont, Brushes.Black, p.X + 4, p.Y - 4);
                            }
                            brush.Dispose();

                        }
                        else
                        {
                            point.Clear();
                        }
                    }
                    if (inrdbSklejanaKrzywaBeziera.Checked)
                    {
                        if (point.Count < 4)
                        {
                            int x = 0;
                            int y = 0;
                            if (point.Count < 1)
                            {
                                x = startPoint.X;
                                y = startPoint.Y;
                                point.Add(new Point(x, y));
                            }
                            else
                            {
                                x = endPoint.X;
                                y = endPoint.Y;

                                point.Add(new Point(x, y));
                                
                                Point[] arr_point = point.ToArray();
                                graphicsProjektNr3.DrawBeziers(pen, arr_point);

                                if (point.Count == 4)
                                {
                                    point.Clear();
                                    point.Add(new Point(x, y));
                                }
                           
                            }
                            SolidBrush brush = new SolidBrush(Color.Red);
                            
                            foreach (Point p in point)
                            {
                                graphicsProjektNr3.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);

                                Font smallFont = new Font(Font.FontFamily, 7);
                                graphicsProjektNr3.DrawString($"P{point.IndexOf(p) + 1}", smallFont, Brushes.Black, p.X + 4, p.Y - 4);
                            }
                            brush.Dispose();

                        }
                        else if (point.Count < 7)
                        {
                            int x = endPoint.X;
                            int y = startPoint.Y;
                            point.Add(new Point(x, y));

                            Point[] arr_point = point.ToArray();
                            graphicsProjektNr3.DrawBeziers(pen, arr_point);
                        }
                        else
                        {
                            point.Clear();
                        }

                    }
                    if (inrdb_KrzywaKardynalna.Checked)
                    {
                        if (point1.Count < 5)
                        {
                            int x = 0;
                            int y = 0;
                            if (point1.Count < 1)
                            {
                                x = startPoint.X;
                                y = startPoint.Y;
                                point1.Add(new Point(x, y));
                            }
                            else
                            {

                                x = endPoint.X;
                                y = endPoint.Y;
                                point1.Add(new Point(x, y));

                                Point[] arr_point = new Point[point1.Count];
                                int i = 0;
                                foreach (Point p in point1)
                                {
                                    arr_point[i] = p;
                                    i++;
                                }

                                if (point1.Count == 5)
                                    graphicsProjektNr3.DrawCurve(pen, arr_point);
                            }
                            SolidBrush brush = new SolidBrush(Color.Red);

                            foreach (Point p in point1)
                            {
                                graphicsProjektNr3.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);

                                Font smallFont = new Font(Font.FontFamily, 7);
                                graphicsProjektNr3.DrawString($"P{point1.IndexOf(p) + 1}", smallFont, Brushes.Black, p.X + 4, p.Y - 4);
                            }
                            brush.Dispose();

                        }
                        else
                        {
                            point1.Clear();
                        }
                    }
                    if (inrdb_ZamkniętaKrzywaKardynalna.Checked)
                    {
                        if (point1.Count < 5)
                        {
                            int x = 0;
                            int y = 0;
                            if (point1.Count < 1)
                            {
                                x = startPoint.X;
                                y = startPoint.Y;
                                point1.Add(new Point(x, y));
                            }
                            else
                            {
                                x = endPoint.X;
                                y = endPoint.Y;

                                point1.Add(new Point(x, y));

                                Point[] arr_point = new Point[point1.Count];
                                int i = 0;
                                foreach (Point p in point1)
                                {
                                    arr_point[i] = p;
                                    i++;
                                }

                                if (point1.Count == 5)
                                    graphicsProjektNr3.DrawClosedCurve(pen, arr_point);
                            }
                            SolidBrush brush = new SolidBrush(Color.Red);

                            foreach (Point p in point1)
                            {
                                graphicsProjektNr3.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);

                                Font smallFont = new Font(Font.FontFamily, 7);
                                graphicsProjektNr3.DrawString($"P{point1.IndexOf(p) + 1}", smallFont, Brushes.Black, p.X + 4, p.Y - 4);
                            }
                            brush.Dispose();

                        }
                        else
                        {
                            point1.Clear();
                        }
                    }
                    if (inrdb_WypełnionaZamkniętaKrzywKardynalna.Checked)
                    {
                        if (point1.Count < 5)
                        {
                            int x = 0;
                            int y = 0;
                            if (point1.Count < 1)
                            {
                                x = startPoint.X;
                                y = startPoint.Y;
                                point1.Add(new Point(x, y));
                            }
                            else
                            {
                                x = endPoint.X;
                                y = endPoint.Y;

                                point1.Add(new Point(x, y));
 
                                Point[] arr_point = new Point[point1.Count];
                                int i = 0;
                                foreach (Point p in point1)
                                {
                                    arr_point[i] = p;
                                    i++;
                                }

                                if (point1.Count == 5)
                                {
                                    SolidBrush brush1 = new SolidBrush(Color.Blue);
                                    graphicsProjektNr3.FillClosedCurve(brush1, arr_point);
                                    brush1.Dispose();
                                }

                            }
                            SolidBrush brush = new SolidBrush(Color.Red);

                            foreach (Point p in point1)
                            {
                                graphicsProjektNr3.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);

                                Font smallFont = new Font(Font.FontFamily, 7);
                                graphicsProjektNr3.DrawString($"P{point1.IndexOf(p) + 1}", smallFont, Brushes.Black, p.X + 4, p.Y - 4);
                            }
                            brush.Dispose();

                        }
                        else
                        {
                            point1.Clear();
                        }
                    }
                    if (inrdb_WypełnionaObramowaZamkniętaKrzywKar.Checked)
                    {
                        if (point1.Count < 5)
                        {

                            int x = 0;
                            int y = 0;
                            if (point1.Count < 1)
                            {
                                x = startPoint.X;
                                y = startPoint.Y;
                                point1.Add(new Point(x, y));
                            }
                            else
                            {
                                x = endPoint.X;
                                y = endPoint.Y;
                                point1.Add(new Point(x, y));
                                
                                Point[] arr_point = new Point[point1.Count];
                                int i = 0;
                                foreach (Point p in point1)
                                {
                                    arr_point[i] = p;
                                    i++;
                                }

                                if (point1.Count == 5)
                                {
                                    SolidBrush brush1 = new SolidBrush(Color.Blue);
                                    graphicsProjektNr3.FillClosedCurve(brush1, arr_point);
                                    x = arr_point[0].X - 10;
                                    y = arr_point[2].Y;
                                    int width = Math.Abs(arr_point[0].X - arr_point[4].X) + 15;
                                    int height = Math.Abs(Math.Min(arr_point[0].Y, arr_point[4].Y) - arr_point[2].Y) + 20;
                                    graphicsProjektNr3.DrawRectangle(pen, x, y, width, height);
                                    brush1.Dispose();
                                }

                            }
                            SolidBrush brush = new SolidBrush(Color.Red);

                            foreach (Point p in point1)
                            {
                                graphicsProjektNr3.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);

                                Font smallFont = new Font(Font.FontFamily, 7);
                                graphicsProjektNr3.DrawString($"P{point1.IndexOf(p) + 1}", smallFont, Brushes.Black, p.X + 4, p.Y - 4);
                            }
                            brush.Dispose();

                        }
                        else
                        {
                            point1.Clear();
                        }
                    }
                   
                    inpbProjekt.Refresh();

                }
            }
           
        }

        private void InpbProjekt_MouseMove(object sender, MouseEventArgs e)
        {
            inlblX.Text = e.Location.X.ToString();
            inlblY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;
            }
            inpbProjekt.Refresh();
        }

        private void INzapiszBitMapęWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog INZapisPliku = new SaveFileDialog();
            INZapisPliku.Filter = "Image Files|*.jpg;*.jpeg;*.png|Allfiles(*.*.)|*.*";
            INZapisPliku.FilterIndex = 1;
            INZapisPliku.RestoreDirectory = true;
            INZapisPliku.InitialDirectory = "D:\\";
            INZapisPliku.Title = "Zapisz BitMapę";

            if (INZapisPliku.ShowDialog() == DialogResult.OK)
            {
                int INSzerokośćTła = Convert.ToInt32(inpbProjekt.Width);
                int INWysokośćTła = Convert.ToInt32(inpbProjekt.Height);

                using (Bitmap INBitmap = new Bitmap(INSzerokośćTła, INWysokośćTła))
                {
                    inpbProjekt.DrawToBitmap(INBitmap, new Rectangle(0, 0, INSzerokośćTła, INWysokośćTła));
                    INBitmap.Save(INZapisPliku.FileName, ImageFormat.Jpeg);
                }
            }
            
        }

        private void INrestartProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProjektNr3_Nakonechna68940 INForm3 = new ProjektNr3_Nakonechna68940();
            INForm3.Show();
        }

        private void INexitZFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void INodczytajBitMapęZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
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
                        Image myThumbnail = myBitmap.GetThumbnailImage(inpbProjekt.Width, inpbProjekt.Height,
                            myCallback, IntPtr.Zero);
                        inpbProjekt.Image = myThumbnail;

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

        private void INkolorLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color color = colorDialog1.Color; kolorLinii = color;
            }
        }

        private void INkolorWypełnieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color color = colorDialog1.Color; kolorWypełnienia = color;
            }
        }

        private void INkolorTłaRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color color = colorDialog1.Color; inpbProjekt.BackColor = color;
            }
        }

        private void INtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            grubośćLinii = 1;
        }

        private void INtoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            grubośćLinii = 5;
        }

        private void INtoolStripMenuItem4_Click(object sender, EventArgs e)
        {
            grubośćLinii = 10;
        }

        private void INciaglyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dashStyle= DashStyle.Solid; 
        }

        private void INkropkowanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dashStyle = DashStyle.Dot;
        }

        private void INkreskowanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dashStyle = DashStyle.Dash;
        }
     

        private void INkreskowanaKrokpowanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dashStyle = DashStyle.DashDot;
        }

        private void INkreskowanaKropkowanaKropkowanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dashStyle=DashStyle.DashDotDot;
        }

       

        private void INtriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           lineCapStart = LineCap.Triangle;
        }

        private void INnoAnchorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineCapStart = LineCap.NoAnchor;
        }

        private void INsquareAnchorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lineCapStart = LineCap.SquareAnchor;
        }

        private void INroundAnchorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            lineCapStart = LineCap.RoundAnchor;
        }
                       
        private void INtriangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lineCapEnd = LineCap.Triangle;
        }

        private void INroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineCapEnd = LineCap.Round;
        }

        private void INsquareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineCapEnd = LineCap.Square;
        }

        private void INsquare1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineCapStart = LineCap.Square;
        }

        private void INround1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineCapStart = LineCap.Round;
        }

        private void INdiamondAnchorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            lineCapStart = LineCap.DiamondAnchor;
        }

        private void INarrowAnchorToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            lineCapStart = LineCap.ArrowAnchor;
        }

        private void INdiamondAnchorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lineCapEnd= LineCap.DiamondAnchor;
        }

        private void INarrowAnchorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            lineCapEnd= LineCap.ArrowAnchor;
        }

        private void INroundAnchorToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            lineCapEnd=LineCap.RoundAnchor;
        }

        private void INsquareAnchorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            lineCapEnd = LineCap.SquareAnchor;
        }

        private void INnoAnchorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lineCapEnd = LineCap.NoAnchor;
        }

        private void INkrójCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog INKrójCzcionki = new FontDialog();
            INKrójCzcionki.Font = this.Font;
            if (INKrójCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = INKrójCzcionki.Font;
            }

            INKrójCzcionki.Dispose();
        }

        private void INrozmiarCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog INRozmiarCzcionki = new FontDialog();
            INRozmiarCzcionki.Font = this.Font;
            if (INRozmiarCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = INRozmiarCzcionki.Font;
            }

            INRozmiarCzcionki.Dispose();
        }

        private void INkolorCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
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

