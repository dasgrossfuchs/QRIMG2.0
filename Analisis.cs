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
        public int Error { get; set; } //tipo de error.
        public string Codigo { get; set; } //codigo recibido
        public string[] Acodigo { get; set; } //codigo por partes
        public string[] Datos { get; set; }
        public string[] Pixeles { get; set; }
        public int Tamaño { get; set; }//Tamaño
        int s = 0;

        public Analisis(string codigo)
        {
            Error = 0;
            Codigo = codigo;
            Lexico();
            Sintactico();
            Semantico();
        }
        public void Sintactico()
        {
            if (Acodigo.Length != (4 + Tamaño ^ 2)) { Error = 2; return; }
            if (!Codigo.Contains(",")) { Error = 1; return; }
            if (Acodigo[0] != "qrimg")
            {Error = 1;return;}
        }
        public void Semantico()
        {
            bool logro = int.TryParse(Acodigo[2], out s);
            if (!logro)
            { Error = 2; return; }
            if (Acodigo.Length != 4 + s * s)
            { Error = 2; return; }
            for (int x = 0; x < s * s; x++)
            {
                string val = Acodigo[4 + x];
                int temp = 50;
                int.TryParse(val, out temp);
                if (!(val == "w" || val == "t" || val == "b" || temp >= 0 || temp <= 11))
                { Error = 2; return; }
            }
        }
        public void Lexico() 
        {

            if (!Codigo.Contains(",")){ Error = 1; return; }
            Acodigo = Codigo.Split(',');
            Datos = new string[4];
            for (int i = 0; i < 5; i++){Datos[i] = Acodigo[i];}

            bool logro = int.TryParse(Datos[2], out int temp);
            if (!logro) { Error = 2; return;}
            Tamaño = temp;

            if (Acodigo.Length != (4 + Tamaño ^ 2)) {Error = 2; return; }
            Pixeles = new string[Tamaño ^ 2];

            for (int i = 0; i < Pixeles.Length; i++)
            {
                string val = Acodigo[4 + i];
                temp = 50;
                int.TryParse(val, out temp);
                if (!(val == "w" || val == "t" || val == "b" || temp >= 0 || temp <= 11))
                { Error = 3; return; }
            }
        }
        //Analizadores Fin
    }
}
