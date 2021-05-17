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

        public Analisis(string codigo)
        {
            Error = 0;
            Codigo = codigo;
            if (Codigo.Contains(",")) { arreglocodigo = Codigo.Split(',');}
            else{ Error=1;return;}
            Sintactico();
        }
        public void Sintactico()
        {
            if (arreglocodigo[0] != "qrimg")
            {Error = 1;return;}
            Semantico();
        }
        public void Semantico()
        {
            int s;
            bool logro = int.TryParse(arreglocodigo[2], out s);
            if (!logro)
            { Error = 2; return; }
            if (arreglocodigo.Length != 4 + s * s)
            { Error = 2; return; }
            for (int x = 0; x < s * s; x++)
            {
                string val = arreglocodigo[4 + x];
                int temp = 69;
                int.TryParse(val, out temp);
                if (!(val == "w" || val == "t" || val == "b" || temp >= 0 || temp <= 11))
                { Error = 2; return; }
            }
            Lexico();
        }
        public void Lexico() 
        {
            int s;
            bool logro = int.TryParse(arreglocodigo[2], out s);
            if (!logro)
            { Error = 2; return; }
            if (arreglocodigo.Length != 4 + s * s)
            { Error = 2; return; }
            for (int x = 0; x < s * s; x++)
            {
                string val = arreglocodigo[4 + x];
                int temp = 69;
                int.TryParse(val, out temp);
                if (!(val == "w" || val == "t" || val == "b" || temp >= 0 || temp <= 11))
                { Error = 3; return; }
            }
        }
        //Analizadores Fin
    }
}
