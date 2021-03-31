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
        public string Ruta { get; private set; }

        public string Nombre { get; set; }

        public int? Dia { get; set; }
        public int? Mes { get; set; }
        public int? Año { get; set; }
        public string Lugar { get; set; }

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
