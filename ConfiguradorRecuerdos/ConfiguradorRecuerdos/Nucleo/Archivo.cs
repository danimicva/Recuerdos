using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorRecuerdos.Nucleo
{
    class Archivo
    {
        public string Nombre { get; private set; }
        public string Ruta { get; private set; }

        public static Archivo cargarArchivo(string ruta)
        {
            Archivo a = new Archivo();
            a.Ruta = ruta;
            a.Nombre = ruta.Substring(ruta.LastIndexOf("\\") + 1);

            return a;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
