using Recuerdos.Sql;
using Recuerdos.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class Biblioteca: Elemento
    {
        public static string NombrePapelera = "Papelera";
        public int IdBiblioteca { get; private set; }
        public string Ruta { get; private set; }

        public List<Recuerdo> Recuerdos { get; private set; }
        public List<Evento> Eventos { get; private set; }


        private GestorBBDD mGestorBBDD;


        public Biblioteca(string ruta) : base() {
            Ruta = ruta;
            Recuerdos = new List<Recuerdo>();
            Eventos = new List<Evento>();
        }

        public void IniciarBiblioteca() {


            mGestorBBDD = new GestorBBDD(this);
            mGestorBBDD.IniciarBBDD();

            if (!mGestorBBDD.ExisteBBDD()) {
                mGestorBBDD.CrearBBDD();
            } else {
                Eventos = mGestorBBDD.LeerTodosLosEventos();
                Recuerdos = mGestorBBDD.LeerTodosLosRecuerdos();
                Recuerdos.ForEach(r => {
                    r.Evento = Eventos.FirstOrDefault(e => e.IdEvento == r.IdEvento);
                });
            }
        }

        public void CalcularMd5(Func<int, string, bool> onUpdate = null, Func<int, bool> onEnd = null) {

            int calculados = 0;

            if (onUpdate != null)
                onUpdate.Invoke(calculados, "");

            List<Recuerdo> sinMd5 = Recuerdos.Where(r => string.IsNullOrEmpty(r.Md5)).ToList();

            mGestorBBDD.AbrirConexion(true);

            foreach (Recuerdo r in sinMd5) {
                string md5 = UtilsGeneral.generarMD5(r.Ruta);
                r.Md5 = md5;
                mGestorBBDD.ActualizarRecuerdo(r, false);

                if (onUpdate != null)
                    onUpdate.Invoke(++calculados, r.Ruta);
            }

            mGestorBBDD.CerrarConexion(true);

            if (onEnd != null)
                onEnd.Invoke(calculados);
        }

        #region Gestion elementos

        public void GuardarRecuerdo(Recuerdo recuerdo) {
            if (recuerdo.IdElemento == -1)
                mGestorBBDD.InsertarRecuerdo(recuerdo);
            else
                mGestorBBDD.ActualizarRecuerdo(recuerdo);
        }

        public void RecuperarRecuerdos(List<Recuerdo> recuerdos) {
            recuerdos.ForEach(r => RecuperarRecuerdo(r));
        }

        public void RecuperarRecuerdo(Recuerdo recuerdo) {
            if (recuerdo.IdElemento == -1)
                return;
            mGestorBBDD.RecuperarRecuerdo(recuerdo);
            recuerdo.Evento = Eventos.FirstOrDefault(e => e.IdEvento == recuerdo.IdEvento);

        }

        public void BorrarRecuerdos(List<Recuerdo> recuerdos) {
            recuerdos.ForEach(r => BorrarRecuerdo(r));
        }

        public void BorrarRecuerdo(Recuerdo recuerdo) {

            mGestorBBDD.BorrarRecuerdo(recuerdo);
            Recuerdos.Remove(recuerdo);
            
            string nuevaRuta = getRutaPapelera() + "\\" + recuerdo.Ruta.Substring(Ruta.Length + 1);
            string carpetaNuevaRuta = nuevaRuta.Substring(0, nuevaRuta.LastIndexOf("\\"));

            if (!Directory.Exists(carpetaNuevaRuta))
                Directory.CreateDirectory(carpetaNuevaRuta);

            File.Move(recuerdo.Ruta, nuevaRuta);
        }

        public void GuardarEvento(Evento evento) {
            if (evento.IdElemento == -1) {
                mGestorBBDD.InsertarEvento(evento);
                Eventos.Add(evento);
            } else
                mGestorBBDD.ActualizarEvento(evento);
        }
        
        #endregion

        public void PararBBDD() {
            if (mGestorBBDD.Conexion != null)
                mGestorBBDD.CerrarConexion(mGestorBBDD.Transaccion);
        }


        public void IncorporarFicherosNuevos(Func<int, string, bool> onUpdate = null, Func<int, bool> onEnd = null) {

            int nuevosFicheros = 0;

            if (onUpdate != null)
                onUpdate.Invoke(nuevosFicheros, "");

            mGestorBBDD.AbrirConexion(true);

            leerFicheros(Ruta, ref nuevosFicheros, onUpdate);

            mGestorBBDD.CerrarConexion(true);

            if (onEnd != null)
                onEnd.Invoke(nuevosFicheros);
        }


        private void leerFicheros(string ruta, ref int nuevosFicheros, Func<int, string, bool> onUpdate = null) {

            // Primero leemos los ficheros
            string[] ficheros = Directory.GetFiles(ruta).Where(f => !f.Contains(GestorBBDD.NombreBBDD)).ToArray();

            foreach(string fichero in ficheros) {
                // Ahora lo hacemos a parte, porque tarda un cojón
                //string md5 = UtilsGeneral.generarMD5(fichero);

                Recuerdo rec= Recuerdos.FirstOrDefault(r => r.Ruta == fichero);
                if (rec != null) {
                    rec.Borrado = false;
                } else {
                    Recuerdo nuevo = new Recuerdo(fichero);
                    Recuerdos.Add(nuevo);
                    mGestorBBDD.InsertarRecuerdo(nuevo, false);

                    if(onUpdate != null)
                        onUpdate.Invoke(++nuevosFicheros, nuevo.Ruta);
                }
            }

            // Luego las carpetas
            string[] carpetas = Directory.GetDirectories(ruta).Where(c => c != getRutaPapelera()).ToArray();
            foreach (string carpeta in carpetas)
                leerFicheros(carpeta, ref nuevosFicheros, onUpdate);

        }

        private string getRutaPapelera() {
            return Ruta + "\\" + NombrePapelera;
        }

    }
}
