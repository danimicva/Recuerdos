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
            Vacia = 0,
            Exacta = 1,
            Aproximada = 2,
            Rango = 3
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

        public MiFecha() {
            Tipo = TipoFecha.Vacia;
            Año = Mes = Dia = Año2 = Mes2 = Dia2 = null;
        }

        public MiFecha Clonar() {

            MiFecha ret = new() {
                Tipo = Tipo,
                Dia = Dia,
                Mes = Mes,
                Año = Año,
                Dia2 = Dia2,
                Mes2 = Mes2,
                Año2 = Año2
            };

            return ret;
        }

        public static bool FechasIguales(IEnumerable<MiFecha> fechas) {
            
            if(fechas == null)
                return false;

            if (fechas.Count() < 2)
                return true;


            if (fechas.Any(f => f.Tipo != fechas.ElementAt(0).Tipo))
                return false;
            if (fechas.Any(f => f.Dia != fechas.ElementAt(0).Dia))
                return false;
            if (fechas.Any(f => f.Mes != fechas.ElementAt(0).Mes))
                return false;
            if (fechas.Any(f => f.Año != fechas.ElementAt(0).Año))
                return false;
            if (fechas.Any(f => f.Dia2 != fechas.ElementAt(0).Dia2))
                return false;
            if (fechas.Any(f => f.Mes2 != fechas.ElementAt(0).Mes2))
                return false;
            if (fechas.Any(f => f.Año2 != fechas.ElementAt(0).Año2))
                return false;


            return true;
        }

    }
}
