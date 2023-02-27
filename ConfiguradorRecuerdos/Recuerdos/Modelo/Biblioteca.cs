using Recuerdos.Modelo.BBDD;
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
        public const string NombrePapelera = "Papelera";
        public int IdBiblioteca { get; private set; }
        public string Ruta { get; private set; }

        public List<Recuerdo> Recuerdos { get; private set; }
        public List<Evento> Eventos { get; private set; }
        public List<Persona> Personas { get; private set; }


        private readonly GestorBBDD mGestorBBDD;


        public Biblioteca(string ruta) : base() {
            Ruta = ruta;
            Recuerdos = new();
            Eventos = new();
            mGestorBBDD = new(this);
            Personas = new();
        }

        public string IniciarBiblioteca() {

            try {
                if (!mGestorBBDD.ExisteBBDD()) {
                    mGestorBBDD.CrearBBDD();
                }
            }catch(Exception ex) {
                return "Error comprobando si existe la base de datos o creándola: " + ex.Message;
            }

            try {
                mGestorBBDD.AbrirConexion();
            }catch(Exception ex) {
                return "Error abriendo conexión a la base de datos: " + ex.Message;
            }


            try {
                Personas = mGestorBBDD.LeerTodasLasPersonas();
                Eventos = mGestorBBDD.LeerTodosLosEventos();
                Recuerdos = mGestorBBDD.LeerTodosLosRecuerdos();
            }catch(Exception ex) {
                try {
                    mGestorBBDD.CerrarConexion();
                } catch (Exception ex2) {
                    return "Error cerrando conexión a la base de datos (" + ex2.Message + ") cuando hubo un error al obtener la información de la biblioteca: " + ex.Message;
                }
                return "Error obteniendo la información de la biblioteca: " + ex.Message;
            }
            try {
                mGestorBBDD.CerrarConexion();
            } catch (Exception ex) {
                return "Error cerrando conexión a la base de datos: " + ex.Message;
            }

            return "";
        }

        public void CalcularMd5(Func<int, string, bool>? onUpdate = null, Func<int, bool>? onEnd = null) {

            int calculados = 0;

            if (onUpdate != null)
                onUpdate.Invoke(calculados, "");

            List<Recuerdo> sinMd5 = Recuerdos.Where(r => string.IsNullOrEmpty(r.Md5)).ToList();

            mGestorBBDD.AbrirConexion(true);

            foreach (Recuerdo r in sinMd5) {
                string md5 = UtilsGeneral.generarMD5(r.Ruta);
                r.Md5 = md5;
                mGestorBBDD.ActualizarRecuerdo(r);

                if (onUpdate != null)
                    onUpdate.Invoke(++calculados, r.Ruta);
            }

            mGestorBBDD.CerrarConexion(true);

            if (onEnd != null)
                onEnd.Invoke(calculados);
        }

        #region Recuerdos

        public void GuardarRecuerdo(Recuerdo recuerdo, bool abrirConexion = true) {

            if(abrirConexion)
                mGestorBBDD.AbrirConexion();

            if (recuerdo.IdElemento == null) {
                mGestorBBDD.InsertarRecuerdo(recuerdo);
                recuerdo.Personas.Where(p => p.Persona != null && p.Persona.IdPersona == null).ToList().ForEach(rp => {
                    GuardarPersona(rp.Persona, false);
                });
                mGestorBBDD.InsertarRecuerdoPersona(recuerdo);
                Recuerdos.Add(recuerdo);
            } else {
                mGestorBBDD.ActualizarRecuerdo(recuerdo);
                recuerdo.Personas.Where(p => p.Persona != null && p.Persona.IdPersona == null).ToList().ForEach(rp => {
                    GuardarPersona(rp.Persona, false);
                });

                mGestorBBDD.BorrarRecuerdoPersona(recuerdo);
                mGestorBBDD.InsertarRecuerdoPersona(recuerdo);

                Recuerdos.RemoveAll(r => r.IdElemento == recuerdo.IdElemento);
                Recuerdos.Add(recuerdo);
            }
            if (abrirConexion)
                mGestorBBDD.AbrirConexion();
        }

        public void RecuperarRecuerdos(List<Recuerdo> recuerdos) {

            mGestorBBDD.AbrirConexion();

            recuerdos.ForEach(r => RecuperarRecuerdo(r, false));

            mGestorBBDD.AbrirConexion();
        }

        public void RecuperarRecuerdo(Recuerdo recuerdo, bool abrirConexion = true) {

            if(abrirConexion)
                mGestorBBDD.AbrirConexion();

            mGestorBBDD.RecuperarRecuerdo(recuerdo);
            recuerdo.Evento = Eventos.FirstOrDefault(e => e.IdEvento == recuerdo.IdEvento);

            if(abrirConexion)
                mGestorBBDD.CerrarConexion();
        }

        public void BorrarRecuerdos(List<Recuerdo> recuerdos) {

            mGestorBBDD.AbrirConexion();

            recuerdos.ForEach(r => BorrarRecuerdo(r, false));

            mGestorBBDD.AbrirConexion();
        }

        public void BorrarRecuerdo(Recuerdo recuerdo, bool abrirConexion = true) {

            if(abrirConexion)
                mGestorBBDD.AbrirConexion();

            mGestorBBDD.BorrarRecuerdo(recuerdo);
            Recuerdos.Remove(recuerdo);
            
            string nuevaRuta = getRutaPapelera() + "\\" + recuerdo.Ruta[(Ruta.Length + 1)..];
            string carpetaNuevaRuta = nuevaRuta[..nuevaRuta.LastIndexOf("\\")];

            if (!Directory.Exists(carpetaNuevaRuta))
                Directory.CreateDirectory(carpetaNuevaRuta);

            File.Move(recuerdo.Ruta, nuevaRuta);

            if (abrirConexion)
                mGestorBBDD.CerrarConexion();

        }

        #endregion

        #region Eventos

        public void GuardarEvento(Evento evento) {

            mGestorBBDD.AbrirConexion();

            if (evento.IdElemento == null) {
                mGestorBBDD.InsertarEvento(evento);
                evento.Personas.Where(p => p.Persona != null && p.Persona.IdPersona == null).ToList().ForEach(ep => {
                    GuardarPersona(ep.Persona, false);
                });
                mGestorBBDD.InsertarEventoPersona(evento);
                Eventos.Add(evento);
            } else {
                mGestorBBDD.ActualizarEvento(evento);
                evento.Personas.Where(p => p.Persona != null && p.Persona.IdPersona == null).ToList().ForEach(ep => {
                    GuardarPersona(ep.Persona, false);
                });

                mGestorBBDD.BorrarEventoPersona(evento);
                mGestorBBDD.InsertarEventoPersona(evento);

                int indice = Eventos.FindIndex(e => e.IdEvento == evento.IdEvento);
                Eventos.RemoveAt(indice);
                Eventos.Insert(indice, evento);

                Recuerdos.ForEach(r => {
                    if (r.IdEvento == evento.IdEvento)
                        r.Evento = evento;                    
                });

            }

            mGestorBBDD.CerrarConexion();
        }

        public void BorrarEvento(Evento evento) {

            mGestorBBDD.AbrirConexion();

            mGestorBBDD.BorrarEvento(evento);
            Eventos.Remove(evento);

            mGestorBBDD.CerrarConexion();
        }

        public void RecuperarEventos(List<Evento> eventos) {

            mGestorBBDD.AbrirConexion();

            eventos.ForEach(r => RecuperarEvento(r, false));

            mGestorBBDD.CerrarConexion();
        }

        public void RecuperarEvento(Evento evento, bool abrirConexion = true) {
            
            if(abrirConexion)
                mGestorBBDD.AbrirConexion();

            mGestorBBDD.RecuperarEvento(evento);

            if(abrirConexion)
                mGestorBBDD.CerrarConexion();
        }

        #endregion

        #region Personas

        public int ObtenerUsosPersona(Persona persona) {

            if (persona == null || persona.IdPersona == null)
                return 0;

            mGestorBBDD.AbrirConexion();

            int usos = mGestorBBDD.ObtenerUsosPersona(persona.IdPersona.Value);

            mGestorBBDD.CerrarConexion();

            return usos;
        }

        public void GuardarPersona(Persona persona, bool abrirConexion = true) {

            if(abrirConexion)
                mGestorBBDD.AbrirConexion();

            if (persona.IdElemento == null) {
                mGestorBBDD.InsertarPersona(persona);
                Personas.Add(persona);
                Eventos.ForEach(e => e.Personas.ForEach(ep => {
                    if (ep.Persona != null && ep.Persona.IdPersona == persona.IdPersona)
                        ep.IdPersona = ep.Persona.IdPersona;
                }));
                Recuerdos.ForEach(r => r.Personas.ForEach(rp => {
                    if (rp.Persona != null && rp.Persona.IdPersona == persona.IdPersona)
                        rp.IdPersona = rp.Persona.IdPersona;
                }));
            } else {
                mGestorBBDD.ActualizarPersona(persona);
                
                int indice = Personas.FindIndex(p => p.IdPersona == persona.IdPersona);
                Personas.RemoveAt(indice);
                Personas.Insert(indice, persona);

                Eventos.ForEach(e => {
                    e.Personas.ForEach(ep => {
                        if (ep.IdPersona == persona.IdPersona)
                            ep.Persona = persona;
                    });
                });
                
            }

            if(abrirConexion)
                mGestorBBDD.CerrarConexion();

        }

        public void BorrarPersona(Persona persona) {

            if (persona.IdPersona != null) {
                mGestorBBDD.AbrirConexion();
                mGestorBBDD.BorrarPersona(persona);
                mGestorBBDD.CerrarConexion();
            }

            Eventos.ForEach(e => e.Personas.RemoveAll(ep => ep.IdPersona == persona.IdPersona));
            Personas.Remove(persona);

        }

        public void RecuperarPersonas(List<Persona> personas) {

            mGestorBBDD.AbrirConexion();

            personas.ForEach(p => RecuperarPersona(p, false));

            mGestorBBDD.CerrarConexion();
        }

        public void RecuperarPersona(Persona persona, bool abrirConexion = true) {

            if(abrirConexion)
                mGestorBBDD.AbrirConexion();

            mGestorBBDD.RecuperarPersona(persona);

            if (abrirConexion)
                mGestorBBDD.CerrarConexion();
        }

        #endregion

        public void PararBBDD() {
            if (mGestorBBDD.Conexion != null)
                mGestorBBDD.CerrarConexion(mGestorBBDD.Transaccion);
        }

        public void IncorporarFicherosNuevos(Func<int, string, bool>? onUpdate = null, Func<int, bool>? onEnd = null) {

            int nuevosFicheros = 0;

            if (onUpdate != null)
                onUpdate.Invoke(nuevosFicheros, "");

            mGestorBBDD.AbrirConexion(true);

            leerFicheros(Ruta, ref nuevosFicheros, onUpdate);

            mGestorBBDD.CerrarConexion(true);

            if (onEnd != null)
                onEnd.Invoke(nuevosFicheros);
        }

        private void leerFicheros(string ruta, ref int nuevosFicheros, Func<int, string, bool>? onUpdate = null) {

            // Primero leemos los ficheros
            string[] ficheros = Directory.GetFiles(ruta).Where(f => !f.Contains(GestorBBDD.NombreBBDD)).ToArray();

            foreach(string fichero in ficheros) {
                // Ahora lo hacemos a parte, porque tarda un cojón
                //string md5 = UtilsGeneral.generarMD5(fichero);

                Recuerdo? rec= Recuerdos.FirstOrDefault(r => r.Ruta == fichero);
                if (rec != null) {
                    rec.Borrado = false;
                } else {
                    Recuerdo nuevo = new(fichero);
                    GuardarRecuerdo(nuevo, false);

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
