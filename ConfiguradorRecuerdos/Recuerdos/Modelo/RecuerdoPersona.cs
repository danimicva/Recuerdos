using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class RecuerdoPersona
    {
        public int? IdRecuerdo { get; internal set; }
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
        public RecuerdoPersona(int? idRecuerdo, Persona p) {
            IdRecuerdo = idRecuerdo;
            Persona = p;
        }

        public RecuerdoPersona(int? idRecuerdo, int idPersona) {
            IdRecuerdo = idRecuerdo;
            IdPersona = idPersona;
        }

    }
}
