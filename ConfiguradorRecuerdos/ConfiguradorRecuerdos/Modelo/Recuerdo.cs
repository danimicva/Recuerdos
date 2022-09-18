
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

        public int IdRecuerdo { get; set; }
        public string Ruta { get; set; }
        public TipoRecuerdo Tipo { get; private set; }
        public string Lugar { get; set; }
        public string Fuente { get; set; }
        public string Md5 { get; set; }

        public bool Revisado { get; set; }

        public int IdEvento { get; set; }
        private Evento _evento = null;
        public Evento Evento { 
            get {
                return _evento;
            } 
            set {
                _evento = value;
                IdEvento = _evento == null ? -1 : _evento.IdEvento;
            }
        }

        public bool Borrado { get; set; }
        public bool Nuevo { get; set; }

        //public List<Etiqueta> Etiquetas { get; private set; }
        //public MiFecha Fecha { get; set; }

        public Recuerdo(int idElemento, string descripcion, DateTime fechaCreacion, int idRecuerdo, 
                string ruta, TipoRecuerdo tipo, string lugar, string fuente, string md5, 
                //MiFecha fecha, 
                bool revisado, int idEvento, bool borrado, bool nuevo) : base(idElemento, descripcion, fechaCreacion) {
            IdRecuerdo = idRecuerdo;
            Ruta = ruta;
            Tipo = tipo;
            Lugar = lugar;
            Fuente = fuente;
            Md5 = md5;
            Evento = null;
            IdEvento = idEvento;
            //Fecha = fecha;
            Revisado = revisado;
            Borrado = borrado;
            Nuevo = nuevo;
        }
        /**
         * Constructor para los nuevos recuerdos
         */
        public Recuerdo(string ruta) 
                : this(-1, "", DateTime.Now, -1, ruta, TipoRecuerdo.Otro, "", "", "", false, -1, false, true)  {
            Tipo = obtenerTipoRecuerdo(ruta);
        }

        public string getNombreImagen() {
            return Ruta.Substring(Ruta.LastIndexOf("\\") + 1);
        }

        private TipoRecuerdo obtenerTipoRecuerdo(string ruta) {
            foreach (string ex in ExtensionesFotos)
                if (ruta.ToUpper().EndsWith(ex.ToUpper()))
                    return TipoRecuerdo.Foto;

            foreach (string ex in ExtensionesVideos)
                if (ruta.ToUpper().EndsWith(ex.ToUpper()))
                    return TipoRecuerdo.Video;

            return TipoRecuerdo.Otro;
        }
    }
}
