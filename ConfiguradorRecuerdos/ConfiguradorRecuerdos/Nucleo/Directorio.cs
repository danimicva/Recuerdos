using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorRecuerdos.Nucleo
{
    class Directorio
    {
        public string Ruta { get; private set; }
        public List<Directorio> Directorios { get; private set; }
        public List<Archivo> Archivos { get; private set; }

        public Directorio(string ruta)
        {
            this.Ruta = ruta;
            this.Archivos = new List<Archivo>();
            this.Directorios= new List<Directorio>();
        }

        public static List<Archivo> obtenerTodosArchivos(string ruta)
        {
            List<Archivo> ret = new List<Archivo>();

            foreach (string rutaArchivo in Directory.GetFiles(ruta))
            {
                ret.Add(Archivo.cargarArchivo(rutaArchivo));
            }

            foreach (string rutaDirectorio in Directory.GetDirectories(ruta))
            {
                ret.AddRange(obtenerTodosArchivos(rutaDirectorio));
            }

            return ret;
        }

        public override string ToString()
        {
            return this.getNombre();
        }

        public string getNombre()
        {
            return this.Ruta.Substring(Ruta.LastIndexOf("\\") + 1);
        }

    }
}
