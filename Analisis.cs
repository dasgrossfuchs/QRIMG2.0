using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QR_Imagenes
{
    class Analisis
    {
        public string Codigo { get; set; } //codigo recibido
        public int Error { get; set; } //tipo de error.
        string[] arreglocodigo; //codigo por partes
        int dimension; //dimension de la imagen

        public Analisis(string codigo)
        {
            Error = 0;
            Codigo = codigo;
            if (Codigo.Contains(",")) { arreglocodigo = Codigo.Split(',');}
            else{ Error=1;return;}
            Sintactico();
        }
        //Analizadores Inicio
        /*Analizador Sintactico
         * Estructura base del codigo:
         * 
         * qrimg,nombre_autor<string>,ancho_imagen<int>,a-,arreglo_pixeles,-o
         * 
         * ----El nombre del autor sera parte de la informacion
         * ----Dado que la imagen generada por el momento sera cuadrada solo se necesita el ancho.
         * ----El inicio del arreglo es marcado por "a-" y el final por "-o"
         */
        public void Sintactico()
        {
            if (arreglocodigo[0] != "qrimg")
            {Error = 1;return;}
            Semantico();
            
        }
        /*Analizador Semantico
         * Dependiendo de la dimension(dato en la tercera posicion)
         * el tamaño del arreglo debe ser su cuadrado
         */
        public void Semantico()
        {
            dimension = Int32.Parse(arreglocodigo[2]);
            if (Array.IndexOf(arreglocodigo, "a-") != 3 || Array.IndexOf(arreglocodigo, "-o") != (4 + dimension * dimension))
            {Error = 2;return;}
            Lexico();
        }
        /*Analizador Lexico
         * El arreglo debe estar en el siguiente formato
         *  a-,#,#,#,#,-o
         *  donde cada valor debe estar en el formato
         *  #123456
         *  con valores hexadecimales 0 - F
         */
        public void Lexico() 
        {
            for (int i = 0; i < dimension*dimension; i++)
            {
                if (arreglocodigo[4 + i].Length != 7)
                { Error = 3;return; }
                if (arreglocodigo[4+i].ToCharArray().ElementAt(0) != '#')
                { Error = 3; return;}
                try
                {
                    if (int.Parse(arreglocodigo[4 + i].Replace("#", ""), System.Globalization.NumberStyles.HexNumber) > 16777215)
                    { Error = 3;return; }
                    if (int.Parse(arreglocodigo[4 + i].Replace("#", ""), System.Globalization.NumberStyles.HexNumber) < 0)
                    { Error = 3;return; }
                }
                catch (Exception)
                {
                    Error = 3;
                    return;
                }
            }
        }
        //Analizadores Fin
        
        

    }
}
