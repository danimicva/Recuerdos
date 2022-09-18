using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    public class MiFecha
    {

        public enum TipoFecha {
            Exacta = 0,
            Aproximada = 1,
            Rango = 2
        }
        public int? Año { get; set; }
        public int? Mes { get; set; }
        public int? Dia { get; set; }

        public int? Año2 { get; set; }
        public int? Mes2 { get; set; }
        public int? Dia2 { get; set; }

        private TipoFecha _Tipo;
        public TipoFecha Tipo { 
            get {
                return _Tipo;
            }
            set {
                _Tipo = value;
                if(_Tipo != TipoFecha.Rango) {
                    Año2 = Mes2 = Dia2 = null;
                }
            } 
        }

    }
}
