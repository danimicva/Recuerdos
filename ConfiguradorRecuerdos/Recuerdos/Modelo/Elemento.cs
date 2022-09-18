using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class Elemento
    {
        public int? IdElemento { get; internal set; }
        public string Descripcion { get; set; } = "";
        //public List<Tag> Tags { get; internal set; }
        public DateTime FechaCreacion { get; internal set; }


        protected Elemento() {
            //Tags = new List<Tag>();
        }

        public Elemento(int? idElemento, string descripcion, DateTime fechaCreacion): this() {
            IdElemento = idElemento;
            Descripcion = descripcion;
            FechaCreacion = fechaCreacion;
        }

        public Elemento(string descripcion, DateTime fechaCreacion) : this(null, descripcion, fechaCreacion) {
        }

        public void CopiarDeOtroElemento(Elemento elemento) {
            IdElemento = elemento.IdElemento;
            Descripcion = elemento.Descripcion;
            FechaCreacion = elemento.FechaCreacion;
        }

    }
}
