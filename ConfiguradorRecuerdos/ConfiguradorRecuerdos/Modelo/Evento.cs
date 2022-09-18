using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class Evento: Elemento
    {

        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        //public List<Persona> Asistentes { get; private set; }

        public Evento(int idElemento, string descripcion, DateTime fechaCreacion, int idEvento, 
                    string nombre, string lugar) : base(idElemento, descripcion, fechaCreacion) {
            IdEvento = idEvento;
            Nombre = nombre;
            Lugar = lugar;
            //Asistentes = asistentes;
        }

        /**
         * Constructor para los nuevos eventos
         */
        public Evento() : base(-1, "", DateTime.Now) {

        }

        public override string ToString() {
            return Nombre;
        }
    }
}
