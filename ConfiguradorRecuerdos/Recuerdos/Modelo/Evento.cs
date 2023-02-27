using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class Evento: Elemento
    {

        public int? IdEvento { get; internal set; }
        public string Nombre { get; set; } = "";
        public string Lugar { get; set; } = "";
        public MiFecha Fecha { get; internal set; }


        public List<EventoPersona> Personas { get; private set; } = new();

        public Evento(int? idElemento, string descripcion, DateTime fechaCreacion, int? idEvento, 
                    string nombre, string lugar) : base(idElemento, descripcion, fechaCreacion) {
            IdEvento = idEvento;
            Nombre = nombre;
            Lugar = lugar;
            Fecha = new();
            Personas = new();
        }

        /**
         * Constructor para los nuevos eventos
         */
        public Evento() : this(null, "", DateTime.Now, null, "", "") {
        }
        /*
        public Evento Clonar() {
            Evento ret = new() {
                IdEvento = IdEvento,
                Nombre = Nombre,
                Lugar = Lugar,
                Fecha = Fecha.Clonar(),
                Personas = new()
            };

            ret.CopiarDeOtroElemento(this);

            Personas.ForEach(ep => {
                ret.Personas.Add(ep);
            });

            return ret;
        }
        */
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

            personas.ForEach(p => Personas.Add(new(IdEvento, p)));
        }

        public override string ToString() {
            return Nombre;
        }
    }
}
