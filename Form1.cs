using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorPickerWPF;
using QRCodeEncoderLibrary;
using QRCodeDecoderLibrary;


namespace QR_Imagenes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*  Variables Globales
         *  size - Dimensiones del dibujo
         *  cadena - Cadena de salida que representa los datos del dibujo
         *  pixel - arreglo de colores contenidios en el dibujo
         *  selcol - color en formato hexadecimal seleccionado en el momento
         *  seleccionado - Si la herramienta de seleccion esta activa o no
         *  pxl - Arreglo de picturebox, mostrados en interfaz grafica
         */
        int size = 0;
        string cadena;
        string[] pixel;
        string selcol = "#FFFFFF";
        bool seleccionando = false;
        PictureBox[] pxl;
        ToolTip toolTip = new ToolTip();
        /* Proceso Form1_Load ; carga inicial
         * La dimension de la imagen por default es de 16*16
         * por lo que el indice del combobox es igual a la dimension -1
         * El nombre de autor de la imagen por default es 'anon'
         */
        private void Form1_Load(object sender, EventArgs e)//estado inicial de la forma
        {
            dimension.SelectedIndex = 15;
            textBox1.Text = "anon";
        }
        /*  Fragmento Dibujo
         *  Aqui se realizan todas las operaciones que
         *  requieren de la libreria de graficos
         *  o hacen operaciones dentro de la interfaz 
         *  grafica del dibujo
         */
        /*  Proceso cuadricular
         *  Este proceso realiza las operaciones necesarias para crear la cuadricula compuesta por los sobjetos picturebox
         *  1- Se inicializan los valores necesarios
         *      size - se asigna el valor de la dimension basado en el combobox dimension
         *      pixel - se inicializa el arreglo basado en el la variable size para determinar la cuadricula
         *      pxl - se inicializa el arreglo de picturebox basado en size
         *  2- Se crean los cuadros
         *      2.1 - pixel - Los valores default son 't'
         *      2.2 - Para el proceso de creacion de la cuadricula se requiere
         *          2.2.w - Tamaño de cada cuadro tomando como base las dimensiones de panel1 como referencia unicamente
         *          2.2.cont - Contador local
         *          2.2.1 - Se utilizan 2 for anidados y dentro de estos se inicializa cada uno de los objetos picturebox
         *          2.2.2 - A cada cuadro se le asignan las propiedades necesarias
         *              2.2.2.x - Posicion en x del cuadro
         *              2.2.2.y - Posicion en y del cuadro
         *              2.2.2.Size - Dimensiones del cuadro
         *              2.2.2.Location - Posicion del cuadro
         *              2.2.2.Name - Nombre del objeto, es utilizado unicamente como referencia mas adelante
         *              2.2.2.BorderStyle - Estilo de borde, para separacion de cuadros
         *              2.2.2.SizeMode - Forma en la que la imagen es mostrada en el picturebox
         *          2.2.3 - A cada cuadro se le asigna un evento MouseClick, que al dar click a este se va al proceso clickcuadro
         *      2.3 - Finalmente se llama al proceso actualizardibujo
         */
        public void cuadricular()
        {
            size = dimension.SelectedIndex + 1;
            pixel = new string[size*size];
            pxl = new PictureBox[size*size];
            for (int i = 0; i < size*size; i++)
            {
                pixel[i] = "t";
            }
            int w = panel1.Width / size;
            int cont=0;
            for (int i = 0; i < size; i++)
            {
                for (int ii = 0; ii < size; ii++)
                {

                    int x = panel1.Location.X + (w * ii);
                    int y = panel1.Location.Y + (w * i);
                    pxl[cont] = new PictureBox();
                    pxl[cont].Size = new Size(w,w);
                    pxl[cont].Location = new Point(x, y);
                    pxl[cont].Name = ii+1+","+i+1;
                    pxl[cont].BorderStyle = BorderStyle.FixedSingle;
                    pxl[cont].SizeMode = PictureBoxSizeMode.StretchImage;
                    pxl[cont].MouseClick += clickcuadro;
                    this.Controls.Add(pxl[cont]);
                    toolTip.SetToolTip(pxl[cont],(ii+1)+","+(i+1));
                    cont++;
                }
            }
            panel1.SendToBack();
            actualizardibujo();
        }
        /*  Funcion img (Llamado por el proceso actualizardibujo)
*  Esta funcion crea la imagen que compone a cada cuadro
*  1 - Se crean los objetos
*      1.imagen - objeto bitmap, que contiene la imagen en si
*      1.grafico - objeto grafico, que realiza operaciones de dibujo
*  2 - Dependiendo del valor dado por el arreglo pixel[]
*      2.1 - "t" el valor default crea una cuadricula que representa un valor nulo
*      2.2 - "#xxxxxx" el valor de color en formato hexadecimal crea un cuadro del color
*  3 - Finalmente se regresa el objeto bitmap imagen
*/
        public Image img(string value)
        {
            Bitmap imagen = new Bitmap(16,16);
            Graphics grafico = Graphics.FromImage(imagen);
            grafico.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (value == "t")
            {
                grafico.FillRectangle(new SolidBrush(Color.Gray), 0, 0, 8, 8);
                grafico.FillRectangle(new SolidBrush(Color.Gray), 8, 8, 8, 8);
                grafico.FillRectangle(new SolidBrush(Color.White), 8, 0, 8, 8);
                grafico.FillRectangle(new SolidBrush(Color.White), 0, 8, 8, 8);

            }
            else
            {
                Color valuecolor = ColorTranslator.FromHtml(value); 
                grafico.FillRectangle(new SolidBrush(valuecolor), 0, 0, 15, 15);
                grafico.DrawRectangle(new Pen(valuecolor), 0, 0, 15, 15);
            }
            return imagen;
        }
        /*  Funcion Completa (Llamado por el evento botonguardarimagen_Click)
         *  Esta funcion crea la imagen completa, compuesta por todos los cuadros
         *  1 - Se inicializan los objetos y variables
         *      1.imagen - objeto bitmap, que contiene la imagen en si
         *      1.grafico - objeto grafico, que realiza operaciones de dibujo
         *      1.temper - contador local
         *      1.sq - tamaño de cada cuadro
         *      1.x - posicion x
         *      1.y - posicion y
         *      1.valuecolor - color del cuadro
         *  2 - Se dibuja cada cuadro
         *      2.1 - Se asigna el valor del arreglo array a valuecolor; 't' = '#FFFFFF'
         *      2.2 - Se dibuja con el objeto grafico
         *  3 - Finalmente se regresa el objeto bitmap imagen
         */
        public Image Completa(string[] array)
        {
            Bitmap imagen = new Bitmap(size*panel1.Width,size*panel1.Width);
            Graphics grafico = Graphics.FromImage(imagen);
            grafico.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            int temper = 0;
            int sq = panel1.Width/size,x=0,y=0;
            Color valuecolor = Color.White;
            for (int i = 0; i < size; i++)
            {
                y = i * sq;
                for (int ii = 0; ii < size; ii++)
                {
                    x = ii * sq;
                    if (array[temper] != "t")
                    {
                        valuecolor = ColorTranslator.FromHtml(array[temper]);
                    }
                    else { valuecolor = ColorTranslator.FromHtml("#FFFFFF");}
                    grafico.FillRectangle(new SolidBrush(valuecolor), x, y, sq, sq);
                    grafico.DrawRectangle(new Pen(valuecolor), x, y, sq, sq);
                    temper++;
                }
            }
            return imagen;
        }
        /*  Fragmento actualizaciones
         *  Aqui se actualizan los elementos principales.
         */
        /*  Proceso actualizardibujo (Llamado por [proceso] cuadricular, [evento] botoncargar_Click, [evento] clickcuadro)
         *  Asigna a cada cuadro el color del arreglo pixel[] por medio de la funcion img
         *  1 - Se realiza un ciclo for
         *  2 - Se asigna la imagen generada por la funcion img con el valor del arreglo pixel[]
         *  3 - Finalmente se llama al procedimiento actualizarcadena
         */
        public void actualizardibujo()
        {
            for (int i = 0; i < size*size; i++)
            {
                pxl[i].Image = img(pixel[i]);
                pxl[i].Refresh();
            }
            actualizarcadena();
        }
        /* Proceso actualizarcadena (Llamado por el proceso actualizardibujo y el evento botonguardar_Click)
         * Se asignan los datos necesarios a la cadena.
         * 1 - Si el valor de nombre esta vacio se asigna 'anon'
         * 2 - Se inicializa el valor de la cadena
         * 3 - Se agrega uno por uno los valores de pixel, donde 't' se corrige por '#FFFFFF'
         * 4 - Finalmente se llama al proceso actualizarqr
         */
        public void actualizarcadena()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "anon";
            }
            cadena = "qrimg," + textBox1.Text + "," + size + ",a-";
            for (int i = 0; i < size*size; i++)
            {
                if (pixel[i] == "t")
                {
                    cadena = cadena + ",#FFFFFF";
                }
                else
                {
                    cadena = cadena + "," +pixel[i];
                }
            }
            cadena = cadena + ",-o";
            actualizarqr();
        }
        /*  Proceso actualizarqr (Llamado por el proceso actualizarcadena)
         *  1 - Se crea el objeto QRCodeEncoder, de la libreria QREncoder
         *  2 - Se asignan las propiedades basicas del objeto
         *  3 - Se crea el codigo QR con la cadena
         *  4 - Finalmente se muestra el codigo qr en una imagen en picturebox1
         */
        public void actualizarqr() 
        {
            QRCodeEncoder qce = new QRCodeEncoder();
            qce.ErrorCorrection = QRCodeEncoderLibrary.ErrorCorrection.L;
            qce.ModuleSize = 4;
            qce.QuietZone = 16;
            qce.Encode(cadena);
            pictureBox1.Image = qce.CreateQRCodeBitmap();
        }
        /*  Segmento Botones
         *  Aqui se encuentran todos los eventos click de los objetos boton
         */
        /*  Evento botonguardar_Click
         *  Este evento guarda el codigo QR generado por los datos de la imagen
         *  1 - Se llama al proceso actualizarcadena()
         *  2 - Se crea el objeto QRCodeEncoder, de la libreria QREncoder
         *      2.1 - Se asignan las propiedades basicas del objeto
         *      2.2 - Se crea el codigo QR con la cadena
         *      2.3 - Se crea y asigna la imagen obtenida del objeto
         *  3 - Se crea el objeto SaveFileDialog
         *      3.1 - Se asignan las propiedades basicas del objeto
         *      3.2 - Se abre el dialogo de abrir archivo
         *      3.3 - Se guarda el archivo
         *  4 - Se destruyen los objetos
         */
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
        /*  Evento botonguardarimagen_Click
         *  Este evento guarda la imagen compuesta por los cuadros
         *  1 - Se crea el objeto SaveFileDialog
         *      1.1 - Se asignan las propiedades basicas del objeto
         *      1.2 - Se abre el dialogo de abrir archivo
         *      1.3 - Se guarda el archivo creado por la funcion Completa
         *  2 - Se destruyen los objetos
         */
        private void botonguardarimagen_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Guardar imagen";
            sf.Filter = "Bitmap|*.bmp|JPEG |*.jpeg|PNG |*.png";
            sf.FilterIndex = 1;
            sf.FileName = "ElDibujoDe"+textBox1.Text;
            if (sf.FileName != "" && sf.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)sf.OpenFile();
                switch (sf.FilterIndex)
                {
                    case 1:
                        this.Completa(pixel).Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 2:
                        this.Completa(pixel).Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 3:
                        this.Completa(pixel).Save(fs,
                          System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
                fs.Close();
                sf.Dispose();
            }
        }
        /*  Evento botoncargar_Click
         *  Este evento realiza la operacion de carga del codigo QR
         *  1 - Se crean los objetos
         *      1.qd - QRDecoder que realiza la operacion de decodificacion del codigo qr
         *      1.img - Image donde se guardara la imagen del codigo qr
         *      1.of - OpenFileDialog que realiza las operaciones para abrir archivos
         *  2 - Se asignan las propiedades del objeto OpenFileDialog
         *  3 - Se abre el dialogo de abrir archivo
         *  4 - la imagen seleccionada es guardada en el objeto img
         *  5 - Se utiliza el objeto QRDecoder para convertir a cadena el codigo
         *  6 - Se utiliza la clase Analisis para realizar el analisis del codigo
         *  7 - Si el codigo regresa algun error, este llama al proceso Errorentrada
         *  8 - En caso de no mandar error se abre Form2
         *      9.1 - Form2 presenta la opcion de cargar el codigo
         *      9.2 - En caso de cargar, los valores son asignados a las variables correspondientes
         *      9.3 - Se llama al proceso actualizar imagen
         *      9.4 - Se destruye el objeto Form2
         */
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
                        Form2 form2 = new Form2(img,codigo);
                        form2.StartPosition = FormStartPosition.CenterParent;
                        form2.ShowDialog();
                        if (form2.OKButtonClicked)
                        {
                            dimension.SelectedIndex = int.Parse(codigo.Split(',').ElementAt(2)) - 1;
                            if (size == int.Parse(codigo.Split(',').ElementAt(2)))
                            {
                                textBox1.Text = codigo.Split(',').ElementAt(1);
                                for (int i = 0; i < size*size; i++)
                                {
                                    pixel[i] = codigo.Split(',').ElementAt(4+i);
                                }
                                actualizardibujo();
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
        /*  Evento button1_Click
         *  Este evento se encarga de la seleccion de color
         *  1 - Se crea un objeto color
         *  2 - Se asigna el color dado por el dialogo al objeto
         *  3 - Se actualiza el color de la variable selcol
         *  4 - Se actualiza el color del boton del dialogo
         *  5 - Se actualiza el texto que muestra el valor hexadecimal del color seleccionado
         */
        private void button1_Click(object sender, EventArgs e)
        {
            if (seleccionando == true)
            {
                Cursor = Cursors.Default;
                seleccionando = false;
            }
            System.Windows.Media.Color diacol;
            bool x = ColorPickerWindow.ShowDialog(out diacol,ColorPickerWPF.Code.ColorPickerDialogOptions.SimpleView);
            selcol = diacol.ToString().Remove(1,2);
            botoncolor.BackColor = ColorTranslator.FromHtml(selcol);
            label3.Text = selcol;
        }
        /*  Evento botonsalir_Click
         *  Este evento es para salir del programa
         *  1 - Se llama a un MessageBox
         *  2 - Dependiendo de la seleccion el programa se cierra
         */
        private void botonsalir_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Los cambios no seran guardados, esta seguro que desea salir?","Salir?",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }
        /*  Evento botonayuda_Click
         *  Este evento muestra la interfaz de ayuda
         *  1 - Se crea el objeto Form3
         *  2 - Se asignan las propiedades del objeto
         *  3 - Se Muestra la forma
         *  4 - Se destruye el objeto
         */
        private void botonayuda_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.FormBorderStyle = FormBorderStyle.None;
            f3.StartPosition = FormStartPosition.CenterParent;
            f3.ShowDialog();
            f3.Dispose();
        }
        /*  Segmento Eventos
         *  Aqui se encuentran los eventos no relacionados con botones
         */
        /*  Evento dimension_SelectedIndexChanged
         *  Este evento realiza el cambio de dimension
         *  1 - prevencion de errores
         *      1.1 - si el estado es inicial, simplemente se llama al proceso cuadricular
         *      1.2 - Si el estado es por carga, no hace nada
         *  2 - Se asegura de que el usuario desea hacer el cambio
         *      2.1 - Si el usuario desea continuar
         *          2.1.1 - Se destruyen todos los objetos del arreglo pxl[]
         *          2.1.2 - Se llama al proceso cuadricular
         *      2.2 - Si el usuario no desea continuar
         *          2.2.1 - La seleccion regresa a donde estaba y no se hacen cambios
         */
        private void dimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (size == 0)
            {cuadricular();return;}
            if (dimension.SelectedIndex == size -1)
            {return;}
            DialogResult dr = MessageBox.Show("La accion reestablecera la imagen, por lo que sera borrada, deseas continuar?", "Redimensionar?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < size*size; i++)
                    {
                        pxl[i].Dispose();
                    }
                }
                catch (Exception)
                {
                }
                cuadricular();
            }
            else { dimension.SelectedIndex = size - 1; }
        }
        /*  Evento clickcuadro
         *  Este evento se llama cuando el usuario da click a uno de los cuadros
         *  1 - Si el nombre de ambos objetos es el mismo continua, sino se repite
         *      1.1 - Si la herramienta de seleccion de olor se encuentra seleccionada
         *          1.1.1 - Se asigna el valor del color a selcol
         *          1.1.2 - Se cambian los valores de la interfaz
         *      1.2 - Si no esta seleccionada
         *          1.2.1 - Se cambia el valor del arreglo pixel[]
         *          1.2.2 - se asigna un nuevo tooltip
         *          1.2.3 - Se llama al proceso actualizardibujo
         *  
         */
        private void clickcuadro(object sender, EventArgs e)
        {
            string n = ((PictureBox)sender).Name;
            for (int i = 0; i < size * size; i++)
            {
                if (pxl[i].Name == n )
                {
                    if (seleccionando)
                    {
                        if (pixel[i] == "t")
                        {
                            selcol = "#FFFFFF";  
                        }
                        else
                        {
                            selcol = pixel[i];
                        }
                        botoncolor.BackColor = ColorTranslator.FromHtml(selcol);
                        label3.Text = selcol;
                        Cursor = Cursors.Default;
                        seleccionando = false;
                    }
                    else
                    {
                        pixel[i] = selcol;
                        toolTip.SetToolTip(pxl[i], pxl[i].Name+" "+pixel[i]);
                        actualizardibujo();
                    }
                }
            }
        }
        /*  Evento textBox1_KeyPress
         *  Este evento se llama para controlar el texto ingresado por el usuario en la parte del nombre
         *  1 - Solo admite caracteres o numeros
         */
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /*  Evento pictureBox2_Click
         *  Este evento se llama para el seleccionador de color
         *  1 - Se cambia el icono del cursor
         *  2 - Se cambia la variable seleccionado a true
         */
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            seleccionando = true;
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
                    MessageBox.Show("El codigo no tiene la estructura correcta","Error de Sintaxis");
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

        public void Errorentrada(string mensaje)
        {
            MessageBox.Show(mensaje,"Error no controlado");
        }

    }
}
