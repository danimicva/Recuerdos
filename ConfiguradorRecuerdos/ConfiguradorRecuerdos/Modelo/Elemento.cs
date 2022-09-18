using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class Elemento
    {
        public int IdElemento { get; set; }
        public string Descripcion { get; set; }
        public List<Tag> Tags { get; private set; }
        public DateTime FechaCreacion { get; private set; }


        protected Elemento() {
            Tags = new List<Tag>();
        }
        public Elemento(int idElemento, string descripcion, DateTime fechaCreacion): this() {
            IdElemento = idElemento;
            Descripcion = descripcion;
            FechaCreacion = fechaCreacion;
        }

        public Elemento(string descripcion, DateTime fechaCreacion) : this(-1, descripcion, fechaCreacion) {
        }

    }
}
