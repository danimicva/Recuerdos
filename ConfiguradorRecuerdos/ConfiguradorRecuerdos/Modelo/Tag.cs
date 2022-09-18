using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class Tag
    {
        public string Nombre { get; private set; }

        public Tag(string nombre) {
            Nombre = nombre;
        }

    }
}
