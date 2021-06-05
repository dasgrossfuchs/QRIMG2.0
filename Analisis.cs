using System;

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

        public Analisis(string codigo)
        {
            Error = 0;
            Codigo = codigo;
            Lexico();
            if (Error != 0){return;}
            Sintactico();
            if (Error != 0) { return; }
            Semantico();
            if (Error != 0) { return; }
            Finalizador();
            if (Error != 0) { return; }
        }
        public void Lexico() 
        {
            // SE CREA UNA TABLA QUE CONTIENE LOS VALORES UTILIZADOS EN EL CODIGO
            if (!Codigo.Contains(",")){ Error = 1; return; }
            Acodigo = Codigo.Split(',');
        }
        public void Sintactico()
        {
            // SE ORGANIZAN LOS DATOS OBTENIDOS DEL CODIGO
            Datos = new string[4];
            for (int i = 0; i < 4; i++) { Datos[i] = Acodigo[i]; }

            bool logro = int.TryParse(Datos[2], out int temp);
            if (!logro) { Error = 2; return; }
            Tamaño = temp;

            if (Acodigo.Length != (4 + Math.Pow(Tamaño, 2))) { Error = 2; return; }
            Pixeles = new string[Convert.ToInt32(Math.Pow(Tamaño, 2))];
        }
        public void Semantico()
        {
            // SE VERIFICA QUE LOS TIPOS DE DATO Y SUS LUGARES SEAN CORRECTOS

            for (int x = 0; x < Pixeles.Length; x++)
            {
                string val = Acodigo[4 + x];
                bool logro = int.TryParse(val, out int temp);
                if (logro)
                {
                    if (!(temp >= 0 || temp <= 11))
                    { Error = 3; return; }
                }
                else if (!(val == "w" || val == "t" || val == "b"))
                { Error = 3; return; }
            }
        }
        public void Finalizador()
        {
            Acodigo = Codigo.Split(',');
            Array.Copy(Acodigo, 1, Datos, 0, 3);
            Tamaño = int.Parse(Acodigo[2]);
            Array.Copy(Acodigo, 4, Pixeles, 0, Convert.ToInt32(Math.Pow(Tamaño, 2)));
        }
    }
}
