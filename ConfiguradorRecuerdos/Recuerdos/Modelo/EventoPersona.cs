using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class EventoPersona
    {
        public int? IdEvento { get; internal set; }
        public int? IdPersona { get; internal set; }

        private Persona? _Persona = null;
        public Persona? Persona { get {
                return _Persona;
            }
            set {
                if (value == null)
                    IdPersona = null;
                else
                    IdPersona = value.IdPersona;

                _Persona = value;
            }
        }
        public EventoPersona(int? idEvento, Persona p) {
            IdEvento = idEvento;
            Persona = p;
        }

        public EventoPersona(int? idEvento, int idPersona) {
            IdEvento = idEvento;
            IdPersona = idPersona;
        }

    }
}
