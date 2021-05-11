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
        public Form2(Image qr, string codigo)
        {
            InitializeComponent();
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
            string[] array = new string[s * s];
            for (int i = 0; i < s * s; i++)
            {
                array[i] = codigo[Array.IndexOf(codigo, "a-") + 1 + i];
            }
            Bitmap imagen = new Bitmap(480, 320);
            Graphics grafico = Graphics.FromImage(imagen);
            Bitmap dibujo = new Bitmap(300,300);
            Graphics gfx = Graphics.FromImage(dibujo);
            grafico.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Image bck = new Bitmap(QR_Imagenes.Properties.Resources.Mcbck);
            grafico.DrawImage(bck,0,0,480,320);
            int temper = 0;
            int sq = 300 / s, x = 0, y = 0;
            Color valuecolor = Color.White;
            for (int i = 0; i < s; i++)
            {
                y = i * sq;
                for (int ii = 0; ii < s; ii++)
                {
                    x = ii * sq;
                    valuecolor = ColorTranslator.FromHtml(array[temper]);
                    gfx.FillRectangle(new SolidBrush(valuecolor), x, y, sq, sq);
                    gfx.DrawRectangle(new Pen(valuecolor), x, y, sq, sq);
                    temper++;
                }
            }
            grafico.DrawImage(dibujo, 5, 5, 300, 300);
            int dif = 305;//45 + (sq * s) + (sq + x);
            grafico.DrawLine(new Pen(Color.Black, 3), 5, 5, dif, 5);
            grafico.DrawLine(new Pen(Color.Black, 3), 5, 5, 5, dif);
            grafico.DrawLine(new Pen(Color.Black, 3), dif,5,dif, dif);
            grafico.DrawLine(new Pen(Color.Black, 3), 5, dif, dif, dif);
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
