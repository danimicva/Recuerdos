using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class Persona : Elemento {
        
        public string Nombre { get; set; }
        public MiFecha FechaNacimiento { get; private set; }

        
        public Persona(int idElemento, string descripcion, DateTime fechaCreacion, string nombre, MiFecha fechaNacimiento) 
                : base(idElemento, descripcion, fechaCreacion) {
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
        }

    }
}
