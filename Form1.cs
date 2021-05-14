﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ColorPickerWPF;
using System.IO;
using QRCodeEncoderLibrary;
using QRCodeDecoderLibrary;


namespace QR_Imagenes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
        }
        int size = 0;
        string cadena;
        string paleta = "0";
        string[,] pixl2;
        string[,] Paletas = new string[0,0];
        int selpal = 0;
        int selcol = 14;
        bool seleccionando = false, md = false;
        private void Form1_Load(object sender, EventArgs e)//estado inicial de la forma
        {
            textBox1.Text = "anon";
            dimension.SelectedIndex = 15;
            CargaPaleta();
            Coloreta();
            cuadricular2();
        }
        public void CargaPaleta() 
        {
            string path = @"prueba.csv";
            string[] csv = File.ReadAllLines(path);
                Paletas = new string[csv.Length-1,13];
            for (int i = 1; i < csv.Length; i++)
            {
                comboBox1.Items.Add(csv[i]);
                string[] paletatemp = csv[i].Split(',');
                for (int ii = 1; ii < 14; ii++)
                {
                    Paletas[i - 1, ii - 1] = paletatemp[ii];
                }
            }
            for (int i = 0; i < Paletas.GetLength(0); i++)
            {
                int x = 180;
                int y = 20;
                Bitmap img = new Bitmap(x,y);
                Graphics gfx = Graphics.FromImage(img);
                for (int ii = 0; ii < 13; ii++)
                {
                    gfx.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(Paletas[i,ii])), ii * x/12, 0, x / 12, y);
                    gfx.DrawLine(new Pen(Color.Black),0,0,x,0);
                    gfx.DrawLine(new Pen(Color.Black), 0, 0, 0, y);
                    gfx.DrawLine(new Pen(Color.Black), x, 0, x, y);
                    gfx.DrawLine(new Pen(Color.Black), 0, y, x, y);
                }
                imageList1.Images.Add(img);

            }
            comboBox1.SelectedIndex = 0;
            comboBox1.Update();
        }
        public void Coloreta() 
        {
            int x = button13.Width;
            Bitmap img = new Bitmap(x,x);
            Graphics gfx = Graphics.FromImage(img);
            gfx.FillRectangle(new SolidBrush(Color.Gray),0,0,x/2,x/2 );
            gfx.FillRectangle(new SolidBrush(Color.Gray),x/2,x/2, x / 2, x / 2);
            gfx.FillRectangle(new SolidBrush(Color.White),x/2,0, x / 2, x / 2);
            gfx.FillRectangle(new SolidBrush(Color.White),0,x/2, x / 2, x / 2);
            button13.Image = img;
            button14.BackColor = Color.White;
            button15.BackColor = Color.Black;
            button15.BackColor = Color.Black;
            label1.Text = comboBox1.SelectedItem.ToString();
            button1.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(1));
            button2.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(2));
            button3.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(3));
            button4.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(4));
            button5.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(5));
            button6.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(6));
            button7.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(7));
            button8.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(8));
            button9.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(9));
            button10.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(10));
            button11.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(11));
            button12.BackColor = ColorTranslator.FromHtml(comboBox1.SelectedItem.ToString().Split(',').ElementAt(12));
        }
        public void cuadricular2() //Falta implementar diccionario
        {
            size = int.Parse(dimension.SelectedItem.ToString().Split('x').ElementAt(0));
            if (pixl2 == null)
            {
                pixl2 = new string[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int ii = 0; ii < size; ii++)
                    {
                        pixl2[i, ii] = "t";
                    }
                }
            }
            else {
                string[,] px2tmp = new string[pixl2.GetLength(0), pixl2.GetLength(1)];
                for (int i = 0; i < pixl2.GetLength(0); i++)
                {
                    for (int ii = 0; ii < pixl2.GetLength(1); ii++)
                    {
                        px2tmp[i, ii] = pixl2[i, ii];
                    }
                }
                pixl2 = new string[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int ii = 0; ii < size; ii++)
                    {
                        pixl2[i, ii] = "t";
                    }
                }
                for (int i = 0; i < px2tmp.GetLength(0); i++)
                {
                    for (int ii = 0; ii < px2tmp.GetLength(1); ii++)
                    {
                        if (pixl2.GetLength(0) > i && pixl2.GetLength(1) > ii)
                        {
                            pixl2[i, ii] = px2tmp[i, ii];
                        }

                    }
                }

            }


            float step = 500f / size;
            float hstep = 500f / size / 2;
            Bitmap img = new Bitmap(501, 501);
            Graphics gfx = Graphics.FromImage(img);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    switch (pixl2[x, y])
                    {
                        case "t":
                            gfx.FillRectangle(new SolidBrush(Color.Gray), x * step, y * step, hstep, hstep);
                            gfx.FillRectangle(new SolidBrush(Color.Gray), x * step + hstep, y * step + hstep, hstep, hstep);
                            gfx.FillRectangle(new SolidBrush(Color.White), x * step + hstep, y * step, hstep, hstep);
                            gfx.FillRectangle(new SolidBrush(Color.White), x * step, y * step + hstep, hstep, hstep);
                            break;
                        case "w":
                            gfx.FillRectangle(new SolidBrush(Color.White), x * step, y * step, step, step);
                            break;
                        case "b":
                            gfx.FillRectangle(new SolidBrush(Color.Black), x * step, y * step, step, step);
                            break;
                        default:

                            break;
                    }
                }
            }
            for (float i = 0; i < size + 1; i++)
            {
                gfx.DrawLine(new Pen(Color.Black, 2), 0f, i * step, 500f, i * step);
                gfx.DrawLine(new Pen(Color.Black, 2), i * step, 0f, i * step, 500f);
            }
            imagenvista.Image = img;
            actualizarcadena();
            //if (panel1.BackgroundImage == null) { panel1.BackgroundImage = img; }
            //else { panel1.BackgroundImage.Dispose(); panel1.BackgroundImage = img; }

        }
        public void updater(int x, int y) 
        {
            float step = 500f / size;
            float hstep = 500f / size / 2;
            Image img = imagenvista.Image;
            Graphics gfx = Graphics.FromImage(img);
            switch (pixl2[x, y])
            {
                case "t":
                    gfx.FillRectangle(new SolidBrush(Color.Gray), x * step, y * step, hstep, hstep);
                    gfx.FillRectangle(new SolidBrush(Color.Gray), x * step + hstep, y * step + hstep, hstep, hstep);
                    gfx.FillRectangle(new SolidBrush(Color.White), x * step + hstep, y * step, hstep, hstep);
                    gfx.FillRectangle(new SolidBrush(Color.White), x * step, y * step + hstep, hstep, hstep);
                    break;
                case "w":
                    gfx.FillRectangle(new SolidBrush(Color.White), x * step, y * step, step, step);
                    break;
                case "b":
                    gfx.FillRectangle(new SolidBrush(Color.Black), x * step, y * step, step, step);
                    break;
                default:
                    break;
            }
            for (float i = 0; i < size + 1; i++)
            {
                gfx.DrawLine(new Pen(Color.Black, 2), 0f, i * step, 500f, i * step);
                gfx.DrawLine(new Pen(Color.Black, 2), i * step, 0f, i * step, 500f);
            }
            imagenvista.Image = img;
            actualizarcadena();

        }
        public void actualizarcadena()//
        {
            if (string.IsNullOrEmpty(textBox1.Text))//0
            {
                textBox1.Text = "anon";
            }
            cadena = "qrimg," + textBox1.Text + "," + size + "," + paleta;//0,1,2,3
            for (int i = 0; i < size; i++)
            {
                for (int ii = 0; ii < size; ii++)//4,...,size*size+4
                {
                    cadena = cadena + "," + pixl2[i, ii];
                }
            }
            actualizarqr();
        }

        private void imagenvista_Click(object sender, EventArgs e)
        {
            Point coor = imagenvista.PointToClient(Cursor.Position);
            double stp = Convert.ToDouble(imagenvista.Width) / Convert.ToDouble(size);
            //ME CAGA LA LOGICA DE ESTO PERO BUENO
            int x = Convert.ToInt32(Math.Floor(Convert.ToDouble(coor.X) / stp));
            int y = Convert.ToInt32(Math.Floor(Convert.ToDouble(coor.Y) / stp));
            string color= "w";
            if (x < pixl2.GetLength(0) && y < pixl2.GetLength(1) && x >= 0 && y >= 0 && pixl2[x, y] != color)
            {
                pixl2[x, y] = color;// utilizar color seleccionado aqui, a partir de los colores de las bibliotecas.
                updater(x, y);
            }
        }
        private void imagenvista_MouseMove(object sender, MouseEventArgs e)
        {
            if (md)
            {
                Point coor = imagenvista.PointToClient(Cursor.Position);
                double stp = Convert.ToDouble(imagenvista.Width) / Convert.ToDouble(size);
                //ME CAGA LA LOGICA DE ESTO PERO BUENO
                int x = Convert.ToInt32(Math.Floor(Convert.ToDouble(coor.X) / stp));
                int y = Convert.ToInt32(Math.Floor(Convert.ToDouble(coor.Y) / stp));
                string color = "w";
                if (x < pixl2.GetLength(0) && y < pixl2.GetLength(1) && x >= 0 && y >= 0 && pixl2[x, y] != color)
                {
                    pixl2[x, y] = color;// utilizar color seleccionado aqui, a partir de los colores de las bibliotecas.
                    updater(x, y);
                }
            }
        }
        private void imagenvista_MouseDown(object sender, MouseEventArgs e){md = true;}

        private void imagenvista_MouseLeave(object sender, EventArgs e){md = false;}
        private void dimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (size == 0)
            {
                //cuadricular();
                cuadricular2();
                return; }
            if (dimension.SelectedIndex == size - 1)
            { return; }
            DialogResult dr = MessageBox.Show("Es posible que los cambios no se guarden, deseas continuar?", "Redimensionar?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cuadricular2();
            }
            else {
                dimension.SelectedIndex = dimension.Items.IndexOf(size.ToString() + " x " + size.ToString());
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void actualizarqr()
        {
            QRCodeEncoder qce = new QRCodeEncoder();
            qce.ErrorCorrection = QRCodeEncoderLibrary.ErrorCorrection.L;
            qce.ModuleSize = 4;
            qce.QuietZone = 16;
            qce.Encode(cadena);
            pictureBox1.Image = qce.CreateQRCodeBitmap();
        }
        private void botonguardar_Click(object sender, EventArgs e)
        {
            actualizarcadena();
            QRCodeEncoder qce = new QRCodeEncoder();
            qce.ErrorCorrection = QRCodeEncoderLibrary.ErrorCorrection.L;
            qce.ModuleSize = 4;
            qce.QuietZone = 16;
            qce.Encode(cadena);
            Image qrcode = qce.CreateQRCodeBitmap();

            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Guardar imagen";
            sf.Filter = "PNG |*.png| JPEG |*.jpeg";
            sf.FileName = "Codigo" + textBox1.Text;
            if (sf.FileName != "" && sf.ShowDialog() == DialogResult.OK)
            {

                System.IO.FileStream fs = (System.IO.FileStream)sf.OpenFile();
                switch (sf.FilterIndex)
                {
                    case 1:
                        qrcode.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 2:
                        qrcode.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 3:
                        qrcode.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
                fs.Close();
                sf.Dispose();
            }
        }
        private void botonguardarimagen_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Guardar imagen";
            sf.Filter = "Bitmap|*.bmp|JPEG |*.jpeg|PNG |*.png";
            sf.FilterIndex = 1;
            sf.FileName = "ElDibujoDe" + textBox1.Text;
            if (sf.FileName != "" && sf.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)sf.OpenFile();
                switch (sf.FilterIndex)
                {
                    case 1:
                        imagenvista.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 2:
                        imagenvista.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                       break;
                    case 3:
                        imagenvista.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
                fs.Close();
                sf.Dispose();
            }
        }
        /// VERSION1 no actualizado
        //public void cuadricular()
        //{
        //    size = dimension.SelectedIndex + 1;
        //    pixel = new string[size * size];
        //    pxl = new PictureBox[size * size];
        //    for (int i = 0; i < size * size; i++)
        //    {
        //        pixel[i] = "t";
        //    }
        //    int w = panel1.Width / size;
        //    int cont = 0;
        //    for (int i = 0; i < size; i++)
        //    {
        //        for (int ii = 0; ii < size; ii++)
        //        {

        //            int x = panel1.Location.X + (w * ii);
        //            int y = panel1.Location.Y + (w * i);
        //            pxl[cont] = new PictureBox();
        //            pxl[cont].Size = new Size(w, w);
        //            pxl[cont].Location = new Point(x, y);
        //            pxl[cont].Name = ii + 1 + "," + i + 1;
        //            pxl[cont].BorderStyle = BorderStyle.FixedSingle;
        //            pxl[cont].SizeMode = PictureBoxSizeMode.StretchImage;
        //            pxl[cont].MouseClick += clickcuadro;
        //            this.Controls.Add(pxl[cont]);
        //            toolTip.SetToolTip(pxl[cont], (ii + 1) + "," + (i + 1));
        //            cont++;
        //        }
        //    }
        //    panel1.SendToBack();
        //    actualizardibujo();
        //} //Deprecated
        //public Image img(string value) //Se vuelve innecesario con nueva version
        //{
        //    Bitmap imagen = new Bitmap(16, 16);
        //    Graphics grafico = Graphics.FromImage(imagen);
        //    grafico.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        //    if (value == "t")
        //    {
        //        grafico.FillRectangle(new SolidBrush(Color.Gray), 0, 0, 8, 8);
        //        grafico.FillRectangle(new SolidBrush(Color.Gray), 8, 8, 8, 8);
        //        grafico.FillRectangle(new SolidBrush(Color.White), 8, 0, 8, 8);
        //        grafico.FillRectangle(new SolidBrush(Color.White), 0, 8, 8, 8);

        //    }
        //    else
        //    {
        //        Color valuecolor = ColorTranslator.FromHtml(value);
        //        grafico.FillRectangle(new SolidBrush(valuecolor), 0, 0, 15, 15);
        //        grafico.DrawRectangle(new Pen(valuecolor), 0, 0, 15, 15);
        //    }
        //    return imagen;
        //}
        //public Image Completa(string[] array) //guardar imagen- es innecesario con nueva version. o requiere utilizar bg de panel1
        //{
        //    Bitmap imagen = new Bitmap(size * imagenvista.Width, size * imagenvista.Width);
        //    Graphics grafico = Graphics.FromImage(imagen);
        //    grafico.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        //    int temper = 0;
        //    int sq = panel1.Width / size, x = 0, y = 0;
        //    Color valuecolor = Color.White;
        //    for (int i = 0; i < size; i++)
        //    {
        //        y = i * sq;
        //        for (int ii = 0; ii < size; ii++)
        //        {
        //            x = ii * sq;
        //            if (array[temper] != "t")
        //            {
        //                valuecolor = ColorTranslator.FromHtml(array[temper]);
        //            }
        //            else { valuecolor = ColorTranslator.FromHtml("#FFFFFF"); }
        //            grafico.FillRectangle(new SolidBrush(valuecolor), x, y, sq, sq);
        //            grafico.DrawRectangle(new Pen(valuecolor), x, y, sq, sq);
        //            temper++;
        //        }
        //    }
        //    return imagen;
        //}
        //public void actualizardibujo()//deprecated
        //{
        //    for (int i = 0; i < size * size; i++)
        //    {
        //        pxl[i].Image = img(pixel[i]);
        //        pxl[i].Refresh();
        //    }
        //    actualizarcadena();
        //}
        private void botoncargar_Click(object sender, EventArgs e)
        {
            try
            {
                QRDecoder qd = new QRDecoder();
                Image img;
                OpenFileDialog of = new OpenFileDialog();
                of.Title = "Abre el codigo QR";
                of.Filter = "PNG | *.png|JPEG | *.jpeg";
                string codigo = "";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    img = new Bitmap(of.FileName);
                    byte[][] DataByteArray = qd.ImageDecoder(new Bitmap(of.FileName));
                    codigo = QRDecoder.ByteArrayToStr(DataByteArray[0]);
                    of.Dispose();
                    Analisis analisis = new Analisis(codigo);
                    if (analisis.Error != 0)
                    {
                        Errorentrada(analisis.Error);
                        return;
                    }
                    else
                    {
                        Form2 form2 = new Form2(img, codigo);
                        form2.StartPosition = FormStartPosition.CenterParent;
                        form2.ShowDialog();
                        if (form2.OKButtonClicked)
                        {
                            dimension.SelectedIndex = int.Parse(codigo.Split(',').ElementAt(2)) - 1;
                            if (size == int.Parse(codigo.Split(',').ElementAt(2)))
                            {
                                textBox1.Text = codigo.Split(',').ElementAt(1);
                                paleta = codigo.Split(',').ElementAt(3);
                                for (int y = 0; y < size; y++)
                                {
                                    for (int x = 0; x < size; x++)
                                    {
                                        string color = codigo.Split(',').ElementAt(4 + y*size + x);
                                        pixl2[x, y] = color;// utilizar color seleccionado aqui, a partir de los colores de las bibliotecas.
                                        updater(x, y);
                                    }
                                }
                            }
                        }
                        form2.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                Errorentrada(5);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (seleccionando == true)
            //{
            //    Cursor = Cursors.Default;
            //    seleccionando = false;
            //}
            //System.Windows.Media.Color diacol;
            //bool x = ColorPickerWindow.ShowDialog(out diacol, ColorPickerWPF.Code.ColorPickerDialogOptions.SimpleView);
            //selcol = diacol.ToString().Remove(1, 2);
            //botoncolor.BackColor = ColorTranslator.FromHtml(selcol);
            //label3.Text = selcol;
        }
        private void botonsalir_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Los cambios no seran guardados, esta seguro que desea salir?", "Salir?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }
        private void botonayuda_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.FormBorderStyle = FormBorderStyle.None;
            f3.StartPosition = FormStartPosition.CenterParent;
            f3.ShowDialog();
            f3.Dispose();
        }
        // Errores
        /* Proceso Errorentrada
         * Llama Messagebox en caso de encontrar errores en el proceso de analisis
         */
        /*Glosario de errores de entrada
         *  -1 Error sintactico
         *      El codigo ingresado no tiene la estructura 
         *      correcta, por lo que no puede ser procesado.
         *  -2 Error Semantico
         *      El codigo no tiene congruencia entre sus
         *      componentes.
         *  -3 Error lexico
         *      El codigo contiene palabras no reconocidas, codigos de colores ilegales
         *      o no esta en formato hexadecimal.
         */
        public void Errorentrada(int error)
        {
            switch (error)
            {
                case 1:
                    MessageBox.Show("El codigo no tiene la estructura correcta", "Error de Sintaxis");
                    break;
                case 2:
                    MessageBox.Show("El codigo no tiene congruencia entre componentes", "Error de Semantica");
                    break;
                case 3:
                    MessageBox.Show("Los colores no estan en el formato correcto", "Error Lexico");
                    break;
                case 4:
                    MessageBox.Show("", "Error");
                    break;
                case 5:
                    MessageBox.Show("No se detecto un codigo QR valido", "Error");
                    break;
                default:
                    break;
            }
        }

        private void gotero_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //string fdsdsfd = sender.ToString();
            //e.DrawBackground();
            //for (int i = 0; i < Paletas.Count; i++)
            //{
            //    string[] col = paleta.Split(',');
            //    int x = comboBox1.Size.Width;
            //    int y = comboBox1.Size.Height;
            //    for (int ii = 1; ii < col.Length; ii++)
            //    {
            //        e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(col[ii])), ii * x, 0, x / 12, y);
            //    }
            //}

            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                if (e.Index < imageList1.Images.Count)
                {
                    Image img = new Bitmap(imageList1.Images[e.Index]);
                    e.Graphics.DrawImage(img, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
            }


            //e.DrawBackground();
            //e.DrawFocusRectangle();
            //if (e.Index >= 0)
            //{
            //    if (e.Index < comboBox1.Items.Count)
            //    {
            //        int x = 180;
            //        int y = 20;
            //        Image img = new Bitmap(x,y);
            //        Graphics gfx = Graphics.FromImage(img);
            //        string[] valor =comboBox1.Items[e.Index].ToString().Split(',');
            //        for (int i = 1; i < valor.Length; i++)
            //        {
            //            gfx.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(valor[i])), i * x, 0, x / 12, y);
            //        }
            //        e.Graphics.DrawImage(img, new PointF(e.Bounds.Left, e.Bounds.Top));
            //    }
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Coloreta();
            selpal =comboBox1.SelectedIndex;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string color = ((Button)sender).Name.Substring(6);
            selcol = int.Parse(color);
        }

        public void Errorentrada(string mensaje)
        {
            MessageBox.Show(mensaje, "Error no controlado");
        }


    }
}
