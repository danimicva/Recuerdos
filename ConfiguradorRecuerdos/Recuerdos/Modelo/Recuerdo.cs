﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class Recuerdo : Elemento {

        private string[] ExtensionesFotos = { "jpg", "jpeg", "png", "bmp", "tif" };
        private string[] ExtensionesVideos = { "avi", "mp4" };

        public enum TipoRecuerdo {
            Foto,
            Video,
            Otro
        }

        public int? IdRecuerdo { get; internal set; }
        public string Ruta { get; set; }
        public TipoRecuerdo Tipo { get; internal set; }
        public string Lugar { get; set; }
        public string Fuente { get; set; }
        public string Md5 { get; set; }

        public bool Revisado { get; set; }

        public int? IdEvento { get; set; }
        private Evento? _evento = null;
        public Evento? Evento { 
            get {
                return _evento;
            } 
            set {
                _evento = value;
                IdEvento = _evento == null ? null : _evento.IdEvento;
            }
        }

        public bool Borrado { get; set; }
        public bool Nuevo { get; set; }

        public List<RecuerdoPersona> Personas { get; private set; } = new();
        public MiFecha Fecha { get; set; }

        public Recuerdo(int? idElemento, string descripcion, DateTime fechaCreacion, int? idRecuerdo, 
                string ruta, TipoRecuerdo tipo, string lugar, string fuente, string md5, MiFecha fecha, 
                bool revisado, int? idEvento, bool borrado, bool nuevo) : base(idElemento, descripcion, fechaCreacion) {
            IdRecuerdo = idRecuerdo;
            Ruta = ruta;
            Tipo = tipo;
            Lugar = lugar;
            Fuente = fuente;
            Md5 = md5;
            Evento = null;
            IdEvento = idEvento;
            Fecha = fecha;
            Revisado = revisado;
            Borrado = borrado;
            Nuevo = nuevo;
            Personas = new();
        }
        /**
         * Constructor para los nuevos recuerdos
         */
        public Recuerdo(string ruta) 
                : this(null, "", DateTime.Now, null, ruta, TipoRecuerdo.Otro, "", "", "", new(), false, null, false, true)  {
            if(!string.IsNullOrEmpty(ruta))
                Tipo = obtenerTipoRecuerdo(ruta);
        }
        /**
         * Para al leerlos de BBDD
         */
        public Recuerdo() : this("") {
           
        }


        public string getNombreImagen() {
            return Ruta.Substring(Ruta.LastIndexOf("\\") + 1);
        }
        /*
        public Recuerdo Clonar() {

            Recuerdo ret = new() {
                IdRecuerdo = IdRecuerdo,
                Ruta = Ruta,
                Tipo = Tipo,
                Lugar = Lugar,
                Fuente = Fuente,
                Md5 = Md5,
                Evento = Evento?.Clonar(),
                IdEvento = IdEvento,
                Fecha = Fecha.Clonar(),
                Revisado = Revisado,
                Borrado = Borrado,
                Nuevo = Nuevo,
                Personas = new()
            };

            ret.CopiarDeOtroElemento(this);

            Personas.ForEach(ep => {
                ret.Personas.Add(ep);
            });

            return ret;
        }
        */
        private TipoRecuerdo obtenerTipoRecuerdo(string ruta) {
            foreach (string ex in ExtensionesFotos)
                if (ruta.ToUpper().EndsWith(ex.ToUpper()))
                    return TipoRecuerdo.Foto;

            foreach (string ex in ExtensionesVideos)
                if (ruta.ToUpper().EndsWith(ex.ToUpper()))
                    return TipoRecuerdo.Video;

            return TipoRecuerdo.Otro;
        }


        public List<Persona> GetListaPersonas() {
            List<Persona> ret = new();

            Personas.ForEach(ep => {
                if (ep.Persona != null)
                    ret.Add(ep.Persona);
            });

            return ret;
        }

        public string GetPersonasString() {
            string ret = "";
            Personas.ForEach(p => {
                if (p.Persona == null)
                    return;
                ret += (ret != "" ? ", " : "") + p.Persona.Nombre;
            });
            return ret;
        }

        public void RevisarPersonas(List<Persona> personas) {
            if (Personas == null)
                Personas = new();
            else
                Personas.Clear();

            personas.ForEach(p => Personas.Add(new(IdRecuerdo, p)));
        }
    }
}
