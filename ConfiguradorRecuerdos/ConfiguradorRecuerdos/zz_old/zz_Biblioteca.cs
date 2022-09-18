using Recuerdos.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    class zz_Biblioteca
    {
        public string Ruta { get; private set; }
        public List<zz_Recuerdo> Recuerdos { get; private set; } = new List<zz_Recuerdo>();

        private zz_GestorBBDD mGestorBBDD;

        public zz_Biblioteca(string ruta) {
            Ruta = ruta;
            //Archivos.AddRange(obtenerTodosArchivos(ruta));
            mGestorBBDD = new zz_GestorBBDD(ruta + "bbdd.sqlite");
        }

        public void GuardarSql() {
            if (string.IsNullOrEmpty(Ruta))
                throw new Exception("Ruta no especificada ni ruta inicial");

            mGestorBBDD.AbrirConexion();

            mGestorBBDD.CerrarConexion();
            
        }

        public bool AñadirArchivoOCarpeta(string ruta, out string error) {

            //Si es un archivo)
            if (File.Exists(ruta)) {
                zz_Recuerdo a = zz_Recuerdo.cargarArchivo(ruta);
                return AñadirArchivo(a, out error);
            }else if (Directory.Exists(ruta)) { // Si es un directorio.
                return AñadirCarpeta(ruta, out error);
            } else {
                error = "Error en la ruta obtenida: " + ruta;
                return false;
            }
        }


        private bool AñadirCarpeta(string ruta, out string error) {

            List<zz_Recuerdo> archivos = obtenerTodosArchivos(ruta);

            error = "";

            foreach(zz_Recuerdo a in archivos) {
                AñadirArchivo(a, out string err);
                if (!string.IsNullOrEmpty(err))
                    error += err + ", ";
            }

            
            return string.IsNullOrEmpty(error);
        }

        private bool AñadirArchivo(zz_Recuerdo archivo, out string error) {

            if(Recuerdos.Any(a => a.MD5Fichero.Equals(archivo.MD5Fichero))) {
                error = "El fichero ya está en la biblioteca";
                return false;
            }

            error = "";
            return true;   
        }

        private List<zz_Recuerdo> obtenerTodosArchivos(string ruta) {
            List<zz_Recuerdo> ret = new List<zz_Recuerdo>();

            foreach (string rutaArchivo in Directory.GetFiles(ruta)) {
                if(!rutaArchivo.EndsWith("sqlite"))
                    ret.Add(zz_Recuerdo.cargarArchivo(rutaArchivo));
            }

            foreach (string rutaDirectorio in Directory.GetDirectories(ruta)) {
                ret.AddRange(obtenerTodosArchivos(rutaDirectorio));
            }

            return ret;
        }
    }
}
