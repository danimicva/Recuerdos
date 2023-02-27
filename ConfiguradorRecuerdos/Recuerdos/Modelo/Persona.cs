
namespace Recuerdos.Modelo
{
    public class Persona : Elemento {
        
        public int? IdPersona { get; internal set; }
        public string? Nombre { get; set; }
        //public MiFecha FechaNacimiento { get; private set; }

        
        public Persona(int idElemento, string descripcion, DateTime fechaCreacion, int idPersona, string nombre)//, MiFecha fechaNacimiento) 
                : base(idElemento, descripcion, fechaCreacion) {
            IdPersona = idPersona;
            Nombre = nombre;
            //FechaNacimiento = fechaNacimiento;
        }

        public Persona Clonar() {
            Persona ret = new() {
                IdPersona = IdPersona,
                Nombre = Nombre
            };

            ret.CopiarDeOtroElemento(this);

            return ret;
        }

        public Persona() : base() {
        }


        public override string? ToString() => Nombre;
    }
}
