using System;
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
        bool helping = false;
        string drawString = "";
        string cadena;
        string[,] pixl2;
        string[,] Paletas = new string[0,0];
        int size = 0, selpal = 0;
        string selcol = "w";
        bool md = false;
        private void Form1_Load(object sender, EventArgs e)//estado inicial de la forma
        {
            textBox1.Text = "anon";
            dimension.SelectedIndex = 15;
            CargaPaleta();
            Coloreta();
            cuadricular2();
            CargaAyuda();
        }
        /*
         * FUNCIONES DE CARGA Y ACTUALIZACION
         */
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
        public void cuadricular2() 
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
            else
            {
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
                            Color tmpcolor = ColorTranslator.FromHtml(Paletas[selpal, int.Parse(pixl2[x, y])]);
                            gfx.FillRectangle(new SolidBrush(tmpcolor), x * step, y * step, step, step);
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

        }
        public void updater(int x, int y) 
        {
            Image img = imagenvista.Image;
            float step = 500f / size;
            float hstep = 500f / size / 2;
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
                    Color tmpcolor = ColorTranslator.FromHtml(Paletas[selpal,int.Parse(pixl2[x,y])]);
                    gfx.FillRectangle(new SolidBrush(tmpcolor), x * step, y * step, step, step);
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
            cadena = "qrimg," + textBox1.Text + "," + size + "," + selpal;//0,1,2,3
            for (int i = 0; i < size; i++)
            {
                for (int ii = 0; ii < size; ii++)//4,...,size*size+4
                {
                    cadena = cadena + "," + pixl2[i, ii];
                }
            }
            actualizarqr();
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
        private void colorSeleccionado()
        {
            int x = 10;
            Bitmap img = new Bitmap(20, 20);
            Graphics gfx = Graphics.FromImage(img);
            switch (selcol)
            {
                case "t":
                    gfx.FillRectangle(new SolidBrush(Color.Gray), 0, 0, x, x);
                    gfx.FillRectangle(new SolidBrush(Color.Gray), x, x, x, x);
                    gfx.FillRectangle(new SolidBrush(Color.White), x, 0, x, x);
                    gfx.FillRectangle(new SolidBrush(Color.White), 0, x, x, x);
                    drawString = "Transparente";
                    break;
                case "w":
                    gfx.FillRectangle(new SolidBrush(Color.White), 0, 0, 20, 20);
                    drawString = "#FFFFFF";
                    break;
                case "b":
                    selcol = "b";
                    gfx.FillRectangle(new SolidBrush(Color.Black), 0, 0, 20, 20);
                    drawString = "#000000";
                    break;
                case "s":
                    gfx.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, 20, 20);
                    drawString = "Seleccionando...";
                    break;
                default:
                    drawString = Paletas[selpal, int.Parse(selcol)];
                    Color tmpcolor = ColorTranslator.FromHtml(drawString);
                    gfx.FillRectangle(new SolidBrush(tmpcolor), 0, 0, 20, 20);
                    break;
            }
            label5.Text = drawString;
            pictureBox2.BackgroundImage = img;
        }
        public void CargaAyuda()
        {
            if (helping) 
            {
                pbhelpcode.Show();
                pbhelpcode.BringToFront();
                pbhelpcolor.Show();
                pbhelpcolor.BringToFront();
                pbhelpdraw.Show();
                pbhelpdraw.BringToFront();
                pbhelpname.Show();
                pbhelpname.BringToFront();
                pbhelpsel.Show();
                pbhelpsel.BringToFront();
                pbhelpsize.Show();
                pbhelpsize.BringToFront();
            }
            else
            {
                pbhelpcode.Hide();
                pbhelpcode.SendToBack();
                pbhelpcolor.Hide();
                pbhelpcolor.SendToBack();
                pbhelpdraw.Hide();
                pbhelpdraw.SendToBack();
                pbhelpname.Hide();
                pbhelpname.SendToBack();
                pbhelpsel.Hide();
                pbhelpsel.SendToBack();
                pbhelpsize.Hide();
                pbhelpsize.SendToBack();
            }
            botonayuda.Enabled = !helping;
            botoncargar.Enabled = !helping;
            botonguardar.Enabled = !helping;
            botonguardarimagen.Enabled = !helping;
            botonsalir.Enabled = !helping;
            button1.Enabled = !helping;
            button2.Enabled = !helping;
            button3.Enabled = !helping;
            button4.Enabled = !helping;
            button5.Enabled = !helping;
            button6.Enabled = !helping;
            button7.Enabled = !helping;
            button8.Enabled = !helping;
            button9.Enabled = !helping;
            button10.Enabled = !helping;
            button11.Enabled = !helping;
            button12.Enabled = !helping;
            button13.Enabled = !helping;
            button14.Enabled = !helping;
            button15.Enabled = !helping;
            button16.Enabled = !helping;
            comboBox1.Enabled = !helping;
        }
        /*
         * TODOS LOS EVENTOS
         */
        private void imagenvista_Click(object sender, EventArgs e)
        {
            Point coor = imagenvista.PointToClient(Cursor.Position);
            double stp = Convert.ToDouble(imagenvista.Width) / Convert.ToDouble(size);
            int x = Convert.ToInt32(Math.Floor(Convert.ToDouble(coor.X) / stp));
            int y = Convert.ToInt32(Math.Floor(Convert.ToDouble(coor.Y) / stp));
            string color= selcol;
            if (color != "s")
            {
                if (x < pixl2.GetLength(0) && y < pixl2.GetLength(1) && x >= 0 && y >= 0 && pixl2[x, y] != color && helping == false)
                {
                    pixl2[x, y] = color;// utilizar color seleccionado aqui, a partir de los colores de las bibliotecas.
                    updater(x, y);
                }
            }
            else
            {
                if (helping == false)
                {
                    selcol = pixl2[x, y];
                }
            }
            colorSeleccionado();
            if (helping == true)
            {
                helping = false;
                CargaAyuda();
            }
        }
        private void imagenvista_MouseMove(object sender, MouseEventArgs e)
        {
            if (md)
            {
                Point coor = imagenvista.PointToClient(Cursor.Position);
                double stp = Convert.ToDouble(imagenvista.Width) / Convert.ToDouble(size);
                int x = Convert.ToInt32(Math.Floor(Convert.ToDouble(coor.X) / stp));
                int y = Convert.ToInt32(Math.Floor(Convert.ToDouble(coor.Y) / stp));
                string color = selcol;
                if (x < pixl2.GetLength(0) && y < pixl2.GetLength(1) && x >= 0 && y >= 0 && pixl2[x, y] != color && color != "s")
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

                FileStream fs = (FileStream)sf.OpenFile();
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
            cuadricular2();
        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
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
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Coloreta();
            selpal =comboBox1.SelectedIndex;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    updater(x,y);
                }
            }
            colorSeleccionado();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int color = int.Parse(((Button)sender).Name.Substring(6))-1;
            switch (color)
            {
                case 12: selcol = "t"; break;
                case 13: selcol = "w"; break;
                case 14: selcol = "b"; break;
                case 15: selcol = "s"; break;
                default:
                    selcol = color.ToString();
                    break;
            }

            colorSeleccionado();
        }
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
                    of.OpenFile().Close();
                    of.Dispose();
                    Analisis analisis = new Analisis(codigo);
                    if (analisis.Error != 0)
                    {
                        Errorentrada(analisis.Error);
                        return;
                    }
                    else
                    {
                        Form2 form2 = new Form2(img, codigo, Paletas);
                        form2.StartPosition = FormStartPosition.CenterParent;
                        form2.ShowDialog();
                        if (form2.OKButtonClicked)
                        {
                            dimension.SelectedIndex = int.Parse(codigo.Split(',').ElementAt(2)) - 1;
                            comboBox1.SelectedIndex = int.Parse(codigo.Split(',').ElementAt(3));
                            if (size == int.Parse(codigo.Split(',').ElementAt(2)))
                            {
                                textBox1.Text = codigo.Split(',').ElementAt(1);
                                selpal = int.Parse(codigo.Split(',').ElementAt(3));
                                for (int y = 0; y < size; y++)
                                {
                                    for (int x = 0; x < size; x++)
                                    {
                                        string color = codigo.Split(',').ElementAt(4 + y*size + x);
                                        pixl2[y, x] = color;// utilizar color seleccionado aqui, a partir de los colores de las bibliotecas.
                                        updater(y, x);
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
        private void botonsalir_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Los cambios no seran guardados, esta seguro que desea salir?", "Salir?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }
        private void botonayuda_Click(object sender, EventArgs e)
        {
            helping = true;
            CargaAyuda();
        }
        private void imagenvista_MouseLeave(object sender, MouseEventArgs e)
        {
            md = false;
        }
        public void Errorentrada(string mensaje)
        {
            MessageBox.Show(mensaje, "Error no controlado");
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            helping = false;
            CargaAyuda();
        }

        private void pbhelpdraw_Click(object sender, EventArgs e)
        {
            helping = false;
            CargaAyuda();
        }

        /* Errores
* Proceso Errorentrada
* Llama Messagebox en caso de encontrar errores en el proceso de analisis
*
*Glosario de errores de entrada
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


    }
}
