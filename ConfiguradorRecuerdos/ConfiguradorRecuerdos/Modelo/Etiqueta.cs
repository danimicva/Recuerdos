using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    class Etiqueta : Elemento {
        public int IdEtiqueta { get; private set; }
        public Persona Persona { get; private set; }
        public Point Posicion { get; private set; }

        public Etiqueta(int idElemento, string descripcion, DateTime fechaCreacion, int idEtiqueta, Persona persona, 
                Point posicion) : base(idElemento, descripcion, fechaCreacion) {
            IdEtiqueta = idEtiqueta;
            Persona = persona;
            Posicion = posicion;
        }
    }
}
