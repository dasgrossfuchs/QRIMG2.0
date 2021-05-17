using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_Imagenes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string[,] pals;
        public Form2(Image qr, string codigo, string[,] Paletas)
        {
            InitializeComponent();
            pals = Paletas;
            pictureBox1.Image = Cargada(codigo,qr);
        }
        bool cargar = false;
        public bool OKButtonClicked
        {
            get { return cargar; }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        public Image Cargada(string code, Image qr)
        {
            string[] codigo = code.Split(',');
            int s = int.Parse(codigo[2]);
            int p = int.Parse(codigo[3]);
            string[,] array = new string[s,s];
            for (int i = 0; i < s; i++)
            {
                for (int ii = 0; ii < s; ii++)
                {
                    array[i, ii] = codigo[4 + i * s + ii];
                }
            }
            Bitmap imagen = new Bitmap(480, 320);
            Graphics grafico = Graphics.FromImage(imagen);
            Bitmap dibujo = new Bitmap(501,501);
            Graphics gfx = Graphics.FromImage(dibujo);
            Image bck = new Bitmap(QR_Imagenes.Properties.Resources.Mcbck);
            grafico.DrawImage(bck,0,0,480,320);
            int sq = 500 / s, x = 0, y = 0;
            string tmpcolor ="0";
            Color valuecolor = Color.White;
            for (int i = 0; i < s; i++)
            {
                for (int ii = 0; ii < s; ii++)
                {
                    tmpcolor = array[i, ii];
                    switch (tmpcolor)
                    {
                        case "w": valuecolor = Color.White; break;
                        case "b": valuecolor = Color.Black; break;
                        case "t": valuecolor = Color.Transparent; break;
                        default:
                            valuecolor = ColorTranslator.FromHtml(pals[p,int.Parse(tmpcolor)]);
                            break;
                    }
                    gfx.FillRectangle(new SolidBrush(valuecolor),i*sq,ii*sq,sq,sq);
                }
            }
            Point izqsup = new Point(0, 0);//0
            Point dersup = new Point(sq * s, 0);//1
            Point izqinf = new Point(0, sq * s);//2
            Point derinf = new Point(sq * s, sq * s);//3
            gfx.DrawLine(new Pen(Color.Black), izqsup, dersup);//0 1
            gfx.DrawLine(new Pen(Color.Black), izqinf, derinf);//2 3
            gfx.DrawLine(new Pen(Color.Black), izqsup, izqinf);//0 2
            gfx.DrawLine(new Pen(Color.Black), dersup, derinf);//1 3
            grafico.DrawImage(dibujo, 5, 5, 300, 300);
            grafico.DrawImage(qr, 320, 5, 150, 150);
            grafico.DrawString("Dimension :", new Font("Times New Roman", 14), new SolidBrush(Color.Black), 320, 170);
            grafico.DrawString(s + " x " + s, new Font("Times New Roman", 13, FontStyle.Italic), new SolidBrush(Color.Black), 320, 190);
            grafico.DrawString("Hecho por :", new Font("Times New Roman", 14), new SolidBrush(Color.Black), 320, 210);
            grafico.DrawString(codigo[1], new Font("Times New Roman", 14, FontStyle.Italic), new SolidBrush(Color.Black), 320, 230);
            return imagen;
        }

        private void buttonguardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Guardar imagen";
            sf.Filter = "Bitmap|*.bmp|JPEG |*.jpeg|PNG |*.png";
            sf.FilterIndex = 1;
            sf.FileName = "ElDibujo";
            if (sf.FileName != "" && sf.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)sf.OpenFile();
                switch (sf.FilterIndex)
                {
                    case 1:
                        pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 2:
                        pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 3:
                        pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
                fs.Close();
                sf.Dispose();
            }
        }

        private void buttoncargar_Click(object sender, EventArgs e)
        {
            cargar = true;
            this.Close();
        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {
            cargar = false;
            this.Close();
        }
    }
}
